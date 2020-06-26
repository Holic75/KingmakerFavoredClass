using CallOfTheWild;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFavoredClass
{
    class DietySelection
    {
        internal static void run()
        {
             addDietySelectionToEveryone();
        }


        static void addDietySelectionToEveryone()
        {
            var atheism = Main.library.Get<BlueprintFeature>("92c0d2da0a836ce418a267093c09ca54");
            var deity = Main.library.Get<BlueprintFeatureSelection>("59e7a76987fe3b547b9cce045f4db3e4");

            deity.AllFeatures = deity.AllFeatures.AddToArray(atheism);

            var forbidden_classes = new BlueprintCharacterClass[]
            {
            Main.library.Get<BlueprintCharacterClass>("f5b8c63b141b2f44cbb8c2d7579c34f5"), //eldritch scion
            Main.library.Get<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920"),
            CallOfTheWild.Eidolon.eidolon_class
            };

            var classes = Main.library.Root.Progression.CharacterClasses.Where(c => !forbidden_classes.Contains(c) && !c.Archetypes.Empty() || c == VindicativeBastard.vindicative_bastard_class).ToList();
            foreach (var c in classes)
            {
                if (hasDietySelection(c.Progression.LevelEntries))
                {//already has diety
                    atheism.AddComponent(Helpers.Create<PrerequisiteNoClassLevel>(p => p.CharacterClass = c));
                    continue;
                }

                c.Progression.LevelEntries[0].Features.Add(deity);

                foreach (var a in c.Archetypes)
                {
                    if (!hasDietySelection(a.AddFeatures))
                    {
                        continue;
                    }
                    atheism.AddComponent(Common.prerequisiteNoArchetype(a));
                    if (a.RemoveFeatures.Empty() || a.RemoveFeatures[0].Level != 1)
                    {
                        a.RemoveFeatures = new LevelEntry[] { Helpers.LevelEntry(1, deity) }.AddToArray(a.RemoveFeatures);
                    }
                    else
                    {
                        a.RemoveFeatures[0].Features.Add(deity);
                    }
                }
            }
        }


        static bool hasDietySelection(LevelEntry[] level_entries)
        {
            foreach (var le in level_entries)
            {
                if (le.Features.Any(f =>
                {
                    var selection = (f as BlueprintFeatureSelection);
                    return selection != null && selection.Group == FeatureGroup.Deities;
                }
                                    ))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
