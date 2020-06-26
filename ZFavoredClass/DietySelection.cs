using CallOfTheWild;
using Kingmaker.Blueprints;
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
            //fixCompanions();
        }


        static void fixCompanions()
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

            addDeityToCompanion(amiri1_feature.GetComponent<AddClassLevels>(), ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("8f49a5d8528a82c44b8c117a89f6b68c"));//gorum
            addDeityToCompanion(linzi_feature.GetComponent<AddClassLevels>(), ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("b382afa31e4287644b77a8b30ed4aa0b"));//shaelyn
            //addDeityToCompanion(kanerah_feature.GetComponent<AddClassLevels>(), ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("6262cfce7c31626458325ca0909de997"));//nethys
            //addDeityToCompanion(kalikke_feature.GetComponent<AddClassLevels>(), ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("6262cfce7c31626458325ca0909de997"));//nethys
            addDeityToCompanion(octavia_feature.GetComponent<AddClassLevels>(), ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("c7531715a3f046d4da129619be63f44c"));//callistria
            addDeityToCompanion(regongar_feature.GetComponent<AddClassLevels>(), ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("c7531715a3f046d4da129619be63f44c"));//callistria
            //nok-nok should have lamashtu
            //jubilost
            //jaethal - first uragathoa
            //varn ?
            addDeityToCompanion(ekun_feature.GetComponent<AddClassLevels>(), ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("d2d5c5a58885a6b489727467e13c3337"));//torag
            addDeityToCompanion(cephal_feature.GetComponent<AddClassLevels>(), ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("a3a5ccc9c670e6f4ca4a686d23b89900"));//asmodeus
        }


        static void addDeityToCompanion(AddClassLevels add_classLevels, BlueprintFeature deity)
        {
            var deity_selection = new SelectionEntry();
            deity_selection.Selection = ResourcesLibrary.TryGetBlueprint<BlueprintFeatureSelection>("59e7a76987fe3b547b9cce045f4db3e4");
            deity_selection.Features = new BlueprintFeature[] { deity };
      
            add_classLevels.Selections = add_classLevels.Selections.AddToArray(deity_selection);
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
