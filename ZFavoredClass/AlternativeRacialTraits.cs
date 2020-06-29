using CallOfTheWild;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
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
        static internal void load()
        {
            createHalfElfAdaptability();
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
