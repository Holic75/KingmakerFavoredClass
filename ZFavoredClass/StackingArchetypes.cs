using CallOfTheWild;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic;
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
                CallOfTheWild.Eidolon.eidolon_class
            };

            var classes = Main.library.Root.Progression.CharacterClasses.Where(c => !forbidden_classes.Contains(c) && !c.Archetypes.Empty()).ToList();
            foreach (var c in classes)
            {
                var archetypes = c.Archetypes.ToList().ToArray();

                for (int i = 0; i < archetypes.Length; i++)
                {
                    for (int j = i + 1; j < archetypes.Length; j++)
                    {
                        if (canCombineArchetypes(archetypes[i], archetypes[j]))
                        {
                            createCombinedArchetype(archetypes[i], archetypes[j]);
                        }
                    }
                }
            }

            //fix some abilities
            //fix nature mystery animal companion to avoid double scaling with sacred huntsmaster and mystery level
            library.Get<BlueprintFeatureSelection>("c5e2d914e4174aadb3e3fcec72008711").AddComponent(Common.prerequisiteNoArchetype(combined_archetypes["SacredHuntsmasterArchetypeRavenerHunterArchetype"]));
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

            combined_archetype.IsArcaneCaster = archetype1.IsArcaneCaster || archetype2.IsArcaneCaster;
            combined_archetype.IsDivineCaster = archetype1.IsDivineCaster || archetype2.IsDivineCaster;
            combined_archetype.ChangeCasterType = archetype1.ChangeCasterType || archetype2.ChangeCasterType;
            combined_archetype.AddComponent(Helpers.Create<CombineArchetypes>(c => c.archetypes = new BlueprintArchetype[] { archetype1, archetype2 }));
            combined_archetypes[archetype1.name + archetype2.name] = combined_archetype;
            return combined_archetype;

        }



        static bool canCombineArchetypes(BlueprintArchetype archetype1, BlueprintArchetype archetype2)
        {
            Main.logger.Log($"Checking {archetype1.Name} and {archetype2.Name} stacking");

            if (archetype1 == CallOfTheWild.Archetypes.Seeker.archetype || archetype2 == CallOfTheWild.Archetypes.Seeker.archetype)
            {
                Main.logger.Log("Seeker");
                return false;
            }
            if ((archetype1.ReplaceSpellbook != null || archetype1.RemoveSpellbook) && (archetype2.ReplaceSpellbook != null || archetype2.RemoveSpellbook))
            {
                Main.logger.Log("Spellbook Failure");
                return false;
            }

            if ((!archetype1.ClassSkills.Empty()) && (!archetype2.ClassSkills.Empty()))
            {
                Main.logger.Log("Skills Failure");
                return false;
            }


            if ((archetype1.BaseAttackBonus != null) && (archetype2.BaseAttackBonus != null) && archetype1.BaseAttackBonus != archetype2.BaseAttackBonus)
            {
                Main.logger.Log("Base Attack Bonus Failure");
                return false;
            }

            if ((archetype1.WillSave != null) && (archetype2.WillSave != null) && archetype1.BaseAttackBonus != archetype2.WillSave)
            {
                Main.logger.Log("Will Save Failure");
                return false;
            }

            if ((archetype1.ReflexSave != null) && (archetype2.ReflexSave != null) && archetype1.BaseAttackBonus != archetype2.ReflexSave)
            {
                Main.logger.Log("Reflex Save Failure");
                return false;
            }


            if ((archetype1.FortitudeSave != null) && (archetype2.FortitudeSave != null) && archetype1.BaseAttackBonus != archetype2.FortitudeSave)
            {
                Main.logger.Log("Fort Save Failure");
                return false;
            }

            if ((archetype1.IsDivineCaster && archetype1.IsArcaneCaster) || (archetype1.IsArcaneCaster && archetype1.IsDivineCaster))
            {
                Main.logger.Log("Caster type Failure");
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
                        Main.logger.Log($"{feature.name} Failure");
                        return false;
                    }
                }
            }
            Main.logger.Log("Passed");
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
    }
}
