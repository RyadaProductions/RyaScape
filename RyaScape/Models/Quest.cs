using System.Collections.Generic;
namespace RyaScape.Models
{
    public class Quest
    {
        public string Name { get; set; }
        public List<Quest> PrerequisteQuests { get; } = new List<Quest>();
        public Dictionary<SkillTypes, int> PrerequisteSkills { get; } = new Dictionary<SkillTypes, int>();
        public bool Completed { get; set; }
    }
}
