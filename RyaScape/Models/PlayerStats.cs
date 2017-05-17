using System.Collections.Generic;

namespace RyaScape.Models {
  public static class PlayerStats {
    public static string PlayerName = "";

    public static Dictionary<SkillTypes, Skill> Player = new Dictionary<SkillTypes, Skill>() {
      [SkillTypes.Total] = new Skill(),
      [SkillTypes.Attack] = new Skill(),
      [SkillTypes.Defence] = new Skill(),
      [SkillTypes.Strength] = new Skill(),
      [SkillTypes.Hitpoints] = new Skill(),
      [SkillTypes.Ranged] = new Skill(),
      [SkillTypes.Prayer] = new Skill(),
      [SkillTypes.Magic] = new Skill(),
      [SkillTypes.Cooking] = new Skill(),
      [SkillTypes.Woodcutting] = new Skill(),
      [SkillTypes.Fletching] = new Skill(),
      [SkillTypes.Fishing] = new Skill(),
      [SkillTypes.Firemaking] = new Skill(),
      [SkillTypes.Crafting] = new Skill(),
      [SkillTypes.Smithing] = new Skill(),
      [SkillTypes.Mining] = new Skill(),
      [SkillTypes.Herblore] = new Skill(),
      [SkillTypes.Agility] = new Skill(),
      [SkillTypes.Thieving] = new Skill(),
      [SkillTypes.Slayer] = new Skill(),
      [SkillTypes.Farming] = new Skill(),
      [SkillTypes.Runecraft] = new Skill(),
      [SkillTypes.Hunter] = new Skill(),
      [SkillTypes.Construction] = new Skill()
    };
  }
}