using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyaScape.Models
{
  public class Quest
  {
    public string Name { get; set; }
    public List<Quest> PrerequisteQuests { get; } = new List<Quest>();
    public Dictionary<SkillType, int> PrerequisteSkills { get; } = new Dictionary<SkillType, int>();
    public bool Completed { get; set; }

    public Quest()
    {

    }

    public void SetPrequesite(Quest quest)
    {
      if (PrerequisteQuests.Contains(quest))
        return;
      PrerequisteQuests.Add(quest);
    }

    public void SetPrequesite(SkillType skill, int level)
    {
      if (PrerequisteSkills.ContainsKey(skill))
        PrerequisteSkills[skill] = level;
      else
        PrerequisteSkills.Add(skill, level);
    }
  }

  class Quests
  {
    private Dictionary<string, Quest> _quests = new Dictionary<string, Quest>();

    public Quests()
    {
      #region MakeQuests

      var BlackKnightsFortress = new Quest() {
        Name = "Black Knights' Fortress",
      };

      var CooksAssistant = new Quest() {
        Name = "Cook's Assistant",
      };

      var DemonSlayer = new Quest() {
        Name = "Demon Slayer",
      };

      var DoricsQuest = new Quest() {
        Name = "Doric's Quest",
        PrerequisteSkills =
        {
          { SkillType.Mining, 15 }
        },
      };

      var DragonSlayer = new Quest() {
        Name = "Dragon Slayer",
        PrerequisteSkills =
        {
          { SkillType.Magic, 33 },
          { SkillType.Crafting, 8 }
        },
      };

      var ErnestTheChicken = new Quest() {
        Name = "Ernest the Chicken",
      };

      var GoblinDiplomacy = new Quest() {
        Name = "Goblin Diplomacy",
      };

      var ImpCatcher = new Quest() {
        Name = "Imp Catcher",
      };

      var TheKnightsSword = new Quest() {
        Name = "The Knight's Sword",
        PrerequisteSkills =
        {
          { SkillType.Mining, 10 },
          { SkillType.Cooking, 10 }
        },
      };

      var MisthalinMystery = new Quest() {
        Name = "Misthalin Mystery",
      };

      var PiratesTreasure = new Quest() {
        Name = "Pirate's Treasure",
      };

      var PrinceAliRescue = new Quest() {
        Name = "Prince Ali Rescue",
      };

      var TheRestlessGhost = new Quest() {
        Name = "The Restless Ghost",
      };

      var RomeoAndJuliet = new Quest() {
        Name = "Romeo & Juliet",
      };

      var RuneMysteries = new Quest() {
        Name = "Rune Mysteries",
      };

      var SheepShearer = new Quest() {
        Name = "Sheep Shearer",
      };

      var ShieldOfArrav = new Quest() {
        Name = "Shield of Arrav",
      };

      var VampireSlayer = new Quest() {
        Name = "Vampire Slayer",
      };

      var WitchsPotion = new Quest() {
        Name = "Witch's Potion",
      };

      var ClientOfKourend = new Quest() {
        Name = "Client of Kourend",
      };

      var ClockTower = new Quest() {
        Name = "Clock Tower",
      };

      var DeathPlateau = new Quest() {
        Name = "Death Plateau",
      };

      var DruidicRitual = new Quest() {
        Name = "Druidic Ritual",
      };

      var PriestInPeril = new Quest() {
        Name = "Priest in Peril",
      };

      var ColdWar = new Quest() {
        Name = "Cold War",
        PrerequisteSkills =
        {
          { SkillType.Hunter, 10 },
          { SkillType.Agility, 30 },
          { SkillType.Crafting, 30 },
          { SkillType.Construction, 34 },
          { SkillType.Thieving, 15 },
        },
      };

      var TheDigsite = new Quest() {
        Name = "The Digsite",
        PrerequisteSkills =
        {
          { SkillType.Agility, 10 },
          { SkillType.Herblore, 10 },
          { SkillType.Thieving, 25 },
        },
        PrerequisteQuests = { DruidicRitual }
      };

      var TheLostTribe = new Quest() {
        Name = "The Lost Tribe",
        PrerequisteSkills =
        {
          { SkillType.Agility, 13 },
          { SkillType.Thieving, 13 },
          { SkillType.Mining, 17 },
        },
        PrerequisteQuests = { GoblinDiplomacy, RuneMysteries }
      };

      var DeathToTheDorgeshuun = new Quest() {
        Name = "Death to the Dorgeshuun",
        PrerequisteSkills =
        {
          { SkillType.Agility, 23 },
          { SkillType.Thieving, 23 },
        },
        PrerequisteQuests = { TheLostTribe }
      };

      var AnimalMagnetism = new Quest() {
        Name = "Animal Magnetism",
        PrerequisteSkills =
        {
          { SkillType.Slayer, 18 },
          { SkillType.Crafting, 19 },
          { SkillType.Ranged, 30 },
          { SkillType.Woodcutting, 35 },
          { SkillType.Prayer, 31 },
        },
        PrerequisteQuests = { TheRestlessGhost, ErnestTheChicken, PriestInPeril }
      };

      var TheGiantDwarf = new Quest() {
        Name = "The Giant Dwarf",
        PrerequisteSkills =
        {
          { SkillType.Crafting, 12 },
          { SkillType.Firemaking, 16 },
          { SkillType.Magic, 33 },
          { SkillType.Thieving, 14 },
          { SkillType.Mining, 20 },
          { SkillType.Smithing, 20 },
        },
        PrerequisteQuests = { TheKnightsSword }
      };

      var AnotherSliceOfHAM = new Quest() {
        Name = "Another Slice of H.A.M.",
        PrerequisteSkills =
        {
          { SkillType.Attack, 15 },
          { SkillType.Prayer, 25 },
        },
        PrerequisteQuests = { DeathToTheDorgeshuun, TheGiantDwarf, TheDigsite }
      };

      var DwarfCannon = new Quest() {
        Name = "Dwarf Cannon",
      };

      var FishingContest = new Quest() {
        Name = "Fishing Contest",
        PrerequisteSkills =
        {
          { SkillType.Fishing, 10 },
        },
      };

      var BetweenARock = new Quest() {
        Name = "Between a Rock...",
        PrerequisteSkills =
        {
          { SkillType.Defence, 30 },
          { SkillType.Mining, 40 },
          { SkillType.Smithing, 50 },
        },
        PrerequisteQuests = { DwarfCannon, FishingContest }
      };

      var BigChompyBirdHunting = new Quest() {
        Name = "Big Chompy Bird Hunting",
        PrerequisteSkills =
        {
          { SkillType.Fletching, 5 },
          { SkillType.Cooking, 30 },
          { SkillType.Ranged, 30 },
        },
      };

      var PlagueCity = new Quest() {
        Name = "Plague City",
      };

      var Biohazard = new Quest() {
        Name = "Biohazard",
        PrerequisteQuests = { PlagueCity }
      };

      var JunglePotion = new Quest() {
        Name = "Jungle Potion",
        PrerequisteSkills =
        {
          { SkillType.Herblore, 3 },
        },
        PrerequisteQuests = { DruidicRitual }
      };

      var ZogreFleshEaters = new Quest() {
        Name = "Zogre Flesh Eaters",
        PrerequisteSkills =
        {
          { SkillType.Smithing, 4 },
          { SkillType.Herblore, 8 },
          { SkillType.Ranged, 30 },
          { SkillType.Fletching, 30 },
        },
        PrerequisteQuests = { BigChompyBirdHunting, JunglePotion }
      };

      var RumDeal = new Quest() {
        Name = "Rum Deal",
        PrerequisteSkills =
        {
          { SkillType.Crafting, 42 },
          { SkillType.Fishing, 50 },
          { SkillType.Farming, 40 },
          { SkillType.Prayer, 47 },
          { SkillType.Slayer, 42 },
        },
        PrerequisteQuests = { ZogreFleshEaters }
      };

      var CabinFever = new Quest() {
        Name = "Cabin Fever",
        PrerequisteSkills =
        {
          { SkillType.Agility, 42 },
          { SkillType.Crafting, 45 },
          { SkillType.Smithing, 50 },
          { SkillType.Ranged, 40 },
        },
        PrerequisteQuests = { PiratesTreasure, RumDeal, PriestInPeril }
      };

      var GertrudesCat = new Quest() {
        Name = "Gertrude's Cat",
      };

      var IcthlarinsLittleHelper = new Quest() {
        Name = "Icthlarin's Little Helper",
        PrerequisteQuests = { GertrudesCat }
      };

      var Contact = new Quest() {
        Name = "Contact!",
        PrerequisteQuests = { PrinceAliRescue, IcthlarinsLittleHelper, GertrudesCat }
      };

      var NatureSpirit = new Quest() {
        Name = "Nature Spirit",
        PrerequisteSkills =
        {
          { SkillType.Crafting, 18 },
        },
        PrerequisteQuests = { PriestInPeril, TheRestlessGhost }
      };

      var InSearchOfTheMyreque = new Quest() {
        Name = "In Search of the Myreque",
        PrerequisteSkills =
        {
          { SkillType.Agility, 25 },
        },
        PrerequisteQuests = { NatureSpirit }
      };

      var InAidOfTheMyreque = new Quest() {
        Name = "In Aid of the Myreque",
        PrerequisteSkills =
        {
          { SkillType.Mining, 15 },
          { SkillType.Crafting, 25 },
          { SkillType.Magic, 7 },
        },
        PrerequisteQuests = { InSearchOfTheMyreque, NatureSpirit }
      };

      var DarknessofHallowvale = new Quest() {
        Name = "Darkness of Hallowvale",
        PrerequisteSkills =
        {
          { SkillType.Construction, 5 },
          { SkillType.Mining, 20 },
          { SkillType.Thieving, 22 },
          { SkillType.Agility, 26 },
          { SkillType.Crafting, 32 },
          { SkillType.Magic, 33 },
          { SkillType.Strength, 40 },
        },
        PrerequisteQuests = { InAidOfTheMyreque }
      };

      var CreatureofFenkenstrain = new Quest() {
        Name = "Creature of Fenkenstrain",
        PrerequisteSkills =
        {
          { SkillType.Crafting, 20 },
          { SkillType.Thieving, 25 },
        },
        PrerequisteQuests = { PriestInPeril, TheRestlessGhost }
      };

      var RecruitmentDrive = new Quest() {
        Name = "Recruitment Drive",
        PrerequisteQuests = { BlackKnightsFortress, DruidicRitual }
      };

      var Wanted = new Quest() {
        Name = "Wanted!",
        PrerequisteQuests = { RecruitmentDrive, RuneMysteries, TheLostTribe, PriestInPeril }
      };

      var TrollStronghold = new Quest() {
        Name = "Troll Stronghold",
        PrerequisteSkills =
        {
        { SkillType.Agility, 15 },
          { SkillType.Thieving, 30 },
          { SkillType.Prayer, 43 },
        },
        PrerequisteQuests = { DeathPlateau }
      };

      var EnterTheAbyss = new Quest() {
        Name = "Enter the Abyss (miniquest)",
        PrerequisteQuests = { RuneMysteries }
      };

      var DeviousMinds = new Quest() {
        Name = "Devious Minds",
        PrerequisteSkills =
        {
        { SkillType.Smithing, 65 },
          { SkillType.Runecraft, 50 },
          { SkillType.Fletching, 50 },
        },
        PrerequisteQuests = { Wanted, TrollStronghold, DoricsQuest, EnterTheAbyss, RecruitmentDrive }
      };

      var TempleOfIkov = new Quest() {
        Name = "Temple of Ikov",
        PrerequisteSkills =
           {
          { SkillType.Thieving, 42 },
          { SkillType.Ranged, 40 },
        },
      };

      var TheTouristTrap = new Quest() {
        Name = "The Tourist Trap",
        PrerequisteSkills =
           {
          { SkillType.Fletching, 10 },
          { SkillType.Smithing, 20 },
        },
      };

      var WaterfallQuest = new Quest() {
        Name = "Waterfall Quest",
      };

      var DesertTreasure = new Quest() {
        Name = "Desert Treasure",
        PrerequisteSkills =
           {
          { SkillType.Thieving, 53 },
          { SkillType.Firemaking, 50 },
          { SkillType.Slayer, 10 },
          { SkillType.Magic, 50 },
        },
        PrerequisteQuests = { TheDigsite, TempleOfIkov, TheTouristTrap, TrollStronghold, PriestInPeril, WaterfallQuest }
      };

      var TheFremennikTrails = new Quest() {
        Name = "The Fremennik Trails",
        PrerequisteSkills =
           {
          { SkillType.Fletching, 25 },
          { SkillType.Woodcutting, 40 },
          { SkillType.Crafting, 40 },
        },
      };

      var LostCity = new Quest() {
        Name = "Lost City",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 31 },
          { SkillType.Woodcutting, 36 },
        },
      };

      var ShiloVillage = new Quest() {
        Name = "Shilo Village",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 20 },
          { SkillType.Agility, 32 },
          { SkillType.Smithing, 4 },
        },
        PrerequisteQuests = { JunglePotion }
      };

      var LunarDiplomacy = new Quest() {
        Name = "Lunar Diplomacy",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 61 },
          { SkillType.Defence, 40 },
          { SkillType.Firemaking, 49 },
          { SkillType.Herblore, 5 },
          { SkillType.Magic, 65 },
          { SkillType.Mining, 60 },
          { SkillType.Woodcutting, 55 },
        },
        PrerequisteQuests = { TheFremennikTrails, LostCity, RuneMysteries, ShiloVillage }
      };

      var EadgarsRuse = new Quest() {
        Name = "Eadgar's Ruse",
        PrerequisteSkills =
           {
          { SkillType.Herblore, 31 },
        },
        PrerequisteQuests = { DruidicRitual, TrollStronghold }
      };

      var DreamMentor = new Quest() {
        Name = "Dream Mentor",
        PrerequisteQuests = { LunarDiplomacy, EadgarsRuse }
      };

      var EaglesPeak = new Quest() {
        Name = "Eagles' Peak",
        PrerequisteSkills =
           {
          { SkillType.Hunter, 27 },
        },
      };

      var ElementalWorkshopI = new Quest() {
        Name = "Elemental Workshop I",
        PrerequisteSkills =
           {
          { SkillType.Mining, 20 },
          { SkillType.Smithing, 20 },
          { SkillType.Crafting, 20 },
        },
      };

      var ElementalWorkshopII = new Quest() {
        Name = "Elemental Workshop II",
        PrerequisteSkills =
           {
          { SkillType.Magic, 20 },
          { SkillType.Smithing, 30 },
        },
        PrerequisteQuests = { ElementalWorkshopI }
      };

      var EnakhrasLament = new Quest() {
        Name = "Enakhra's Lament",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 50 },
          { SkillType.Firemaking, 45 },
          { SkillType.Prayer, 43 },
          { SkillType.Magic, 39 },
          { SkillType.Mining, 45 },
        },
      };

      var EnlightenedJourney = new Quest() {
        Name = "Enlightened Journey",
        PrerequisteSkills =
           {
          { SkillType.Firemaking, 20 },
          { SkillType.Farming, 30 },
          { SkillType.Crafting, 36 },
        },
      };

      var TheGrandTree = new Quest() {
        Name = "The Grand Tree",
        PrerequisteSkills =
           {
          { SkillType.Agility, 25 },
        },
      };

      var TheEyesOfGlouphrie = new Quest() {
        Name = "The Eyes of Glouphrie",
        PrerequisteSkills =
           {
          { SkillType.Construction, 5 },
          { SkillType.Magic, 46 },
          { SkillType.Woodcutting, 45 },
        },
        PrerequisteQuests = { TheGrandTree }
      };

      var FairytaleI = new Quest() {
        Name = "Fairytale I - Growing Pains",
        PrerequisteQuests = { LostCity, NatureSpirit }
      };

      var FairytaleII = new Quest() {
        Name = "Fairytale II - Cure a Queen",
        PrerequisteSkills =
           {
          { SkillType.Thieving, 40 },
          { SkillType.Farming, 49 },
          { SkillType.Herblore, 57 },
        },
        PrerequisteQuests = { FairytaleI }
      };

      var FamilyCrest = new Quest() {
        Name = "Family Crest",
        PrerequisteSkills =
           {
          { SkillType.Mining, 40 },
          { SkillType.Smithing, 40 },
          { SkillType.Magic, 59 },
          { SkillType.Crafting, 40 },
        },
      };

      var FightArena = new Quest() {
        Name = "Fight Arena",
      };

      var TheFeud = new Quest() {
        Name = "The Feud",
        PrerequisteSkills =
           {
          { SkillType.Thieving, 30 },
        },
      };

      var ForgettableTale = new Quest() {
        Name = "Forgettable Tale...",
        PrerequisteSkills =
           {
          { SkillType.Cooking, 22 },
          { SkillType.Farming, 17 },
        },
        PrerequisteQuests = { TheGiantDwarf, FishingContest }
      };

      var TheFremennikIsles = new Quest() {
        Name = "The Fremennik Isles",
        PrerequisteSkills =
           {
          { SkillType.Construction, 20 },
          { SkillType.Agility, 40 },
          { SkillType.Woodcutting, 56 },
          { SkillType.Crafting, 46 },
        },
        PrerequisteQuests = { TheFremennikTrails }
      };

      var GardenOfTranquillity = new Quest() {
        Name = "Garden of Tranquillity",
        PrerequisteSkills =
           {
          { SkillType.Farming, 25 },
        },
        PrerequisteQuests = { CreatureofFenkenstrain }
      };

      var TheGolem = new Quest() {
        Name = "The Golem",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 20 },
          { SkillType.Thieving, 25 },
        },
      };

      var MurderMystery = new Quest() {
        Name = "Murder Mystery",
      };

      var WitchsHouse = new Quest() {
        Name = "Witch's House",
      };

      var ShadowOfTheStorm = new Quest() {
        Name = "Shadow of the Storm",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 30 },
        },
        PrerequisteQuests = { DemonSlayer, TheGolem }
      };

      var MerlinsCrystal = new Quest() {
        Name = "Merlin's Crystal",
      };

      var HeroesQuest = new Quest() {
        Name = "Heroes' Quest",
        PrerequisteSkills =
           {
          { SkillType.Cooking, 53 },
          { SkillType.Fishing, 53 },
          { SkillType.Herblore, 25 },
          { SkillType.Mining, 50 },
        },
        PrerequisteQuests = { ShieldOfArrav, LostCity, MerlinsCrystal, DragonSlayer, DruidicRitual }
      };

      var UndergroundPass = new Quest() {
        Name = "Underground Pass",
        PrerequisteSkills =
           {
          { SkillType.Ranged, 25 },
        },
        PrerequisteQuests = { Biohazard }
      };

      var LegendsQuest = new Quest() {
        Name = "Legends' Quest",
        PrerequisteSkills =
           {
          { SkillType.Agility, 50 },
          { SkillType.Crafting, 50 },
          { SkillType.Herblore, 45 },
          { SkillType.Magic, 56 },
          { SkillType.Mining, 52 },
          { SkillType.Prayer, 42 },
          { SkillType.Smithing, 50 },
          { SkillType.Strength, 50 },
          { SkillType.Thieving, 50 },
          { SkillType.Woodcutting, 50 },
        },
        PrerequisteQuests = { FamilyCrest, HeroesQuest, ShiloVillage, UndergroundPass, WaterfallQuest }
      };

      var TreeGnomeVillage = new Quest() {
        Name = "Tree Gnome Village",
      };

      var MonkeyMadness = new Quest() {
        Name = "Monkey Madness",
        PrerequisteQuests = { TheGrandTree, TreeGnomeVillage }
      };

      var AlfredGrimhandsBarcrawl = new Quest() {
        Name = "Alfred Grimhand's Barcrawl (Miniquest)",
      };

      var HorrorFromTheDeep = new Quest() {
        Name = "Horror From The Deep",
        PrerequisteSkills =
           {
          { SkillType.Agility, 35 },
        },
        PrerequisteQuests = { AlfredGrimhandsBarcrawl }
      };

      var RecipeForDisaster = new Quest() {
        Name = "Recipe For Disaster",
        PrerequisteSkills =
           {
          { SkillType.Cooking, 70 },
          { SkillType.Agility, 48 },
          { SkillType.Mining, 50 },
          { SkillType.Fishing, 53 },
          { SkillType.Thieving, 53 },
          { SkillType.Herblore, 25 },
          { SkillType.Magic, 59 },
          { SkillType.Smithing, 40 },
          { SkillType.Firemaking, 50 },
          { SkillType.Ranged, 40 },
          { SkillType.Crafting, 40 },
          { SkillType.Fletching, 10 },
          { SkillType.Slayer, 10 },
          { SkillType.Woodcutting, 36 },
        },
        PrerequisteQuests = { CooksAssistant, FishingContest, GoblinDiplomacy, BigChompyBirdHunting, MurderMystery, NatureSpirit, WitchsHouse, GertrudesCat, ShadowOfTheStorm, LegendsQuest, MonkeyMadness, DesertTreasure, HorrorFromTheDeep }
      };

      var TheGreatBrainRobbery = new Quest() {
        Name = "The Great Brain Robbery",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 16 },
          { SkillType.Construction, 30 },
          { SkillType.Prayer, 50 },
        },
        PrerequisteQuests = { CreatureofFenkenstrain, CabinFever, RumDeal, RecipeForDisaster }
      };

      var GhostsAhoy = new Quest() {
        Name = "Ghosts Ahoy",
        PrerequisteSkills =
           {
          { SkillType.Agility, 25 },
          { SkillType.Cooking, 20 },
        },
        PrerequisteQuests = { TheRestlessGhost, PriestInPeril }
      };

      var GrimTales = new Quest() {
        Name = "Grim Tales",
        PrerequisteSkills =
           {
          { SkillType.Farming, 45 },
          { SkillType.Herblore, 52 },
          { SkillType.Thieving, 58 },
          { SkillType.Agility, 59 },
          { SkillType.Woodcutting, 71 },
        },
        PrerequisteQuests = { WitchsHouse }
      };

      var TheHandInTheSand = new Quest() {
        Name = "The Hand in the Sand",
        PrerequisteSkills =
           {
          { SkillType.Thieving, 17 },
          { SkillType.Crafting, 49 },
        },
      };

      var HauntedMine = new Quest() {
        Name = "Haunted Mine",
        PrerequisteSkills =
           {
          { SkillType.Agility, 15 },
          { SkillType.Crafting, 35 },
        },
        PrerequisteQuests = { PriestInPeril }
      };

      var HazeelCult = new Quest() {
        Name = "Hazeel Cult",
      };

      var HolyGrail = new Quest() {
        Name = "Holy Grail",
        PrerequisteSkills =
           {
          { SkillType.Attack, 30 },
        },
        PrerequisteQuests = { MerlinsCrystal }
      };

      var OneSmallFavour = new Quest() {
        Name = "One Small Favour",
        PrerequisteSkills =
           {
          { SkillType.Agility, 36 },
          { SkillType.Crafting, 25 },
          { SkillType.Herblore, 18 },
          { SkillType.Smithing, 30 },
        },
        PrerequisteQuests = { RuneMysteries, ShiloVillage }
      };

      var KingsRansom = new Quest() {
        Name = "King's Ransom",
        PrerequisteSkills =
           {
          { SkillType.Magic, 45 },
          { SkillType.Defence, 65 },
        },
        PrerequisteQuests = { BlackKnightsFortress, HolyGrail, MerlinsCrystal, MurderMystery, OneSmallFavour }
      };

      var MakingHistory = new Quest() {
        Name = "Making History",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 24 },
          { SkillType.Mining, 40 },
          { SkillType.Smithing, 40 },
        },
        PrerequisteQuests = { TheRestlessGhost, PriestInPeril }
      };

      var MonksFriend = new Quest() {
        Name = "Monk's Friend",
      };

      var Watchtower = new Quest() {
        Name = "Watchtower",
        PrerequisteSkills =
           {
          { SkillType.Magic, 15 },
          { SkillType.Thieving, 15 },
          { SkillType.Agility, 25 },
          { SkillType.Herblore, 14 },
          { SkillType.Mining, 40 },
        },
      };

      var MonkeyMadnessII = new Quest() {
        Name = "Monkey Madness II",
        PrerequisteSkills =
           {
          { SkillType.Slayer, 69 },
          { SkillType.Crafting, 70 },
          { SkillType.Hunter, 60 },
          { SkillType.Agility, 55 },
          { SkillType.Thieving, 55 },
        },
        PrerequisteQuests = { EnlightenedJourney, TheEyesOfGlouphrie, RecipeForDisaster, TrollStronghold, Watchtower, MonkeyMadness }
      };

      var MountainDaughter = new Quest() {
        Name = "Mountain Daughter",
        PrerequisteSkills =
           {
          { SkillType.Agility, 20 },
        },
      };

      var Regicide = new Quest() {
        Name = "Regicide",
        PrerequisteSkills =
           {
          { SkillType.Agility, 56 },
          { SkillType.Crafting, 10 },
        },
        PrerequisteQuests = { UndergroundPass }
      };

      var RovingElves = new Quest() {
        Name = "Roving Elves",
        PrerequisteSkills =
           {
          { SkillType.Agility, 56 },
        },
        PrerequisteQuests = { Regicide, WaterfallQuest }
      };

      var SheepHerder = new Quest() {
        Name = "Sheep Herder",
      };

      var MourningsEndsPartI = new Quest() {
        Name = "Mourning's Ends Part I",
        PrerequisteSkills =
           {
          { SkillType.Ranged, 60 },
          { SkillType.Thieving, 50 },
        },
        PrerequisteQuests = { RovingElves, BigChompyBirdHunting, SheepHerder }
      };

      var MourningsEndsPartII = new Quest() {
        Name = "Mourning's Ends Part II",
        PrerequisteQuests = { MourningsEndsPartI }
      };

      var MyArmsBigAdventure = new Quest() {
        Name = "My Arm's Big Adventure",
        PrerequisteSkills =
           {
          { SkillType.Woodcutting, 10 },
          { SkillType.Farming, 29 },
        },
        PrerequisteQuests = { EadgarsRuse, TheFeud, JunglePotion }
      };

      var ObservatoryQuest = new Quest() {
        Name = "Observatory Quest",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 10 },
        },
      };

      var OlafsQuest = new Quest() {
        Name = "Olaf's Quest",
        PrerequisteSkills =
           {
          { SkillType.Firemaking, 40 },
          { SkillType.Woodcutting, 50 },
        },
        PrerequisteQuests = { TheFremennikTrails }
      };

      var RagAndBoneMan = new Quest() {
        Name = "Rag and Bone Man",
      };

      var Ratcatchers = new Quest() {
        Name = "Ratcatchers",
        PrerequisteQuests = { IcthlarinsLittleHelper }
      };

      var ThroneOfMiscellania = new Quest() {
        Name = "Throne of Miscellania",
        PrerequisteSkills =
           {
          { SkillType.Woodcutting, 45 },
          { SkillType.Farming, 10 },
          { SkillType.Herblore, 35 },
          { SkillType.Mining, 30 },
          { SkillType.Fishing, 35 },
        },
        PrerequisteQuests = { HeroesQuest, TheFremennikTrails }
      };

      var RoyalTrouble = new Quest() {
        Name = "Royal Trouble",
        PrerequisteSkills =
           {
          { SkillType.Agility, 40 },
          { SkillType.Slayer, 40 },
        },
        PrerequisteQuests = { ThroneOfMiscellania }
      };

      var ScorpionCatcher = new Quest() {
        Name = "Scorpion Catcher",
        PrerequisteSkills =
           {
          { SkillType.Prayer, 31 },
        },
        PrerequisteQuests = { AlfredGrimhandsBarcrawl }
      };

      var SeaSlug = new Quest() {
        Name = "Sea Slug",
        PrerequisteSkills =
           {
          { SkillType.Firemaking, 30 },
        },
      };

      var ShadesOfMortton = new Quest() {
        Name = "Shades of Mort'ton",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 20 },
          { SkillType.Herblore, 15 },
          { SkillType.Firemaking, 5 },
        },
        PrerequisteQuests = { PriestInPeril }
      };

      var TheSlugMenace = new Quest() {
        Name = "The Slug Menace",
        PrerequisteSkills =
           {
          { SkillType.Crafting, 30 },
          { SkillType.Runecraft, 30 },
          { SkillType.Slayer, 30 },
          { SkillType.Thieving, 30 },
        },
        PrerequisteQuests = { Wanted, SeaSlug }
      };

      var ASoulsBane = new Quest() {
        Name = "A Soul's Bane",
      };

      var SpiritsOfTheElid = new Quest() {
        Name = "Spirits of the Elid",
        PrerequisteSkills =
           {
          { SkillType.Magic, 33 },
          { SkillType.Ranged, 37 },
          { SkillType.Mining, 37 },
          { SkillType.Thieving, 37 },
        },
      };

      var SwanSong = new Quest() {
        Name = "Swan Song",
        PrerequisteSkills =
           {
          { SkillType.Magic, 66 },
          { SkillType.Cooking, 62 },
          { SkillType.Fishing, 62 },
          { SkillType.Smithing, 45 },
          { SkillType.Firemaking, 42 },
          { SkillType.Crafting, 40 }
        },
        PrerequisteQuests = { OneSmallFavour, GardenOfTranquillity }
      };

      var TaiBwoWannaiTrio = new Quest() {
        Name = "Tai Bwo Wannai Trio",
        PrerequisteSkills =
           {
          { SkillType.Agility, 15 },
          { SkillType.Cooking, 30 },
          { SkillType.Fishing, 5 },
        },
        PrerequisteQuests = { JunglePotion }
      };

      var ATailOfTwoCats = new Quest() {
        Name = "A Tale of Two Cats",
        PrerequisteQuests = { IcthlarinsLittleHelper }
      };

      var TearsOfGuthix = new Quest() {
        Name = "Tears of Guthix",
        PrerequisteSkills =
           {
          { SkillType.Firemaking, 49 },
          { SkillType.Crafting, 20 },
          { SkillType.Mining, 20 },
        },
      };

      var TowerOfLife = new Quest() {
        Name = "Tower of Life",
        PrerequisteSkills =
           {
          { SkillType.Construction, 10 },
        },
      };

      var TribalTotem = new Quest() {
        Name = "Tribal Totem",
        PrerequisteSkills =
           {
          { SkillType.Thieving, 21 },
        },
      };

      var TrollRomance = new Quest() {
        Name = "Troll Romance",
        PrerequisteSkills =
           {
          { SkillType.Agility, 25 },
        },
        PrerequisteQuests = { DeathPlateau, TrollStronghold }
      };

      var WhatLiesBelow = new Quest() {
        Name = "What Lies Below",
        PrerequisteSkills =
           {
          { SkillType.Runecraft, 35 },
          { SkillType.Mining, 42 },
        },
        PrerequisteQuests = { RuneMysteries }
      };

      var ArchitecturalAlliance = new Quest() {
        Name = "Architectural Alliance (Miniquest)",
        PrerequisteSkills =
           {
          { SkillType.Smithing, 45 },
          { SkillType.Mining, 42 },
          { SkillType.Fishing, 15 },
          { SkillType.Crafting, 30 },
          { SkillType.Hunter, 15 },
        },
      };

      var BearYourSoul = new Quest() {
        Name = "Bear your Soul (Miniquest)",
      };

      var CurseOfTheEmptyLord = new Quest() {
        Name = "Curse of the Empty Lord (Miniquest)",
        PrerequisteQuests = { DesertTreasure }
      };

      var EnchantedKey = new Quest() {
        Name = "Enchanted Key (Miniquest)",
        PrerequisteQuests = { MakingHistory }
      };
      
      var FamilyPest = new Quest() {
        Name = "Family Pest (Miniquest)",
        PrerequisteQuests = { FamilyCrest }
      };
      
      var TheGeneralsShadow = new Quest() {
        Name = "The General's Shadow (Miniquest)",
        PrerequisteQuests = { FightArena, CurseOfTheEmptyLord }
      };
      
      var LairOfTarnRazorlor = new Quest() {
        Name = "Lair of Tarn Razorlor (Miniquest)",
        PrerequisteSkills =
           {
          { SkillType.Slayer, 40 },
        },
        PrerequisteQuests = { HauntedMine }
      };
      
      var TheMageArena = new Quest() {
        Name = "The Mage Arena (Miniquest)",
        PrerequisteSkills =
           {
          { SkillType.Magic, 60 },
        },
      };

      var RagAndBoneWishList = new Quest() {
        Name = "Rag & Bone Wish List (Miniquest)",
        PrerequisteQuests = { RagAndBoneMan }
      };

      var SkippyAndTheMogres = new Quest() {
        Name = "Skippy and the Mogres (Miniquest)",
      };
      #endregion

      #region Add Quests to Dictionary
      //FreeQuests
      _quests.Add(BlackKnightsFortress.Name, BlackKnightsFortress);
      _quests.Add(CooksAssistant.Name, CooksAssistant);
      _quests.Add(DemonSlayer.Name, DemonSlayer);
      _quests.Add(DoricsQuest.Name, DoricsQuest);
      _quests.Add(DragonSlayer.Name, DragonSlayer);
      _quests.Add(ErnestTheChicken.Name, ErnestTheChicken);
      _quests.Add(GoblinDiplomacy.Name, GoblinDiplomacy);
      _quests.Add(ImpCatcher.Name, ImpCatcher);
      _quests.Add(TheKnightsSword.Name, TheKnightsSword);
      _quests.Add(MisthalinMystery.Name, MisthalinMystery);
      _quests.Add(PiratesTreasure.Name, PiratesTreasure);
      _quests.Add(PrinceAliRescue.Name, PrinceAliRescue);
      _quests.Add(TheRestlessGhost.Name, TheRestlessGhost);
      _quests.Add(RomeoAndJuliet.Name, RomeoAndJuliet);
      _quests.Add(RuneMysteries.Name, RuneMysteries);
      _quests.Add(SheepShearer.Name, SheepShearer);
      _quests.Add(ShieldOfArrav.Name, ShieldOfArrav);
      _quests.Add(VampireSlayer.Name, VampireSlayer);
      _quests.Add(WitchsPotion.Name, WitchsPotion);
      //MemberQuests
      _quests.Add(AnimalMagnetism.Name, AnimalMagnetism);
      _quests.Add(AnotherSliceOfHAM.Name, AnotherSliceOfHAM);
      _quests.Add(BetweenARock.Name, BetweenARock);
      _quests.Add(BigChompyBirdHunting.Name, BigChompyBirdHunting);
      _quests.Add(Biohazard.Name, Biohazard);
      _quests.Add(CabinFever.Name, CabinFever);
      _quests.Add(ClientOfKourend.Name, ClientOfKourend);
      _quests.Add(ClockTower.Name, ClockTower);
      _quests.Add(ColdWar.Name, ColdWar);
      _quests.Add(Contact.Name, Contact);
      _quests.Add(CreatureofFenkenstrain.Name, CreatureofFenkenstrain);
      _quests.Add(DarknessofHallowvale.Name, DarknessofHallowvale);
      _quests.Add(DeathPlateau.Name, DeathPlateau);
      _quests.Add(DeathToTheDorgeshuun.Name, DeathToTheDorgeshuun);
      _quests.Add(DesertTreasure.Name, DesertTreasure);
      _quests.Add(DeviousMinds.Name, DeviousMinds);
      _quests.Add(TheDigsite.Name, TheDigsite);
      _quests.Add(DreamMentor.Name, DreamMentor);
      _quests.Add(DruidicRitual.Name, DruidicRitual);
      _quests.Add(DwarfCannon.Name, DwarfCannon);
      _quests.Add(EadgarsRuse.Name, EadgarsRuse);
      _quests.Add(EaglesPeak.Name, EaglesPeak);
      _quests.Add(ElementalWorkshopI.Name, ElementalWorkshopI);
      _quests.Add(ElementalWorkshopII.Name, ElementalWorkshopII);
      _quests.Add(EnakhrasLament.Name, EnakhrasLament);
      _quests.Add(EnlightenedJourney.Name, EnlightenedJourney);
      _quests.Add(TheEyesOfGlouphrie.Name, TheEyesOfGlouphrie);
      _quests.Add(FairytaleI.Name, FairytaleI);
      _quests.Add(FairytaleII.Name, FairytaleII);
      _quests.Add(FamilyCrest.Name, FamilyCrest);
      _quests.Add(FightArena.Name, FightArena);
      _quests.Add(TheFeud.Name, TheFeud);
      _quests.Add(FishingContest.Name, FishingContest);
      _quests.Add(ForgettableTale.Name, ForgettableTale);
      _quests.Add(TheFremennikIsles.Name, TheFremennikIsles);
      _quests.Add(TheFremennikTrails.Name, TheFremennikTrails);
      _quests.Add(GardenOfTranquillity.Name, GardenOfTranquillity);
      _quests.Add(GertrudesCat.Name, GertrudesCat);
      _quests.Add(TheGiantDwarf.Name, TheGiantDwarf);
      _quests.Add(TheGolem.Name, TheGolem);
      _quests.Add(TheGrandTree.Name, TheGrandTree);
      _quests.Add(TheGreatBrainRobbery.Name, TheGreatBrainRobbery);
      _quests.Add(GhostsAhoy.Name, GhostsAhoy);
      _quests.Add(GrimTales.Name, GrimTales);
      _quests.Add(TheHandInTheSand.Name, TheHandInTheSand);
      _quests.Add(HauntedMine.Name, HauntedMine);
      _quests.Add(HazeelCult.Name, HazeelCult);
      _quests.Add(HeroesQuest.Name, HeroesQuest);
      _quests.Add(HolyGrail.Name, HolyGrail);
      _quests.Add(HorrorFromTheDeep.Name, HorrorFromTheDeep);
      _quests.Add(IcthlarinsLittleHelper.Name, IcthlarinsLittleHelper);
      _quests.Add(InAidOfTheMyreque.Name, InAidOfTheMyreque);
      _quests.Add(InSearchOfTheMyreque.Name, InSearchOfTheMyreque);
      _quests.Add(JunglePotion.Name, JunglePotion);
      _quests.Add(KingsRansom.Name, KingsRansom);
      _quests.Add(LegendsQuest.Name, LegendsQuest);
      _quests.Add(LostCity.Name, LostCity);
      _quests.Add(TheLostTribe.Name, TheLostTribe);
      _quests.Add(LunarDiplomacy.Name, LunarDiplomacy);
      _quests.Add(MakingHistory.Name, MakingHistory);
      _quests.Add(MerlinsCrystal.Name, MerlinsCrystal);
      _quests.Add(MonksFriend.Name, MonksFriend);
      _quests.Add(MonkeyMadness.Name, MonkeyMadness);
      _quests.Add(MonkeyMadnessII.Name, MonkeyMadnessII);
      _quests.Add(MountainDaughter.Name, MountainDaughter);
      _quests.Add(MourningsEndsPartI.Name, MourningsEndsPartI);
      _quests.Add(MourningsEndsPartII.Name, MourningsEndsPartII);
      _quests.Add(MurderMystery.Name, MurderMystery);
      _quests.Add(MyArmsBigAdventure.Name, MyArmsBigAdventure);
      _quests.Add(NatureSpirit.Name, NatureSpirit);
      _quests.Add(ObservatoryQuest.Name, ObservatoryQuest);
      _quests.Add(OlafsQuest.Name, OlafsQuest);
      _quests.Add(OneSmallFavour.Name, OneSmallFavour);
      _quests.Add(PlagueCity.Name, PlagueCity);
      _quests.Add(PriestInPeril.Name, PriestInPeril);
      _quests.Add(RagAndBoneMan.Name, RagAndBoneMan);
      _quests.Add(Ratcatchers.Name, Ratcatchers);
      _quests.Add(RecipeForDisaster.Name, RecipeForDisaster);
      _quests.Add(RecruitmentDrive.Name, RecruitmentDrive);
      _quests.Add(Regicide.Name, Regicide);
      _quests.Add(RovingElves.Name, RovingElves);
      _quests.Add(RoyalTrouble.Name, RoyalTrouble);
      _quests.Add(RumDeal.Name, RumDeal);
      _quests.Add(ScorpionCatcher.Name, ScorpionCatcher);
      _quests.Add(SeaSlug.Name, SeaSlug);
      _quests.Add(ShadesOfMortton.Name, ShadesOfMortton);
      _quests.Add(ShadowOfTheStorm.Name, ShadowOfTheStorm);
      _quests.Add(SheepHerder.Name, SheepHerder);
      _quests.Add(ShiloVillage.Name, ShiloVillage);
      _quests.Add(TheSlugMenace.Name, TheSlugMenace);
      _quests.Add(ASoulsBane.Name, ASoulsBane);
      _quests.Add(SpiritsOfTheElid.Name, SpiritsOfTheElid);
      _quests.Add(SwanSong.Name, SwanSong);
      _quests.Add(TaiBwoWannaiTrio.Name, TaiBwoWannaiTrio);
      _quests.Add(ATailOfTwoCats.Name, ATailOfTwoCats);
      _quests.Add(TearsOfGuthix.Name, TearsOfGuthix);
      _quests.Add(TempleOfIkov.Name, TempleOfIkov);
      _quests.Add(TheTouristTrap.Name, TheTouristTrap);
      _quests.Add(ThroneOfMiscellania.Name, ThroneOfMiscellania);
      _quests.Add(TowerOfLife.Name, TowerOfLife);
      _quests.Add(TreeGnomeVillage.Name, TreeGnomeVillage);
      _quests.Add(TribalTotem.Name, TribalTotem);
      _quests.Add(TrollRomance.Name, TrollRomance);
      _quests.Add(TrollStronghold.Name, TrollStronghold);
      _quests.Add(UndergroundPass.Name, UndergroundPass);
      _quests.Add(Wanted.Name, Wanted);
      _quests.Add(Watchtower.Name, Watchtower);
      _quests.Add(WaterfallQuest.Name, WaterfallQuest);
      _quests.Add(WhatLiesBelow.Name, WhatLiesBelow);
      _quests.Add(WitchsHouse.Name, WitchsHouse);
      _quests.Add(ZogreFleshEaters.Name, ZogreFleshEaters);
      //MiniQuests
      _quests.Add(AlfredGrimhandsBarcrawl.Name, AlfredGrimhandsBarcrawl);
      _quests.Add(ArchitecturalAlliance.Name, ArchitecturalAlliance);
      _quests.Add(BearYourSoul.Name, BearYourSoul);
      _quests.Add(CurseOfTheEmptyLord.Name, CurseOfTheEmptyLord);
      _quests.Add(EnchantedKey.Name, EnchantedKey);
      _quests.Add(EnterTheAbyss.Name, EnterTheAbyss);
      _quests.Add(FamilyPest.Name, FamilyPest);
      _quests.Add(TheGeneralsShadow.Name, TheGeneralsShadow);
      _quests.Add(LairOfTarnRazorlor.Name, LairOfTarnRazorlor);
      _quests.Add(TheMageArena.Name, TheMageArena);
      _quests.Add(RagAndBoneWishList.Name, RagAndBoneWishList);
      _quests.Add(SkippyAndTheMogres.Name, SkippyAndTheMogres);
      #endregion
    }

    public Dictionary<string, Quest> GetQuests()
    {
      return _quests;
    }
  }
}
