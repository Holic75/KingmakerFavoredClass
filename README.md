# Favored Class

This is a mod for Pathfinder:Kingmaker that adds favored class mechanics.

It is not compatible with favored class from Eldritch Arcana mod (you will normally get two favored classes - one from this mod and one from EA, so you probably might just pick some dummy class from one mod and use bonus from the other).

It adds the following options for favored class bonuses:
 - +1 HP/level
 - +1 skill point/2 levels
 - +1 round of rage/bloodrage/bard or skald performance/level for certain races
 - +1 bomb use per day/2 levels for gnome alchemist
 - +1 combat feat/rogue, slayer or wild talent/witch or shaman hex/magus arcana/6 levels for certain races
 - +1 monk ki pool/magus arcane pool/4 levels for certain races
 - +1 known spell of highest level-1/2 levels for alchemist/bard/inquisitor/sorceror/wizard/witch/skald for certain races
 - +1 known cleric spell of highes level-1/2 levels for half-elf, human or half-orc shaman
 - +1 luck bonus on saving throws/4 levels for animal companion of halfling druid or hunter
 - +1 DR/magic /2 levels for animal companion of gnome ranger or hunter
 - +1 to natural AC in wildshape/3 levels for elf or half-orc druid
 - +1 bonus to lay on hands healing/damage/2 levels for elf, halfling and gnome paladins
 - +1 bonus to lay on hands self healing/level for tiefling paladins
 - +1 bonus to channel energy healing or damage/3 levels for half-elf clerics and warpriests
 - +1 bonus to channel energy damage for purpose of harming undead/2 levels for aasimar clerics
 - +1 to damage of fire spells/2 levels for half orcs sorcerors or magi
 - +1 to damage of earth and acid spells/2 levels for dwarf sorcerors
 - +1 to earth elemental blasts damage/3 levels for dwarf kineticists
 - +1 to elemental blasts damage/4 levels for half-elf and elf kineticists
 - +1 to base speed/level for elf barbarians, bloodragers and monks
 - +1 to natural AC when using mutagen/4 levels for dwarf alchemists
 
It requires at least Call of the Wild 1.47.

This mod supposed to work with all classes that were introduced by other mods as long as it is loaded the last (should be by default).

For other modders: you can easily add favored class bonuses for your races/classes by providing a simple description file and placing it in /ZFavoredClass/Custom/,
 (there is already an example), you will need to specify:
- guid of the feature corresponding to the favored class bonus (ensure that it has enough ranks, do not use existing features, but rather create a copy of them, since blueprint will be altered)
- how many levels are needed to acquire the feature
- guid of the feature giving partial bonus (if there is any, otherwise leave it empty)
- guid of the class (due to guid generation process, if you want to use same bonus for different classes, you will need to supply full and partial features with different guids for each class)
- guid of races providing this favored class bonus


Install
- Download and install Unity Mod Manager﻿﻿ 0.13.0 or later
- Download the mod
- Build it using Visual Studio 2017 Community Edition or use prebuilt binaries from latest Releases (just drop archive into UMM GUI)
- Run the game
