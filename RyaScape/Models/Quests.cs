using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyaScape.Models {
  public class Quest {
    public string Name { get; set; }
    public List<Quest> PrerequisteQuests { get; } = new List<Quest>();
    public Dictionary<SkillTypes, int> PrerequisteSkills { get; } = new Dictionary<SkillTypes, int>();

    public Quest() {

    }

    public void SetPrequesite(Quest quest) {
      if (PrerequisteQuests.Contains(quest))
        return;
      PrerequisteQuests.Add(quest);
    }

    public void SetPrequesite(SkillTypes skill, int level) {
      if (PrerequisteSkills.ContainsKey(skill))
        PrerequisteSkills[skill] = level;
      else
        PrerequisteSkills.Add(skill, level);
    }
  }

  class Quests {
    private Dictionary<string, Quest> _quests = new Dictionary<string, Quest>();

    public Quests() {
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
        PrerequisteSkills = {
          { SkillTypes.Mining, 15 }
        },
      };

      var slayer = new Quest() {
        Name = "Slayer Slayer",
        PrerequisteSkills =
          {
                { SkillTypes.Attack, 45 },
                { SkillTypes.Construction, 42 }
            },
        PrerequisteQuests = { BlackKnightsFortress }
      };

      _quests.Add(BlackKnightsFortress.Name, BlackKnightsFortress);
      _quests.Add(CooksAssistant.Name, CooksAssistant);
      _quests.Add(DemonSlayer.Name, DemonSlayer);
      _quests.Add(DoricsQuest.Name, DoricsQuest);

      _quests.Add(slayer.Name, slayer);
    }

    public Dictionary<string, Quest> GetQuests() {
      return _quests;
    }
  }
}
