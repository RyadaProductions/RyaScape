using System;
using System.Collections.Generic;
using System.Linq;
namespace RyaScape.Models
{
    public class Quest
    {
        public string Name { get; set; }
        public List<Quest> PrerequisteQuests { get; } = new List<Quest>();
        public Dictionary<SkillType, int> PrerequisteSkills { get; } = new Dictionary<SkillType, int>();
        public bool Completed { get; set; }
    }
}
