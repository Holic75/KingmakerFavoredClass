using JetBrains.Annotations;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFavoredClass.NewMechanics
{
    [AllowedOn(typeof(BlueprintUnitFact))]
    public class DisableAutomaticFavoredClassHitPoints : OwnedGameLogicComponent<UnitDescriptor>, ILevelUpSelectClassHandler
    {
        [JsonProperty]
        private bool applied = false;

        public void HandleSelectClass(UnitDescriptor unit, LevelUpState state)
        {
            if (applied)
            {
                return;
            }

            if (Owner == unit)
            {
                Apply(state);
                applied = true;
            }
        }

        public override void OnFactActivate()
        {
            if (applied)
            {
                return;
            }
            // Note: this is different from the other favored class bonus components,
            // because the feature remains on the character, and kicks in at each level up.
            var levelUp = Game.Instance.UI.CharacterBuildController.LevelUpController;
            if (levelUp.State.NextLevel == 1 && (Owner == levelUp.Preview || Owner == levelUp.Unit))
            {
                // Handle the level 1 hit point adjustment in the character generator.
                Apply(levelUp.State);
                applied = true;
            }
        }

        void Apply(LevelUpState state)
        {
            // If a user-selectable favored class was chosen, then we need to disable the game's automatic favored class hit points.
            // TODO: could use a patch to skip ApplyClassMechanics.ApplyHitPoints instead of undoing it.
            var @class = state.SelectedClass;
            int nextLevel = state.NextLevel;
            var classes = BlueprintRoot.Instance.Progression.CharacterClasses;
            // This calculation was taken from ApplyClassMechanics.ApplyHitPoints.
            // All we want to do here is undo that function, so we replicate the logic as accurately as possible.
            //
            // Note: there is a bug in the base game (seen here): if a prestige class is higher level than a base class,
            // it won't allow the base class to get its favored class bonus.
            bool isFavoredClass = !@class.PrestigeClass && classes.Contains(@class) && !Owner.Progression.Classes.Any(c => c.Level >= nextLevel && c.CharacterClass != @class);

            if (isFavoredClass)
            {
                Owner.Stats.HitPoints.BaseValue--;
            }
        }
    }


    public abstract class ComponentAppliedOnceOnLevelUp : OwnedGameLogicComponent<UnitDescriptor>, ILevelUpCompleteUIHandler
    {
        public override void OnFactActivate()
        {
            try
            {

                // If we're in the level-up UI, apply the component
                var levelUp = Game.Instance.UI.CharacterBuildController.LevelUpController;
                if (Owner == levelUp.Preview || Owner == levelUp.Unit)
                {
                    Apply(levelUp.State);
                }
            }
            catch (Exception e)
            {
                Main.logger.Log(e.ToString());
            }
        }

        // Optionally remove this fact to free some memory; useful if the fact is already applied
        // and there is no reason to track its overall rank.
        protected virtual bool RemoveAfterLevelUp => false;

        public void HandleLevelUpComplete(UnitEntityData unit, bool isChargen)
        {

        }

        protected abstract void Apply(LevelUpState state);
    }


    [AllowedOn(typeof(BlueprintUnitFact))]
    public class AddOneSpellChoice : ComponentAppliedOnceOnLevelUp
    {
        public BlueprintCharacterClass CharacterClass;
        public int SpellLevel;

        protected override void Apply(LevelUpState state)
        {
            if (CharacterClass != state.SelectedClass) return;

            var spellbook = Owner.Progression.GetClassData(CharacterClass).Spellbook;
            var spellSelection = state.DemandSpellSelection(spellbook, spellbook.SpellList);
            int existingNewSpells = spellSelection.LevelCount[SpellLevel]?.SpellSelections.Length ?? 0;

           // Main.logger.Log($"Adding spell selection to level {SpellLevel}");
            spellSelection.SetLevelSpells(SpellLevel, 1 + existingNewSpells);
        }
    }


    [AllowedOn(typeof(BlueprintUnitFact))]
    public class AddHitPointOnce : ComponentAppliedOnceOnLevelUp
    {
        protected override void Apply(LevelUpState state)
        {
           // Main.logger.Log(GetType().Name + $" {state.SelectedClass}");
            Owner.Stats.HitPoints.BaseValue++;
        }
    }

    [AllowedOn(typeof(BlueprintUnitFact))]
    public class AddSkillRankOnce : ComponentAppliedOnceOnLevelUp
    {
        protected override void Apply(LevelUpState state)
        {
            //Main.logger.Log(GetType().Name + $" {state.SelectedClass}");
            state.ExtraSkillPoints++;
        }
    }


    [AllowMultipleComponents]
    public class PrerequisiteFeatureFullRank : Prerequisite
    {
        [NotNull]
        public BlueprintFeature Feature;
        public BlueprintFeature checked_feature;
        public int divisor;
        public bool not;


        public override bool Check(
          FeatureSelectionState selectionState,
          UnitDescriptor unit,
          LevelUpState state)
        {
            if (selectionState != null && selectionState.IsSelectedInChildren(this.Feature))
                return false;
            if (selectionState != null && checked_feature != null && selectionState.IsSelectedInChildren(this.checked_feature))
                return false;
            var feat = unit.Progression.Features.GetFact(this.Feature);

            if (feat == null)
            {
                return not;
            }
            else
            {
                return (((feat.GetRank() + 1) % divisor) == 0) != not;
            }

        }

        public override string GetUIText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if ((UnityEngine.Object)this.Feature == (UnityEngine.Object)null)
            {
                UberDebug.LogError((object)("Empty Feature fild in prerequisite component: " + this.name), (object[])Array.Empty<object>());
            }
            else
            {
                if (string.IsNullOrEmpty(this.Feature.Name))
                    UberDebug.LogError((object)string.Format("{0} has no Display Name", (object)this.Feature.name), (object[])Array.Empty<object>());
                stringBuilder.Append(this.Feature.Name);
            }

            if (not)
            {
                return $"Less than {divisor - 1} rank(s) of {stringBuilder.ToString()}";
            }
            else
            {
                return $"{divisor - 1} rank(s) of {stringBuilder.ToString()}";
            }
        }
    }


    public class PrerequisiteRace : Prerequisite
    {
        public BlueprintRace race;

        public override bool Check(
          FeatureSelectionState selectionState,
          UnitDescriptor unit,
          LevelUpState state)
        {
            return race == unit.Progression.Race;
        }

        public override string GetUIText()
        {
            return race.Name;
        }
    }


    public class PrerequisiteClassSpellbook : Prerequisite
    {
        public BlueprintCharacterClass character_class;

        public override bool Check(
          FeatureSelectionState selectionState,
          UnitDescriptor unit,
          LevelUpState state)
        {
            return unit.GetSpellbook(character_class) != null;
        }

        public override string GetUIText()
        {
            return character_class.Name + " Spellbook";
        }
    }



    public class addSpellBookLevel : OwnedGameLogicComponent<UnitDescriptor>, ILevelUpCompleteUIHandler
    {
        [JsonProperty]
        bool applied;
        public BlueprintCharacterClass character_class;

        public void HandleLevelUpComplete(UnitEntityData unit, bool isChargen)
        {
        }

        public override void OnFactActivate()
        {
            try
            {                
                var levelUp = Game.Instance.UI.CharacterBuildController.LevelUpController;
                if (Owner == levelUp.Preview || Owner == levelUp.Unit)
                {
                    applied = true;
                    var spellbook = this.Owner.GetSpellbook(character_class);
                    if (spellbook == null)
                    {
                        return;
                    }
                    int caster_level1 = spellbook.CasterLevel;
                    spellbook.AddCasterLevel();
                    int caster_level2 = spellbook.CasterLevel;
                    if (!spellbook.Blueprint.Spontaneous)
                    {
                        return;
                    }
                    //now let us try to add more spells if spellbook is spontaneous

                    var spell_selection = levelUp.State.DemandSpellSelection(spellbook.Blueprint, spellbook.Blueprint.SpellList);

                    if (spellbook.Blueprint.SpellsKnown != null)
                    {
                        for (int index = 0; index <= 9; ++index)
                        {
                            int? count1 = spellbook.Blueprint.SpellsKnown.GetCount(caster_level1, index);
                            int num1 = !count1.HasValue ? 0 : count1.Value;
                            int? count2 = spellbook.Blueprint.SpellsKnown.GetCount(caster_level2, index);
                            int num2 = !count2.HasValue ? 0 : count2.Value;
                            int existing_new_spells = spell_selection.LevelCount[index]?.SpellSelections.Length ?? 0;
                            spell_selection.SetLevelSpells(index, existing_new_spells + num2 - num1);
                        }
                    }                  
                }

            }
            catch (Exception e)
            {
                Main.logger.Error(e.ToString());
            }
        }
    }
}
