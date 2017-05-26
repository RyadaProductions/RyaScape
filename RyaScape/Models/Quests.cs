using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
  }

  class Quests
  {
    private Dictionary<string, Quest> _quests = new Dictionary<string, Quest>();

    public Quests()
    {
      if (File.Exists(Environment.CurrentDirectory + "\\Resources\\Quests.json")) {
        string input = File.ReadAllText(Environment.CurrentDirectory + "\\Resources\\Quests.json");
        var desList = JsonConvert.DeserializeObject<Dictionary<string, Quest>>(input);
        _quests = desList;
      }
    }

    public Dictionary<string, Quest> GetQuests()
    {
      return _quests;
    }
  }
}
