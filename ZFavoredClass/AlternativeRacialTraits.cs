using CallOfTheWild;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
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
    class AlternativeRacialTraits
    {
        static LibraryScriptableObject library => Main.library;
        static public BlueprintFeature skip_feature;


        static public BlueprintFeature sacred_tattoo;
        static internal void load()
        {
            skip_feature = Helpers.CreateFeature("SkipAlternateRacialFeature",
                       "No Alternate Racial Traits",
                       "Keep original racial traits.",
                       "",
                       null,
                       FeatureGroup.Racial
                       );
            skip_feature.HideInCharacterSheetAndLevelUp = true;

            createHalfElfAdaptability();
            createHalfOrcAlternativeRacialFeatures();

            //TODO: creepy for elf (+2 intimidate/ +1 dc for fear/confusion spells)
        }


        static void createHalfOrcAlternativeRacialFeatures()
        {
            var ferocity = library.Get<BlueprintFeature>("c99f3405d1ef79049bd90678a666e1d7");

            var toothy = Helpers.CreateFeature("ToothyHalfOrcRacialFeature",
                                               "Toothy",
                                               "Some half-orcs’ tusks are large and sharp, granting a bite attack. This is a primary natural attack that deals 1d4 points of piercing damage. This racial trait replaces orc ferocity.",
                                               "",
                                               NewSpells.savage_maw.Icon,
                                               FeatureGroup.Racial,
                                               CallOfTheWild.Common.createAddAdditionalLimb(library.Get<BlueprintItemWeapon>("35dfad6517f401145af54111be04d6cf")),
                                               Common.createRemoveFeatureOnApply(ferocity)
                                               );

           sacred_tattoo = Helpers.CreateFeature("SacredHalfOrcRacialFeature",
                                   "Sacred Tattoo",
                                   "Many half-orcs decorate themselves with tattoos, piercings, and ritual scarification, which they consider sacred markings. Half-orcs with this racial trait gain a +1 luck bonus on all saving throws. This racial trait replaces orc ferocity.",
                                   "",
                                   NewFeats.mages_tattoo.Icon,
                                   FeatureGroup.Racial,
                                   Helpers.Create<BuffAllSavesBonus>(b => { b.Descriptor = ModifierDescriptor.Luck; b.Value = 1; }),
                                   Common.createRemoveFeatureOnApply(ferocity)
                                   );

            var alternative_racial_trait = Helpers.CreateFeatureSelection("HalfOrcAlternativeRacialTraitsSelection",
                                                                 "Alternate Racial Traits",
                                                                 "Aternate racial traits may be selected in place of one or more of the standard racial traits.",
                                                                 "",
                                                                 null,
                                                                 FeatureGroup.Racial);
            alternative_racial_trait.Obligatory = false;
            alternative_racial_trait.HideInCharacterSheetAndLevelUp = true;
            alternative_racial_trait.HideInUI = true;
            alternative_racial_trait.AllFeatures = new BlueprintFeature[] { toothy, sacred_tattoo, skip_feature };
            Core.half_orc.Features = Core.half_orc.Features.AddToArray(alternative_racial_trait);


            var regongar_feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("12ee53c9e546719408db257f489ec366");
            var regongar_class_levels = regongar_feature.GetComponent<AddClassLevels>();
            regongar_class_levels.Selections = regongar_class_levels.Selections.AddToArray(new SelectionEntry()
            {
                Selection = alternative_racial_trait,
                Features = new BlueprintFeature[] { toothy }
            }
            );
        }


        static void createHalfElfAdaptability()
        {
            var exotic_weapon_proficiency = library.Get<BlueprintFeatureSelection>("9a01b6815d6c3684cb25f30b8bf20932");
            var martial_weapon_proficiency = library.Get<BlueprintFeature>("203992ef5b35c864390b4e4a1e200629");


            var ancestral_arms = Helpers.CreateFeatureSelection("AncestralArmsFeature",
                                                       "Ancestral Arms",
                                                       "Some half-elves receive training in an unusual weapon. Half-elves with this racial trait receive Exotic Weapon Proficiency or Martial Weapon Proficiency with one weapon as a bonus feat at 1st level.",
                                                       "",
                                                       exotic_weapon_proficiency.Icon,
                                                       FeatureGroup.None);
            ancestral_arms.AllFeatures = exotic_weapon_proficiency.AllFeatures.AddToArray(martial_weapon_proficiency);

            var adaptability = library.Get<BlueprintFeatureSelection>("26a668c5a8c22354bac67bcd42e09a3f");
            adaptability.AllFeatures = adaptability.AllFeatures.AddToArray(ancestral_arms);

            adaptability.SetDescription("Half-elves receive Skill Focus as a bonus feat at 1st level or a proficiency with any one martial or exotic weapon.");
        }
    }
}
