﻿using CallOfTheWild;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
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


        static internal BlueprintRace elf = library.Get<BlueprintRace>("25a5878d125338244896ebd3238226c8");
        static internal BlueprintRace half_elf = library.Get<BlueprintRace>("b3646842ffbd01643ab4dac7479b20b0");
        static internal BlueprintRace human = library.Get<BlueprintRace>("0a5d473ead98b0646b94495af250fdc4");
        static internal BlueprintRace gnome = library.Get<BlueprintRace>("ef35a22c9a27da345a4528f0d5889157");
        static internal BlueprintRace dwarf = library.Get<BlueprintRace>("c4faf439f0e70bd40b5e36ee80d06be7");
        static internal BlueprintRace half_orc = library.Get<BlueprintRace>("1dc20e195581a804890ddc74218bfd8e");
        static internal BlueprintRace halfling = library.Get<BlueprintRace>("b0c3ef2729c498f47970bb50fa1acd30");
        static internal BlueprintRace tiefling = library.Get<BlueprintRace>("5c4e42124dc2b4647af6e36cf2590500");


        static internal BlueprintCharacterClass alchemist = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
        static internal BlueprintCharacterClass barbarian = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
        static internal BlueprintCharacterClass bard = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
        static internal BlueprintCharacterClass cleric = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
        static internal BlueprintCharacterClass druid = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
        static internal BlueprintCharacterClass fighter = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
        static internal BlueprintCharacterClass inquistor = library.Get<BlueprintCharacterClass>("f1a70d9e1b0b41e49874e1fa9052a1ce");
        static internal BlueprintCharacterClass kineticist = library.Get<BlueprintCharacterClass>("42a455d9ec1ad924d889272429eb8391");
        static internal BlueprintCharacterClass magus = library.Get<BlueprintCharacterClass>("45a4607686d96a1498891b3286121780");
        static internal BlueprintCharacterClass rogue = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
        static internal BlueprintCharacterClass sorceror = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
        static internal BlueprintCharacterClass wizard = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
        static internal BlueprintCharacterClass slayer = library.Get<BlueprintCharacterClass>("c75e0971973957d4dbad24bc7957e4fb");
        static internal BlueprintCharacterClass monk = library.Get<BlueprintCharacterClass>("e8f21e5b58e0569468e420ebea456124");


        static public FavoredClassFeature favored_skill;
        static public FavoredClassFeature favored_hp;
        static public FavoredClassFeature favored_bombs;


        static internal void load()
        {
            favored_class_selection = CallOfTheWild.Helpers.CreateFeatureSelection("FavoredClassSelection",
                                                                                   "Favored Class",
                                                                                   "Each character begins play with a single favored class of his choosing—typically, this is the same class as the one he chooses at 1st level.Whenever a character gains a level in his favored class, he receives either + 1 hit point per level or + 1 skill rank per 2 levels. The choice of favored class cannot be changed once the character is created, and the choice of gaining a hit point or a skill rank each time a character gains a level(including his first level) cannot be changed once made for a particular level.Prestige classes(see Prestige Classes) can never be a favored class.",
                                                                                   "",
                                                                                   null,
                                                                                   FeatureGroup.AasimarHeritage);

            var classes = library.Root.Progression.CharacterClasses.Where(c => c.AssetGuid != eldritchScionClassId && !c.PrestigeClass).ToList();
            foreach (var c in classes)
            {
                var progression = CallOfTheWild.Helpers.CreateProgression("FavoredClass" + c.name + "Progression",
                                                                          "Favored Class - " + c.Name,
                                                                          favored_class_selection.Description,
                                                                          CallOfTheWild.Helpers.MergeIds("602ea6032c324258a183588f84522ea1", c.AssetGuid),
                                                                          null,
                                                                          FeatureGroup.None,
                                                                          CallOfTheWild.Helpers.Create<NewMechanics.DisableAutomaticFavoredClassHitPoints>()
                                                                          );
                progression.Classes = new BlueprintCharacterClass[] { c };

                favored_class_selection.AllFeatures = favored_class_selection.AllFeatures.AddToArray(progression);
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
                for (int i = 1; i <= 20; i++)
                {
                    entries.Add(CallOfTheWild.Helpers.LevelEntry(i, bonus_selection));
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


            favored_hp = addFavoredClassBonus(bonus_hp, null, classes.ToArray(), 1);
            favored_skill = addFavoredClassBonus(bonus_skill, null, classes.ToArray(), 2);

            addExtraKnownSpellsFavoredClassBonus();
            addExtraSelectionFavoredClassBonus();
            addExtraResourceFavoredClassBonus();

             fixCompanions();
        }


        static void fixCompanions()
        {
            var valerie_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("912444657701e2d4ab2634c3d1e130ad");
            var amiri1_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("df943986ee329e84a94360f2398ae6e6");
            var tristian_companion = ResourcesLibrary.TryGetBlueprint<BlueprintUnit>("f6c23e93512e1b54dba11560446a9e02");
            var harrim_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("8910febae2a7b9f4ba5eca4dde1e9649");
            var linzi_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("c13cba80a1d22a94788b735a3e847242");
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

            addFavoredClassBonus(createFeatureCopy(Warpriest.fighter_feat, "Gain 1/6 of a new bonus combat feat.", 3), null, Warpriest.warpriest_class, 6, human);
            addFavoredClassBonus(createFeatureCopy(library.Get<BlueprintFeatureSelection>("c074a5d615200494b8f2a9c845799d93"), "Gain 1/6 of a new rogue talent.", 3), null, rogue, 6, human);
            addFavoredClassBonus(createFeatureCopy(Witch.hex_selection, "Gain 1/6 of a new witch hex.", 3), null, Witch.witch_class, 6, gnome);
            addFavoredClassBonus(createFeatureCopy(Shaman.hex_selection, "Gain 1/6 of a new shaman hex.", 3), null, Shaman.shaman_class, 6, gnome);
            addFavoredClassBonus(createFeatureCopy(library.Get<BlueprintFeatureSelection>("43d1b15873e926848be2abf0ea3ad9a8"), "Gain 1/6 of a new slayer talent.", 3), null, slayer, 6, human, gnome);
            addFavoredClassBonus(createFeatureCopy(library.Get<BlueprintFeatureSelection>("5c883ae0cd6d7d5448b7a420f51f8459"), "Gain 1/6 of a new wild talent.", 3), null, kineticist, 6, human);

            var magus_arcana = createFeatureCopy(library.Get<BlueprintFeatureSelection>("e9dc4dfc73eaaf94aae27e0ed6cc9ada"), "Gain 1/6 of a new magus arcana.", 3);
            magus_arcana.AddComponent(Common.prerequisiteNoArchetype(magus, eldritch_scion));

            var eldritch_arcana = createFeatureCopy(library.Get<BlueprintFeatureSelection>("d4b54d9db4932454ab2899f931c2042c"), "Gain 1/6 of a new magus arcana.", 3);
            eldritch_arcana.AddComponent(Common.createPrerequisiteArchetypeLevel(magus, eldritch_scion, 1));
            addFavoredClassBonus(magus_arcana, null, magus, 6, elf, halfling);
            addFavoredClassBonus(eldritch_arcana, null, magus, 6, elf, halfling);
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



            addFavoredClassBonus(extra_bloodrage, null, Bloodrager.bloodrager_class, 1, dwarf, half_orc, human);
            addFavoredClassBonus(extra_rage, null, barbarian, 1, dwarf, half_orc);
            addFavoredClassBonus(extra_performance, null, bard, 1, half_elf, half_orc, gnome);
            addFavoredClassBonus(extra_skald_performance, null, Skald.skald_class, 1, half_elf, half_orc);
            favored_bombs = addFavoredClassBonus(extra_bombs, null, alchemist, 2, gnome);
            addFavoredClassBonus(extra_ki, null, monk, 4, human);
            addFavoredClassBonus(extra_arcane_pool, null, magus, 4, human, half_elf, tiefling);
            addFavoredClassBonus(extra_eldritch_pool, null, magus, 4, human, half_elf,tiefling);
        }


        static BlueprintFeature createResourceBonusFeature(string name, string display_name, string description, UnityEngine.Sprite icon, BlueprintAbilityResource resource)
        {
            var feat = Helpers.CreateFeature(name,
                                             display_name,
                                             description,
                                             "",
                                             icon,
                                             FeatureGroup.None,
                                             CallOfTheWild.Helpers.Create<CallOfTheWild.NewMechanics.ContextIncreaseResourceAmount>(c => { c.Resource = resource; c.Value = Helpers.CreateContextValue(Kingmaker.Enums.AbilityRankType.Default); })
                                            );
            feat.AddComponent(Helpers.CreateContextRankConfig(baseValueType: ContextRankBaseValueType.FeatureRank, feature: feat));
            feat.AddComponent(Helpers.Create<RecalculateOnFactsChange>(r => r.CheckedFacts = new BlueprintUnitFact[] { feat }));
            feat.Ranks = 20;
            
            return feat;
        }




        static void addExtraKnownSpellsFavoredClassBonus()
        {
            addFavoredClassBonus(CreateExtraSpellSelection(alchemist.Spellbook, alchemist, 5), null, alchemist, 2, elf, human, halfling);
            addFavoredClassBonus(CreateExtraSpellSelection(bard.Spellbook, bard, 5), null, bard, 2,human);
            addFavoredClassBonus(CreateExtraSpellSelection(inquistor.Spellbook, inquistor, 5), null, inquistor, 2, elf, human);
            addFavoredClassBonus(CreateExtraSpellSelection(cleric.Spellbook, CallOfTheWild.Shaman.shaman_class, 8), null, CallOfTheWild.Shaman.shaman_class, 2, half_elf, human, half_orc);
            addFavoredClassBonus(CreateExtraSpellSelection(sorceror.Spellbook, sorceror, 8), null, sorceror, 2, human);
            addFavoredClassBonus(CreateExtraSpellSelection(wizard.Spellbook, wizard, 8), null, wizard, 2, human);
            addFavoredClassBonus(CreateExtraSpellSelection(CallOfTheWild.Witch.witch_class.Spellbook, CallOfTheWild.Witch.witch_class, 8), null, CallOfTheWild.Witch.witch_class, 2, human, half_orc, half_elf, elf);
            addFavoredClassBonus(CreateExtraSpellSelection(CallOfTheWild.Skald.skald_class.Spellbook, CallOfTheWild.Skald.skald_class, 5), null, CallOfTheWild.Skald.skald_class, 2, human);
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

    }
}
