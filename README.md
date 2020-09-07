# Favored Class

This is a mod for Pathfinder:Kingmaker that adds favored class mechanics and traits and archetype stacking.

It is not compatible with favored class from Eldritch Arcana mod.

It adds the following options for favored class bonuses:
 - +1 HP/level
 - +1 skill point/2 levels
 - +1 round of rage/bloodrage/bard or skald performance/level for certain races
 - +1 bomb use per day/2 levels for gnome or hobgoblin alchemist
 - +1 combat feat/rogue, slayer or wild talent/witch or shaman hex/magus arcana/arcane exploit/teamwork feat/6 levels for certain races
 - +1 monk ki pool/magus arcane pool/4 levels for certain races
 - +1 known spell of highest level-1/2 levels for alchemist/bard/inquisitor/sorceror/wizard/witch/skald/arcanist/oracle/investigator for certain races
 - +1 known cleric spell of highest level-1/2 levels for half-elf, human or half-orc shaman
 - +1 known oracle/wizard spell of enchantment school of highest level-1/2 levels for ganzi oracles
 - +1 known sorcerer spell with fire descriptor of highest level-1/2 levels for goblin sorcerers
 - +1 luck bonus on saving throws/4 levels for animal companion of halfling druid or hunter
 - +1 DR/magic /2 levels for animal companion of gnome or fetchling ranger or hunter
 - +1 to natural AC in wildshape/3 levels for elf or half-orc druid
 - +1 bonus to lay on hands healing/damage/2 levels for elf, halfling and gnome paladins
 - +1 bonus to fervor healing/damage/2 levels for drow warpriests
 - +1 bonus to lay on hands self healing/level for tiefling paladins
 - +1 bonus to channel energy healing or damage/3 levels for half-elf clerics and warpriests
 - +1 bonus to channel energy damage for purpose of harming undead/2 levels for aasimar clerics
 - +1 to damage of negative energy spells/2 levels for hobgoblin or fetchling clerics or dhampir oracles
 - +1 to damage of fire spells/2 levels for half orcs sorcerers or magi
 - +1 to damage of earth and acid spells/2 levels for dwarf sorcerers
 - +1 to earth elemental blasts damage/3 levels for dwarf kineticists
 - +1 to elemental blasts damage/4 levels for half-elf and elf kineticists
 - +1 to base speed/level for elf barbarians, bloodragers and monks
 - +1 to natural AC when using mutagen/4 levels for dwarf alchemists
 - +1 to number of internal buffer uses/6 levels for halfling kineticists
 - +1 to maximum number of arcane reservoir points/level for elf or half-elf arcanists
 - +1 to aracane reservoir point restored after rest/6 levels for gnome arcanists
 - +1 to investigator inspiration pool/3 levels for for elf, ganzi or half-elf investigators,
 - +1 to Eidolon evolution pool/6 levels for half-elf summoners,
 - +1 DR/evil /2 levels for eidolon of aasimar summoner,
 - +1 bonus to natural AC of eidolon/4 levels for dwarf summoners,
 - +1 energy resistance to specific energy type/level for certain classes and races,
 - +1 caster level for necromancy school spells/4 levels for drow wizards,
 - +1 caster level for patron spells/4 levels for halfling witches,
 - +1 judgment use per day/6 levels for duergar inquisitors,
 - +1 disarm cmb bonus/3 levels for drow fighters,
 - +1 trip and grapple cmb bonus/4 levels for hobgoblin monks,
 - +1 to dodge bonus against favored enemies/4 levels for halfling rangers,
 - +1 to dodge bonus against studied targets/4 levels for halfling and fetchling slayers,
 - +1 to attack bonus against one favored enemy/4 levels for hobgoblin rangers.
 
Other features:
- Everyone can select a Deity (optional),
- Everyone can select 2 traits at character creation (optional),
- It is possible to stack up to 2 compatible archetypes.
 
 
It also add following feats:
- Additional Traits (if traits are enabled),
- Favored Prestige Class (due to technical reasons should always be taken before taking first level in corresponding prestige class)
- Prestigious Spellcaster (again due to technical reasons can be taken only after you select a spellbook to advance with corresponding prestige class,
also it will not work if it is taken for spontaneous caster advancing prestige class and you get to select new spells known from some other spontaneous casting class,
i.e. if you have eldritch knight advancing sorcerer spellcasting, you can not take the feat during a level up for let's say inquisitor class)

It requires at least Call of the Wild 1.102.

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
