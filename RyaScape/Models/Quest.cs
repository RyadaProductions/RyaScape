using System.Collections.Generic;
namespace RyaScape.Models
{
    public class Quest
    {
        public string Name { get; set; }
        public List<Quest> PrerequisiteQuests { get; } = new List<Quest>();
        public Dictionary<SkillTypes, int> PrerequisiteSkills { get; } = new Dictionary<SkillTypes, int>();
        public bool Completed { get; set; }
    }
}
