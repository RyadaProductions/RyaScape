using System.Collections.Generic;

namespace RyaScape.Models
{
  public static class PlayerStats
  {
    public static string PlayerName = "";

    public static Dictionary<SkillType, Skill> Player = new Dictionary<SkillType, Skill>
    {
      [SkillType.Total] = new Skill(),
      [SkillType.Attack] = new Skill(),
      [SkillType.Defence] = new Skill(),
      [SkillType.Strength] = new Skill(),
      [SkillType.Hitpoints] = new Skill(),
      [SkillType.Ranged] = new Skill(),
      [SkillType.Prayer] = new Skill(),
      [SkillType.Magic] = new Skill(),
      [SkillType.Cooking] = new Skill(),
      [SkillType.Woodcutting] = new Skill(),
      [SkillType.Fletching] = new Skill(),
      [SkillType.Fishing] = new Skill(),
      [SkillType.Firemaking] = new Skill(),
      [SkillType.Crafting] = new Skill(),
      [SkillType.Smithing] = new Skill(),
      [SkillType.Mining] = new Skill(),
      [SkillType.Herblore] = new Skill(),
      [SkillType.Agility] = new Skill(),
      [SkillType.Thieving] = new Skill(),
      [SkillType.Slayer] = new Skill(),
      [SkillType.Farming] = new Skill(),
      [SkillType.Runecraft] = new Skill(),
      [SkillType.Hunter] = new Skill(),
      [SkillType.Construction] = new Skill()
    };
  }
}