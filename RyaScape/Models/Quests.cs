using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RyaScape.Models
{
    public class Quest
    {
        public string Name { get; set; }
        public List<Quest> PrerequisteQuests { get; } = new List<Quest>();
        public Dictionary<SkillType, int> PrerequisteSkills { get; } = new Dictionary<SkillType, int>();
        public bool Completed { get; set; }
    }

    internal class Quests
    {
        private readonly Dictionary<string, Quest> _quests = new Dictionary<string, Quest>();

        public Quests()
        {
            if (!File.Exists(Environment.CurrentDirectory + "\\Resources\\Quests.json")) return;
            var input = File.ReadAllText(Environment.CurrentDirectory + "\\Resources\\Quests.json");
            var desList = JsonConvert.DeserializeObject<Dictionary<string, Quest>>(input);
            _quests = desList;
        }

        public Dictionary<string, Quest> GetQuests()
        {
            return _quests;
        }
    }
}
