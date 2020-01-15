using CallOfTheWild;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFavoredClass
{
    class Core
    {
        public class FavoredClassFeature
        {
            public BlueprintFeature partial;
            public BlueprintFeature full;

            public FavoredClassFeature(BlueprintFeature partial_feature, BlueprintFeature full_feature)  
            {
                partial = partial_feature;
                full = full_feature;
            }
        }
        const String eldritchScionClassId = "f5b8c63b141b2f44cbb8c2d7579c34f5";
        static LibraryScriptableObject library => Main.library;
        static Dictionary<string, BlueprintProgression> class_guid_progression_map = new Dictionary<string, BlueprintProgression>();
        static Dictionary<string, BlueprintFeatureSelection> class_guid_bonus_selection_map = new Dictionary<string, BlueprintFeatureSelection>();

        static BlueprintArchetype eldritch_scion = library.Get<BlueprintArchetype>("d078b2ef073f2814c9e338a789d97b73");
        static internal BlueprintFeatureSelection favored_class_selection;
        static public BlueprintFeatureSelection favored_prestige_class_selection;
        static internal Dictionary<StatType, BlueprintFeature> favored_prestige_class_skill_bonus_map = new Dictionary<StatType, BlueprintFeature>();
        static public BlueprintFeatureSelection prestigious_spellcaster;


        static internal BlueprintRace elf = library.Get<BlueprintRace>("25a5878d125338244896ebd3238226c8");
        static internal BlueprintRace half_elf = library.Get<BlueprintRace>("b3646842ffbd01643ab4dac7479b20b0");
        static internal BlueprintRace human = library.Get<BlueprintRace>("0a5d473ead98b0646b94495af250fdc4");
        static internal BlueprintRace gnome = library.Get<BlueprintRace>("ef35a22c9a27da345a4528f0d5889157");
        static internal BlueprintRace dwarf = library.Get<BlueprintRace>("c4faf439f0e70bd40b5e36ee80d06be7");
        static internal BlueprintRace half_orc = library.Get<BlueprintRace>("1dc20e195581a804890ddc74218bfd8e");
        static internal BlueprintRace halfling = library.Get<BlueprintRace>("b0c3ef2729c498f47970bb50fa1acd30");
        static internal BlueprintRace tiefling = library.Get<BlueprintRace>("5c4e42124dc2b4647af6e36cf2590500");
        static internal BlueprintRace aasimar = library.Get<BlueprintRace>("b7f02ba92b363064fb873963bec275ee");

        static internal BlueprintCharacterClass alchemist = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
        static internal BlueprintCharacterClass barbarian = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
        static internal BlueprintCharacterClass bard = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
        static internal BlueprintCharacterClass paladin = library.Get<BlueprintCharacterClass>("bfa11238e7ae3544bbeb4d0b92e897ec");
        static internal BlueprintCharacterClass cleric = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
        static internal BlueprintCharacterClass druid = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
        static internal BlueprintCharacterClass fighter = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
        static internal BlueprintCharacterClass inquistor = library.Get<BlueprintCharacterClass>("f1a70d9e1b0b41e49874e1fa9052a1ce");
        static internal BlueprintCharacterClass kineticist = library.Get<BlueprintCharacterClass>("42a455d9ec1ad924d889272429eb8391");
        static internal BlueprintCharacterClass magus = library.Get<BlueprintCharacterClass>("45a4607686d96a1498891b3286121780");
        static internal BlueprintCharacterClass rogue = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
        static internal BlueprintCharacterClass sorceror = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
        static internal BlueprintCharacterClass wizard = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
        static internal BlueprintCharacterClass ranger = library.Get<BlueprintCharacterClass>("cda0615668a6df14eb36ba19ee881af6");
        static internal BlueprintCharacterClass slayer = library.Get<BlueprintCharacterClass>("c75e0971973957d4dbad24bc7957e4fb");
        static internal BlueprintCharacterClass monk = library.Get<BlueprintCharacterClass>("e8f21e5b58e0569468e420ebea456124");


        static public FavoredClassFeature favored_skill;
        static public FavoredClassFeature favored_hp;
        static public FavoredClassFeature favored_bombs;




        static internal void load()
        {
            favored_class_selection = CallOfTheWild.Helpers.CreateFeatureSelection("FavoredClassSelection",
                                                                                   "Favored Class",
                                                                                   "Each character begins play with a single favored class of his choosing—typically, this is the same class as the one he chooses at 1st level. Whenever a character gains a level in his favored class, he receives either + 1 hit point per level or + 1 skill rank per 2 levels. The choice of favored class cannot be changed once the character is created, and the choice of gaining a hit point or a skill rank each time a character gains a level (including his first level) cannot be changed once made for a particular level. Prestige classes can never be a favored class.",
                                                                                   "",
                                                                                   null,
                                                                                   FeatureGroup.AasimarHeritage);

            favored_prestige_class_selection = CallOfTheWild.Helpers.CreateFeatureSelection("FavoredPrestigeClassSelection",
                                                                                           "Favored Prestige Class",
                                                                                           "Choose one prestige class and one skill that is a class skill for that prestige class. Whenever you gain a level in that prestige class, you receive +1 hit point or +1 skill rank. You gain a +2 bonus on checks using the skill you chose from that prestige class’s class skills. If you have 10 or more ranks in one of these skills, the bonus increases to +4 for that skill. This bonus stacks with the bonus granted by Skill Focus.\n"
                                                                                           + "The choice of favored prestige class cannot be changed once you make it. Levels in a favored prestige class are not the same as levels in a regular favored class, and as such levels in a favored prestige class can never be used to qualify or gain favored class options. You can have only one favored prestige class, but can still have a favored base class as well.\n"
                                                                                           + "Note: You should select this feat before you gain levels in your chosen favored prestige class, but the benefits of the feat do not apply until you actually gain at least 1 level in that prestige class.",
                                                                                           "",
                                                                                           null,
                                                                                           FeatureGroup.Feat);
            favored_prestige_class_selection.AddComponent(Helpers.PrerequisiteNoFeature(favored_prestige_class_selection));
            library.AddFeats(favored_prestige_class_selection);
            createFavoredPrestigeClassSkillFocusSelection();

            var classes = library.Root.Progression.CharacterClasses.Where(c => c.AssetGuid != eldritchScionClassId).ToList();
            foreach (var c in classes)
            {
                var progression = CallOfTheWild.Helpers.CreateProgression("FavoredClass" + c.name + "Progression",
                                                                          $"Favored {(c.PrestigeClass ? "Prestige " : "")}Class - " + c.Name,
                                                                          c.PrestigeClass ? favored_prestige_class_selection.Description : favored_class_selection.Description,
                                                                          CallOfTheWild.Helpers.MergeIds("602ea6032c324258a183588f84522ea1", c.AssetGuid),
                                                                          null,
                                                                          FeatureGroup.None,
                                                                          CallOfTheWild.Helpers.Create<NewMechanics.DisableAutomaticFavoredClassHitPoints>()
                                                                          );
                progression.Classes = new BlueprintCharacterClass[] { c };

                if (c.PrestigeClass)
                {
                    favored_prestige_class_selection.AllFeatures = favored_prestige_class_selection.AllFeatures.AddToArray(progression);
                    progression.AddComponent(Helpers.Create<PrerequisiteNoClassLevel>(p => p.CharacterClass = c));
                }
                else
                {
                    favored_class_selection.AllFeatures = favored_class_selection.AllFeatures.AddToArray(progression);
                }
                class_guid_progression_map.Add(c.AssetGuid, progression);
                var bonus_selection = CallOfTheWild.Helpers.CreateFeatureSelection("FavoredClass" + c.name + "FeatureSelecion",
                                                                                   progression.Name,
                                                                                   progression.Description,
                                                                                   CallOfTheWild.Helpers.MergeIds("f431abc7ab7b4771a58fff7ee2af8a01", c.AssetGuid),
                                                                                   progression.Icon,
                                                                                   FeatureGroup.AasimarHeritage);
                class_guid_bonus_selection_map.Add(c.AssetGuid, bonus_selection);
                bonus_selection.Mode = SelectionMode.Default;

                var entries = new List<LevelEntry>();
                int max_lvl = c.PrestigeClass ? 10 : 20;
                for (int i = 1; i <= max_lvl; i++)
                {
                    if (c.PrestigeClass && i == 1)
                    {
                        var skill_focus_selection = Helpers.CreateFeatureSelection("FavoredPrestigeClass" + c.name + "SkillFocusSelection",
                                                           "Favored Prestige Class Skill Focus",
                                                           favored_prestige_class_selection.Description,
                                                           Helpers.MergeIds(c.AssetGuid, "7b57b4a2378644f299590cfdf559b1c9"),
                                                           null,
                                                           FeatureGroup.None);
                        skill_focus_selection.AllFeatures = c.ClassSkills.Select(s => favored_prestige_class_skill_bonus_map[s]).ToArray();
                        entries.Add(CallOfTheWild.Helpers.LevelEntry(i, bonus_selection, skill_focus_selection));
                    }
                    else
                    {
                        entries.Add(CallOfTheWild.Helpers.LevelEntry(i, bonus_selection));
                    }
                }

                progression.LevelEntries = entries.ToArray();
            }

            var basic_feat_progression = ResourcesLibrary.TryGetBlueprint<BlueprintProgression>("5b72dd2ca2cb73b49903806ee8986325");

            basic_feat_progression.LevelEntries[0].Features.Add(favored_class_selection);

            //create base abilities - hp and skill points

            var bonus_hp = CallOfTheWild.Helpers.CreateFeature("FavoredClassBonusHitPointFeature",
                                                                "Bonus Hit Point", 
                                                                "Gain +1 hit point",
                                                                "",
                                                                CallOfTheWild.Helpers.GetIcon("d09b20029e9abfe4480b356c92095623"), // toughness
                                                                FeatureGroup.None,
                                                                CallOfTheWild.Helpers.Create<NewMechanics.AddHitPointOnce>());
            bonus_hp.Ranks = 20;

            var bonus_skill = Helpers.CreateFeature("FavoredClassBonusSkillRankFeature",
                                                        "Bonus Skill Rank", 
                                                        "Gain +1/2 skill rank",
                                                        "",
                                                        CallOfTheWild.Helpers.GetIcon("3adf9274a210b164cb68f472dc1e4544"), // human skilled
                                                        FeatureGroup.None,
                                                        CallOfTheWild.Helpers.Create<NewMechanics.AddSkillRankOnce>());
            bonus_skill.Ranks = 10;

            var bonus_speed = CallOfTheWild.Helpers.CreateFeature("FavoredClassBonusSpeedFeature",
                                                                  "Bonus Speed",
                                                                  "Gain +1 ft bonus to base speed.",
                                                                  "",
                                                                  CallOfTheWild.Helpers.GetIcon("14c90900b690cac429b229efdf416127"), // longstrider
                                                                  FeatureGroup.None,
                                                                  Helpers.CreateAddContextStatBonus(StatType.Speed, ModifierDescriptor.UntypedStackable)
                                                                  );
            bonus_speed.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank, feature: bonus_speed));
            bonus_speed.Ranks = 20;


            favored_hp = addFavoredClassBonus(bonus_hp, null, classes.ToArray(), 1);
            favored_skill = addFavoredClassBonus(bonus_skill, null, classes.ToArray(), 2);
            addFavoredClassBonus(bonus_speed, null, new BlueprintCharacterClass[] { barbarian, Bloodrager.bloodrager_class, monk }, 1, elf, half_elf);

            addExtraKnownSpellsFavoredClassBonus();
            addExtraSelectionFavoredClassBonus();
            addExtraResourceFavoredClassBonus();
            addAnimalCompanionFavoredClassBonuses();
            addPaladinFavoredClassBonuses();
            addAbilityDamageBonus();
            addDwarfAlchemistMutagenBonus();
            fixCompanions();
          
            loadCustomFavoredClassBonuses();
            createPrestigiousSpellcaster();
        }


        static void createFavoredPrestigeClassSkillFocusSelection()
        {
            var skill_foci = library.Get<BlueprintFeatureSelection>("c9629ef9eebb88b479b2fbc5e836656a").AllFeatures;

            foreach (var skill_focus in skill_foci)
            {
                var favored_skill_focus = library.CopyAndAdd<BlueprintFeature>(skill_focus.AssetGuid, "FavoredPrestigeClass" + skill_focus.name, "");
                var skill = favored_skill_focus.GetComponent<AddContextStatBonus>().Stat;

                var config = Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.BaseStat, stat: skill, progression: ContextRankProgression.Custom,
                                                             customProgression: new (int, int)[] { (9, 2), (20, 4) });
                favored_skill_focus.ReplaceComponent<ContextRankConfig>(config);
                favored_skill_focus.SetName("Favored Prestige Class " + favored_skill_focus.Name);
                favored_skill_focus.SetDescription(favored_skill_focus.Description.Replace("+3", "+2").Replace("+6", "+4"));

                favored_prestige_class_skill_bonus_map.Add(skill, favored_skill_focus);
            }            
        }


        static void addDwarfAlchemistMutagenBonus()
        {
            var mutagens = new BlueprintFeature[]
            {
                library.Get<BlueprintFeature>("cee8f65448ce71c4b8b8ca13751dd8ea"), //mutagen
                library.Get<BlueprintFeature>("76c61966afdd82048911f3d63c6fe0bc"), //greater mutagen
                library.Get<BlueprintFeature>("6f5cb651e26bd97428523061b07ffc85"), //grand mutagen

                library.Get<BlueprintFeature>("e3f460ea61fcc504183c7d6818bbbf7a"), //cognatogen
                library.Get<BlueprintFeature>("18eb29676492e844eb5a55d1c855ce69"), //greater cognatogen
                library.Get<BlueprintFeature>("af4a320648eb5724889d6ff6255090b2"), //grand cognatogen
            };


            var natural_ac = Helpers.CreateFeature("NaturalACButagenFavoredClassBonus",
                                                   "Mutagen Natural Armor Bonus",
                                                   "Add +1/4 to the alchemist’s natural armor bonus when using the character’s mutagen.",
                                                   "",
                                                   library.Get<BlueprintAbility>("c66e86905f7606c4eaa5c774f0357b2b").Icon,
                                                   FeatureGroup.None
                                                   );
            natural_ac.Ranks = 5;

            foreach (var m in mutagens)
            {
                var comp = m.GetComponent<AddFacts>();

                foreach (var f in comp.Facts)
                {

                    var buff = Common.extractActions<ContextActionApplyBuff>((f as BlueprintAbility).GetComponent<AbilityEffectRunAction>().Actions.Actions)[0].Buff;

                    buff.AddComponents(Helpers.CreateAddContextStatBonus(StatType.AC, ModifierDescriptor.NaturalArmor, rankType: AbilityRankType.ProjectilesCount),
                                                                         Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank,
                                                                                                         feature: natural_ac,
                                                                                                         type: AbilityRankType.ProjectilesCount)
                                                                        );
                }
            }

            addFavoredClassBonus(natural_ac, null, alchemist, 4, dwarf);
        }

        static void addAbilityDamageBonus()
        {
            var earth_icon = library.Get<BlueprintAbility>("97d0a51ca60053047afb9aca900fb71b").Icon;
            var fire_icon = library.Get<BlueprintAbility>("4783c3709a74a794dbe7c8e7e0b1b038").Icon;
            var kinetic_balst_damage = library.Get<BlueprintAbility>("0a2f7c6aa81bc6548ac7780d8b70bcbc").Icon; //battering blast
            //kineticist dwarf - earth 1/3, elf/half elf - everything
            BlueprintAbility[] kinetic_blasts = new BlueprintAbility[] {library.Get<BlueprintAbility>("83d5873f306ac954cad95b6aeeeb2d8c"), //fire
                                                                        library.Get<BlueprintAbility>("d663a8d40be1e57478f34d6477a67270"), //water
                                                                        library.Get<BlueprintAbility>("b813ceb82d97eed4486ddd86d3f7771b"), //thunderstorm
                                                                        library.Get<BlueprintAbility>("3baf01649a92ae640927b0f633db7c11"), //steam
                                                                        library.Get<BlueprintAbility>("b93e1f0540a4fa3478a6b47ae3816f32"), //sandstorm
                                                                        library.Get<BlueprintAbility>("9afdc3eeca49c594aa7bf00e8e9803ac"), //plasma
                                                                        library.Get<BlueprintAbility>("e2610c88664e07343b4f3fb6336f210c"), //mud
                                                                        library.Get<BlueprintAbility>("6276881783962284ea93298c1fe54c48"), //metal
                                                                        library.Get<BlueprintAbility>("8c25f52fce5113a4491229fd1265fc3c"), //magma
                                                                        library.Get<BlueprintAbility>("403bcf42f08ca70498432cf62abee434"), //ice
                                                                        library.Get<BlueprintAbility>("45eb571be891c4c4581b6fcddda72bcd"), //electric

                                                                        library.Get<BlueprintAbility>("e53f34fb268a7964caf1566afb82dadd"), //earth
                                                                        library.Get<BlueprintAbility>("7980e876b0749fc47ac49b9552e259c1"), //cold
                                                                        library.Get<BlueprintAbility>("4e2e066dd4dc8de4d8281ed5b3f4acb6"), //charged water
                                                                        library.Get<BlueprintAbility>("d29186edb20be6449b23660b39435398"), //blue flame
                                                                        library.Get<BlueprintAbility>("16617b8c20688e4438a803effeeee8a6"), //blizzard
                                                                        library.Get<BlueprintAbility>("0ab1552e2ebdacf44bb7b20f5393366d") //air
                                                                       };

            BlueprintAbility[] earth_blasts = new BlueprintAbility[] {  library.Get<BlueprintAbility>("b93e1f0540a4fa3478a6b47ae3816f32"), //sandstorm
                                                                        library.Get<BlueprintAbility>("e2610c88664e07343b4f3fb6336f210c"), //mud
                                                                        library.Get<BlueprintAbility>("6276881783962284ea93298c1fe54c48"), //metal
                                                                        library.Get<BlueprintAbility>("8c25f52fce5113a4491229fd1265fc3c"), //magma
                                                                        library.Get<BlueprintAbility>("e53f34fb268a7964caf1566afb82dadd") //earth
                                                                       };

            var kinet_earth_dmg_bonus = Helpers.CreateFeature("EarthBlastKineticistDamageFavoredClassBonusFeature",
                                                              "Earth Element Blast Damage Bonus",
                                                              "Add 1/3 point of damage to earth element blasts that deal damage that apply the kineticist’s elemental overflow bonus.",
                                                              "",
                                                              kinetic_balst_damage,
                                                              FeatureGroup.None,
                                                              Helpers.Create<CallOfTheWild.NewMechanics.DamageAbilityBonus>(e => { e.abilities = earth_blasts; e.value = Helpers.CreateContextValue(AbilityRankType.Default); })
                                                              );
            kinet_earth_dmg_bonus.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank, feature: kinet_earth_dmg_bonus));
            kinet_earth_dmg_bonus.Ranks = 6;
            addFavoredClassBonus(kinet_earth_dmg_bonus, null, kineticist, 3, dwarf);

            var kinet_dmg_bonus = Helpers.CreateFeature("KineticistDamageFavoredClassBonusFeature",
                                                          "Element Blast Damage Bonus",
                                                          "Gain a +1/4 bonus on damage rolls that apply the kineticist’s elemental overflow bonus.",
                                                          "",
                                                          kinetic_balst_damage,
                                                          FeatureGroup.None,
                                                          Helpers.Create<CallOfTheWild.NewMechanics.DamageAbilityBonus>(e => { e.abilities = kinetic_blasts; e.value = Helpers.CreateContextValue(AbilityRankType.Default); })
                                                          );
            kinet_dmg_bonus.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank, feature: kinet_dmg_bonus));
            kinet_dmg_bonus.Ranks = 5;
            addFavoredClassBonus(kinet_dmg_bonus, null, kineticist, 4, elf, half_elf);

            //sorceror dwarf - acid, ground,  half-orc - fire + magus

            var sorc_earth_dmg_bonus = Helpers.CreateFeature("AcidEarthSpellDamageFavoredClassBonusFeature",
                                                              "Acid and Earth Spells Damage Bonus",
                                                              "Add +1/2 to acid and earth spell or spell-like ability damage.",
                                                              "",
                                                              earth_icon,
                                                              FeatureGroup.None,
                                                              Helpers.Create<CallOfTheWild.NewMechanics.SpellDescriptorDamageSpellBonus>(e => { e.SpellDescriptor = SpellDescriptor.Acid | SpellDescriptor.Ground; e.value = Helpers.CreateContextValue(AbilityRankType.Default); })
                                                              );
            sorc_earth_dmg_bonus.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank, feature: sorc_earth_dmg_bonus));
            sorc_earth_dmg_bonus.Ranks = 10;
            addFavoredClassBonus(sorc_earth_dmg_bonus, null, sorceror, 2, dwarf);


            var sorc_fire_dmg_bonus = Helpers.CreateFeature("FireSpellDamageFavoredClassBonusFeature",
                                                  "Fire Spells Damage Bonus",
                                                  "Add +1/2 point of damage to spells with fire descriptor.",
                                                  "",
                                                  fire_icon,
                                                  FeatureGroup.None,
                                                  Helpers.Create<CallOfTheWild.NewMechanics.SpellDescriptorDamageSpellBonus>(e => { e.SpellDescriptor = SpellDescriptor.Fire; e.value = Helpers.CreateContextValue(AbilityRankType.Default); })
                                                  );
            sorc_fire_dmg_bonus.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank, feature: sorc_fire_dmg_bonus));
            sorc_fire_dmg_bonus.Ranks = 10;
            addFavoredClassBonus(sorc_fire_dmg_bonus, null, new BlueprintCharacterClass[] { sorceror, magus },  2, half_orc);
        }
        

        static void addPaladinFavoredClassBonuses()
        {

            var lay_on_hands = library.Get<BlueprintAbility>("caae1dc6fcf7b37408686971ee27db13");
            var lay_on_hands_self = library.Get<BlueprintAbility>("8d6073201e5395d458b8251386d72df1");
            var lay_on_hands_troth = library.Get<BlueprintAbility>("8337cea04c8afd1428aad69defbfc365");

            var lay_on_hands_all = new BlueprintAbility[] { lay_on_hands, lay_on_hands_self, lay_on_hands_troth };


            var lay_on_hands_bonus_feature = Helpers.CreateFeature("LayOnHandsFavoredClassBonusFeature",
                                                                   "Lay On Hands Bonus",
                                                                   "Add +1/2 hp to the paladin’s lay on hands ability (whether using it to heal or harm).",
                                                                   "",
                                                                   lay_on_hands.Icon,
                                                                   FeatureGroup.None);
            var lay_on_hands_self_bonus_feature = Helpers.CreateFeature("LayOnHandsSelfFavoredClassBonusFeature",
                                                                           "Lay On Hands Healing Bonus",
                                                                           "Add +1 to the amount of damage the paladin heals with lay on hands, but only when the paladin uses that ability on herself.",
                                                                           "",
                                                                           lay_on_hands.Icon,
                                                                           FeatureGroup.None);

            lay_on_hands_bonus_feature.Ranks = 10;
            lay_on_hands_self_bonus_feature.Ranks = 20;

            foreach (var loh in lay_on_hands_all)
            {
                var loh_actions = loh.GetComponent<AbilityEffectRunAction>().Actions.Actions;
                loh_actions = CallOfTheWild.Common.changeAction<ContextActionHealTarget>(loh_actions, c => c.Value.BonusValue = Helpers.CreateContextValue(AbilityRankType.SpeedBonus));
                loh_actions = CallOfTheWild.Common.changeAction<ContextActionDealDamage>(loh_actions, c => c.Value.BonusValue = Helpers.CreateContextValue(AbilityRankType.DamageDiceAlternative));
                //damage bonus
                loh.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank, feature: lay_on_hands_bonus_feature, type: AbilityRankType.DamageDiceAlternative));
                if (loh != lay_on_hands)
                {
                    loh.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureListRanks, 
                                                                     featureList: new BlueprintFeature[] { lay_on_hands_bonus_feature, lay_on_hands_self_bonus_feature },
                                                                     type: AbilityRankType.SpeedBonus));
                }
                else
                {
                    loh.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank, 
                                                                     feature: lay_on_hands_bonus_feature, 
                                                                     type: AbilityRankType.DamageDiceAlternative));
                }

                loh.ReplaceComponent<AbilityEffectRunAction>(CallOfTheWild.Helpers.CreateRunActions(loh_actions));
            }

            addFavoredClassBonus(lay_on_hands_bonus_feature, null, paladin, 2, elf, gnome, halfling, half_elf);
            addFavoredClassBonus(lay_on_hands_self_bonus_feature, null, paladin, 1, tiefling);

            var concentration_bonus = Helpers.CreateFeature("ConcentrationFavoredClassBonus",
                                                            "Concentration Bonus",
                                                            "Add a +1 bonus on concentration checks when casting spells.",
                                                            "",
                                                            library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d").Icon, //combat casting
                                                            FeatureGroup.None,
                                                            CallOfTheWild.Helpers.Create<ConcentrationBonus>(c => c.Value = CallOfTheWild.Helpers.CreateContextValue(AbilityRankType.Default))
                                                            );
            concentration_bonus.Ranks = 20;
            concentration_bonus.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank, feature: concentration_bonus));

            addFavoredClassBonus(concentration_bonus, null, new BlueprintCharacterClass[] {paladin, VindicativeBastard.vindicative_bastard_class }, 1, dwarf);
        }


        static void addAnimalCompanionFavoredClassBonuses()
        {
            var icon = library.Get<BlueprintFeature>("571f8434d98560c43935e132df65fe76").Icon;
            var animal_companion_saves_feature = Helpers.CreateFeature("AnimalCompanionSavesFavoredClassFeature",
                                                                       "Animal Companion Saving Throws Bonus",
                                                                       "Add a +1/4 luck bonus on the saving throws of your animal companion.",
                                                                       "",
                                                                       icon,
                                                                       FeatureGroup.None,
                                                                       Helpers.CreateAddContextStatBonus(StatType.SaveFortitude, ModifierDescriptor.Luck),
                                                                       Helpers.CreateAddContextStatBonus(StatType.SaveReflex, ModifierDescriptor.Luck),
                                                                       Helpers.CreateAddContextStatBonus(StatType.SaveWill, ModifierDescriptor.Luck)
                                                                       );

            
            animal_companion_saves_feature.Ranks = 5;
            animal_companion_saves_feature.ReapplyOnLevelUp = true;

            var master_saves_feature = Common.createAddFeatToAnimalCompanion(animal_companion_saves_feature, "");
            animal_companion_saves_feature.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueTypeExtender.MasterFeatureRank.ToContextRankBaseValueType(),
                                                                                        feature: master_saves_feature));

            var animal_companion_dr_feature = Helpers.CreateFeature("AnimalCompanionDRFavoredClassFeature",
                                                           "Animal Companion DR/magic Bonus",
                                                           "Add DR 1/magic to your animal companion. Each time you gain another level, the DR increases by 1/2 (maximum DR 10/magic).",
                                                           "",
                                                           icon,
                                                           FeatureGroup.None,
                                                           Common.createMagicDR(Helpers.CreateContextValue(AbilityRankType.Default))
                                                           );
            
            animal_companion_dr_feature.Ranks = 19;
            animal_companion_dr_feature.ReapplyOnLevelUp = true;

            var master_dr_feature = Common.createAddFeatToAnimalCompanion(animal_companion_dr_feature, "");
            animal_companion_dr_feature.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueTypeExtender.MasterFeatureRank.ToContextRankBaseValueType(),
                                                                                     feature: master_dr_feature, progression: ContextRankProgression.OnePlusDiv2));

            addFavoredClassBonus(master_dr_feature, null, new BlueprintCharacterClass[]{ Hunter.hunter_class, ranger }, 1, gnome);
            addFavoredClassBonus(master_saves_feature, null, new BlueprintCharacterClass[] { Hunter.hunter_class, druid }, 4, halfling);
        }


        static void loadCustomFavoredClassBonuses()
        {
            string[] filePaths = Directory.GetFiles(@"./Mods/ZFavoredClass/Custom/", "*.json", SearchOption.TopDirectoryOnly);
            foreach (var fp in filePaths)
            {
                loadCustomFeature(fp);
            }
        }


        static void createPrestigiousSpellcaster()
        {

            prestigious_spellcaster = Helpers.CreateFeatureSelection("PrestigiousSpellcasterFeature",
                                                                     "Prestigious Spellcaster",
                                                                     "You gain new spells per day and spells known and +1 spellcasting level in caster class that is advanced by your prestige class.\n"
                                                                     + "Special: You can select the Prestigious Spellcaster feat multiple times. Each time you select the Prestigious Spellcaster feat, your effective caster level increases by 1.\n"
                                                                     + "However, regardless of the number of times you choose this feat, the total increase to your effective caster level cannot exceed your actual prestige class level.",
                                                                     "",
                                                                     library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d").Icon,
                                                                     FeatureGroup.Feat);
            library.AddFeats(prestigious_spellcaster);
            string[] filePaths = Directory.GetFiles(@"./Mods/ZFavoredClass/PrestigiousSpellcaster/", "*.json", SearchOption.TopDirectoryOnly);
            foreach (var fp in filePaths)
            {
                loadPrestigiousSpellCaster(fp);
            }
        }


        static void fixCompanions()
        {
            var valerie_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("912444657701e2d4ab2634c3d1e130ad");
            var amiri1_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("df943986ee329e84a94360f2398ae6e6");
            var tristian_companion = ResourcesLibrary.TryGetBlueprint<BlueprintUnit>("f6c23e93512e1b54dba11560446a9e02");
            var harrim_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("8910febae2a7b9f4ba5eca4dde1e9649");
            var linzi_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("920cb420385dbb34681b620b6c1b59e9");
            var ekun_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("0bc6dc9b6648a744899752508addae8c");
            var jaethal_feature = library.Get<BlueprintFeature>("34280596dd550074ca55bd15285451b3");
            var jubilost_feature = library.Get<BlueprintFeature>("c9618e3c61e65114b994f3fabcae1d97");
            var nok_nok_companion = library.Get<BlueprintUnit>("f9417988783876044b76f918f8636455");
            var kanerah_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("ccb52e235941e0442be0cb0ee5570f07");
            var kalikke_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("385e8d69b89992844b0992caf666a5fd");
            var octavia_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("200151a5a5c78a4439d0f6e9fb26620a");
            var regongar_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("12ee53c9e546719408db257f489ec366");
            var varn_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("2babd2d4687b5ee428966322eccfe4b6");
            var cephal_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("d152b07305353474ba15d750015d99ee");

            addFavoredClassToCompanion(favored_hp, valerie_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_skill, amiri1_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_skill, tristian_companion.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_hp, harrim_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_hp, linzi_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_skill, ekun_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_hp, jaethal_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_bombs, jubilost_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_skill, nok_nok_companion.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_skill, kanerah_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_hp, kalikke_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_hp, octavia_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_skill, regongar_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_skill, varn_feature.GetComponent<AddClassLevels>());
            addFavoredClassToCompanion(favored_hp, cephal_feature.GetComponent<AddClassLevels>());
        }


        static void addFavoredClassToCompanion(FavoredClassFeature favored_feature, AddClassLevels add_classLevels)
        {
            var @class = add_classLevels.CharacterClass;
            var level = add_classLevels.Levels;
            var fc_selection = new SelectionEntry();
            fc_selection.Selection = favored_class_selection;
            fc_selection.Features = new BlueprintFeature[] { class_guid_progression_map[@class.AssetGuid] };
       
            var fc_bonus_selection = new SelectionEntry();
            fc_bonus_selection.Selection = class_guid_bonus_selection_map[@class.AssetGuid];

            fc_bonus_selection.Features = new BlueprintFeature[0];
            for (int i = 0; i < level;)
            {
                if (favored_feature.partial != null)
                {
                    i += 2;
                    fc_bonus_selection.Features = fc_bonus_selection.Features.AddToArray(new BlueprintFeature[] { favored_feature.partial, favored_feature.full });
                }
                else
                {
                    i += 1;
                    fc_bonus_selection.Features = fc_bonus_selection.Features.AddToArray(new BlueprintFeature[] { favored_feature.full });
                }
            }

            add_classLevels.Selections = add_classLevels.Selections.AddToArray(fc_selection, fc_bonus_selection);
        }

        static public FavoredClassFeature addFavoredClassBonus(BlueprintFeature feature, BlueprintFeature partial_feature, BlueprintCharacterClass[] classes, int divisor, params BlueprintRace[] races)
        {
           
            int max_rank = feature.Ranks > 0 ? feature.Ranks : 1;
            if (divisor > 1)
            {
                if (partial_feature == null)
                {
                    partial_feature = CallOfTheWild.Helpers.CreateFeature("Partial" + feature.name,
                                                                              feature.Name + " (Partial)",
                                                                              feature.Description,
                                                                              CallOfTheWild.Helpers.MergeIds(feature.AssetGuid, "2a34dc814a504699914e2020d3252bc8"),
                                                                              feature.Icon,
                                                                              FeatureGroup.None,
                                                                              feature.GetComponents<Prerequisite>().ToArray()
                                                                              );
                }
                partial_feature.AddComponent(CallOfTheWild.Helpers.Create<NewMechanics.PrerequisiteFeatureFullRank>(p =>
                                                                                                                    {
                                                                                                                        p.divisor = divisor;
                                                                                                                        p.Feature = partial_feature;
                                                                                                                        p.checked_feature = feature;
                                                                                                                        p.not = true;
                                                                                                                    }
                                                                                                                    )
                                            );
                partial_feature.Ranks = max_rank * divisor;

                foreach (var race in races)
                {
                    partial_feature.AddComponent(CallOfTheWild.Helpers.Create<NewMechanics.PrerequisiteRace>(p => { p.race = race; p.Group = Prerequisite.GroupType.Any; }));
                }

                feature.AddComponents(CallOfTheWild.Helpers.Create<NewMechanics.PrerequisiteFeatureFullRank>(p =>
                                                                                                            {
                                                                                                                p.divisor = divisor;
                                                                                                                p.Feature = partial_feature;
                                                                                                                p.not = false;
                                                                                                            }
                                                                                                            ),
                                       CallOfTheWild.Helpers.Create<AddFeatureOnApply>(a => a.Feature = partial_feature)
                                      );

                foreach (var c in classes)
                {
                    var selection = class_guid_bonus_selection_map[c.AssetGuid];
                    selection.AllFeatures = selection.AllFeatures.AddToArray(partial_feature);
                }
            }


            foreach (var race in races)
            {
                feature.AddComponent(CallOfTheWild.Helpers.Create<NewMechanics.PrerequisiteRace>(p => { p.race = race; p.Group = Prerequisite.GroupType.Any; }));
            }

            foreach (var c in classes)
            {
                var selection = class_guid_bonus_selection_map[c.AssetGuid];
                selection.AllFeatures = selection.AllFeatures.AddToArray(feature);
            }

            return new FavoredClassFeature(partial_feature, feature);
        }

        static public FavoredClassFeature addFavoredClassBonus(BlueprintFeature feature, BlueprintFeature partial_feature, BlueprintCharacterClass @class, int divisor, params BlueprintRace[] races)
        {
            return addFavoredClassBonus(feature, partial_feature, new BlueprintCharacterClass[] { @class }, divisor, races);
        }



        static void addExtraSelectionFavoredClassBonus()
        {
            //human warpriest bonus combat feat 1/6
            //human rogue talent 1/6
            //gnome witch hex 1/6
            //gnome shaman hex 1/6
            //gnome/human slayer talent 1/6
            //human wild talent 1/6
            //magus arcana 1/6

            addFavoredClassBonus(createFeatureCopy(Warpriest.fighter_feat, "Gain 1/6 of a new bonus combat feat.", 3), null, Warpriest.warpriest_class, 6, human, half_elf, half_orc, aasimar, tiefling);
            addFavoredClassBonus(createFeatureCopy(library.Get<BlueprintFeatureSelection>("c074a5d615200494b8f2a9c845799d93"), "Gain 1/6 of a new rogue talent.", 3), null, rogue, 6, human, half_elf, half_orc, aasimar, tiefling);
            addFavoredClassBonus(createFeatureCopy(Witch.hex_selection, "Gain 1/6 of a new witch hex.", 3), null, Witch.witch_class, 6, gnome);
            addFavoredClassBonus(createFeatureCopy(Shaman.hex_selection, "Gain 1/6 of a new shaman hex.", 3), null, Shaman.shaman_class, 6, gnome);
            addFavoredClassBonus(createFeatureCopy(library.Get<BlueprintFeatureSelection>("43d1b15873e926848be2abf0ea3ad9a8"), "Gain 1/6 of a new slayer talent.", 3), null, slayer, 6, human, gnome, half_elf, half_orc, aasimar, tiefling);
            addFavoredClassBonus(createFeatureCopy(library.Get<BlueprintFeatureSelection>("5c883ae0cd6d7d5448b7a420f51f8459"), "Gain 1/6 of a new wild talent.", 3), null, kineticist, 6, human, half_elf, half_orc, aasimar, tiefling);

            var magus_arcana = createFeatureCopy(library.Get<BlueprintFeatureSelection>("e9dc4dfc73eaaf94aae27e0ed6cc9ada"), "Gain 1/6 of a new magus arcana.", 3);
            magus_arcana.AddComponent(Common.prerequisiteNoArchetype(magus, eldritch_scion));

            var eldritch_arcana = createFeatureCopy(library.Get<BlueprintFeatureSelection>("d4b54d9db4932454ab2899f931c2042c"), "Gain 1/6 of a new magus arcana.", 3);
            eldritch_arcana.AddComponent(Common.createPrerequisiteArchetypeLevel(magus, eldritch_scion, 1));
            addFavoredClassBonus(magus_arcana, null, magus, 6, elf, halfling, half_elf);
            addFavoredClassBonus(eldritch_arcana, null, magus, 6, elf, halfling, half_elf);
        }


        static BlueprintFeature createFeatureCopy(BlueprintFeature original, string description,int rank = 0)
        {
            var feat =  library.CopyAndAdd<BlueprintFeature>(original, "FavoredClass" + original.name, "");
            feat.SetDescription(description);
            if (rank != 0)
            {
                feat.Ranks = rank;
            }
            return feat;
        }


        static void addExtraResourceFavoredClassBonus()
        {
            var rage_resource = library.Get<BlueprintAbilityResource>("24353fcf8096ea54684a72bf58dedbc9"); //same for barbarian and bloodrager
            var rage_icon = library.Get<BlueprintFeature>("2479395977cfeeb46b482bc3385f4647").Icon; //rage

            var performance_resource = library.Get<BlueprintAbilityResource>("e190ba276831b5c4fa28737e5e49e6a6");
            var performance_icon = library.Get<BlueprintFeature>("0d3651b2cb0d89448b112e23214e744e").Icon; //extra performance

            var bomb_resource = library.Get<BlueprintAbilityResource>("1633025edc9d53f4691481b48248edd7"); 
            var bomb_icon = library.Get<BlueprintFeature>("c59b2f256f5a70a4d896568658315b7d").Icon; //bomb

            var ki_resource = library.Get<BlueprintAbilityResource>("9d9c90a9a1f52d04799294bf91c80a82");
            var ki_icon = library.Get<BlueprintFeature>("e9590244effb4be4f830b1e3fffced13").Icon;


            var arcane_pool_resource = library.Get<BlueprintAbilityResource>("effc3e386331f864e9e06d19dc218b37");
            var eldritch_pool_resource = library.Get<BlueprintAbilityResource>("17b6158d363e4844fa073483eb2655f8");
            var pool_icon = library.Get<BlueprintFeature>("42f96fc8d6c80784194262e51b0a1d25").Icon; //extra arcane pool

            var extra_rage = createResourceBonusFeature("FavoredClassExtraRageFeature",
                                                        "Bonus Rage Rounds",
                                                        "Add 1 to total number of rage rounds per day.",
                                                        rage_icon,
                                                        rage_resource);

            var extra_bloodrage = createResourceBonusFeature("FavoredClassExtraBloodrageFeature",
                                                            "Bonus Bloodrage Rounds",
                                                            "Add 1 to total number of bloodrage rounds per day.",
                                                            rage_icon,
                                                            Bloodrager.bloodrage_resource);

            var extra_performance = createResourceBonusFeature("FavoredClassExtraPerformanceFeature",
                                                                "Bonus Performance Rounds",
                                                                "Add +1 to the bard’s total number of bardic performance rounds per day.",
                                                                performance_icon,
                                                                performance_resource);

            var extra_skald_performance = createResourceBonusFeature("FavoredClassExtraSkaldPerformanceFeature",
                                                                    "Bonus Performance Rounds",
                                                                    "Add +1 to the bard’s total number of skald performance rounds per day.",
                                                                    performance_icon,
                                                                    Skald.performance_resource);

            var extra_bombs = createResourceBonusFeature("FavoredClassExtraBombsFeature",
                                                        "Bonus Bombs",
                                                        "Add +1/2 to the number of bombs per day the alchemist can create.",
                                                        bomb_icon,
                                                        bomb_resource);
            extra_bombs.AddComponent(Common.prerequisiteNoArchetype(alchemist, library.Get<BlueprintArchetype>("68cbcd9fbf1fb1d489562f829bb97e38"))); //no bombs on vivisectionist

            var extra_ki = createResourceBonusFeature("FavoredClassExtraKiFeature",
                                            "Bonus Ki",
                                            "Add +1/4 point to the monk‘s ki pool.",
                                            ki_icon,
                                            ki_resource);

            var extra_arcane_pool = createResourceBonusFeature("FavoredClassExtraArcanePoolFeature",
                                                                "Bonus Arcane Pool",
                                                                "Add +1/4 point to the magus’ arcane pool.",
                                                                pool_icon,
                                                                arcane_pool_resource);
            extra_arcane_pool.AddComponent(Common.prerequisiteNoArchetype(magus, eldritch_scion));


            var extra_eldritch_pool = createResourceBonusFeature("FavoredClassExtraArcaneEldritchpoolFeature",
                                                                "Bonus Eldritch Pool",
                                                                "Add +1/4 point to the magus’ eldritch pool.",
                                                                pool_icon,
                                                                eldritch_pool_resource);
            extra_eldritch_pool.AddComponent(Common.createPrerequisiteArchetypeLevel(magus, eldritch_scion, 1));


            var extra_internal_buffer = createResourceBonusFeature("FavoredClassExtraInternalBufferFeature",
                                                    "Bonus Internal Buffer",
                                                    "Add +1/6 point to the kineticist’s internal buffer.",
                                                    CallOfTheWild.KineticistFix.internal_buffer.Icon,
                                                    CallOfTheWild.KineticistFix.internal_buffer_resource);



            addFavoredClassBonus(extra_bloodrage, null, Bloodrager.bloodrager_class, 1, dwarf, half_orc, human, half_elf, aasimar, tiefling);
            addFavoredClassBonus(extra_rage, null, barbarian, 1, dwarf, half_orc);
            addFavoredClassBonus(extra_performance, null, bard, 1, half_elf, half_orc, gnome);
            addFavoredClassBonus(extra_skald_performance, null, Skald.skald_class, 1, half_elf, half_orc);
            favored_bombs = addFavoredClassBonus(extra_bombs, null, alchemist, 2, gnome);
            addFavoredClassBonus(extra_ki, null, monk, 4, human, half_elf, half_orc, aasimar, tiefling);
            addFavoredClassBonus(extra_arcane_pool, null, magus, 4, human, half_elf, tiefling, aasimar, half_orc);
            addFavoredClassBonus(extra_eldritch_pool, null, magus, 4, human, half_elf,tiefling, aasimar, half_orc);
            addFavoredClassBonus(extra_internal_buffer, null, kineticist, 6, halfling);
        }


        static BlueprintFeature createResourceBonusFeature(string name, string display_name, string description, UnityEngine.Sprite icon, BlueprintAbilityResource resource)
        {
            var feat = Helpers.CreateFeature(name,
                                             display_name,
                                             description,
                                             "",
                                             icon,
                                             FeatureGroup.None,
                                             CallOfTheWild.Helpers.Create<CallOfTheWild.ResourceMechanics.ContextIncreaseResourceAmount>(c => { c.Resource = resource; c.Value = Helpers.CreateContextValue(Kingmaker.Enums.AbilityRankType.Default); })
                                            );
            feat.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank, feature: feat));
            feat.AddComponent(Helpers.Create<RecalculateOnFactsChange>(r => r.CheckedFacts = new BlueprintUnitFact[] { feat }));
            feat.Ranks = 20;
            
            return feat;
        }




        static void addExtraKnownSpellsFavoredClassBonus()
        {
            addFavoredClassBonus(CreateExtraSpellSelection(alchemist.Spellbook, alchemist, 5), null, alchemist, 2, elf, human, halfling, half_elf, half_orc, aasimar, tiefling);
            addFavoredClassBonus(CreateExtraSpellSelection(bard.Spellbook, bard, 5), null, bard, 2,human, half_elf, half_orc, aasimar, tiefling, half_elf);
            addFavoredClassBonus(CreateExtraSpellSelection(inquistor.Spellbook, inquistor, 5), null, inquistor, 2, elf, human, half_elf, half_orc, aasimar, tiefling);
            addFavoredClassBonus(CreateExtraSpellSelection(cleric.Spellbook, CallOfTheWild.Shaman.shaman_class, 8), null, CallOfTheWild.Shaman.shaman_class, 2, half_elf, human, half_orc, aasimar, tiefling);
            addFavoredClassBonus(CreateExtraSpellSelection(sorceror.Spellbook, sorceror, 8), null, sorceror, 2, human, half_elf, half_orc, aasimar, tiefling);
            addFavoredClassBonus(CreateExtraSpellSelection(wizard.Spellbook, wizard, 8), null, wizard, 2, human, half_elf, half_orc, aasimar, tiefling);
            addFavoredClassBonus(CreateExtraSpellSelection(CallOfTheWild.Witch.witch_class.Spellbook, CallOfTheWild.Witch.witch_class, 8), null, CallOfTheWild.Witch.witch_class, 2, human, half_orc, half_elf, elf, aasimar, tiefling);
            addFavoredClassBonus(CreateExtraSpellSelection(CallOfTheWild.Skald.skald_class.Spellbook, CallOfTheWild.Skald.skald_class, 5), null, CallOfTheWild.Skald.skald_class, 2, human, half_elf, half_orc, aasimar, tiefling);
        }


        static BlueprintFeatureSelection CreateExtraSpellSelection(BlueprintSpellbook spellbook, BlueprintCharacterClass @class, int max_spellLevel)
        {
            String[] spellLevelGuids = new String[] {"1541c1ef94e24659b1120cf18792094a",
                                                     "5c570cda113846ea86b800d64a90c2d5",
                                                     "2eae028571d54067949a046773069e2b",
                                                     "7c0dcae4a4684ea883f8907bfcad3caa",
                                                     "bc28b1e441634077b16616f19e23a2fe",
                                                     "41273452987d45d5a979cd714cefffaf",
                                                     "33973c98b8bf4ccea6f86ee91a83fc47",
                                                     "4ca9c712af684d609b5e168b5ad4eec1",
                                                     "15794bead9f4417796c77667fdba1068" };


            var icon = Helpers.GetIcon("55edf82380a1c8540af6c6037d34f322"); // elven magic
            BlueprintFeatureSelection learn_selection = CallOfTheWild.Helpers.CreateFeatureSelection($"Favored{@class.Name}{spellbook.SpellList.name}BonusSpellFeatureSelection",
                                                                          $"Bonus {spellbook.Name} Spell",
                                                                           $"Add 1/2 spell to your spellbook from the {spellbook.Name} spell list. This spell must be at least one level below the highest {@class.Name} spell you can cast.",
                                                                          "",
                                                                          icon,
                                                                          FeatureGroup.None);
            for (int i = 1; i <= max_spellLevel; i++)
            {
                var learn_spell = library.CopyAndAdd<BlueprintParametrizedFeature>("bcd757ac2aeef3c49b77e5af4e510956", $"Favored{@class.Name}{spellbook.SpellList.name}{i}ParametrizedFeature", "");
                learn_spell.SpellLevel = i;
                learn_spell.SpecificSpellLevel = true;
                learn_spell.SpellLevelPenalty = 0;
                learn_spell.SpellcasterClass = @class;
                learn_spell.SpellList = spellbook.SpellList;
                learn_spell.ReplaceComponent<LearnSpellParametrized>(l => { l.SpellList = spellbook.SpellList; l.SpecificSpellLevel = true; l.SpellLevel = i; l.SpellcasterClass = @class; });
                learn_spell.AddComponents(Common.createPrerequisiteClassSpellLevel(@class, i + 1)
                    );
                learn_spell.SetName(Helpers.CreateString($"Favored{@class.Name}{spellbook.SpellList.name}BonusSpellParametrizedFeature{i}.Name", $"Bonus {spellbook.Name} Spell" + $" (level {i})"));
                learn_spell.SetDescription(learn_selection.Description);
                learn_spell.SetIcon(learn_selection.Icon);

                learn_selection.AllFeatures = learn_selection.AllFeatures.AddToArray(learn_spell);
            }


            learn_selection.Ranks = 10;
            return learn_selection;
        }


        static void loadCustomFeature(string filename)
        {
            Main.logger.Log("Loading favored class bonus from: " + filename);

            string feature_guid;
            string partial_guid;
            int divisor;
            string[] class_guids;
            string[] races_guids;
            using (StreamReader bonus_file = File.OpenText(filename))
            using (JsonTextReader reader = new JsonTextReader(bonus_file))
            {
                JObject jo = (JObject)JToken.ReadFrom(reader);

                feature_guid = (string)jo["feature"];
                partial_guid = (string)jo["partial"];
                class_guids = jo["classes"].Select(x => (string)x).ToArray();
                divisor = (int)jo["divisor"];
                races_guids = jo["races"].Select(x => (string)x).ToArray();
            }
            try
            {
                BlueprintFeature feature = library.Get<BlueprintFeature>(feature_guid);
                BlueprintFeature partial_feature = null;
                if (partial_guid != "")
                {
                    partial_feature = library.Get<BlueprintFeature>(partial_guid);
                }
                List<BlueprintCharacterClass> classes = new List<BlueprintCharacterClass>();
                foreach (var class_guid in class_guids)
                {
                    classes.Add(library.Get<BlueprintCharacterClass>(class_guid));
                }

                List<BlueprintRace> races = new List<BlueprintRace>();

                foreach (var race_guid in races_guids)
                {
                    races.Add(library.Get<BlueprintRace>(race_guid));
                }
                addFavoredClassBonus(feature, partial_feature, classes.ToArray(), divisor, races.ToArray());
                Main.logger.Log("Success");
            }
            catch (Exception ex)
            {
                Main.logger.Log("Failure");
                Main.logger.Log(ex.ToString());
            }

        }


        static void loadPrestigiousSpellCaster(string filename)
        {
            string[] merge_guids = new string[]
                                            {
                                                "5de35dca32484ccdbce307504b9fe554",
                                                "5c47d51fcb80411c864e6791fa3c4886",
                                                "e895af43dd4e40acbff1e6d8798b3b55",
                                                "9b229bde63cb429b8539821f8e4f00d2",
                                                "b0f8d2960a0a4ff7b5815397423321e6",
                                                "53e61ed513024eccb854ae4b0d7684b9",
                                                "435bc51b95dd4f9f91d9f19345d3714d",
                                                "43d076225ec74d8daa23df1265b1e45f",
                                                "a673258000804214be8da878270599fe",
                                                "d1506b1eef8b4a2fb5730e4c42f8302e"
                                            };
            Main.logger.Log("Loading prestigious spllcaster data from: " + filename);

            string class_guid;
            int[] levels;
            using (StreamReader caster_file = File.OpenText(filename))
            using (JsonTextReader reader = new JsonTextReader(caster_file))
            {
                JObject jo = (JObject)JToken.ReadFrom(reader);

                class_guid = (string)jo["class"];
                levels = jo["spell_levels"].Select(x => (int)x).ToArray();
            }
            try
            {
                var caster_class = library.Get<BlueprintCharacterClass>(class_guid);
                BlueprintFeature[] features = new BlueprintFeature[levels.Length];

                for (int i = 0; i < levels.Length; i++)
                {
                    features[i] = Helpers.CreateFeature("PrestigiousSpellcaster" + caster_class.name + levels[i].ToString() +"Feature",
                                                        $"Prestigious Spellcaster: {caster_class.Name} ({levels[i]})",
                                                        prestigious_spellcaster.Description,
                                                        Helpers.MergeIds(caster_class.AssetGuid, merge_guids[levels[i] - 1]),
                                                        null,
                                                        FeatureGroup.Feat,
                                                        Helpers.Create<NewMechanics.addSpellBookLevel>(a => a.character_class = caster_class),
                                                        Helpers.PrerequisiteClassLevel(caster_class, levels[i]),
                                                        Helpers.PrerequisiteFeature(class_guid_progression_map[caster_class.AssetGuid])
                                                        );
                    if (i > 0)
                    {
                        features[i].AddComponent(Helpers.PrerequisiteFeature(features[i - 1]));
                    }
                }
                prestigious_spellcaster.AllFeatures = prestigious_spellcaster.AllFeatures.AddToArray(features);
                Main.logger.Log("Success");
            }
            catch (Exception ex)
            {
                Main.logger.Log("Failure");
                Main.logger.Log(ex.ToString());
            }

        }

    }
}
