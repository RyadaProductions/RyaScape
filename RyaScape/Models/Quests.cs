﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RyaScape.Models
{
    internal class Quests
    {
        public Dictionary<string, Quest> LoadQuests()
        {
            if (!File.Exists(Environment.CurrentDirectory + "\\Resources\\Quests.json")) return new Dictionary<string, Quest>();
            var input = File.ReadAllText(Environment.CurrentDirectory + "\\Resources\\Quests.json");
            var desList = JsonConvert.DeserializeObject<Dictionary<string, Quest>>(input);
            return desList;
        }
    }
}
