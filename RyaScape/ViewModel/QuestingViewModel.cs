using NanoMVVM.ViewModels;
using RyaScape.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RyaScape.ViewModel {
  public class QuestingViewModel : BaseViewModel {
    public ObservableCollection<QuestViewModel> QuestList { get; } = new ObservableCollection<QuestViewModel>();

    public QuestingViewModel() {
      Load();
    }

    public void Load() {
      var loader = new Quests();
      Dictionary<string, Quest> tempquestList = loader.GetQuests();

      QuestList.Clear();
      foreach (var X in tempquestList) {
        List<Requirements> Questrequirements = new List<Requirements>();
        
        foreach (var skill in X.Value.PrerequisteSkills) {
          if (PlayerStats.Player[skill.Key].Level >= skill.Value) {
            Requirements req = new Requirements { RequirementName = skill.Value.ToString() + " " + skill.Key.ToString(),
            RequirementStatus = "Strikethrough"};
            Questrequirements.Add(req);
          } else {
            Requirements req = new Requirements {
              RequirementName = skill.Value.ToString() + " " + skill.Key.ToString(),
              RequirementStatus = ""
            };
            Questrequirements.Add(req);
          }
        }
        if (X.Value.PrerequisteQuests.Count > 0) {
          Requirements req = new Requirements {
            RequirementName = "",
            RequirementStatus = ""
          };
          Questrequirements.Add(req);
        }
        foreach (var quests in X.Value.PrerequisteQuests) {
          Requirements req = new Requirements {
            RequirementName = quests.Name,
            RequirementStatus = ""
          };
          Questrequirements.Add(req);
        }


        QuestList.Add(new QuestViewModel {
          Name = X.Value.Name,
          PrerequisteQuests = X.Value.PrerequisteQuests,
          PrerequisteSkills = X.Value.PrerequisteSkills,
          Requirements = Questrequirements
        });
      }
    }
  }
}
