using CallOfTheWild;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp.Actions;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFavoredClass
{
    internal class StackingArchetypes
    { 
        static LibraryScriptableObject library => Main.library;
        static public Dictionary<string, BlueprintArchetype> combined_archetypes = new Dictionary<string, BlueprintArchetype>();
        internal static void load()
        {
            var forbidden_classes = new BlueprintCharacterClass[]
            {
                Main.library.Get<BlueprintCharacterClass>("f5b8c63b141b2f44cbb8c2d7579c34f5"), //eldritch scion
                Main.library.Get<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920"), //animal
                CallOfTheWild.Eidolon.eidolon_class,
                CallOfTheWild.Phantom.phantom_class,
                library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc")
            };

            var classes = Main.library.Root.Progression.CharacterClasses.Where(c => !forbidden_classes.Contains(c) && !c.Archetypes.Empty()).ToList();
            foreach (var c in classes)
            {
                var archetypes = c.Archetypes.ToList().ToArray();

                var archetypes_idx = new List<int>();
                archetypes_idx.Add(0);
                int next_archetype_idx = 1;
                while (true)
                {
                    //Main.logger.Log("Checking " + archetypes[archetypes_idx.Last()].name);
                    bool add_archetype = false;
                    for (int i = next_archetype_idx; i < archetypes.Length; i++)
                    {
                        add_archetype = true;
                        foreach (var a_idx in archetypes_idx)
                        {
                            add_archetype = add_archetype && canCombineArchetypes(archetypes[a_idx], archetypes[i]);
                            if (!add_archetype)
                            {
                                break;
                            }
                        }
                        if (add_archetype)
                        {
                            archetypes_idx.Add(i);
                            //Main.logger.Log("Added " + archetypes[i].name);
                            break;
                        }
                    }
                    next_archetype_idx = archetypes_idx.Last() + 1;
                    if (add_archetype)
                    {
                        createCombinedArchetypeMultiple(archetypes_idx.Select(ai => archetypes[ai]).ToArray());
                    }
                    else
                    {
                        archetypes_idx.RemoveAt(archetypes_idx.Count - 1);
                    }
                    if (archetypes_idx.Empty())
                    {
                        if (next_archetype_idx >= archetypes.Length)
                        {
                            break;
                        }
                        archetypes_idx.Add(next_archetype_idx);
                        next_archetype_idx++;
                    }
                }
            }

            //fix some abilities
            //fix nature mystery animal companion to avoid double scaling with sacred huntsmaster and mystery level
            if (combined_archetypes.ContainsKey("SacredHuntsmasterArchetypeRavenerHunterArchetype"))
            {
                library.Get<BlueprintFeatureSelection>("c5e2d914e4174aadb3e3fcec72008711").AddComponent(Common.prerequisiteNoArchetype(combined_archetypes["SacredHuntsmasterArchetypeRavenerHunterArchetype"]));
            }
        }


        static BlueprintArchetype createCombinedArchetypeMultiple(params BlueprintArchetype[] archetypes)
        {
            var parent_class = archetypes[0].GetParentClass();

            var combined_archetype = Helpers.Create<BlueprintArchetype>(a =>
            {
                a.name = "";
                string localized_name = "";
                string description_header = "This archetype represents a combination of the following archetypes:";
                string description = "";
                foreach (var ar in archetypes)
                {
                    a.name += ar.name;
                    localized_name += ar.Name + (ar == archetypes.Last() ? "" : " / ");
                    description_header += (ar == archetypes.Last() ? " and " : " ") + ar.Name + (ar == archetypes.Last() ? "." : "");
                    description += ar.Name + ": " + ar.Description + (ar == archetypes.Last() ? "" : "\n");
                }
                                
                a.LocalizedName = Helpers.CreateString($"{a.name}.Name", localized_name);
                a.LocalizedDescription = Helpers.CreateString($"{a.name}.Description", $"{description_header}\n{description}");
            });
            Helpers.SetField(combined_archetype, "m_ParentClass", parent_class);
            library.AddAsset(combined_archetype, Helpers.MergeIdsMultiple(archetypes.Select(s => s.AssetGuid).ToArray()));

            combined_archetype.RemoveFeatures = new LevelEntry[] { };

            combined_archetype.AddFeatures = new LevelEntry[] {Helpers.LevelEntry(1)
                                                                  };
            parent_class.Archetypes = parent_class.Archetypes.AddToArray(combined_archetype);

            var extra_skills = new List<StatType>();
            var missing_skills = new List<StatType>();

            var replace_skills = false;
            for (int i = 0; i < archetypes.Length; i++)
            {
                var skills = archetypes[i].ReplaceClassSkills ? archetypes[i].ClassSkills : parent_class.ClassSkills;

                replace_skills = replace_skills || archetypes[i].ReplaceClassSkills;
                missing_skills.AddRange(parent_class.ClassSkills.Except(skills));
                missing_skills = missing_skills.Distinct().ToList();

                extra_skills.AddRange(skills.Except(parent_class.ClassSkills));
                extra_skills = extra_skills.Distinct().ToList();               
            }
         

            if (replace_skills)
            {
                combined_archetype.ReplaceClassSkills = replace_skills;
                combined_archetype.ClassSkills = parent_class.ClassSkills.AddToArray(extra_skills).Except(missing_skills).ToArray();
            }
            combined_archetype.ComponentsArray = new BlueprintComponent[0];
            foreach (var a in archetypes)
            {
                combined_archetype.IsArcaneCaster = combined_archetype.IsArcaneCaster || a.IsArcaneCaster;
                combined_archetype.IsDivineCaster = combined_archetype.IsDivineCaster || a.IsDivineCaster;
                combined_archetype.ChangeCasterType = combined_archetype.ChangeCasterType || a.ChangeCasterType;
                combined_archetype.ComponentsArray = combined_archetype.ComponentsArray.AddToArray(a.ComponentsArray);
            }

            combined_archetype.AddComponent(Helpers.Create<CombineArchetypes>(c => c.archetypes =archetypes));
            combined_archetypes[combined_archetype.name] = combined_archetype;
            return combined_archetype;
        }


        static BlueprintArchetype createCombinedArchetype(BlueprintArchetype archetype1, BlueprintArchetype archetype2)
        {
            var parent_class = archetype1.GetParentClass();

            var combined_archetype = Helpers.Create<BlueprintArchetype>(a =>
            {
                a.name = archetype1.name + archetype2.name;
                a.LocalizedName = Helpers.CreateString($"{a.name}.Name", $"{archetype1.Name} / {archetype2.Name}");
                a.LocalizedDescription = Helpers.CreateString($"{a.name}.Description", $"This archetype represents a combination of {archetype1.Name} and {archetype2.Name} archetypes.\n{archetype1.Name}: {archetype1.Description}\n{archetype2.Name}: {archetype2.Description}");
            });
            Helpers.SetField(combined_archetype, "m_ParentClass", parent_class);
            library.AddAsset(combined_archetype, Helpers.MergeIds(archetype1.AssetGuid, archetype2.AssetGuid));

            combined_archetype.RemoveFeatures = new LevelEntry[] { };

            combined_archetype.AddFeatures = new LevelEntry[] {Helpers.LevelEntry(1)
                                                                  };
            parent_class.Archetypes = parent_class.Archetypes.AddToArray(combined_archetype);

            var skills1 = archetype1.ReplaceClassSkills ? archetype1.ClassSkills : parent_class.ClassSkills;
            var skills2 = archetype2.ReplaceClassSkills ? archetype2.ClassSkills : parent_class.ClassSkills;
            combined_archetype.ReplaceClassSkills = archetype1.ReplaceClassSkills || archetype2.ReplaceClassSkills;
            var missing_skills = parent_class.ClassSkills.Except(skills1).ToList();
            missing_skills.AddRange(parent_class.ClassSkills.Except(skills2));
            missing_skills = missing_skills.Distinct().ToList();

            var extra_skills = skills1.Except(parent_class.ClassSkills).ToList();
            extra_skills.AddRange(skills2.Except(parent_class.ClassSkills));
            extra_skills = extra_skills.Distinct().ToList();

            if (combined_archetype.ReplaceClassSkills)
            {
                combined_archetype.ClassSkills = parent_class.ClassSkills.AddToArray(extra_skills).Except(missing_skills).ToArray();
            }




            combined_archetype.IsArcaneCaster = archetype1.IsArcaneCaster || archetype2.IsArcaneCaster;
            combined_archetype.IsDivineCaster = archetype1.IsDivineCaster || archetype2.IsDivineCaster;
            combined_archetype.ChangeCasterType = archetype1.ChangeCasterType || archetype2.ChangeCasterType;
            combined_archetype.AddComponent(Helpers.Create<CombineArchetypes>(c => c.archetypes = new BlueprintArchetype[] { archetype1, archetype2 }));
            combined_archetypes[archetype1.name + archetype2.name] = combined_archetype;
            return combined_archetype;
        }



        static bool canCombineArchetypes(BlueprintArchetype archetype1, BlueprintArchetype archetype2)
        {
            //Main.logger.Log($"Checking {archetype1.Name} and {archetype2.Name} stacking");

            if (archetype1 == CallOfTheWild.Archetypes.Seeker.archetype || archetype2 == CallOfTheWild.Archetypes.Seeker.archetype)
            {
                //Main.logger.Log("Seeker");
                return false;
            }
            if ((archetype1.ReplaceSpellbook != null || archetype1.RemoveSpellbook) && (archetype2.ReplaceSpellbook != null || archetype2.RemoveSpellbook))
            {
               //Main.logger.Log("Spellbook Failure");
                return false;
            }

            if (archetype1.ReplaceClassSkills && archetype2.ReplaceClassSkills)
            {
                var parent_class_skills = archetype1.GetParentClass().ClassSkills;
                var missing_skills1 = parent_class_skills.Except(archetype1.ClassSkills);
                var missing_skills2 = parent_class_skills.Except(archetype2.ClassSkills);

                if (missing_skills1.Intersect(missing_skills2).Any())
                {
                    //both skills are removed
                    //Main.logger.Log("Skills Failure");
                    return false;
                }
            }


            if ((archetype1.BaseAttackBonus != null) && (archetype2.BaseAttackBonus != null) && archetype1.BaseAttackBonus != archetype2.BaseAttackBonus)
            {
                //Main.logger.Log("Base Attack Bonus Failure");
                return false;
            }

            if ((archetype1.WillSave != null) && (archetype2.WillSave != null) && archetype1.BaseAttackBonus != archetype2.WillSave)
            {
                //Main.logger.Log("Will Save Failure");
                return false;
            }

            if ((archetype1.ReflexSave != null) && (archetype2.ReflexSave != null) && archetype1.BaseAttackBonus != archetype2.ReflexSave)
            {
                //Main.logger.Log("Reflex Save Failure");
                return false;
            }


            if ((archetype1.FortitudeSave != null) && (archetype2.FortitudeSave != null) && archetype1.FortitudeSave != archetype2.FortitudeSave)
            {
                //Main.logger.Log("Fort Save Failure");
                return false;
            }

            if ((archetype2.IsDivineCaster && archetype1.IsArcaneCaster) || (archetype2.IsArcaneCaster && archetype2.IsDivineCaster))
            {
                //Main.logger.Log("Caster type Failure");
                return false;
            }

            foreach (LevelEntry removeFeature in archetype1.RemoveFeatures)
            {
                var level_entry2 = archetype2.RemoveFeatures.FirstOrDefault((le => le.Level == removeFeature.Level)) ?? new LevelEntry();
                foreach (BlueprintFeatureBase feature1 in removeFeature.Features)
                {
                    BlueprintFeatureBase feature = feature1;
                    if (removeFeature.Features.Count((f => f == feature)) !=0 && level_entry2.Features.Count((f => f == feature)) != 0)
                    {
                        //Main.logger.Log($"{feature.name} Failure");
                        return false;
                    }
                }
            }
            //Main.logger.Log("Passed");
            return true;
        }


        [Harmony12.HarmonyPatch(typeof(UnitProgressionData))]
        [Harmony12.HarmonyPatch("AddArchetype", Harmony12.MethodType.Normal)]
        class ProgressionData__AddArchetype__Patch
        {
            static void Postfix(UnitProgressionData __instance, BlueprintArchetype archetype)
            {
                var combined_archetypes = archetype.GetComponent<CombineArchetypes>();
                if (combined_archetypes == null)
                {
                    return;
                }

                foreach (var a in combined_archetypes.archetypes)
                {
                    __instance.AddArchetype(a.GetParentClass(), a);
                }
            }
        }



        public class CombineArchetypes : OwnedGameLogicComponent<UnitDescriptor>
        {
            public BlueprintArchetype[] archetypes = new BlueprintArchetype[0];
        }


        [Harmony12.HarmonyPatch(typeof(ApplyClassMechanics))]
        [Harmony12.HarmonyPatch("ApplyClassSkills", Harmony12.MethodType.Normal)]
        class ApplyClassMechanics__ApplyClassSkills__Patch
        {
            static bool Prefix(ApplyClassMechanics __instance, ClassData classData, UnitDescriptor unit)
            {
                List<StatType> class_skills = new List<StatType>();
                var combined_archetype = classData.Archetypes.Where(a => a.GetComponent<CombineArchetypes>() != null && a.ReplaceClassSkills).FirstOrDefault();
                if (combined_archetype == null)
                {
                    return true;
                }
                
                foreach (var s in combined_archetype.ClassSkills)
                {
                    unit.Stats.AddClassSkill(s);
                }
                return false;
            }
        }
    }
}
