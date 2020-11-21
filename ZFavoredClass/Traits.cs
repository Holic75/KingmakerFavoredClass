using CallOfTheWild;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Root;
using Kingmaker.Designers;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UI.Common;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist.Properties;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFavoredClass
{
    class Traits
    {
        static LibraryScriptableObject library => Main.library;
        //COMBAT TRAITS
        static public BlueprintFeature anatomist;
        static public BlueprintFeature armor_expert;
        static public BlueprintFeature berserker_of_the_society;
        static public BlueprintFeature blade_of_the_society;
        static public BlueprintFeature defender_of_the_society;
        static public BlueprintFeature deft_dodger;
        static public BlueprintFeature dirty_fighter;
        static public BlueprintFeature reactionary;
        static public BlueprintFeature resilent;
        static public BlueprintFeature slippery;
        //dirty trickster
        static public BlueprintFeatureSelection dragon_armor;
        //evasive_sting;
        static public BlueprintFeature fencer;
        static public BlueprintFeature honored_fist_of_society;
        static public BlueprintFeature threatening_defender;



        //FAITH TRAITS
        static public BlueprintFeature birthmark;
        static public BlueprintFeature caretaker;
        static public BlueprintFeature devotee_of_the_green;
        static public BlueprintFeature ease_of_faith;
        static public BlueprintFeature exalted_of_the_society;
        static public BlueprintFeature indomitable_faith;
        static public BlueprintFeature sacred_conduit;
        static public BlueprintFeature scholar_of_the_greate_beyond;
        static public BlueprintFeature fates_favored;
        static public BlueprintFeature omen;
        static public BlueprintFeature reincarnated;
        //martial manuscript

        //SOCIAL TRAITS
        static public BlueprintFeatureSelection adopted;
        static public BlueprintFeature bully;
        static public BlueprintFeature fast_talker;
        static public BlueprintFeature maestro_of_the_society;
        static public BlueprintFeature poverty_stricken;
        static public BlueprintFeature student_of_philosophy;
        static public BlueprintFeature bruising_intellect;
        static public BlueprintFeature clever_wordplay;
        static public BlueprintFeature child_of_streets;
        static public BlueprintFeature seeker;

        //MAGIC TRAITS
        static public BlueprintFeature classically_schooled;
        static public BlueprintFeature dangerously_curious;
        static public BlueprintFeature focused_mind;
        static public BlueprintParametrizedFeature gifted_adept;
        static public BlueprintFeatureSelection magical_knack;
        static public BlueprintParametrizedFeature magical_lineage;
        static public BlueprintFeature pragmatic_activator;
        static public BlueprintFeature transmuter_of_korada;
        static public BlueprintFeature strength_of_the_land;
        static public BlueprintFeature trickster;
        static public BlueprintFeature aeromantic_affinity;
        //stabbing spell

        //RELIGION TRAITS
        //deadeye bowman - done in proper flanking 2
        static public BlueprintFeature shield_trained;
        static public BlueprintFeatureSelection wisdom_in_flesh;
        static public BlueprintFeature opportunistic;
        static public BlueprintFeature erastils_speaker;
        static public BlueprintFeature child_of_nature;
        static public BlueprintFeature purity_of_faith;
        static public BlueprintFeature underlying_principles;
        static public BlueprintFeatureSelection secret_knowledge;
        static public BlueprintFeature spirit_guide;
        static public BlueprintFeature illuminator;
        static public BlueprintFeature defensive_strategist;
        static public BlueprintFeature bestial_wrath;
        static public BlueprintFeature corpse_hunter;
        static public BlueprintFeature demoralizing_presence;
        static public BlueprintFeature eyes_and_ears_of_the_city;
        static public BlueprintFeature good_natured;
        static public BlueprintFeature liars_tongue;
        //pain_in_pleasure;
        static public BlueprintFeature regal_presence;
        static public BlueprintFeature stoic_optimism;
        static public BlueprintFeature strong_willed;
        static public BlueprintFeature unswaying_love;
        static public BlueprintFeature mothers_teeth;
        static public BlueprintFeature mothers_rage;


        //RACE TRAITS
        static public BlueprintFeature auspicious_tatoo;
        static public BlueprintFeature big_ears;
        static public BlueprintFeature bred_for_war;
        static public BlueprintFeature brute;
        static public BlueprintFeature elven_reflexes;
        static public BlueprintFeature forlorn;
        static public BlueprintFeature latent_psion;
        static public BlueprintFeature outcast;
        static public BlueprintFeature ruthless;
        static public BlueprintFeature finish_the_fight;
        static public BlueprintFeature unbreakable_hate;
        static public BlueprintFeature varisian_tattoo;
        static public BlueprintFeature shield_bearer;
        static public BlueprintFeature grounded;
        static public BlueprintFeature shadow_stabber;
        static public BlueprintFeature warrior_of_old;
        static public BlueprintFeatureSelection intrepid_volunteer;
        static public BlueprintFeature helpful;
        static public BlueprintFeature well_informed;
        static public BlueprintFeatureSelection eclectic;
        static public BlueprintFeature goblin_foolhardiness;
        static public BlueprintFeature celestial_contact;
        static public BlueprintFeature harrows_chosen;

        //REGIONAL TRAITS
        static public BlueprintFeature chilled_by_brutality;
        static public BlueprintFeature honeyed_tongue;
        static public BlueprintFeature militia;
        static public BlueprintFeature freed_slave;
        static public BlueprintFeature aspiring_hellknight;
        static public BlueprintFeature secret_revolutionary;
        static public BlueprintFeature glory_of_old;
        static public BlueprintFeature spiritual_forester;
        static public BlueprintFeature viking_blood;
        static public BlueprintFeature river_rat;
        static public BlueprintFeature quain_martial_artist;
        static public BlueprintFeature sargavan_guard;
        static public BlueprintFeature hermean_paragon;
        static public BlueprintParametrizedFeature wayang_spellhunter;
        static public BlueprintFeature valashmai_veteran;
        static public BlueprintFeature rice_runner;
        static public BlueprintFeature sound_of_mind;
        static public BlueprintFeature xa_hoi_soldier;
        static public BlueprintFeature blighted_physiology;
        static public BlueprintFeature child_of_crusades;
        static public BlueprintFeature demon_bane_summoner;
        //elemental_pupil;
        static public BlueprintFeature empathic_diplomat;
        static public BlueprintFeature cunning_liar;
        static public BlueprintFeature flotsam;
        static public BlueprintFeature minkai_advocate;
        static public BlueprintFeature pirate_duelist;
        static public BlueprintParametrizedFeature secret_of_the_impossible_kingdom;

        //EQUIPMENT TRAITS
        static public Dictionary<WeaponCategory, BlueprintFeatureSelection> heirloom_weapon = new Dictionary<WeaponCategory, BlueprintFeatureSelection>();



        static public BlueprintFeatureSelection combat_traits;
        static public BlueprintFeatureSelection faith_traits;
        static public BlueprintFeatureSelection magic_traits;
        static public BlueprintFeatureSelection religion_traits;
        static public BlueprintFeatureSelection social_traits;
        static public BlueprintFeatureSelection racial_traits;
        static public BlueprintFeatureSelection traits_selection, traits_selection2;
        static public BlueprintFeatureSelection regional_traits;
        static public BlueprintFeatureSelection equipment_traits;

        static public BlueprintFeature additional_traits;

        static internal void load(bool enable)
        {
            createCombatTratits();
            createReligionlTraits();
            createFaithTraits();
            createMagicalTraits();
            createSocialTraits();
            createRacialTraits();
            createRegionalTraits();
            createEquipmentTraits();

            traits_selection = Helpers.CreateFeatureSelection("TraitsSelection",
                                                             "Trait",
                                                             "Character traits are abilities that are not tied to your character’s race or class. They can enhance your character’s skills, racial abilities, class abilities, or other statistics, enabling you to further customize him. At its core, a character trait is approximately equal in power to half a feat, so two character traits are roughly equivalent to a bonus feat. Yet a character trait isn’t just another kind of power you can add on to your character—it’s a way to quantify (and encourage) building a character background that fits into your campaign world. Think of character traits as “story seeds” for your background; after you pick your two traits, you’ll have a point of inspiration from which to build your character’s personality and history. Alternatively, if you’ve already got a background in your head or written down for your character, you can view picking his traits as a way to quantify that background, just as picking race and class and ability scores quantifies his other strengths and weaknesses.",
                                                             "",
                                                             null,
                                                             FeatureGroup.None
                                                             );
            traits_selection.AllFeatures = new BlueprintFeature[] { combat_traits, faith_traits, magic_traits, religion_traits, social_traits, racial_traits, regional_traits, equipment_traits};
            traits_selection.HideInCharacterSheetAndLevelUp = true;

            adopted = library.CopyAndAdd(racial_traits, "AdoptedTraitSelection", "");
            adopted.SetNameDescription("Adopted",
                                       "You were adopted and raised by someone not of your race, and raised in a society not your own. As a result, you picked up a race trait from your adoptive parents and society, and may immediately select a race trait from your adoptive parents’ race.");
            adopted.ComponentsArray = new BlueprintComponent[0];
            adopted.IgnorePrerequisites = true;

            social_traits.AllFeatures = social_traits.AllFeatures.AddToArray(adopted);
            traits_selection2 = library.CopyAndAdd(traits_selection, "TraitSelection2Feature", "");
            additional_traits = Helpers.CreateFeature("AdditionalTraitsFeature",
                                                      "Additional Traits",
                                                      "You gain two character traits of your choice. These traits must be chosen from different lists, and cannot be chosen from lists from which you have already selected a character trait. You must meet any additional qualifications for the character traits you choose — this feat cannot enable you to select a dwarf character trait if you are an elf, for example.",
                                                      "",
                                                      Helpers.GetIcon("0d3651b2cb0d89448b112e23214e744e"), // Extra Performance
                                                      FeatureGroup.None,
                                                      Helpers.Create<CallOfTheWild.EvolutionMechanics.addSelection>(a => a.selection = traits_selection),
                                                      Helpers.Create<CallOfTheWild.EvolutionMechanics.addSelection>(a => a.selection = traits_selection2)
                                                      );
            var animal_calss = ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");
            additional_traits.AddComponent(Helpers.PrerequisiteNoFeature(additional_traits));
            additional_traits.AddComponents(Helpers.Create<PrerequisiteNoClassLevel>(p => p.CharacterClass = animal_calss),
                                            Helpers.Create<PrerequisiteNoClassLevel>(p => p.CharacterClass = Eidolon.eidolon_class));


            if (enable)
            {
                Main.logger.Log("Enabling Traits.");
                var basic_feats_progression = library.Get<BlueprintProgression>("5b72dd2ca2cb73b49903806ee8986325"); //basic feats
                basic_feats_progression.LevelEntries[0].Features = new BlueprintFeatureBase[] { traits_selection, traits_selection2 }.AddToArray(basic_feats_progression.LevelEntries[0].Features).ToList();
                library.AddFeats(additional_traits);

                addTraitsToCompanions();
            }



        }

        static void addTraitsToCompanions()
        {
            var valerie_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("912444657701e2d4ab2634c3d1e130ad");
            var amiri1_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("df943986ee329e84a94360f2398ae6e6");
            var tristian_companion = ResourcesLibrary.TryGetBlueprint<BlueprintUnit>("f6c23e93512e1b54dba11560446a9e02");
            var harrim_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("8910febae2a7b9f4ba5eca4dde1e9649");
            var linzi_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("920cb420385dbb34681b620b6c1b59e9");
            var ekun_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("0bc6dc9b6648a744899752508addae8c");
            var jaethal_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("34280596dd550074ca55bd15285451b3");
            var jubilost_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("c9618e3c61e65114b994f3fabcae1d97");
            var nok_nok_companion = ResourcesLibrary.TryGetBlueprint<BlueprintUnit>("f9417988783876044b76f918f8636455");
            var kanerah_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("ccb52e235941e0442be0cb0ee5570f07");
            var kalikke_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("385e8d69b89992844b0992caf666a5fd");
            var octavia_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("200151a5a5c78a4439d0f6e9fb26620a");
            var regongar_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("12ee53c9e546719408db257f489ec366");
            var varn_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("2babd2d4687b5ee428966322eccfe4b6");
            var cephal_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("d152b07305353474ba15d750015d99ee");

            //linzi - reactionary and helpful
            Common.addFeatureSelectionToAcl(linzi_feature.GetComponent<AddClassLevels>(), traits_selection, combat_traits);
            Common.addFeatureSelectionToAcl(linzi_feature.GetComponent<AddClassLevels>(), combat_traits, reactionary);
            Common.addFeatureSelectionToAcl(linzi_feature.GetComponent<AddClassLevels>(), traits_selection2, racial_traits);
            Common.addFeatureSelectionToAcl(linzi_feature.GetComponent<AddClassLevels>(), racial_traits, helpful);

            //jaethal - anatomist, and warrior of old
            Common.addFeatureSelectionToAcl(jaethal_feature.GetComponent<AddClassLevels>(), traits_selection, combat_traits);
            Common.addFeatureSelectionToAcl(jaethal_feature.GetComponent<AddClassLevels>(), combat_traits, anatomist);
            Common.addFeatureSelectionToAcl(jaethal_feature.GetComponent<AddClassLevels>(), traits_selection2, racial_traits);
            Common.addFeatureSelectionToAcl(jaethal_feature.GetComponent<AddClassLevels>(), racial_traits, warrior_of_old);

            //harrim - glory of old and fate favored
            Common.addFeatureSelectionToAcl(harrim_feature.GetComponent<AddClassLevels>(), traits_selection, faith_traits);
            Common.addFeatureSelectionToAcl(harrim_feature.GetComponent<AddClassLevels>(), faith_traits, fates_favored);
            Common.addFeatureSelectionToAcl(harrim_feature.GetComponent<AddClassLevels>(), traits_selection2, regional_traits);
            Common.addFeatureSelectionToAcl(harrim_feature.GetComponent<AddClassLevels>(), regional_traits, glory_of_old);

            //valerie - threatening defender, fate's favored
            Common.addFeatureSelectionToAcl(valerie_feature.GetComponent<AddClassLevels>(), traits_selection, faith_traits);
            Common.addFeatureSelectionToAcl(valerie_feature.GetComponent<AddClassLevels>(), faith_traits, fates_favored);
            Common.addFeatureSelectionToAcl(valerie_feature.GetComponent<AddClassLevels>(), traits_selection2, combat_traits);
            Common.addFeatureSelectionToAcl(valerie_feature.GetComponent<AddClassLevels>(), combat_traits, threatening_defender);

            //amiri - chilled by brutality, bred for war
            Common.addFeatureSelectionToAcl(amiri1_feature.GetComponent<AddClassLevels>(), traits_selection, racial_traits);
            Common.addFeatureSelectionToAcl(amiri1_feature.GetComponent<AddClassLevels>(), racial_traits, bred_for_war);
            Common.addFeatureSelectionToAcl(amiri1_feature.GetComponent<AddClassLevels>(), traits_selection2, regional_traits);
            Common.addFeatureSelectionToAcl(amiri1_feature.GetComponent<AddClassLevels>(), regional_traits, chilled_by_brutality);

            //tristian - seeker, exalted
            Common.addFeatureSelectionToAcl(tristian_companion.GetComponent<AddClassLevels>(), traits_selection, social_traits);
            Common.addFeatureSelectionToAcl(tristian_companion.GetComponent<AddClassLevels>(), social_traits, seeker);
            Common.addFeatureSelectionToAcl(tristian_companion.GetComponent<AddClassLevels>(), traits_selection2, faith_traits);
            Common.addFeatureSelectionToAcl(tristian_companion.GetComponent<AddClassLevels>(), faith_traits, exalted_of_the_society);

            //regongar - finish the fight, reactionary
            Common.addFeatureSelectionToAcl(regongar_feature.GetComponent<AddClassLevels>(), traits_selection, racial_traits);
            Common.addFeatureSelectionToAcl(regongar_feature.GetComponent<AddClassLevels>(), racial_traits, finish_the_fight);
            Common.addFeatureSelectionToAcl(regongar_feature.GetComponent<AddClassLevels>(), traits_selection2, combat_traits);
            Common.addFeatureSelectionToAcl(regongar_feature.GetComponent<AddClassLevels>(), combat_traits, deft_dodger);

            //octavia - magical knack (wizard), elven reflexes
            Common.addFeatureSelectionToAcl(octavia_feature.GetComponent<AddClassLevels>(), traits_selection, magic_traits);
            Common.addFeatureSelectionToAcl(octavia_feature.GetComponent<AddClassLevels>(), magic_traits, pragmatic_activator);
            Common.addFeatureSelectionToAcl(octavia_feature.GetComponent<AddClassLevels>(), traits_selection2, racial_traits);
            Common.addFeatureSelectionToAcl(octavia_feature.GetComponent<AddClassLevels>(), racial_traits, elven_reflexes);

            //kalikke - reactionary, indomitable faith
            Common.addFeatureSelectionToAcl(kalikke_feature.GetComponent<AddClassLevels>(), traits_selection, faith_traits);
            Common.addFeatureSelectionToAcl(kalikke_feature.GetComponent<AddClassLevels>(), faith_traits, indomitable_faith);
            Common.addFeatureSelectionToAcl(kalikke_feature.GetComponent<AddClassLevels>(), traits_selection2, combat_traits);
            Common.addFeatureSelectionToAcl(kalikke_feature.GetComponent<AddClassLevels>(), combat_traits, reactionary);

            //kanerah - pragmatic activator, indomitable faith
            Common.addFeatureSelectionToAcl(kanerah_feature.GetComponent<AddClassLevels>(), traits_selection, faith_traits);
            Common.addFeatureSelectionToAcl(kanerah_feature.GetComponent<AddClassLevels>(), faith_traits, indomitable_faith);
            Common.addFeatureSelectionToAcl(kanerah_feature.GetComponent<AddClassLevels>(), traits_selection2, magic_traits);
            Common.addFeatureSelectionToAcl(kanerah_feature.GetComponent<AddClassLevels>(), magic_traits, pragmatic_activator);

            //jubilost - bruising intellect, indomitable faith
            Common.addFeatureSelectionToAcl(jubilost_feature.GetComponent<AddClassLevels>(), traits_selection, social_traits);
            Common.addFeatureSelectionToAcl(jubilost_feature.GetComponent<AddClassLevels>(), social_traits, bruising_intellect);
            Common.addFeatureSelectionToAcl(jubilost_feature.GetComponent<AddClassLevels>(), traits_selection2, magic_traits);
            Common.addFeatureSelectionToAcl(jubilost_feature.GetComponent<AddClassLevels>(), magic_traits, pragmatic_activator);

            //ekun defensive strategist and magical knack ranger
            Common.addFeatureSelectionToAcl(ekun_feature.GetComponent<AddClassLevels>(), traits_selection, magic_traits);
            Common.addFeatureSelectionToAcl(ekun_feature.GetComponent<AddClassLevels>(), magic_traits, magical_knack);
            Common.addFeatureSelectionToAcl(ekun_feature.GetComponent<AddClassLevels>(), magical_knack, library.Get<BlueprintFeature>("9625361668bf4c1c9c5d9962274b6f78"));//ranger
            Common.addFeatureSelectionToAcl(ekun_feature.GetComponent<AddClassLevels>(), traits_selection2, religion_traits);
            Common.addFeatureSelectionToAcl(ekun_feature.GetComponent<AddClassLevels>(), religion_traits, defensive_strategist);

            //nok-nok - mothers teeth, goblin foolhardiness
            Common.addFeatureSelectionToAcl(nok_nok_companion.GetComponent<AddClassLevels>(), traits_selection, racial_traits);
            Common.addFeatureSelectionToAcl(nok_nok_companion.GetComponent<AddClassLevels>(), racial_traits, goblin_foolhardiness);
            Common.addFeatureSelectionToAcl(nok_nok_companion.GetComponent<AddClassLevels>(), traits_selection2, religion_traits);
            Common.addFeatureSelectionToAcl(nok_nok_companion.GetComponent<AddClassLevels>(), religion_traits, mothers_teeth);
        }


        static BlueprintFeatureSelection createTraitSelction(string name, string display_name, string description, params BlueprintFeature[] features)
        {
            var selection = Helpers.CreateFeatureSelection(name,
                                                display_name,
                                                description,
                                                "",
                                                null,
                                                FeatureGroup.Trait
                                                );
            selection.AddComponent(Helpers.PrerequisiteNoFeature(selection));
            selection.AllFeatures = features;
            selection.HideInCharacterSheetAndLevelUp = true;
            return selection;
        }

        static void createReligionlTraits()
        {
            var shield_proficiency = Helpers.CreateFeature("ShieldWeaponProficiencyTrait",
                                                           "",
                                                           "",
                                                           "",
                                                           null,
                                                           FeatureGroup.Trait,
                                                           Common.createAddWeaponProficiencies(WeaponCategory.SpikedHeavyShield, WeaponCategory.SpikedLightShield, WeaponCategory.WeaponLightShield, WeaponCategory.WeaponHeavyShield)
                                                           );
            shield_proficiency.HideInUI = true;
            shield_proficiency.HideInCharacterSheetAndLevelUp = true;
            shield_trained = Helpers.CreateFeature("ShieldTrainedTrait",
                                                   "Shield-Trained",
                                                   "You were trained to use shields as weapons.\n"
                                                   + "Benefits: Heavy and light shields are considered simple weapons rather than martial weapons for you. Heavy shields are considered light weapons for you.",
                                                   "",
                                                   Helpers.GetIcon("121811173a614534e8720d7550aae253"), //shield bash
                                                   FeatureGroup.Trait,
                                                   Helpers.Create<CallOfTheWild.HoldingItemsMechanics.ConsiderWeaponCategoriesAsLightWeapon>(c => c.categories = new WeaponCategory[] { WeaponCategory.SpikedHeavyShield, WeaponCategory.WeaponHeavyShield }),
                                                   Common.createAddFeatureIfHasFact(library.Get<BlueprintFeature>("203992ef5b35c864390b4e4a1e200629"), shield_proficiency),
                                                   Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("8f49a5d8528a82c44b8c117a89f6b68c")) //gorum
                                                   );

            wisdom_in_flesh = Helpers.CreateFeatureSelection("WisdomInFleshTraitSelection",
                                                             "Wisdom in Flesh",
                                                             "Your hours of meditation on inner perfection and the nature of strength and speed allow you to focus your thoughts to achieve things your body might not normally be able to do on its own.\n"
                                                             + "Benefits: Select any Strength-, Constitution-, or Dexterity-based skill. You may make checks with that skill using your Wisdom modifier instead of the skill’s normal ability score. That skill is always a class skill for you.",
                                                             "",
                                                             Helpers.GetIcon("35f3724d4e8877845af488d167cb8a89"), //mind blank
                                                             FeatureGroup.Trait,
                                                             Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("23a77a5985de08349820429ce1b5a234")) //irori
                                                             );

            var physical_skills = new StatType[] { StatType.SkillAthletics, StatType.SkillThievery, StatType.SkillMobility, StatType.SkillStealth };
            wisdom_in_flesh.HideInCharacterSheetAndLevelUp = true;

            foreach (var s in physical_skills)
            {
                var f = Helpers.CreateFeature(s.ToString() + wisdom_in_flesh.name,
                                               wisdom_in_flesh.Name + ": " + UIUtility.GetStatText(s),
                                               wisdom_in_flesh.Description,
                                               "",
                                               wisdom_in_flesh.Icon,
                                               FeatureGroup.Trait,
                                                 Helpers.Create<CallOfTheWild.StatReplacementMechanics.ReplaceBaseStatForStatTypeLogic>(r =>
                                                 {
                                                     r.StatTypeToReplaceBastStatFor = s;
                                                     r.NewBaseStatType = StatType.Wisdom;
                                                 }),
                                                 Helpers.Create<RecalculateOnStatChange>(r => r.Stat = StatType.Wisdom),
                                                 Helpers.Create<RecalculateOnStatChange>(r => r.Stat = (s == StatType.SkillAthletics) ? StatType.Strength : StatType.Dexterity),
                                               Helpers.Create<AddClassSkill>(a => a.Skill = s)
                                               );
                wisdom_in_flesh.AllFeatures = wisdom_in_flesh.AllFeatures.AddToArray(f);
            }

            opportunistic = Helpers.CreateFeature("OpportunisticTrait",
                                                   "Opportunistic",
                                                   "You have learned to recognize openings that your foes leave, and you know how to take advantage of them.\n"
                                                   + "Benefits: You gain a +1 trait bonus on attacks of opportunity when using a dagger or a sword.",
                                                   "",
                                                   Helpers.GetIcon("5bb6dc5ce00550441880a6ff8ad4c968"), //opportunist
                                                   FeatureGroup.Trait,
                                                   Helpers.Create<CallOfTheWild.NewMechanics.AttackBonusOnAttacksOfOpportunity>(a =>
                                                   {
                                                       a.categories = new WeaponCategory[] { WeaponCategory.Estoc, WeaponCategory.Rapier, WeaponCategory.Scimitar, WeaponCategory.Shortsword, WeaponCategory.Dagger, WeaponCategory.Kukri, WeaponCategory.PunchingDagger, WeaponCategory.Longsword, WeaponCategory.BastardSword, WeaponCategory.Falchion, WeaponCategory.Greatsword, WeaponCategory.DuelingSword };
                                                       a.Value = 1;
                                                       a.Descriptor = ModifierDescriptor.Trait;
                                                   }
                                                   ),
                                                   Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("c7531715a3f046d4da129619be63f44c")) //calistria
                                                   );

            erastils_speaker = Helpers.CreateFeature("ErastilsSpeakerTrait",
                                                     "Erastil's Speaker",
                                                     "You understand the importance of keeping the peace in your community, and you have learned how to speak to the faithful in ways that they understand.\n"
                                                     + "Benefits: You gain a +1 bonus on Diplomacy checks, and consider Persuasion skill as class skill for the purpose of diplomacy checks.",
                                                     "",
                                                     Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // skill focus diplomacy
                                                     FeatureGroup.Trait,
                                                     Helpers.CreateAddStatBonus(StatType.CheckDiplomacy, 1, ModifierDescriptor.Trait),
                                                     Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckDiplomacy; }),
                                                     Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("afc775188deb7a44aa4cbde03512c671")) //erastil
                                                     );

            child_of_nature = Helpers.CreateFeature("ChildOfNatureTrait",
                                                     "Child of Nature",
                                                     "The wild places are your home, and provide everything you need to be happy.\n"
                                                     + "Benefits: You gain a +2 bonus on Lore (Nature) checks, and Lore (Nature) is always a class skill for you.",
                                                     "",
                                                     Helpers.GetIcon("6507d2da389ed55448e0e1e5b871c013"), // sf nature
                                                     FeatureGroup.Trait,
                                                     Helpers.CreateAddStatBonus(StatType.SkillLoreNature, 2, ModifierDescriptor.Trait),
                                                     Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillLoreNature),
                                                     Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("4af983eec2d821b40a3065eb5e8c3a72")) //gozreh
                                                     );

            purity_of_faith = Helpers.CreateFeature("PurityOfFaithTrait",
                                                     "Purity of Faith",
                                                     "Your soul is free from impurity, and you are deeply committed to fulfilling your duties to the church.\n"
                                                     + "Benefits: You gain a +1 trait bonus on Will saving throws and a +1 trait bonus on saving throws against spells and effects originating from an outsider with the evil subtype.",
                                                     "",
                                                     Helpers.GetIcon("175d1577bb6c9a04baf88eec99c66334"), // iron will
                                                     FeatureGroup.Trait,
                                                     Helpers.CreateAddStatBonus(StatType.SaveWill, 1, ModifierDescriptor.Trait),
                                                     Common.createContextSavingThrowBonusAgainstFact(Common.outsider, AlignmentComponent.Evil, 1, ModifierDescriptor.Trait),
                                                     Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("88d5da04361b16746bf5b65795e0c38c")) //iomedae
                                                     );

            underlying_principles = Helpers.CreateFeature("UnderlyingPrinciplesTrait",
                                             "Underlying Principles",
                                             "You’ve spent a large amount of time around magical items, and understand the similarities between many of them.\n"
                                             + "Benefits: You gain a +1 bonus on Use Magic Device checks, and Use Magic Device is always a class skill for you.",
                                             "",
                                             Helpers.GetIcon("f43ffc8e3f8ad8a43be2d44ad6e27914"), // sf umd
                                             FeatureGroup.Trait,
                                             Helpers.CreateAddStatBonus(StatType.SkillUseMagicDevice, 1, ModifierDescriptor.Trait),
                                             Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillUseMagicDevice),
                                             Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("6262cfce7c31626458325ca0909de997")) //nethys
                                             );

            secret_knowledge = Helpers.CreateFeatureSelection("SecretKnowledgeTraitSelection",
                                                 "Secret Knowledge",
                                                 "You may choose one Knowledge skill. You gain a permanent +2 trait bonus on checks with that skill, and it is a class skill for you.",
                                                 "",
                                                 Helpers.GetIcon("35f3724d4e8877845af488d167cb8a89"), //mind blank
                                                 FeatureGroup.Trait,
                                                 Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("805b6bdc8c96f4749afc687a003f9628")) //norgorber
                                                 );

            var knowledge_skills = new StatType[] { StatType.SkillLoreNature, StatType.SkillLoreReligion, StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld };
            secret_knowledge.HideInCharacterSheetAndLevelUp = true;

            foreach (var s in knowledge_skills)
            {
                var f = Helpers.CreateFeature(s.ToString() + secret_knowledge.name,
                                               secret_knowledge.Name + ": " + UIUtility.GetStatText(s),
                                               secret_knowledge.Description,
                                               "",
                                               secret_knowledge.Icon,
                                               FeatureGroup.Trait,
                                               Helpers.CreateAddStatBonus(s, 2, ModifierDescriptor.Trait),
                                               Helpers.Create<AddClassSkill>(a => a.Skill = s)
                                               );
                secret_knowledge.AllFeatures = secret_knowledge.AllFeatures.AddToArray(f);
            }


            spirit_guide = Helpers.CreateFeature("SpiritGuideTrait",
                                             "Spirit Guide",
                                             "As someone who has performed or observed funeral rites for a wide variety of people, you have a basic understanding of many different religions.\nBenefits: You gain a +2 trait bonus on Lore (Religion) checks, and Lore (Religion) is always a class skill for you.",
                                             "",
                                             Helpers.GetIcon("f6f95242abdfac346befd6f4f6222140"), // remove sickness
                                             FeatureGroup.Trait,
                                             Helpers.CreateAddStatBonus(StatType.SkillLoreReligion, 2, ModifierDescriptor.Trait),
                                             Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillLoreReligion),
                                             Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("458750bc214ab2e44abdeae404ab22e9")) //pharasma
                                             );


            illuminator = Helpers.CreateFeature("IlluminatorTrait",
                                                "Illuminator",
                                                "When you are filled with the light of Sarenrae, your speech takes on a fiery eloquence.\n"
                                                + "Benefits: You gain a +2 bonus on Diplomacy checks, and consider Persuasion skill as class skill for the purpose of diplomacy checks.",
                                                "",
                                                Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // skill focus diplomacy
                                                FeatureGroup.Trait,
                                                Helpers.CreateAddStatBonus(StatType.CheckDiplomacy, 2, ModifierDescriptor.Trait),
                                                Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckDiplomacy; }),
                                                Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("c1c4f7f64842e7e48849e5e67be11a1b")) //sarenrae
                                                );

            defensive_strategist = Helpers.CreateFeature("DefensiveStrategistTrait",
                                                        "Defensive Strategist",
                                                        "Your study of dwarven history has trained you in defensive strategy.\n"
                                                        + "Benefits: You aren’t flat-footed during a surprise round that you don’t get to act in or before you get to act at the start of a battle.",
                                                        "",
                                                        Helpers.GetIcon("ac57069b6bf8c904086171683992a92a"), // shield focus
                                                        FeatureGroup.Trait,
                                                        Helpers.Create<CallOfTheWild.FlatFootedMechanics.NotFlatFootedBeforeInitiative>(),
                                                        Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("d2d5c5a58885a6b489727467e13c3337")) //torag
                                                        );

            bestial_wrath = Helpers.CreateFeature("BestialWrathTrait",
                                              "Bestial Wrath",
                                              "When you strike hard, you strike deep.\nBenefit: You gain a +2 trait bonus on all rolls made to confirm critical hits.",
                                              "",
                                              Helpers.GetIcon("f4201c85a991369408740c6888362e20"), // Improved Critical
                                              FeatureGroup.Trait,
                                              Helpers.Create<CriticalConfirmationBonus>(a => { a.Bonus = 2; a.Value = 0; }),
                                              Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("04bc2b62273ab744092d992ed72bff41")) //rovagug
                                              );

            corpse_hunter = Helpers.CreateFeature("CorpseHunterTrait",
                                              "Corpse Hunter",
                                              "You have dedicated yourself to the destruction of undead.\nBenefit: You gain a +1 trait bonus on attacks made against undead.",
                                              "",
                                              Helpers.GetIcon("652739779aa05504a9ad5db1db6d02ae"), // disrupt unded
                                              FeatureGroup.Trait,
                                              Helpers.Create<AttackBonusAgainstFactOwner>(a => { a.AttackBonus = 2; a.Bonus = 0; a.CheckedFact = Common.undead; a.Descriptor = ModifierDescriptor.Trait; }),
                                              Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("458750bc214ab2e44abdeae404ab22e9"))//pharasma
                                              );

            demoralizing_presence = Helpers.CreateFeature("DemoralizingPresenceTrait",
                                  "Demoralizing Presence",
                                  "Your very existence is unsettling to your foes.\nBenefit: You gain a +2 trait bonus on Intimidate checks.",
                                  "",
                                  Helpers.GetIcon("d2aeac47450c76347aebbc02e4f463e0"), // fear
                                  FeatureGroup.Trait,
                                  Helpers.CreateAddStatBonus(StatType.CheckIntimidate, 2, ModifierDescriptor.Trait),
                                  Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("f7eed400baa66a744ad361d4df0e6f1b"))//zon-kuthion
                                  );

            eyes_and_ears_of_the_city = Helpers.CreateFeature("EyesAndEarsOfTheCityTrait",
                                         "Eyes and Ears of the City ",
                                         "Your religious training involved serving in the city watch of a large city, the primary duty of which was standing sentinel on a city wall.\n"
                                         + "Benefits: You gain a +1 trait bonus on Perception checks, and Perception is always a class skill for you.",
                                         "",
                                         Helpers.GetIcon("f74c6bdf5c5f5374fb9302ecdc1f7d64"), // sf perception
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.SkillPerception, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillPerception),
                                         Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("6122dacf418611540a3c91e67197ee4e"))//abadar
                                         );
            good_natured = Helpers.CreateFeature("GoodNaturedTrait",
                                                    "Good Natured",
                                                    "You have an unusually sunny spirit, and it takes serious doing to dampen your mood.\n"
                                                    + "Benefit: you gain a +2 trait bonus on all saves against fear.",
                                                    "",
                                                    Helpers.GetIcon("dd38f33c56ad00a4da386c1afaa49967"), // blessing of courage
                                                    FeatureGroup.Trait,
                                                    Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.Bonus = 2; s.ModifierDescriptor = ModifierDescriptor.Trait; s.SpellDescriptor = SpellDescriptor.Fear | SpellDescriptor.Shaken; }),
                                                    Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("300e212868bca984687c92bcb66d381b"))//cayden cailean
                                                    );
            liars_tongue = Helpers.CreateFeature("LiarsTongueTrait",
                                                 "Liar's Tongue",
                                                 "Thanks to your friendly mien and sly tongue, your lies are often believed.\n"
                                                 + "Benefits: You gain a +1 trait bonus on Bluff checks, and Persuasion is always considered a class skill for you for purpose of Bluff checks.",
                                                 "",
                                                 Helpers.GetIcon("231a37321e26551489503e4e1d99e681"), // deceitful
                                                 FeatureGroup.Trait,
                                                 Helpers.CreateAddStatBonus(StatType.CheckBluff, 1, ModifierDescriptor.Trait),
                                                 Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckBluff; }),
                                                 Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("a3a5ccc9c670e6f4ca4a686d23b89900"))//asmodeus
                                                 );

            regal_presence = Helpers.CreateFeature("RegalPresenceTrait",
                                                 "Regal Presence",
                                                 "You’ve always had a presence that people respect.\n"
                                                 + "Benefits: You gain a +1 trait bonus on Diplomacy checks, and Persuasion is always considered a class skill for you for purpose of Diplomacy checks.",
                                                 "",
                                                 Helpers.GetIcon("231a37321e26551489503e4e1d99e681"), // deceitful
                                                 FeatureGroup.Trait,
                                                 Helpers.CreateAddStatBonus(StatType.CheckDiplomacy, 1, ModifierDescriptor.Trait),
                                                 Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckDiplomacy; }),
                                                 Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("88d5da04361b16746bf5b65795e0c38c"))//iomedae
                                                 );

            stoic_optimism = Helpers.CreateFeature("StoicOptimismTrait",
                                        "Stoic Optimism",
                                        "You realize that accepting the pain in life accentuates its joys by contrast, and so your hope sustains you where others despair.\n"
                                        + "Benefit: you gain a +2 trait bonus on all saves against fear.",
                                        "",
                                        Helpers.GetIcon("dd38f33c56ad00a4da386c1afaa49967"), // blessing of courage
                                        FeatureGroup.Trait,
                                        Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.Bonus = 2; s.ModifierDescriptor = ModifierDescriptor.Trait; s.SpellDescriptor = SpellDescriptor.Fear | SpellDescriptor.Shaken; }),
                                        Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("2c0a3b9971327ba4d9d85354d16998c1"))//desna
                                        );

            strong_willed = Helpers.CreateFeature("StrongWilledTrait",
                                                 "Strong Willed",
                                                 "Your fervent desire to choose your own path gives you strong willpower.\nBenefit: You receive a +2 trait bonus on saving throws against charm and compulsion effects.",
                                                 "",
                                                 Helpers.GetIcon("175d1577bb6c9a04baf88eec99c66334"), // Iron will
                                                 FeatureGroup.Trait,
                                                 Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.ModifierDescriptor = ModifierDescriptor.Trait; s.Bonus = 2; s.SpellDescriptor = SpellDescriptor.Compulsion | SpellDescriptor.Charm; }),
                                                 Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("300e212868bca984687c92bcb66d381b"))//cayden cailean
                                                 );

            unswaying_love = Helpers.CreateFeature("UnswayingLoveTrait",
                                                 "Unswaying Love",
                                                 "Your resolute devotion to the unadulterated purity of your goddess protects you from those who would manipulate you. \nBenefit: You receive a +2 trait bonus on saving throws against charm and compulsion effects.",
                                                 "",
                                                 Helpers.GetIcon("175d1577bb6c9a04baf88eec99c66334"), // Iron will
                                                 FeatureGroup.Trait,
                                                 Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.ModifierDescriptor = ModifierDescriptor.Trait; s.Bonus = 2; s.SpellDescriptor = SpellDescriptor.Compulsion | SpellDescriptor.Charm; }),
                                                 Helpers.PrerequisiteFeature(library.Get<BlueprintFeature>("b382afa31e4287644b77a8b30ed4aa0b"))//shelyn
                                                 );


            mothers_teeth = Helpers.CreateFeature("MothersTeethTrait",
                                                 "Mother's Teeth",
                                                 "Your teeth are more jagged and pointed than normal.\n"
                                                 +"Benefit: You can make a bite attack for 1d3 points of damage as a secondary attack.",
                                                 "",
                                                 CallOfTheWild.NewSpells.savage_maw.Icon, 
                                                 FeatureGroup.Trait,
                                                 Common.createAddSecondaryAttacks(library.Get<BlueprintItemWeapon>("35dfad6517f401145af54111be04d6cf")),
                                                 Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.goblin),
                                                 Helpers.PrerequisiteFeature(CallOfTheWild.Deities.lamashtu)
                                                 );

            mothers_rage = Helpers.CreateFeature("MothersRageTrait",
                                                 "Mother's Teeth",
                                                 "The blood of the beast runs thick in your veins, and your appearance is bestial.\n"
                                                 + "Benefit: You receive a +1 trait bonus on Lore (Nature), and you treat your caster level as +1 higher when summoning creatures.",
                                                 "",
                                                 Helpers.GetIcon("38155ca9e4055bb48a89240a2055dcc3"),
                                                 FeatureGroup.Trait,
                                                 Helpers.CreateAddStatBonus(StatType.SkillLoreNature, 1, ModifierDescriptor.Trait),
                                                 Helpers.Create<IncreaseSpellDescriptorCasterLevel>(i => { i.Descriptor = SpellDescriptor.Summoning; i.BonusCasterLevel = 1; }),
                                                 Helpers.PrerequisiteFeature(CallOfTheWild.Deities.lamashtu)
                                                 );

            religion_traits = createTraitSelction("ReligionTrait",
                                                "Religion Trait",
                                                "Religion traits indicate that your character has an established faith in a specific deity; you need not be a member of a class that can wield divine magic to pick a religion trait, but you do have to have a patron deity and have some amount of religion in your background to justify this trait.",
                                                shield_trained,
                                                wisdom_in_flesh,
                                                opportunistic,
                                                erastils_speaker,
                                                child_of_nature,
                                                purity_of_faith,
                                                underlying_principles,
                                                secret_knowledge,
                                                spirit_guide,
                                                illuminator,
                                                defensive_strategist,
                                                bestial_wrath,
                                                corpse_hunter,
                                                demoralizing_presence,
                                                eyes_and_ears_of_the_city,
                                                good_natured,
                                                liars_tongue,
                                                regal_presence,
                                                stoic_optimism,
                                                strong_willed,
                                                unswaying_love,
                                                mothers_teeth,
                                                mothers_rage
                                                );

            var deadeye_bowman = library.TryGet<BlueprintFeature>("98656c735106478c9944316c2b62fa54");
            if (deadeye_bowman != null)
            {
                religion_traits.AllFeatures = religion_traits.AllFeatures.AddToArray(deadeye_bowman);
            }
        }


        static void createMagicalTraits()
        {
            classically_schooled = Helpers.CreateFeature("ClassicallySchooledTrait",
                                         "Classically Schooled",
                                         "Your apprenticeship or early education was particularly focused on the direct application of magic.\n"
                                         + "Benefits: You gain a +1 trait bonus on Knowledge (Arcana) checks, and Knowledge (Arcana) is always a class skill for you.",
                                         "",
                                         Helpers.GetIcon("cad1b9175e8c0e64583432a22134d33c"), // sf arcana
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.SkillKnowledgeArcana, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillKnowledgeArcana)
                                         );

            dangerously_curious = Helpers.CreateFeature("DangerouslyCuriousTrait",
                                                         "Dangerously Curious",
                                                         "You have always been intrigued by magic, possibly because you were the child of a magician or priest. You often snuck into your parent’s laboratory or shrine to tinker with spell components and magic devices, and frequently caused quite a bit of damage and headaches for your parent as a result.\n"
                                                         + "Benefits: You gain a +1 bonus on Use Magic Device checks, and Use Magic Device is always a class skill for you.",
                                                         "",
                                                         Helpers.GetIcon("f43ffc8e3f8ad8a43be2d44ad6e27914"), // sf umd
                                                         FeatureGroup.Trait,
                                                         Helpers.CreateAddStatBonus(StatType.SkillUseMagicDevice, 1, ModifierDescriptor.Trait),
                                                         Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillUseMagicDevice)
                                                         );

            focused_mind = Helpers.CreateFeature("FocusedMindTrait",
                                             "Focused Mind",
                                             "Your childhood was dominated either by lessons of some sort (whether musical, academic, or other) or by a horrible home life that encouraged your ability to block out distractions and focus on the immediate task at hand.\n"
                                             + "Benefit: You gain a +2 trait bonus on concentration checks.",
                                             "",
                                             Helpers.GetIcon("06964d468fde1dc4aa71a92ea04d930d"), // sf umd
                                             FeatureGroup.Trait,
                                             Helpers.Create<ConcentrationBonus>(c => c.Value = 2)
                                             );

            gifted_adept = library.CopyAndAdd<BlueprintParametrizedFeature>("e69a85f633ae8ca4398abeb6fa11b1fe", "GiftedAdeptParametrizedTrait", "");
            gifted_adept.Groups = new FeatureGroup[] { FeatureGroup.Trait };
            gifted_adept.SetNameDescription("Gifted Adept",
                                            "Your interest in magic was inspired by witnessing a spell being cast in a particularly dramatic method, perhaps even one that affected you physically or spiritually. This early exposure to magic has made it easier for you to work similar magic on your own.\n"
                                            + "Benefit: Pick one spell when you choose this trait—from this point on, whenever you cast that spell, its effects manifest at +1 caster level.");
            gifted_adept.ComponentsArray = new BlueprintComponent[] { Helpers.Create<SpellDuplicates.ClBonusParametrized>(c => c.bonus = 1),
                                                                      Helpers.Create<CallOfTheWild.NewMechanics.ParametrizedFeatureSelection.MaxLearneableSpellLevelLimiter>(m => m.max_lvl = 3) };
            gifted_adept.Prerequisite = null;
            gifted_adept.ParameterType = (FeatureParameterType)CallOfTheWild.NewMechanics.ParametrizedFeatureSelection.FeatureParameterTypeExtender.AllLearnableSpells;
            gifted_adept.AddComponent(Helpers.Create<NewMechanics.PrerequisiteSpellbook>());

            magical_lineage = library.CopyAndAdd<BlueprintParametrizedFeature>("e69a85f633ae8ca4398abeb6fa11b1fe", "MagicalLineageParametrizedTrait", "");
            magical_lineage.Groups = new FeatureGroup[] { FeatureGroup.Trait };
            magical_lineage.SetNameDescription("Magical Lineage",
                                            "One of your parents was a gifted spellcaster who not only used metamagic often, but also developed many magical items and perhaps even a new spell or two—and you have inherited a fragment of this greatness.\n"
                                            + "Benefit: Pick one spell when you choose this trait. When you apply metamagic feats to this spell that add at least 1 level to the spell, treat its actual level as 1 lower for determining the spell’s final adjusted level.");
            magical_lineage.Prerequisite = null;

            magical_lineage.ComponentsArray = new BlueprintComponent[] { Helpers.Create<CallOfTheWild.NewMechanics.MetamagicMechanics.ReduceMetamagicCostForSpellParametrized>(r => r.reduction = 1),
                                                                      Helpers.Create<CallOfTheWild.NewMechanics.ParametrizedFeatureSelection.MaxLearneableSpellLevelLimiter>(m => m.max_lvl = 3) };
            magical_lineage.ParameterType = (FeatureParameterType)CallOfTheWild.NewMechanics.ParametrizedFeatureSelection.FeatureParameterTypeExtender.AllLearnableSpells;
            magical_lineage.AddComponent(Helpers.Create<NewMechanics.PrerequisiteSpellbook>());

            transmuter_of_korada = Helpers.CreateFeature("TransmuterOfKoradaTrait",
                                                         "Transmuter of Korada",
                                                         "You learned the secrets of transmutation from a follower of the empyreal lord Korada.\n"
                                                         + "Whenever you cast a spell from the transmutation school, its effects manifest at +1 caster level. Additionally, once per day you can double the duration of one of the following spells: bear’s endurance, bull’s strength, cat’s grace, eagle’s splendor, fox’s cunning, or owl’s wisdom. A spell affected by this trait cannot be modified further by the Extend Spell metamagic feat or similar abilities.",
                                                         "",
                                                         Helpers.GetIcon("b6a604dab356ac34788abf4ad79449ec"), // transmutation
                                                         FeatureGroup.Trait,
                                                         Helpers.Create<IncreaseSpellSchoolCasterLevel>(i => { i.BonusLevel = 1; i.School = SpellSchool.Transmutation; })
                                                         );
            var transmuter_of_korada_resource = Helpers.CreateAbilityResource("TransmuterOfKoradaResource", "", "", "", null);
            transmuter_of_korada_resource.SetFixedResource(1);

            var transmuter_of_korada_buff = Helpers.CreateBuff("TransmuterOfKoradaBuff",
                                                               transmuter_of_korada.Name,
                                                               transmuter_of_korada.Description,
                                                               "",
                                                               transmuter_of_korada.Icon,
                                                               null,
                                                               Helpers.Create<CallOfTheWild.NewMechanics.MetamagicMechanics.MetamagicOnSpellList>(m =>
                                                               {
                                                                   m.resource = transmuter_of_korada_resource;
                                                                   m.amount = 1;
                                                                   m.Metamagic = Metamagic.Extend;
                                                                   m.spell_list = new BlueprintAbility[]
                                                                   {
                                                                       library.Get<BlueprintAbility>("4c3d08935262b6544ae97599b3a9556d"), //bulls strength
                                                                       library.Get<BlueprintAbility>("de7a025d48ad5da4991e7d3c682cf69d"), //cats grace
                                                                       library.Get<BlueprintAbility>("a900628aea19aa74aad0ece0e65d091a"), //bears endurance
                                                                       library.Get<BlueprintAbility>("ae4d3ad6a8fda1542acf2e9bbc13d113"), //foxs cunning
                                                                       library.Get<BlueprintAbility>("f0455c9295b53904f9e02fc571dd2ce1"), //owls wisdom
                                                                       library.Get<BlueprintAbility>("446f7bf201dc1934f96ac0a26e324803"), //eagles spledor
                                                                   };
                                                               })
                                                               );
            var transmuter_of_korada_toggle = Helpers.CreateActivatableAbility("TransmuterOfKoradaActivatableAbility",
                                                                               transmuter_of_korada.Name,
                                                                               transmuter_of_korada.Description,
                                                                               "",
                                                                               transmuter_of_korada.Icon,
                                                                               transmuter_of_korada_buff,
                                                                               AbilityActivationType.Immediately,
                                                                               Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Free,
                                                                               null,
                                                                               transmuter_of_korada_resource.CreateActivatableResourceLogic(ActivatableAbilityResourceLogic.ResourceSpendType.Never)
                                                                               );
            transmuter_of_korada_toggle.DeactivateImmediately = true;
            transmuter_of_korada.AddComponents(transmuter_of_korada_resource.CreateAddAbilityResource(),
                                              Helpers.CreateAddFact(transmuter_of_korada_toggle)
                                              );

            pragmatic_activator = Helpers.CreateFeature("PragmaticActivatorTrait",
                                             "Pragmatic Activator",
                                             "While some figure out how to use magical devices with stubborn resolve, your approach is more pragmatic.\n"
                                             + "Benefit: You may use your Intelligence modifier when making Use Magic Device checks instead of your Charisma modifier.",
                                             "",
                                             Helpers.GetIcon("f43ffc8e3f8ad8a43be2d44ad6e27914"), // sf umd
                                             FeatureGroup.Trait,
                                             Helpers.Create<CallOfTheWild.StatReplacementMechanics.ReplaceBaseStatForStatTypeLogic>(s =>
                                             {
                                                 s.StatTypeToReplaceBastStatFor = StatType.SkillUseMagicDevice;
                                                 s.NewBaseStatType = StatType.Intelligence;
                                             }),
                                             Helpers.Create<RecalculateOnStatChange>(r => r.Stat = StatType.Charisma),
                                             Helpers.Create<RecalculateOnStatChange>(r => r.Stat = StatType.Intelligence)
                                             );
            strength_of_the_land = Helpers.CreateFeature("StrengthOfTheLandTrait",
                                                         "Strength of the Land",
                                                         "You are able to tap into the living energy of the world to shatter lesser magic.\n"
                                                         + "Benefit: You gain a +1 trait bonus on caster level checks while touching the ground or unworked stone. This includes dispel checks and checks to overcome spell resistance.",
                                                         "",
                                                         Helpers.GetIcon("ee7dc126939e4d9438357fbd5980d459"), // spell penetration
                                                         FeatureGroup.Trait,
                                                         Helpers.Create<SpellPenetrationBonus>(s => s.Value = 1),
                                                         Helpers.Create<DispelCasterLevelCheckBonus>(d => d.Value = 1),
                                                         Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.dwarf)//dwarf
                                                         );

            trickster = Helpers.CreateFeature("TricksterTrait",
                                             "Trickster",
                                             "You are particularly adept with your racial spell-like abilities, and as child you quickly learned how dancing lights and ghost sound could be used to amuse your friends and fool your elders. This natural talent for illusion continued as you grew older, and before long you were being offered training in more advanced figments and glamers.\n"
                                             + "Benefit: Whenever you cast a spell from the illusion school, its effects manifest at +1 caster level. ",
                                             "",
                                             Helpers.GetIcon("24d5402c0c1de48468b563f6174c6256"), 
                                             FeatureGroup.Trait,
                                             Helpers.Create<IncreaseSpellSchoolCasterLevel>(i => { i.BonusLevel = 1; i.School = SpellSchool.Illusion; }),
                                             Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.gnome)//gnome
                                             );

            magical_knack = Helpers.CreateFeatureSelection("MagicalKnackraitSelection",
                                                         "Magical Knack",
                                                         "You were raised, either wholly or in part, by a magical creature, either after it found you abandoned in the woods or because your parents often left you in the care of a magical minion. This constant exposure to magic has made its mysteries easy for you to understand, even when you turn your mind to other devotions and tasks.\n"
                                                         + "Benefit: Pick a class when you gain this trait—your caster level in that class gains a +2 trait bonus as long as this bonus doesn’t raise your caster level above your current Hit Dice.",
                                                         "",
                                                         Helpers.GetIcon("55edf82380a1c8540af6c6037d34f322"), //elven magic
                                                         FeatureGroup.Trait
                                                         );
            magical_knack.HideInCharacterSheetAndLevelUp = true;
            var classes = library.Root.Progression.CharacterClasses.Where(c => !c.HideIfRestricted && !c.PrestigeClass && c.Spellbook != null).ToList();
            foreach (var cls in classes)
            {
                var f = Helpers.CreateFeature(cls.name + magical_knack.name,
                                              magical_knack.Name + ": " + cls.Name,
                                              magical_knack.Description,
                                              "",
                                              magical_knack.Icon,
                                              FeatureGroup.Trait,
                                              Helpers.Create<CallOfTheWild.SpellbookMechanics.CasterLevelBonusBounded>(c =>
                                                                                                                       {
                                                                                                                           c.character_class = cls;
                                                                                                                           c.value = 2;
                                                                                                                           c.bound = Helpers.CreateContextValue(AbilityRankType.Default);
                                                                                                                       }),
                                              Helpers.CreateContextRankConfig(ContextRankBaseValueType.CharacterLevel)
                                              );
                magical_knack.AllFeatures = magical_knack.AllFeatures.AddToArray(f);
            }

            aeromantic_affinity = Helpers.CreateFeature("AeromanticAffinityTrait",
                                                         "Aeromantic Affinity",
                                                         "One of your distant ancestors was either a powerful aeromancer or a creature of elemental air, granting you greater skill with air magic.\n"
                                                         + "Benefit: You treat your caster level as 1 higher when casting spells with the air or electricity descriptor.",
                                                         "",
                                                         Helpers.GetIcon("9fbc4fe045472984aa4a2d15d88bdaf9"), //cyclone
                                                         FeatureGroup.Trait,
                                                         Helpers.Create<IncreaseSpellDescriptorCasterLevel>(i => { i.BonusCasterLevel = 1; i.Descriptor = SpellDescriptor.Electricity | (SpellDescriptor)CallOfTheWild.AdditionalSpellDescriptors.ExtraSpellDescriptor.Air; })
                                                         );

            magic_traits = createTraitSelction("MagicTrait",
                                                "Magic Trait",
                                                "Magic traits are associated with magic, and focus on spellcasting and manipulating magic. You need not be a spellcaster to take a Magic Trait (although several of these traits aren’t as useful to non-spellcasters). Magic Traits can represent a character’s early exposure to magical effects or childhood studies of magic.",
                                                classically_schooled,
                                                dangerously_curious,
                                                focused_mind,
                                                gifted_adept,
                                                magical_knack,
                                                magical_lineage,
                                                pragmatic_activator,
                                                transmuter_of_korada,
                                                strength_of_the_land,
                                                trickster,
                                                aeromantic_affinity
                                                );
        }


        static void createSocialTraits()
        {
            bully = Helpers.CreateFeature("BullyTrait",
                                 "Bully",
                                 "You grew up in an environment where the meek were ignored and you often had to resort to threats or violence to be heard.\n"
                                 + "Benefits: You gain a +1 trait bonus on intimidate checks, and Persuasion is always considered a class skill for you for purpose of intimidate checks.",
                                 "",
                                 Helpers.GetIcon("d76497bfc48516e45a0831628f767a0f"), // intimidating prowess
                                 FeatureGroup.Trait,
                                 Helpers.CreateAddStatBonus(StatType.CheckIntimidate, 1, ModifierDescriptor.Trait),
                                 Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckIntimidate; })
                                 );


            fast_talker = Helpers.CreateFeature("FastTalkerTrait",
                                                 "Fast Talker",
                                                 "You had a knack for getting yourself into trouble as a child, and as a result developed a silver tongue at an early age.\n"
                                                 + "Benefits: You gain a +1 trait bonus on bluff checks, and Persuasion is always considered a class skill for you for purpose of bluff checks.",
                                                 "",
                                                 Helpers.GetIcon("231a37321e26551489503e4e1d99e681"), // deceitful
                                                 FeatureGroup.Trait,
                                                 Helpers.CreateAddStatBonus(StatType.CheckBluff, 1, ModifierDescriptor.Trait),
                                                 Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckBluff; })
                                                 );

            var bard = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
            var perfromance_resource = library.Get<BlueprintAbilityResource>("e190ba276831b5c4fa28737e5e49e6a6");
            maestro_of_the_society = Helpers.CreateFeature("MaestroOfTheSocietyTrait",
                                                           "Maestro of the Society",
                                                           "The skills of the greatest musicians are at your fingertips, thanks to the vast treasure trove of musical knowledge in the vaults you have access to.\nBenefit: You may use bardic performance 3 additional rounds per day.",
                                                           "",
                                                           Helpers.GetIcon("0d3651b2cb0d89448b112e23214e744e"),
                                                           FeatureGroup.Trait,
                                                           Helpers.Create<IncreaseResourceAmount>(i => { i.Resource = perfromance_resource; i.Value = 3; }),
                                                           Helpers.PrerequisiteClassLevel(bard, 1)
                                                           );

            poverty_stricken = Helpers.CreateFeature("PovertyStrickenTrait",
                                                     "Poverty Stricken",
                                                     "Your childhood was tough, and your parents always had to make every copper piece count. Hunger was your constant companion, and you often had to live off the land or sleep in the wild.\n"
                                                     + "Benefits: You gain a +1 bonus on Lore (Nature) checks, and Lore (Nature) is always a class skill for you.",
                                                     "",
                                                     Helpers.GetIcon("6507d2da389ed55448e0e1e5b871c013"), // sf nature
                                                     FeatureGroup.Trait,
                                                     Helpers.CreateAddStatBonus(StatType.SkillLoreNature, 1, ModifierDescriptor.Trait),
                                                     Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillLoreNature)
                                                     );

            student_of_philosophy = Helpers.CreateFeature("StudentOfPhilosophyTrait",
                                                         "Student of Philosophy",
                                                         "You were trained in a now-defunct philosophical tradition—such as that of the now-destroyed magic universities or astrologers—and learned to use logic and reason to persuade others.\n"
                                                         + "Benefit: You can use your Intelligence modifier in place of your Charisma modifier on Diplomacy checks.",
                                                         "",
                                                         Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // sf diplomacy
                                                         FeatureGroup.Trait,
                                                         Helpers.Create<CallOfTheWild.SkillMechanics.DependentAbilityScoreCheckStatReplacement>(s =>
                                                         {
                                                             s.stat = StatType.CheckDiplomacy;
                                                             s.old_stat = StatType.Charisma;
                                                             s.new_stat = StatType.Intelligence;
                                                         })
                                                         );

            bruising_intellect = Helpers.CreateFeature("BruisingIntellectTrait",
                                                         "Bruising Intellect",
                                                         "Your sharp intellect and rapier-like wit bruise egos.\n"
                                                         + "Benefit: Persuasion is considered a class skill for you for the purpose of Intimidate checks, and you may use your Intelligence modifier when making Intimidate checks instead of your Charisma modifier. ",
                                                         "",
                                                         Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // sf diplomacy
                                                         FeatureGroup.Trait,
                                                         Helpers.Create<CallOfTheWild.SkillMechanics.DependentAbilityScoreCheckStatReplacement>(s =>
                                                         {
                                                             s.stat = StatType.CheckIntimidate;
                                                             s.old_stat = StatType.Charisma;
                                                             s.new_stat = StatType.Intelligence;
                                                         }),
                                                         Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckBluff; })
                                                         );

            clever_wordplay = Helpers.CreateFeature("CleverWordpalyTrait",
                                             "Clever Wordplay",
                                             "Your cunning and logic are more than a match for another’s confidence and poise.\n"
                                             + "Benefit: You may use your Intelligence modifier when making Bluff checks instead of your Charisma modifier. ",
                                             "",
                                             Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // sf diplomacy
                                             FeatureGroup.Trait,
                                             Helpers.Create<CallOfTheWild.SkillMechanics.DependentAbilityScoreCheckStatReplacement>(s =>
                                             {
                                                 s.stat = StatType.CheckBluff;
                                                 s.old_stat = StatType.Charisma;
                                                 s.new_stat = StatType.Intelligence;
                                             })
                                             );


            child_of_streets = Helpers.CreateFeature("ChildOfStreetsTrait",
                                         "Child of Streets",
                                         "You grew up on the streets of a large city, and as a result you have developed a knack for picking pockets and hiding small objects on your person.\n"
                                         + "Benefits: You gain a +1 trait bonus on Trickery checks, and Trickery is always a class skill for you.",
                                         "",
                                         Helpers.GetIcon("7feda1b98f0c169418aa9af78a85953b"), // sf nature
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.SkillThievery, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillThievery)
                                         );

            seeker = Helpers.CreateFeature("SeekerTrait",
                                         "Seeker",
                                         "You are always on the lookout for reward and danger.\n"
                                         + "Benefits: You gain a +1 trait bonus on Perception checks, and Perception is always a class skill for you.",
                                         "",
                                         Helpers.GetIcon("f74c6bdf5c5f5374fb9302ecdc1f7d64"), // sf perception
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.SkillPerception, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillPerception)
                                         );

            social_traits = createTraitSelction("SocialTrait",
                                                "Social Trait",
                                                "Social Traits are a sort of catch-all category—these traits reflect the social upbringing of your character, your background with high society or lack thereof, and your history with parents, siblings, friends, competitors, and enemies.",
                                                bully,
                                                fast_talker,
                                                maestro_of_the_society,
                                                poverty_stricken,
                                                student_of_philosophy,
                                                bruising_intellect,
                                                clever_wordplay,
                                                child_of_streets,
                                                seeker
                                                );
        }


        static void createFaithTraits()
        {
            birthmark = Helpers.CreateFeature("BirthmarkTrait", 
                                              "Birthmark",
                                              "You were born with a strange birthmark that looks very similar to the holy symbol of the god you chose to worship later in life.\nBenefits: This birthmark increases your devotion to your god. You gain a +2 trait bonus on all saving throws against charm and compulsion effects.",
                                              "",
                                              Helpers.GetIcon("2483a523984f44944a7cf157b21bf79c"), // Elven Immunities
                                              FeatureGroup.Trait,
                                              Helpers.Create<SavingThrowBonusAgainstSchool>(a =>
                                                {
                                                    a.School = SpellSchool.Enchantment;
                                                    a.Value = 2;
                                                    a.ModifierDescriptor = ModifierDescriptor.Trait;
                                                }));

            caretaker = Helpers.CreateFeature("CaretakerTrait",
                                             "Caretaker",
                                             "Your faith in the natural world or one of the gods of nature makes it easy for you to pick up on related concepts.\n"
                                             + "Benefits: You gain a +1 trait bonus on Lore (Nature) checks, and Lore (Nature) is always a class skill for you.",
                                             "",
                                             Helpers.GetIcon("6507d2da389ed55448e0e1e5b871c013"), // lore nature
                                             FeatureGroup.Trait,
                                             Helpers.CreateAddStatBonus(StatType.SkillLoreNature, 1, ModifierDescriptor.Trait),
                                             Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillLoreNature)
                                             );


            devotee_of_the_green = Helpers.CreateFeature("DevoteeOfTheGreenTrait",
                                                         "Devotee of the Green",
                                                         "As the child of an herbalist or an assistant in a temple infirmary, you often had to assist in tending to the sick and wounded.\nBenefits: You gain a +1 trait bonus on Lore (Religion) checks, and Lore (Religion) is always a class skill for you.",
                                                         "",
                                                         Helpers.GetIcon("f6f95242abdfac346befd6f4f6222140"), // remove sickness
                                                         FeatureGroup.Trait,
                                                         Helpers.CreateAddStatBonus(StatType.SkillLoreReligion, 1, ModifierDescriptor.Trait),
                                                         Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillLoreReligion)
                                                         );


            ease_of_faith = Helpers.CreateFeature("EaseOfFaithTrait",
                                             "Ease of Faith",
                                             "Your mentor, the person who invested your faith in you from an early age, took steps to ensure you understood that what powers your divine magic is no different from that which powers the magic of other religions. This philosophy makes it easier for you to interact with others who may not share your views.\n"
                                             + "Benefits: You gain a +1 bonus on Diplomacy checks, and consider Persuasion skill as class skill for the purpose of diplomacy checks.",
                                             "",
                                             Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // skill focus diplomacy
                                             FeatureGroup.Trait,
                                             Helpers.CreateAddStatBonus(StatType.CheckDiplomacy, 1, ModifierDescriptor.Trait),
                                             Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckDiplomacy; })
                                             );

            var channel_resource = library.Get<BlueprintAbilityResource>("5e2bba3e07c37be42909a12945c27de7");

            var cleric = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            exalted_of_the_society = Helpers.CreateFeature("ExaltedOfTheSocietyTrait", 
                                                            "Exalted of the Society",
                                                            "The vaults of the great city contain many secrets of the divine powers of the gods, and you have studied your god extensively.\nBenefit: You may channel energy 1 additional time per day.",
                                                            "",
                                                            Helpers.GetIcon("cd9f19775bd9d3343a31a065e93f0c47"), // Extra Channel
                                                            FeatureGroup.Trait,
                                                            channel_resource.CreateIncreaseResourceAmount(1),
                                                            Helpers.PrerequisiteClassLevel(cleric, 1)
                                                            );

            indomitable_faith = Helpers.CreateFeature("IndomitableFaithTrait",
                                                      "Indomitable Faith",
                                                      "You were born in a region where your faith was not popular, but you still have never abandoned it. Your constant struggle to maintain your own faith has bolstered your drive.\nBenefit: You gain a +1 trait bonus on Will saves.",
                                                      "",
                                                      Helpers.GetIcon("175d1577bb6c9a04baf88eec99c66334"), // Iron Will
                                                      FeatureGroup.Trait,
                                                      Helpers.CreateAddStatBonus(StatType.SaveWill, 1, ModifierDescriptor.Trait)
                                                      );

            sacred_conduit = ChannelEnergyEngine.sacred_conduit;


            scholar_of_the_greate_beyond = Helpers.CreateFeature("ScholarOfTheGreatBeyondTrait",
                                                                 "Scholar of the Great Beyond",
                                                                 "Your greatest interests as a child did not lie with current events or the mundane—you have always felt out of place, as if you were born in the wrong era. You take to philosophical discussions of the Great Beyond and of historical events with ease.\n"
                                                                 + "You gain a +1 trait bonus on Knowledge (World) checks, and Knowledge (World) is always a class skill for you.",
                                                                 "",
                                                                 Helpers.GetIcon("611e863120c0f9a4cab2d099f1eb20b4"), // sf world
                                                                 FeatureGroup.Trait,
                                                                 Helpers.CreateAddStatBonus(StatType.SkillKnowledgeWorld, 1, ModifierDescriptor.Trait),
                                                                 Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillKnowledgeWorld)
                                                                 );




            omen = Helpers.CreateFeature("OmenTrait",
                                 "Omen",
                                 "You are the harbinger of some future event. Whether this event bodes good or ill, you exude an ominous presence.\n"
                                 + "Benefits: You gain a +1 trait bonus on Intimidate checks, and Persuasion is always a class skill for you for the purpose of intimidate checks. Once per day, you may attempt to demoralize an opponent as a swift action.",
                                 "",
                                 Helpers.GetIcon("d2aeac47450c76347aebbc02e4f463e0"), // fear
                                 FeatureGroup.Trait,
                                 Helpers.CreateAddStatBonus(StatType.CheckIntimidate, 1, ModifierDescriptor.Trait),
                                 Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckIntimidate; })
                                 );

            var omen_demoralize = library.CopyAndAdd<BlueprintAbility>("7d2233c3b7a0b984ba058a83b736e6ac", "OmenDemoralizeAbility", "");
            omen_demoralize.SetNameDescriptionIcon("Omen (Swift Action Demoralize)", omen.Description, omen.Icon);
            omen_demoralize.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift;
            var omen_resource = Helpers.CreateAbilityResource("OmenTraitResource", "", "", "", null);
            omen_resource.SetFixedResource(1);
            omen_demoralize.AddComponent(omen_resource.CreateResourceLogic());
            omen.AddComponents(omen_resource.CreateAddAbilityResource(),
                               Helpers.CreateAddFact(omen_demoralize));

            fates_favored =  Helpers.CreateFeature("FatesFavoredTrait",
                                                  "Fate's Favored",
                                                  "The fates watch over you.\n"
                                                  + "Benefit: Whenever you are under the effect of a luck bonus of any kind, that bonus increases by 1.",
                                                  "",
                                                  Helpers.GetIcon("9a7e3cd1323dfe347a6dcce357844769"), // blessing luck & resolve
                                                  FeatureGroup.Trait,
                                                  Helpers.Create<CallOfTheWild.SpellManipulationMechanics.TargetDescriptorModifierBonus>(t => { t.descriptor = ModifierDescriptor.Luck; t.bonus = 1;})
                                                  );
            AlternativeRacialTraits.sacred_tattoo.AddComponent(Helpers.Create<RecalculateOnFactsChange>(r => r.CheckedFacts = new BlueprintUnitFact[] { fates_favored }));
            reincarnated = Helpers.CreateFeature("ReincarnatedTrait",
                                        "Reincarnated",
                                        "You lived a previous life as someone—or something— else. For you, life and death are a cycle, and you have no fear of death.\n"
                                        + "Benefit: You gain a +2 trait bonus on saving throws against fear and death effects.",
                                        "",
                                        Helpers.GetIcon("0413915f355a38146bc6ad40cdf27b3f"), // death ward
                                        FeatureGroup.Trait,
                                        Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.Bonus = 2; s.ModifierDescriptor = ModifierDescriptor.Trait; s.SpellDescriptor = SpellDescriptor.Fear | SpellDescriptor.Shaken | SpellDescriptor.Death; })
                                        );

            faith_traits = createTraitSelction("FaithTrait",
                                    "Faith Trait",
                                    "Faith traits rely upon conviction of spirit, perception, and religion, but are not directly tied to the worship of a specific deity. You do not need a patron deity to gain a Faith Trait, as these traits can represent conviction in one’s self or philosophy just as easily as they can represent dedication to a deity.",
                                    birthmark,
                                    caretaker,
                                    devotee_of_the_green,
                                    ease_of_faith,
                                    exalted_of_the_society,
                                    indomitable_faith,
                                    sacred_conduit,
                                    scholar_of_the_greate_beyond,
                                    fates_favored,
                                    omen,
                                    reincarnated
                                    );
        }


        static void createCombatTratits()
        {
            anatomist = Helpers.CreateFeature("AnatomistTrait",
                                              "Anatomist",
                                              "You have studied the workings of anatomy, either as a student at university or as an apprentice mortician or necromancer. You know where to aim your blows to strike vital organs.\nBenefit: You gain a +1 trait bonus on all rolls made to confirm critical hits.",
                                              "",
                                              Helpers.GetIcon("f4201c85a991369408740c6888362e20"), // Improved Critical
                                              FeatureGroup.Trait,
                                              Helpers.Create<CriticalConfirmationBonus>(a => { a.Bonus = 1; a.Value = 0; })
                                              );

            armor_expert = Helpers.CreateFeature("ArmorExpertTrait",
                                                 "Armor Expert",
                                                "You have worn armor as long as you can remember, either as part of your training to become a knight’s squire or simply because you were seeking to emulate a hero. Your childhood armor wasn’t the real thing as far as protection, but it did encumber you as much as real armor would have, and you’ve grown used to moving in such suits with relative grace.\nBenefit: When you wear armor of any sort, reduce that suit’s armor check penalty by 1, to a minimum check penalty of 0.",
                                                "",
                                                Helpers.GetIcon("3bc6e1d2b44b5bb4d92e6ba59577cf62"), // Armor Focus (light)
                                                FeatureGroup.Trait,
                                                Helpers.Create<CallOfTheWild.NewMechanics.ArmorCheckPenaltyIncrease>(a => { a.Bonus = 1; a.CheckCategory = true; a.Category = ArmorProficiencyGroup.Light;  }),
                                                Helpers.Create<CallOfTheWild.NewMechanics.ArmorCheckPenaltyIncrease>(a => { a.Bonus = 1; a.CheckCategory = true; a.Category = ArmorProficiencyGroup.Medium; }),
                                                Helpers.Create<CallOfTheWild.NewMechanics.ArmorCheckPenaltyIncrease>(a => { a.Bonus = 1; a.CheckCategory = true; a.Category = ArmorProficiencyGroup.Heavy; })
                                                );

            var rage_resource = library.Get<BlueprintAbilityResource>("24353fcf8096ea54684a72bf58dedbc9");
            berserker_of_the_society = Helpers.CreateFeature("BerserkerOfTheSocietyTrait",
                                                             "Berserker of the Society",
                                                             "Your time spent as a society member has taught you new truths about the origins of the your rage ability.\nBenefit: You may use your rage ability for 3 additional rounds per day.",
                                                             "",
                                                             Helpers.GetIcon("1a54bbbafab728348a015cf9ffcf50a7"), // Extra Rage
                                                             FeatureGroup.Trait,
                                                             rage_resource.CreateIncreaseResourceAmount(3),
                                                             Helpers.PrerequisiteClassLevel(library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853"), 1));

            blade_of_the_society = Helpers.CreateFeature("BladeOfTheSocietyTrait",
                                                         "Blade of the Society",
                                                         "You have studied and learned the weak spots of many humanoids and monsters.\nBenefit: You gain a +1 trait bonus to damage rolls from sneak attacks.",
                                                         "",
                                                         Helpers.GetIcon("9f0187869dc23744292c0e5bb364464e"), // Accomplished Sneak Attacker
                                                         FeatureGroup.Trait,
                                                         Helpers.Create<CallOfTheWild.NewMechanics.SneakAttackDamageBonus>(a => a.value = 1)
                                                         );

            defender_of_the_society = Helpers.CreateFeature("DefenderOfTheSocietyTrait",
                                                            "Defender of the Society",
                                                            "Your time spent fighting and studying the greatest warriors of the society has taught you new defensive skills while wearing armor.\nBenefit: You gain a +1 trait bonus to Armor Class when wearing medium or heavy armor.",
                                                            "",
                                                            Helpers.GetIcon("7dc004879037638489b64d5016997d12"), // Armor Focus Medium
                                                            FeatureGroup.Trait,
                                                            Helpers.Create<CallOfTheWild.NewMechanics.ArmorCategoryAcBonus>(a => { a.category = ArmorProficiencyGroup.Medium; a.descriptor = ModifierDescriptor.Trait; a.value = 1; }),
                                                            Helpers.Create<CallOfTheWild.NewMechanics.ArmorCategoryAcBonus>(a => { a.category = ArmorProficiencyGroup.Heavy; a.descriptor = ModifierDescriptor.Trait; a.value = 1; }),
                                                            Helpers.PrerequisiteClassLevel(library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd"), 1)
                                                            );

            deft_dodger = Helpers.CreateFeature("DeftDodgerTrait",
                                                "Deft Dodger",
                                                "Growing up in a rough neighborhood or a dangerous environment has honed your senses.\nBenefit: You gain a +1 trait bonus on Reflex saves.",
                                                "",
                                                Helpers.GetIcon("15e7da6645a7f3d41bdad7c8c4b9de1e"), // Lightning Reflexes
                                                FeatureGroup.Trait,
                                                Helpers.CreateAddStatBonus(StatType.SaveReflex, 1, ModifierDescriptor.Trait)
                                                );

            dirty_fighter = Helpers.CreateFeature("DirtyFighterTrait",
                                                 "Dirty Fighter",
                                                 "You wouldn’t have lived to make it out of childhood without the aid of a sibling, friend, or companion you could always count on to distract your enemies long enough for you to do a little bit more damage than normal. That companion may be another PC or an NPC (who may even be recently departed from your side).\n" +
                                                 "Benefit: When you hit a foe you are flanking, you deal 1 additional point of damage (this damage is added to your base damage, and is multiplied on a critical hit). This additional damage is a trait bonus.",
                                                 "",
                                                 Helpers.GetIcon("5662d1b793db90c4b9ba68037fd2a768"), // precise strike
                                                 FeatureGroup.Trait,
                                                 Helpers.Create<CallOfTheWild.NewMechanics.DamageBonusAgainstFlankedTarget>(d => d.bonus = 1)
                                                 );

            var dirty_fighter_pf2 = library.TryGet<BlueprintFeature>("b7677db3aa6f457a82c438481c04b659");
            if (dirty_fighter_pf2 != null)
            {
                dirty_fighter.ComponentsArray = dirty_fighter_pf2.ComponentsArray;
            }

            reactionary = Helpers.CreateFeature("ReactionaryTrait",
                                                "Reactionary",
                                                "You were bullied often as a child, but never quite developed an offensive response. Instead, you became adept at anticipating sudden attacks and reacting to danger quickly.\nBenefit: You gain a +2 trait bonus on initiative checks.",
                                                "",
                                                Helpers.GetIcon("797f25d709f559546b29e7bcb181cc74"), // Improved Initiative
                                                FeatureGroup.Trait,
                                                Helpers.CreateAddStatBonus(StatType.Initiative, 2, ModifierDescriptor.Trait)
                                                );

            resilent = Helpers.CreateFeature("ResilientTrait",
                                             "Resilient",
                                             "Growing up in a poor neighborhood or in the unforgiving wilds often forced you to subsist on food and water from doubtful sources. You’ve built up your constitution as a result.\nBenefit: You gain a +1 trait bonus on Fortitude saves.",
                                             "",
                                             Helpers.GetIcon("79042cb55f030614ea29956177977c52"), // Great Fortitude
                                             FeatureGroup.Trait,
                                             Helpers.CreateAddStatBonus(StatType.SaveFortitude, 1, ModifierDescriptor.Trait));

            slippery = Helpers.CreateFeature("SlipperTrait",
                                             "Slippery",
                                             "You have escaped from so many dangerous situations in your life that you’ve gotten quite good at not getting caught.\nBenefit: You gain a +1 trait bonus on Stealth checks and Stealth is a class skill for you.",
                                             "",
                                             Helpers.GetIcon("97a6aa2b64dd21a4fac67658a91067d7"), // fast stealth
                                             FeatureGroup.Trait,
                                             Helpers.CreateAddStatBonus(StatType.SkillStealth, 1, ModifierDescriptor.Trait),
                                             Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillStealth)
                                             );


           dragon_armor = Helpers.CreateFeatureSelection("DragonArmorTraitSelection",
                                                         "Dragon Armor",
                                                         "Xa Hoi’s elite warriors are trained to deflect energy attacks.\nBenefit: Choose an energy type (acid, cold, electricity, fire, or sonic) when you acquire this trait. When you are wearing medium or heavy armor, you gain a +2 trait bonus on Reflex saves against spells and effects of the chosen energy type.",
                                                         "",
                                                         Helpers.GetIcon("d2f116cfe05fcdd4a94e80143b67046f"), // protection from energy
                                                         FeatureGroup.Trait,
                                                         Helpers.CreateAddStatBonus(StatType.SkillStealth, 1, ModifierDescriptor.Trait),
                                                         Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillStealth)
                                                         );
            dragon_armor.HideInCharacterSheetAndLevelUp = true;
            var descriptors = new SpellDescriptor[] { SpellDescriptor.Fire, SpellDescriptor.Acid, SpellDescriptor.Cold, SpellDescriptor.Electricity };
            foreach (var d in descriptors)
            {
                var effect = Helpers.CreateFeature(d.ToString() + "DragonArmorTraitEffect",
                                                     dragon_armor.Name + ": " + d.ToString(),
                                                     dragon_armor.Description,
                                                     "",
                                                     dragon_armor.Icon,
                                                     FeatureGroup.Trait,
                                                     Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.ModifierDescriptor = ModifierDescriptor.Trait; s.Bonus = 2; s.SpellDescriptor = d; })
                                                     );
                effect.HideInCharacterSheetAndLevelUp = true;

                var f = Helpers.CreateFeature(d.ToString() + "DragonArmorTraitFeature",
                                     dragon_armor.Name + ": " + d.ToString(),
                                     dragon_armor.Description,
                                     "",
                                     dragon_armor.Icon,
                                     FeatureGroup.Trait,
                                     Helpers.Create<CallOfTheWild.WeaponTrainingMechanics.AddFeatureOnArmor>(a => 
                                              {
                                                  a.feature = effect;
                                                  a.required_armor = new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Medium, ArmorProficiencyGroup.Heavy };
                                              })
                                     );
                dragon_armor.AllFeatures = dragon_armor.AllFeatures.AddToArray(f);
            }
            fencer = Helpers.CreateFeature("FencerTrait",
                                                   "Fencer",
                                                   "You trained with blades for long hours as a youth, either taking lessons in the genteel art of fencing from tutors paid for by your parents or being taken under the wing of a disenfranchised fencer who may have turned to a life of crime.\n"
                                                   + "Benefits: You gain a +1 trait bonus on attacks of opportunity when using a dagger or a sword.",
                                                   "",
                                                   Helpers.GetIcon("5bb6dc5ce00550441880a6ff8ad4c968"), //opportunist
                                                   FeatureGroup.Trait,
                                                   Helpers.Create<CallOfTheWild.NewMechanics.AttackBonusOnAttacksOfOpportunity>(a =>
                                                   {
                                                       a.categories = new WeaponCategory[] { WeaponCategory.Estoc, WeaponCategory.Rapier, WeaponCategory.Scimitar, WeaponCategory.Shortsword, WeaponCategory.Dagger, WeaponCategory.Kukri, WeaponCategory.PunchingDagger, WeaponCategory.Longsword, WeaponCategory.BastardSword, WeaponCategory.Falchion, WeaponCategory.Greatsword, WeaponCategory.DuelingSword };
                                                       a.Value = 1;
                                                       a.Descriptor = ModifierDescriptor.Trait;
                                                   }
                                                   )
                                                   );

            var ki_resource = library.Get<BlueprintAbilityResource>("9d9c90a9a1f52d04799294bf91c80a82");
            var scaled_fist_ki_resource = library.Get<BlueprintAbilityResource>("7d002c1025fbfe2458f1509bf7a89ce1");
            var monk = library.Get<BlueprintCharacterClass>("e8f21e5b58e0569468e420ebea456124");
            honored_fist_of_society = Helpers.CreateFeature("HonoredFistOfTheSocietyTrait",
                                                            "Honored Fist of the Society",
                                                            "You have studied dozens of ancient texts on martial arts that only the Society possesses, and are more learned in these arts than most.\nBenefit: You increase your ki pool by 1 point.",
                                                            "",
                                                            Helpers.GetIcon("c36562b8e7ae12d408487ba8b532d966"), // pummeling style
                                                            FeatureGroup.Trait,
                                                            ki_resource.CreateIncreaseResourceAmount(1),
                                                            scaled_fist_ki_resource.CreateIncreaseResourceAmount(1),
                                                            Helpers.PrerequisiteClassLevel(monk, 1)
                                                            );

            var combat_expertise_buff = library.Get<BlueprintBuff>("e81cd772a7311554090e413ea28ceea1");
            threatening_defender = Helpers.CreateFeature("ThreateningDefenderTrait",
                                                "Threatening Defender ",
                                                "You know how to avoid a blow while still maintaining your offensive posture.\nBenefit: When you use Combat Expertise, reduce the number you subtract from your melee attack rolls by 1.",
                                                "",
                                                combat_expertise_buff.Icon,
                                                FeatureGroup.Trait
                                                );

            var ce_property = library.Get<BlueprintUnitProperty>("8a63b06d20838954e97eb444f805ec89");
            var comp = ce_property.GetComponent<BaseAttackPropertyWithFeatureList>();
            comp.Features = comp.Features.AddToArray(threatening_defender);

            combat_traits = createTraitSelction("CombatTrait",
                                                "Combat Trait",
                                                "Combat traits are associated with combat, battle, and physical prowess; they give characters minor bonuses in battle and represent conflicts and physical struggles in the character’s backstory.",
                                                 anatomist,
                                                 armor_expert,
                                                 berserker_of_the_society,
                                                 blade_of_the_society,
                                                 defender_of_the_society,
                                                 deft_dodger,
                                                 dirty_fighter,
                                                 reactionary,
                                                 resilent,
                                                 slippery,
                                                 dragon_armor,
                                                 fencer,
                                                 honored_fist_of_society,
                                                 threatening_defender
                                                );
        }


        static void createRacialTraits()
        {
            auspicious_tatoo = Helpers.CreateFeature("AuspiciousTrait",
                                         "Auspicious Tattoo",
                                         "You bear a tattoo depicting one of the totems listed for your quah that favors you with good fortune.\n"
                                         + "Benefit: You gain a +1 trait bonus on Will saving throws.",
                                         "",
                                         Helpers.GetIcon("175d1577bb6c9a04baf88eec99c66334"), // iron will
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.SaveWill, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.human)
                                         );

            big_ears = Helpers.CreateFeature("BigEarsTrait",
                                            "Big Ears",
                                            "Your massive ears are your pride and joy, and other goblins claim you can hear a flea scream as it falls off a goblin dog. While this might not quite be the case, you gain a +2 bonus on all Perception checks.",
                                            "",
                                            Helpers.GetIcon("f74c6bdf5c5f5374fb9302ecdc1f7d64"), // sf perception
                                            FeatureGroup.Trait,
                                            Helpers.CreateAddStatBonus(StatType.SkillPerception, 2, ModifierDescriptor.Trait),
                                            Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.goblin)
                                            );

            bred_for_war = Helpers.CreateFeature("BredForWarTrait",
                                                 "Bred for War",
                                                 "You tower above most other humans and possess a physique of hard, corded muscle.\n"
                                                 + "You gain a +1 trait bonus on Intimidate checks and a +1 trait bonus on your CMB because of your great size.",
                                                 "",
                                                 Helpers.GetIcon("d76497bfc48516e45a0831628f767a0f"), // intimidating prowess
                                                 FeatureGroup.Trait,
                                                 Helpers.CreateAddStatBonus(StatType.CheckIntimidate, 1, ModifierDescriptor.Trait),
                                                 Helpers.CreateAddStatBonus(StatType.AdditionalCMB, 1, ModifierDescriptor.Trait),
                                                 Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.human)
                                                 );

            brute = Helpers.CreateFeature("BruteTrait",
                                         "Brute",
                                         "You have worked for a crime lord, either as a lowlevel enforcer or as a guard, and are adept at frightening away people.\n"
                                         + "Benefits: You gain a +1 trait bonus on intimidate checks, and Persuasion is always considered a class skill for you for purpose of intimidate checks.",
                                         "",
                                         Helpers.GetIcon("d76497bfc48516e45a0831628f767a0f"), // intimidating prowess
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.CheckIntimidate, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckIntimidate; }),
                                         Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.half_orc)
                                         );

            elven_reflexes = Helpers.CreateFeature("ElvenReflexesTrait",
                                                    "Elven Reflexes",
                                                    "One of your parents was a member of a wild elven tribe, and you’ve inherited a portion of your elven parent’s quick reflexes.\nBenefit: You gain a +2 trait bonus on initiative checks.",
                                                    "",
                                                    Helpers.GetIcon("797f25d709f559546b29e7bcb181cc74"), // Improved Initiative
                                                    FeatureGroup.Trait,
                                                    Helpers.CreateAddStatBonus(StatType.Initiative, 2, ModifierDescriptor.Trait),
                                                    Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.half_elf)
                                                    );

            warrior_of_old = Helpers.CreateFeature("WarriorOfOldTrait",
                                                    "Warrior of Old",
                                                    "As a child, you put in long hours on combat drills, and though time has made this training a dim memory, you still have a knack for quickly responding to trouble.\nBenefit: You gain a +2 trait bonus on initiative checks.",
                                                    "",
                                                    Helpers.GetIcon("797f25d709f559546b29e7bcb181cc74"), // Improved Initiative
                                                    FeatureGroup.Trait,
                                                    Helpers.CreateAddStatBonus(StatType.Initiative, 2, ModifierDescriptor.Trait),
                                                    Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.elf)
                                                    );

            forlorn = Helpers.CreateFeature("ForlornTrait",
                                             "Forlorn",
                                             "Having lived outside of traditional elf society for much or all of your life, you know the world can be cruel, dangerous, and unforgiving of the weak.\nBenefit: You gain a +1 trait bonus on Fortitude saves.",
                                             "",
                                             Helpers.GetIcon("79042cb55f030614ea29956177977c52"), // Great Fortitude
                                             FeatureGroup.Trait,
                                             Helpers.CreateAddStatBonus(StatType.SaveFortitude, 1, ModifierDescriptor.Trait),
                                             Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.elf)
                                             );

            latent_psion = Helpers.CreateFeature("LatentPsionTrait",
                                                 "Latent Psion",
                                                 "The power to affect the world with the mind is very much a reality in your distant homeland. Although you may not even have been born in Vudra, this power remains potent in your mind as well and protects you from mental assault.\nBenefit: You gain a +2 trait bonus on saves against mind-affecting effects.",
                                                 "",
                                                 Helpers.GetIcon("175d1577bb6c9a04baf88eec99c66334"), // Iron will
                                                 FeatureGroup.Trait,
                                                 Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.ModifierDescriptor = ModifierDescriptor.Trait; s.Bonus = 2; s.SpellDescriptor = SpellDescriptor.MindAffecting; }),
                                                 Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.human)
                                                 );

            outcast = Helpers.CreateFeature("OutcastTrait",
                                         "Outcast",
                                         "Driven from town after town because of your heritage, you have become adept at living apart from others.\n"
                                         + "Benefits: You gain a +1 bonus on Lore (Nature) checks, and Lore (Nature) is always a class skill for you.",
                                         "",
                                         Helpers.GetIcon("6507d2da389ed55448e0e1e5b871c013"), // sf nature
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.SkillLoreNature, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillLoreNature),
                                         Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.half_orc)
                                         );

            ruthless = Helpers.CreateFeature("RuthlessTrait",
                                             "Ruthless",
                                             "You never hesitate to strike a killing blow.\n"
                                             + "Benefits: You gain a +1 trait bonus on attack rolls to confirm critical hits.",
                                             "",
                                             Helpers.GetIcon("8ac59959b1b23c347a0361dc97cc786d"), // critical focus
                                             FeatureGroup.Trait,
                                             Helpers.Create<CriticalConfirmationBonus>(c => { c.Bonus = 1; c.Value = 0; }),
                                             Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.dwarf)
                                             );



            var finish_the_fight_buff = Helpers.CreateBuff("FinishTheFightBuff",
                                                           "Finish the Fight",
                                                            "You’re at the bottom of the pecking order, so when you challenge that order, your victory must be absolute.\n"
                                                            + "Benefits: You gain a +1 trait bonus on attack rolls against opponents you already injured in the past 24 hours.",
                                                            "",
                                                            Helpers.GetIcon("8ac59959b1b23c347a0361dc97cc786d"), // critical focus
                                                            null);
            finish_the_fight_buff.Stacking = StackingType.Stack;

            var apply_finish_the_fight_buff = Helpers.CreateConditional(Common.createContextConditionHasBuffFromCaster(finish_the_fight_buff, not: true),
                                                                        Common.createContextActionApplyBuff(finish_the_fight_buff, Helpers.CreateContextDuration(1, DurationRate.Days), dispellable: false));
            finish_the_fight = Helpers.CreateFeature("FinishTheFightTrait",
                                                     finish_the_fight_buff.Name,
                                                     finish_the_fight_buff.Description,
                                                     "",
                                                     Helpers.GetIcon("8ac59959b1b23c347a0361dc97cc786d"), // critical focus
                                                     FeatureGroup.Trait,
                                                     Helpers.Create<CallOfTheWild.NewMechanics.AttackBonusAgainstFactsOwner>(a =>
                                                     {
                                                         a.Bonus = 1;
                                                         a.attack_types = new AttackType[] { AttackType.Melee, AttackType.Touch, AttackType.Ranged, AttackType.RangedTouch };
                                                         a.Descriptor = ModifierDescriptor.Trait;
                                                         a.only_from_caster = true;
                                                         a.CheckedFacts = new BlueprintUnitFact[] { finish_the_fight_buff };
                                                     }),
                                                     Common.createAddInitiatorAttackWithWeaponTrigger(Helpers.CreateActionList(apply_finish_the_fight_buff), wait_for_attack_to_resolve: true),
                                                     Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.half_orc)
                                                     );



            unbreakable_hate = Helpers.CreateFeature("UnbreakableHateTrait",
                                             "Unbreakable Hate",
                                             "Your ferocity is focused into your spells, and it is harder to break your concentration. \n"
                                             + "Benefit: You gain a +2 trait bonus on concentration checks.",
                                             "",
                                             Helpers.GetIcon("06964d468fde1dc4aa71a92ea04d930d"), // combat casting
                                             FeatureGroup.Trait,
                                             Helpers.Create<ConcentrationBonus>(c => c.Value = 2),
                                             Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.half_orc)
                                             );


            varisian_tattoo = Helpers.CreateFeature("VarisianTattooTrait",
                                     "Varisian Tattoo",
                                     "You bear the elaborate tattoos of your people, marking you as a free son or daughter of the road. \nBenefit: You gain a +1 trait bonus on saving throws against charm and compulsion effects. Additionally, you are proficient with starknives.",
                                     "",
                                     Helpers.GetIcon("175d1577bb6c9a04baf88eec99c66334"), // Iron will
                                     FeatureGroup.Trait,
                                     Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.ModifierDescriptor = ModifierDescriptor.Trait; s.Bonus = 2; s.SpellDescriptor = SpellDescriptor.Compulsion | SpellDescriptor.Charm; }),
                                     Common.createAddWeaponProficiencies(WeaponCategory.Starknife),
                                     Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.human)
                                     );

            shield_bearer = Helpers.CreateFeature("ShieldBearerTrait",
                                       "Shield Bearer",
                                       "You have survived many battles thanks to your skill with your shield.\n"
                                       + "Benefits: When performing a shield bash, you deal 1 additional point of damage. Also, once per day on your turn as a free action, you may provide one adjacent ally a +2 trait bonus to his Armor Class. This bonus lasts for 1 round, so long as you and the target remain adjacent to one another. You can only use this ability if you are using a shield. You retain your shield bonus to your armor class when using this ability.",
                                       "",
                                       Helpers.GetIcon("121811173a614534e8720d7550aae253"), //shield bash
                                       FeatureGroup.Trait,
                                       Helpers.Create<CallOfTheWild.NewMechanics.ContextWeaponCategoryDamageBonus>(w => { w.Value = 1; w.categories = new WeaponCategory[] { WeaponCategory.SpikedHeavyShield, WeaponCategory.SpikedLightShield, WeaponCategory.WeaponHeavyShield, WeaponCategory.WeaponLightShield }; }),
                                       Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.human)
                                       );

            var shield_bearer_buff = Helpers.CreateBuff("ShieldBearerTraitBuff",
                                                        shield_bearer.Name,
                                                        shield_bearer.Description,
                                                        "",
                                                        shield_bearer.Icon,
                                                        null,
                                                        Helpers.Create<CallOfTheWild.NewMechanics.ContextACBonusIfAdjacentCasterWithShield>(c => { c.value = 2; c.descriptor = ModifierDescriptor.Trait; })
                                                        );
            var shield_bearer_resource = Helpers.CreateAbilityResource("ShieldBearerTraitResource", "", "", "", null);
            shield_bearer_resource.SetFixedResource(1);
            var shield_bearer_ability = Helpers.CreateAbility("ShieldBearerTraitAbility",
                                                              shield_bearer.Name,
                                                              shield_bearer.Description,
                                                              "",
                                                              shield_bearer.Icon,
                                                              AbilityType.Special,
                                                              Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Free,
                                                              AbilityRange.Touch,
                                                              Helpers.oneRoundDuration,
                                                              "",
                                                              Helpers.CreateRunActions(Common.createContextActionApplyBuff(shield_bearer_buff, Helpers.CreateContextDuration(1), dispellable: false)),
                                                              Common.createAbilitySpawnFx("d74f2108085429d4aa15a8cc374745ef", anchor: Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.SelectedTarget),
                                                              shield_bearer_resource.CreateResourceLogic()
                                                              );
            shield_bearer_ability.setMiscAbilityParametersTouchFriendly();
            shield_bearer.AddComponents(shield_bearer_resource.CreateAddAbilityResource(), Helpers.CreateAddFact(shield_bearer_ability));



            grounded = Helpers.CreateFeature("GroundedTrait",
                                    "Grounded",
                                    "You are well balanced, both physically and mentally.\nBenefit: You gain a +1 trait bonus on Mobility checks, and a +1 trait bonus on Reflex saves.",
                                    "",
                                    Helpers.GetIcon("15e7da6645a7f3d41bdad7c8c4b9de1e"), // Lightning Reflexes
                                    FeatureGroup.Trait,
                                    Helpers.CreateAddStatBonus(StatType.SaveReflex, 1, ModifierDescriptor.Trait),
                                    Helpers.CreateAddStatBonus(StatType.SkillMobility, 2, ModifierDescriptor.Trait),
                                    Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.dwarf)
                                    );

            shadow_stabber = Helpers.CreateFeature("ShadowStabberTrait",
                                                  "Shadow Stabber",
                                                  "An instinct for dishonorable conduct serves you well when fighting opponents who are blind, oblivious, or blundering around in the dark.\nBenefit You gain a +2 trait bonus on melee weapon damage rolls made against foes that cannot see you.",
                                                  "",
                                                  Helpers.GetIcon("9f0187869dc23744292c0e5bb364464e"), // accomplished sneak attacker
                                                  FeatureGroup.Trait,
                                                  Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.tiefling),
                                                  Helpers.Create<CallOfTheWild.NewMechanics.DamageBonusIfInvisibleToTarget>(d => d.Bonus = 2)
                                                 );


            well_informed = Helpers.CreateFeature("WellInformedTrait",
                             "Well-Informed",
                             "You make it a point to know everyone and to be connected to everything around you. You frequent the best taverns, attend all of the right events, and graciously help anyone who needs it.\n"
                             + "Benefits: You gain a +1 bonus on Diplomacy checks, and consider Persuasion skill as class skill for the purpose of diplomacy checks.",
                             "",
                             Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // skill focus diplomacy
                             FeatureGroup.Trait,
                             Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.halfling),
                             Helpers.CreateAddStatBonus(StatType.CheckDiplomacy, 1, ModifierDescriptor.Trait),
                             Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckDiplomacy; })
                             );


            helpful = Helpers.CreateFeature("HelpfulTrait",
                             "Helpful",
                             "You see nothing wrong with letting others achieve greatness so long as the job gets done.\n"
                             + "Benefits: Whenever you successfully perform an aid another action, you grant your ally a +4 bonus instead of the normal +2.",
                             "",
                             Helpers.GetIcon("55a037e514c0ee14a8e3ed14b47061de"), // remove fear
                             FeatureGroup.Trait,
                             Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.halfling)
                             );

            Helpers.SetField(Rebalance.aid_another_config, "m_FeatureList",
                 Helpers.GetField<BlueprintFeature[]>(Rebalance.aid_another_config, "m_FeatureList").AddToArray(helpful, helpful));


            intrepid_volunteer = Helpers.CreateFeatureSelection("IntrepidVolunteerFeatureSelection",
                                                                "Intrepid Volunteer",
                                                                "Like many free halflings, you volunteered readily for military service or an adventuring career and met other halflings who showed you how to make up for your small size. Choose one Strength-based skill or one combat maneuver. You can use your Dexterity modifier in place of your Strength modifier to calculate your total modifier for that skill check or combat maneuver check.",
                                                                "",
                                                                null,
                                                                FeatureGroup.Trait,
                                                                Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.halfling)
                                                                );

            var intrepid_volunteer_athletics = Helpers.CreateFeature("IntrepidVolunteerAthleticsFeatureSelection",
                                                    "Intrepid Volunteer (Athletics)",
                                                    intrepid_volunteer.Description,
                                                    "",
                                                    Helpers.GetIcon("9db907332bdaec1468cff3a99efef5b4"), //sf athletics
                                                    FeatureGroup.Trait,
                                                    Helpers.Create<CallOfTheWild.StatReplacementMechanics.ReplaceBaseStatForStatTypeLogic>(r =>
                                                    {
                                                        r.StatTypeToReplaceBastStatFor = StatType.SkillAthletics;
                                                        r.NewBaseStatType = StatType.Dexterity;
                                                    }),
                                                     Helpers.Create<RecalculateOnStatChange>(r => r.Stat = StatType.Strength),
                                                     Helpers.Create<RecalculateOnStatChange>(r => r.Stat = StatType.Dexterity)
                                                    );

            intrepid_volunteer.AllFeatures = new BlueprintFeature[] { intrepid_volunteer_athletics };
            var maneuvers = new CombatManeuver[][] { new CombatManeuver[] { CombatManeuver.BullRush },
                                                     new CombatManeuver[] {CombatManeuver.Disarm },
                                                     new CombatManeuver[] {CombatManeuver.Trip },
                                                     new CombatManeuver[] {CombatManeuver.SunderArmor },
                                                     new CombatManeuver[] {CombatManeuver.DirtyTrickBlind, CombatManeuver.DirtyTrickEntangle, CombatManeuver.DirtyTrickSickened }
                                                   };

            var names = new string[] { "Bull Rush", "Disarm", "Trip", "Sunder", "Dirty Trick" };
            var icons = new UnityEngine.Sprite[]
            {
                library.Get<BlueprintFeature>("b3614622866fe7046b787a548bbd7f59").Icon,
                library.Get<BlueprintFeature>("25bc9c439ac44fd44ac3b1e58890916f").Icon,
                library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa").Icon,
                library.Get<BlueprintFeature>("9719015edcbf142409592e2cbaab7fe1").Icon,
                library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494").Icon,
            };

            for (int i = 0; i < maneuvers.Length; i++)
            {
                var feat = Helpers.CreateFeature("IntrepidVolunteerFeatureSelection" + maneuvers[i][0].ToString() + "Feature",
                                                 intrepid_volunteer.Name + " (" + names[i] + ")",
                                                 intrepid_volunteer.Description,
                                                 "",
                                                 icons[i],
                                                 FeatureGroup.Trait,
                                                 Helpers.Create<CallOfTheWild.CombatManeuverMechanics.ReplaceCombatManeuverStatForSpecificManeuver>(c => { c.StatType = StatType.Dexterity; c.maneuvers = maneuvers[i]; })
                                                 );

                intrepid_volunteer.AllFeatures = intrepid_volunteer.AllFeatures.AddToArray(feat);
            }

            eclectic = library.CopyAndAdd(Core.favored_class_selection, "EclecticTraitSelection", "a331e9bb4906406da1888b4d4e6a2254");
            eclectic.SetNameDescription("Eclectic",
                                              "You have a talent for picking up different vocations.\n"
                                              + "Benefit: Choose an additional favored class and gain either +1 hit point or +1 skill point whenever you take a level in that class.");
            eclectic.Groups = new FeatureGroup[] { FeatureGroup.Trait };
            eclectic.AddComponent(Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.human));


            goblin_foolhardiness = Helpers.CreateFeature("GoblinFoolhardiness",
                                             "Goblin Foolhardiness",
                                             "You have a tendency toward gross overconfidence in combat.\n"
                                             + "Benefit: When facing an enemy that’s larger than you are, if you have no allies in any adjacent squares, your posturing, bravado, and cussing grant you a +1 trait bonus on attack rolls with non-reach melee weapons.",
                                             "",
                                             Helpers.GetIcon("97b991256e43bb140b263c326f690ce2"), // rage
                                             FeatureGroup.Trait,
                                             Helpers.Create<CallOfTheWild.NewMechanics.AttackBonusIfAloneAgainstBiggerSize>(a =>
                                             {
                                                 a.Bonus = 1;
                                                 a.Descriptor = ModifierDescriptor.Trait;
                                                 a.only_melee = true;
                                                 a.only_non_reach = true;
                                                 a.only_if_smaller = true;
                                                 a.only_alone = true;
                                             }),
                                             Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.goblin)
                                             );

            celestial_contact = Helpers.CreateFeature("CelestialContactTrait",
                                                        "Celestial Contact",
                                                        "Witnessing a celestial intervention by your ancestor or a similar being inspired you with the power of good.\n"
                                                        + "Benefit: Treat your caster level as 1 higher when you cast spells with the good descriptor.",
                                                        "",
                                                        Helpers.GetIcon("b1c7576bd06812b42bda3f09ab202f14"), //angelic aspect greater
                                                        FeatureGroup.Trait,
                                                        Helpers.Create<IncreaseSpellDescriptorCasterLevel>(i => { i.Descriptor = SpellDescriptor.Good; i.BonusCasterLevel = 1; }),
                                                        Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.aasimar)
                                                        );

            harrows_chosen = Helpers.CreateFeature("HarrowChoosenTrait",
                                            "Harrow Chosen",
                                            "All your life you’ve been drawn to the mysteries surrounding your family’s harrow deck.\n"
                                            + "Benefit: When you cast a divination spell, your caster level is treated as being 2 levels higher.",
                                            "",
                                            Helpers.GetIcon("d7d18ce5c24bd324d96173fdc3309646"), //divination
                                            FeatureGroup.Trait,
                                            Helpers.Create<IncreaseSpellSchoolCasterLevel>(i => { i.School = SpellSchool.Divination; i.BonusLevel = 2; }),
                                            Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.human)
                                            );

            racial_traits = createTraitSelction("RacialTrait",
                                    "Race Trait",
                                    "Race traits are keyed to specific races or ethnicities. In order to select a race trait, your character must be of the trait’s race or ethnicity. If your race or ethnicity changes at some later point (as could be possible due to the result of polymorph magic or a reincarnation spell), the benefits gained by your racial trait persist— only if your mind and memories change as well do you lose the benefits of a race trait. Of course, in such an event, you’re also likely to lose skills, feats, and a whole lot more!",
                                    auspicious_tatoo,
                                    big_ears,
                                    bred_for_war,
                                    brute,
                                    elven_reflexes,
                                    forlorn,
                                    latent_psion,
                                    outcast,
                                    ruthless,
                                    finish_the_fight,
                                    unbreakable_hate,
                                    varisian_tattoo,
                                    shield_bearer,
                                    grounded,
                                    shadow_stabber,
                                    warrior_of_old,
                                    well_informed,
                                    helpful,
                                    intrepid_volunteer,
                                    goblin_foolhardiness,
                                    celestial_contact,
                                    harrows_chosen
                                    //eclectic
                                    );
        }


        static void createRegionalTraits()
        {

            honeyed_tongue = Helpers.CreateFeature("HoneyedTonguTrait",
                                         "Honeyed Tongue",
                                         "Having matured in the melting pot of New Oppara, you know the customs of the Tian- Shus as well as those of the Taldans, and you utilize this knowledge to create peace between rival groups. \n"
                                         + "Benefits: You gain a +1 bonus on Diplomacy checks, and consider Persuasion skill as class skill for the purpose of diplomacy checks.",
                                         "",
                                         Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // skill focus diplomacy
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.CheckDiplomacy, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckDiplomacy; })
                                         );
            militia = Helpers.CreateFeature("MilitiaTrait",
                                            "Militia",
                                            "As part of Amanandar’s militia, you have trained extensively with groups.\n" +
                                            "Benefit: You gain a +1 trait bonus on attacks made while flanking an opponent.",
                                            "",
                                            Helpers.GetIcon("5662d1b793db90c4b9ba68037fd2a768"), // precise strike
                                            FeatureGroup.Trait,
                                            Helpers.Create<CallOfTheWild.NewMechanics.FlankingAttackBonus>(d => { d.Bonus = 1; d.Descriptor = ModifierDescriptor.Trait; })
                                            );

            freed_slave = Helpers.CreateFeature("FreedSlaveTrait",
                                         "Freed Slave",
                                         "You were either born or sold into slavery, but were freed by Andoren abolitionists. Your strong will helped you persevere in captivity, and gave you strength to start again from nothing in your new life in Andoran.\n"
                                         + "Benefits: You gain a +1 trait bonus on Will saves.",
                                         "",
                                         Helpers.GetIcon("175d1577bb6c9a04baf88eec99c66334"), // iron will
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.SaveWill, 1, ModifierDescriptor.Trait)
                                         );

            aspiring_hellknight = Helpers.CreateFeature("AspiringHellknightTrait",
                                                         "Aspiring Hellknight",
                                                         "Your family has a long tradition of service in the Hellknights, and your strict upbringing and training have given you a forceful aura of command.\n"
                                                         + "Benefits: You gain a +1 trait bonus on intimidate checks, and Persuasion is always considered a class skill for you for purpose of intimidate checks.",
                                                         "",
                                                         Helpers.GetIcon("d76497bfc48516e45a0831628f767a0f"), // intimidating prowess
                                                         FeatureGroup.Trait,
                                                         Helpers.CreateAddStatBonus(StatType.CheckIntimidate, 1, ModifierDescriptor.Trait),
                                                         Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckIntimidate; })
                                                         );

            secret_revolutionary = Helpers.CreateFeature("SecretRevolutionaryTrait",
                                                         "Secret Revolutionary",
                                                         "You seek to return Cheliax to its heyday before the rise of the House of the Thrune. You have trained yourself to resist any questioning or torture should you ever be caught.\n"
                                                         + "Benefit: You gain a +1 trait bonus on saves against mind-affecting effects, and on saves against drugs or poisons.",
                                                         "",
                                                         Helpers.GetIcon("79042cb55f030614ea29956177977c52"), // Great Fortitude
                                                         FeatureGroup.Trait,
                                                         Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.ModifierDescriptor = ModifierDescriptor.Trait; s.Bonus = 1; s.SpellDescriptor = SpellDescriptor.MindAffecting; }),
                                                         Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.ModifierDescriptor = ModifierDescriptor.Trait; s.Bonus = 1; s.SpellDescriptor = SpellDescriptor.Poison; })
                                                         );

            glory_of_old = Helpers.CreateFeature("GloryOfOldTrait",
                                             "Glory of Old",
                                             "In your veins flows the blood of dwarven heroes from Tar Taargadth. \n"
                                             + "Benefit: You receive a +1 trait bonus on saving throws against spells, spell-like abilities, and poison.",
                                             "",
                                             Helpers.GetIcon("f75d3b6110f04d1409564b9d7647db60"), // Great Fortitude
                                             FeatureGroup.Trait,
                                             Helpers.Create<SavingThrowBonusAgainstAbilityType>(s => { s.Bonus = 1; s.ModifierDescriptor = ModifierDescriptor.Trait; s.AbilityType = AbilityType.Spell; }),
                                             Helpers.Create<SavingThrowBonusAgainstAbilityType>(s => { s.Bonus = 1; s.ModifierDescriptor = ModifierDescriptor.Trait; s.AbilityType = AbilityType.SpellLike; }),
                                             Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.ModifierDescriptor = ModifierDescriptor.Trait; s.Bonus = 1; s.SpellDescriptor = SpellDescriptor.Poison; }),
                                             Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = Core.dwarf)
                                             );

            spiritual_forester = Helpers.CreateFeature("SpiritualForesterrait",
                                         "Spiritual Forester",
                                         "You grew up in a small settlement along the outskirts of the Forest of Spirits, and have learned much about the woods as well as about their supernatural inhabitants.\n"
                                         + "Benefits: You gain a +1 bonus on Lore (Nature) checks, and Lore (Nature) is always a class skill for you.",
                                         "",
                                         Helpers.GetIcon("6507d2da389ed55448e0e1e5b871c013"), // sf nature
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.SkillLoreNature, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillLoreNature)
                                         );

            viking_blood = Helpers.CreateFeature("VikingBloodTrait",
                                             "Viking Blood",
                                             "You have the imposing build of a Viking, and people of the south fear your unpredictable nature.\n"
                                             + "Benefits: You gain a +1 trait bonus on intimidate checks, and Persuasion is always considered a class skill for you for purpose of intimidate checks.",
                                             "",
                                             Helpers.GetIcon("d76497bfc48516e45a0831628f767a0f"), // intimidating prowess
                                             FeatureGroup.Trait,
                                             Helpers.CreateAddStatBonus(StatType.CheckIntimidate, 1, ModifierDescriptor.Trait),
                                             Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckIntimidate; })
                                             );

            river_rat = Helpers.CreateFeature("RiverRatTrait",
                                               "River Rat",
                                               "You learned to swim right after you learned to walk. When you were a youth, a gang of river pirates put you to work swimming in nighttime rivers and canals with a dagger between your teeth so you could sever the anchor ropes of merchant vessels.\n"
                                               + "Benefits: You gain a +1 trait bonus on damage rolls with a dagger and a +1 trait bonus on athletics checks. Athletics is always a class skill for you.",
                                               "",
                                               Helpers.GetIcon("9db907332bdaec1468cff3a99efef5b4"), //sf athletics
                                               FeatureGroup.Trait,
                                               Helpers.Create<CallOfTheWild.NewMechanics.ContextWeaponCategoryDamageBonus>(w => { w.Value = 1; w.categories = new WeaponCategory[] { WeaponCategory.Dagger, WeaponCategory.PunchingDagger, WeaponCategory.Kukri, WeaponCategory.Sai}; }),
                                               Helpers.CreateAddStatBonus(StatType.SkillAthletics, 1, ModifierDescriptor.Trait),
                                               Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillAthletics)
                                               );

            quain_martial_artist = Helpers.CreateFeature("QuainMartialArtistTrait",
                                   "Quain Martial Artist",
                                   "Having grown up in Quain, you were taught under various schools of martial arts, and have used all you have learned to hone your fighting prowess.\n"
                                   + "Benefits: You gain a +1 trait bonus on damage rolls when using unarmed strikes.",
                                   "",
                                   Helpers.GetIcon("c36562b8e7ae12d408487ba8b532d966"), //pummeling style
                                   FeatureGroup.Trait,
                                   Helpers.Create<CallOfTheWild.NewMechanics.ContextWeaponCategoryDamageBonus>(w => { w.Value = 1; w.categories = new WeaponCategory[] { WeaponCategory.UnarmedStrike}; })
                                   );

            sargavan_guard = Helpers.CreateFeature("SargavanGuardTrait",
                                     "Sargavan Guard",
                                    "You served in the Sargavan Guard, either as a colonial sub-praetor or as a native Mwangi regular, and have grown accustomed to marching in hot temperatures while wearing armor. \nBenefit: When you wear armor of any sort, reduce that suit’s armor check penalty by 1, to a minimum check penalty of 0.",
                                    "",
                                    Helpers.GetIcon("3bc6e1d2b44b5bb4d92e6ba59577cf62"), // Armor Focus (light)
                                    FeatureGroup.Trait,
                                    Helpers.Create<CallOfTheWild.NewMechanics.ArmorCheckPenaltyIncrease>(a => { a.Bonus = 1; a.CheckCategory = true; a.Category = ArmorProficiencyGroup.Light; }),
                                    Helpers.Create<CallOfTheWild.NewMechanics.ArmorCheckPenaltyIncrease>(a => { a.Bonus = 1; a.CheckCategory = true; a.Category = ArmorProficiencyGroup.Medium; }),
                                    Helpers.Create<CallOfTheWild.NewMechanics.ArmorCheckPenaltyIncrease>(a => { a.Bonus = 1; a.CheckCategory = true; a.Category = ArmorProficiencyGroup.Heavy; })
                                    );

            hermean_paragon = Helpers.CreateFeature("HermeanParagonTrait",
                                    "Hermena Paragon",
                                    "You are a product of Hermea’s breeding programs—either your parents were chosen to be citizens, or you were, but later failed to live up to the island’s high standards. Whatever the case, you are quicker than normal members of your race. \nBenefit: You gain a +2 trait bonus on initiative checks.",
                                    "",
                                    Helpers.GetIcon("797f25d709f559546b29e7bcb181cc74"), // Improved Initiative
                                    FeatureGroup.Trait,
                                    Helpers.CreateAddStatBonus(StatType.Initiative, 2, ModifierDescriptor.Trait)
                                    );

            wayang_spellhunter = library.CopyAndAdd(magical_lineage, "WayangSpellhunterTrait", "");
            wayang_spellhunter.SetNameDescription("Wayang Spellhunter",
                                                  "You grew up on one of the wayang-populated islands of Minata, and your use of magic while hunting has been a boon to you.\nBenefit: Select a spell of 3rd level or below. When you use this spell with a metamagic feat, it uses up a spell slot one level lower than it normally would.");

            valashmai_veteran = Helpers.CreateFeature("ValashmaiVeteranTrait",
                                                     "Valashmai Veteran",
                                                     "You have traveled to the Valashmai Jungle on numerous occasions, and your prowess in traversing the jungle wilderness makes you a formidable guide and explorer.\n"
                                                     + "Benefits: You gain a +1 bonus on Perception checks, and Perception is always a class skill for you.",
                                                     "",
                                                     Helpers.GetIcon("f74c6bdf5c5f5374fb9302ecdc1f7d64"), // sf perception
                                                     FeatureGroup.Trait,
                                                     Helpers.CreateAddStatBonus(StatType.SkillPerception, 1, ModifierDescriptor.Trait),
                                                     Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillPerception)
                                                     );

            rice_runner = Helpers.CreateFeature("RiceRunnerTrait",
                                         "Rice Runner",
                                         "You grew up as a slave in Wanshou, harvesting rice for your kraken despot, and you know how to move agilely across sodden and unsteady ground.\n"
                                         + "Benefits: You gain a +1 trait bonus on Mobility checks, and Mobility becomes a class skill for you.",
                                         "",
                                         Helpers.GetIcon("52dd89af385466c499338b7297896ded"), // sf perception
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.SkillMobility, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<AddClassSkill>(a => a.Skill = StatType.SkillMobility)
                                         );

            sound_of_mind = Helpers.CreateFeature("SoundOfMindTrait",
                                                 "Sound of Mind",
                                                 "You have lived in the mountains of Zi Ha and found utter tranquility among the samsarans of the region.\n"
                                                 + "Benefit: You gain a +2 trait bonus on saving throws against mind-affecting effects.",
                                                 "",
                                                 Helpers.GetIcon("175d1577bb6c9a04baf88eec99c66334"), // iron will
                                                 FeatureGroup.Trait,
                                                 Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.ModifierDescriptor = ModifierDescriptor.Trait; s.Bonus = 2; s.SpellDescriptor = SpellDescriptor.MindAffecting; })
                                                 );

            xa_hoi_soldier = Helpers.CreateFeature("XaHoiSoldierTrait",
                                    "Xa Hoi Soldier",
                                    "You were a soldier in one of Xa Hoi’s extensive armies, trained under the oversight of one of Pham Duc Quan’s draconic brethren.\n"
                                    + "Benefit: You gain a +1 trait bonus on Reflex saves.",
                                    "",
                                    Helpers.GetIcon("15e7da6645a7f3d41bdad7c8c4b9de1e"), // Lightning Reflexes
                                    FeatureGroup.Trait,
                                    Helpers.CreateAddStatBonus(StatType.SaveReflex, 1, ModifierDescriptor.Trait)
                                    );

            var sickened = library.Get<BlueprintBuff>("4e42460798665fd4cb9173ffa7ada323");
            blighted_physiology = Helpers.CreateFeature("BlightedPhysiologyTrait",
                                                    "Blighted Physiology",
                                                    "Exposure to the corruption that seeps through every drop of water and grain of dirt in Numeria has altered your body.\n"
                                                    + "Benefit: Horrific growths beneath your skin provide you a +1 natural armor bonus to AC, but your body does not work as a normal creature’s would. You become sickened for 1 round anytime you receive magical healing.",
                                                    "",
                                                    Helpers.GetIcon("4e42460798665fd4cb9173ffa7ada323"), // sickened
                                                    FeatureGroup.Trait,
                                                    Helpers.CreateAddStatBonus(StatType.AC, 1, ModifierDescriptor.NaturalArmor),
                                                    Helpers.Create<CallOfTheWild.HealingMechanics.OnHealingReceivedActionTrigger>(o =>
                                                    {
                                                        o.actions = Helpers.CreateActionList(Common.createContextActionApplyBuff(sickened, Helpers.CreateContextDuration(1), dispellable: false));
                                                    }
                                                    )
                                                    );

            child_of_crusades = Helpers.CreateFeature("ChildOfCrusadesTrait",
                                                    "Child of Crusades",
                                                    "Your parents stood strong against the demons of the Worldwound, facing down the worst of this world and the Great Beyond. You have inherited their indomitable spirit.\n"
                                                    + "Benefit: You gain a +2 trait bonus on all saves against fear.",
                                                    "",
                                                    Helpers.GetIcon("dd38f33c56ad00a4da386c1afaa49967"), // blessing of courage
                                                    FeatureGroup.Trait,
                                                    Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.Bonus = 2; s.ModifierDescriptor = ModifierDescriptor.Trait; s.SpellDescriptor = SpellDescriptor.Fear | SpellDescriptor.Shaken; })
                                                    );

            chilled_by_brutality = Helpers.CreateFeature("ChilledByBrutalityTrait",
                                        "Chilled by Brutality",
                                        "You were part of a group that was mercilessly attacked by giants of the tundra, who may have gone so far as to eat the dead and dying. After that, little can faze you, but you strongly prefer to finish fights with giants quickly to prevent anything like that from happening again.\n"
                                        + "Benefit: You gain a +2 trait bonus on attack rolls to confirm critical hits against giants and on saving throws against fear effects.",
                                        "",
                                        Helpers.GetIcon("2a6a2f8e492ab174eb3f01acf5b7c90a"), // defensive stance
                                        FeatureGroup.Trait,
                                        Helpers.Create<AttackBonusAgainstFactOwner>(a => { a.AttackBonus = 0; a.Bonus = 2; a.Descriptor = ModifierDescriptor.Trait; a.CheckedFact = Common.giant_humanoid; }),
                                        Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.Bonus = 2; s.ModifierDescriptor = ModifierDescriptor.Trait; s.SpellDescriptor = SpellDescriptor.Fear | SpellDescriptor.Shaken; })
                                        );

            var demon_bane_summoner_buff = Helpers.CreateBuff("DemonbaneSummonerBuff",
                                                               "Demonbane Summoner",
                                                               "Your line is derived directly from the god callers of Sarkoris. You adamantly oppose the demonic forces of the Worldwound in hopes of reclaiming your lost lands.\n"
                                                               + "Benefit: The attacks of creatures you summon are treated as cold iron for the purpose of overcoming damage reduction.",
                                                               "",
                                                               Helpers.GetIcon("ce0ece459ebed9941bb096f559f36fa8"),
                                                               null,
                                                               Common.createAddOutgoingMaterial(Kingmaker.Enums.Damage.PhysicalDamageMaterial.ColdIron));

            demon_bane_summoner = Helpers.CreateFeature("DemonbaneSummonerTrait",
                                                        demon_bane_summoner_buff.Name,
                                                        demon_bane_summoner_buff.Description,
                                                        "",
                                                        demon_bane_summoner_buff.Icon,
                                                        FeatureGroup.Trait);
            demon_bane_summoner.AddComponent(Helpers.Create<OnSpawnBuff>(o =>
                                                                        {
                                                                            o.buff = demon_bane_summoner_buff;
                                                                            o.IfHaveFact = demon_bane_summoner;
                                                                            o.SpellDescriptor = SpellDescriptor.Summoning;
                                                                            o.IsInfinity = true;
                                                                            o.CheckDescriptor = true;
                                                                        })
                                             );

            empathic_diplomat = Helpers.CreateFeature("EmpathicDiplomatTrait",
                                                     "Empathic Diplomat",
                                                     "You have long followed the path of common sense and empathic insight when using diplomacy.\n"
                                                     + "Benefit: You modify your Diplomacy checks using your Wisdom modifier, not your Charisma modifier.",
                                                     "",
                                                     Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // sf diplomacy
                                                     FeatureGroup.Trait,
                                                     Helpers.Create<CallOfTheWild.SkillMechanics.DependentAbilityScoreCheckStatReplacement>(s =>
                                                     {
                                                         s.stat = StatType.CheckDiplomacy;
                                                         s.old_stat = StatType.Charisma;
                                                         s.new_stat = StatType.Wisdom;
                                                     })
                                                     );

            cunning_liar = Helpers.CreateFeature("CunningLiarTrait",
                                         "Cunning Liar",
                                         "You were forced into hiding or willingly went on the run at a young age, and learned to reading others’ interests to inform your lies.\n"
                                         + "Benefit: You modify your Bluff checks using your Wisdom modifier, not your Charisma modifier.",
                                         "",
                                         Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // sf diplomacy
                                         FeatureGroup.Trait,
                                         Helpers.Create<CallOfTheWild.SkillMechanics.DependentAbilityScoreCheckStatReplacement>(s =>
                                         {
                                             s.stat = StatType.CheckBluff;
                                             s.old_stat = StatType.Charisma;
                                             s.new_stat = StatType.Wisdom;
                                         })
                                         );

            flotsam = Helpers.CreateFeature("FlotsamTrait",
                                            "Flotsam",
                                            "You were one of only a few that survived the destruction of the merchant vessel Vantage. Your crew was more than able to hold off the blundering pirate attackers, but their red dragon ally proved too much for your defenses. As you watched the sharks and eels feast on the bodies of your fallen comrades, you vowed to see Aashaq slain. \n"
                                            + "Benefit: You gain a +2 trait bonus against spells and effects with the fire descriptor.",
                                            "",
                                            Helpers.GetIcon("3f9605134d34e1243b096e1f6cb4c148"), // protection from fire
                                            FeatureGroup.Trait,
                                            Helpers.Create<SavingThrowBonusAgainstDescriptor>(s => { s.Bonus = 2; s.ModifierDescriptor = ModifierDescriptor.Trait; s.SpellDescriptor = SpellDescriptor.Fire; })
                                            );

            minkai_advocate = Helpers.CreateFeature("MinkaiAdvocateTrait",
                                         "Minkai Advocate",
                                         "You possess strong ties to Minkai, and spread flattering words regarding your empire.\n"
                                         + "Benefits: You gain a +1 trait bonus on Bluff checks, and Persuasion is always considered a class skill for you for purpose of Bluff checks.",
                                         "",
                                         Helpers.GetIcon("1621be43793c5bb43be55493e9c45924"), // skill focus diplomacy
                                         FeatureGroup.Trait,
                                         Helpers.CreateAddStatBonus(StatType.CheckBluff, 1, ModifierDescriptor.Trait),
                                         Helpers.Create<CallOfTheWild.NewMechanics.AddBonusToSkillCheckIfNoClassSkill>(a => { a.skill = StatType.SkillPersuasion; a.check = StatType.CheckBluff; })
                                         );

            pirate_duelist = Helpers.CreateFeature("PirateDuelistTrait",
                                       "Pirate Duelist",
                                       "You’ve rubbed elbows with pirates of all stripes in Ilizmagorti’s taverns and convinced a few to show off their swordfighting skills.\n"
                                       + "Benefits: You gain a +1 trait bonus on attacks of opportunity when using a dagger or a sword.",
                                       "",
                                       Helpers.GetIcon("5bb6dc5ce00550441880a6ff8ad4c968"), //opportunist
                                       FeatureGroup.Trait,
                                       Helpers.Create<CallOfTheWild.NewMechanics.AttackBonusOnAttacksOfOpportunity>(a =>
                                       {
                                           a.categories = new WeaponCategory[] { WeaponCategory.Estoc, WeaponCategory.Rapier, WeaponCategory.Scimitar, WeaponCategory.Shortsword, WeaponCategory.Dagger, WeaponCategory.Kukri, WeaponCategory.PunchingDagger, WeaponCategory.Longsword, WeaponCategory.BastardSword, WeaponCategory.Falchion, WeaponCategory.Greatsword, WeaponCategory.DuelingSword };
                                           a.Value = 1;
                                           a.Descriptor = ModifierDescriptor.Trait;
                                       }
                                       )
                                       );

            secret_of_the_impossible_kingdom = library.CopyAndAdd(gifted_adept, "SecretOfTheImpossibleKingdomTrait", "");
            secret_of_the_impossible_kingdom.SetNameDescription("Secret of the Impossible Kingdom",
                                                                "You have studied the ancient lore of Vudra at a monastery in Jalmeray, and have learned a mystical secret that empowers your spellcasting.\n"
                                                                + "Benefit: Pick one spell when you choose this trait—from this point on, whenever you cast that spell, you do so at +1 caster level."
                                                                );

            regional_traits = createTraitSelction("RegionalTrait",
                                                "Regional Trait",
                                                "Regional traits are keyed to specific regions, be they large (such as a nation or geographic region) or small (such as a city or a specific mountain). In order to select a regional trait, your PC must have spent at least a year living in that region. At first level, you can only select one regional trait (typically the one tied to your character’s place of birth or homeland), despite the number of regions you might wish to write into your character’s background.",
                                                chilled_by_brutality,
                                                honeyed_tongue,
                                                militia,
                                                freed_slave,
                                                aspiring_hellknight,
                                                cunning_liar,
                                                secret_revolutionary,
                                                glory_of_old,
                                                spiritual_forester,
                                                viking_blood,
                                                river_rat,
                                                quain_martial_artist,
                                                sargavan_guard,
                                                hermean_paragon,
                                                wayang_spellhunter,
                                                valashmai_veteran,
                                                rice_runner,
                                                sound_of_mind,
                                                xa_hoi_soldier,
                                                blighted_physiology,
                                                child_of_crusades,
                                                demon_bane_summoner,
                                                empathic_diplomat,
                                                flotsam,
                                                minkai_advocate,
                                                pirate_duelist,
                                                secret_of_the_impossible_kingdom
                                                );

        }


        static void createEquipmentTraits()
        {
            var martial_weapons = library.Get<BlueprintFeature>("203992ef5b35c864390b4e4a1e200629").GetComponent<AddProficiencies>().WeaponProficiencies;
            var simple_weapons = library.Get<BlueprintFeature>("e70ecf1ed95ca2f40b754f1adb22bbdd").GetComponent<AddProficiencies>().WeaponProficiencies;

            var all_proficiencies = martial_weapons.AddToArray(simple_weapons).Distinct().Where(wp => wp != WeaponCategory.SpikedHeavyShield 
                                                                                                      && wp != WeaponCategory.WeaponLightShield
                                                                                                      && wp != WeaponCategory.SpikedLightShield
                                                                                                      && wp != WeaponCategory.WeaponHeavyShield
                                                                                                      ).ToArray();

            var racial_weapons = new Dictionary<WeaponCategory, BlueprintRace>
            {
                {WeaponCategory.ElvenCurvedBlade, Core.elf},
                //{WeaponCategory.DwarvenWaraxe, Core.dwarf}, //martial for everyone else
                {WeaponCategory.Urgrosh, Core.dwarf},
                {WeaponCategory.HookedHammer, Core.gnome},
                {WeaponCategory.DoubleAxe, Core.half_orc},
                {WeaponCategory.SlingStaff, Core.halfling}
            };

            all_proficiencies = all_proficiencies.AddToArray(WeaponCategory.DuelingSword, WeaponCategory.ElvenCurvedBlade, WeaponCategory.Urgrosh, WeaponCategory.HookedHammer, WeaponCategory.DoubleAxe, WeaponCategory.SlingStaff, WeaponCategory.Estoc);
            all_proficiencies = all_proficiencies.Distinct().ToArray();
            var description = "You carry a masterwork simple or martial weapon that has been passed down from generation to generation in your family (pay the standard gp cost for the weapon).\n"
                + "When you select this trait, choose one of the following benefits: proficiency with that specific weapon, a +1 trait bonus on attacks of opportunity with that specific weapon, or a +2 trait bonus on all combat maneuvers when using that specific weapon.";

            var masterwork_enchant = library.Get<BlueprintWeaponEnchantment>("6b38844e2bffbac48b63036b66e735be");
            var masterwork_weapons = library.GetAllBlueprints().OfType<BlueprintItemWeapon>().Where(w => w.IsOnlyMasterwork && w.Icon != null);

            
            foreach (var wp in all_proficiencies)
            {
                var mw_weapon = masterwork_weapons.Where(w => w.Category == wp).FirstOrDefault();


                if (mw_weapon == null)
                {
                    continue;
                }

                var feature_selection = Helpers.CreateFeatureSelection(wp.ToString() + "HeirloomWeaponTraitSelection",
                                                                       "Heirloom Weapon: " + LocalizedTexts.Instance.Stats.GetText(wp),
                                                                       description,
                                                                       "",
                                                                       mw_weapon.Icon,
                                                                       FeatureGroup.Trait,
                                                                       Helpers.Create<AddStartingEquipment>(a => a.BasicItems = new Kingmaker.Blueprints.Items.BlueprintItem[] {mw_weapon })
                                                                       );

                //feature_selection.HideInUI = true;
                feature_selection.HideInCharacterSheetAndLevelUp = true;

                var proficiency = Helpers.CreateFeature(wp.ToString() + "HeirloomWeaponTraitProficiency",
                                                        "Heirloom Weapon: " + LocalizedTexts.Instance.Stats.GetText(wp) + " (Proficiency)",
                                                        description,
                                                        "",
                                                        mw_weapon.Icon,
                                                        FeatureGroup.Trait,
                                                        Helpers.Create<PrerequisiteNotProficient>(p => p.WeaponProficiencies = new WeaponCategory[] { wp }),
                                                        Common.createAddWeaponProficiencies(wp)
                                                        );

                var attack_bonus = Helpers.CreateFeature(wp.ToString() + "HeirloomWeaponTraitAooBonus",
                                        "Heirloom Weapon: " + LocalizedTexts.Instance.Stats.GetText(wp) + " (AOO Bonus)",
                                        description,
                                        "",
                                        mw_weapon.Icon,
                                        FeatureGroup.Trait,
                                        Helpers.Create<PrerequisiteProficiency>(p => p.WeaponProficiencies = new WeaponCategory[] { wp }),
                                        Helpers.Create<CallOfTheWild.NewMechanics.AttackBonusOnAttacksOfOpportunity>(a =>
                                        {
                                            a.categories = new WeaponCategory[] { wp };
                                            a.Value = 1;
                                            a.Descriptor = ModifierDescriptor.Trait;
                                        }
                                        )
                                        );

                var heirloom_weapon_cmb_bonus = Helpers.CreateFeature(wp.ToString() + "HeirloomWeaponTraitCMBBonusFeature",
                                                                      "Heirloom Weapon: " + LocalizedTexts.Instance.Stats.GetText(wp) + " (CMB Bonus)",
                                                                      "",
                                                                      "",
                                                                      null,
                                                                      FeatureGroup.None,
                                                                      Helpers.CreateAddStatBonus(StatType.AdditionalCMB, 2, ModifierDescriptor.Trait)
                                                                      );
                heirloom_weapon_cmb_bonus.HideInCharacterSheetAndLevelUp = true;


                var cmb_bonus = Helpers.CreateFeature(wp.ToString() + "HeirloomWeaponTraitCMBBonus",
                                                        "Heirloom Weapon: " + LocalizedTexts.Instance.Stats.GetText(wp) + " (CMB Bonus)",
                                                        description,
                                                        "",
                                                        mw_weapon.Icon,
                                                        FeatureGroup.Trait,
                                                        Helpers.Create<PrerequisiteProficiency>(p => p.WeaponProficiencies = new WeaponCategory[] { wp }),
                                                        Helpers.Create<CallOfTheWild.WeaponTrainingMechanics.AddFeatureOnWeaponCategory>(a =>
                                                        {
                                                            a.feature = heirloom_weapon_cmb_bonus;
                                                            a.required_categories = new WeaponCategory[] { wp };
                                                        }
                                                        )
                                                        );

                feature_selection.AllFeatures = new BlueprintFeature[] { proficiency, attack_bonus, cmb_bonus };
                heirloom_weapon.Add(wp, feature_selection);

                if (wp == WeaponCategory.DwarvenWaraxe)
                {
                    //we need to add full proficiency for dwarves
                    proficiency.AddComponents(Helpers.Create<WeaponsFix.FullProficiency>(fp => { fp.category = WeaponCategory.DwarvenWaraxe; fp.race = Core.dwarf; }),
                                              Helpers.Create<CallOfTheWild.HoldingItemsMechanics.CanHoldIn1Hand>(c => { c.category = WeaponCategory.DwarvenWaraxe; c.require_full_proficiency = true; }));
                }

                if (racial_weapons.ContainsKey(wp))
                {
                    var race = racial_weapons[wp];
                    feature_selection.AddComponent(Helpers.Create<NewMechanics.PrerequisiteRace>(p => p.race = race));
                }
            }


            equipment_traits = createTraitSelction("EquipmentTrait",
                                    "Equipment Trait",
                                    "Many adventurers come to rely on certain gear to the extent that the equipment and the adventurer each become something more when the other is present. The symbiosis between adventurers and their gear is varied and complex.",
                                    heirloom_weapon.Values.ToArray()
                                    );
        }
    }
}
