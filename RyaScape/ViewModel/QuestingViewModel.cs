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
          Requirements req = new Requirements();

          req.RequirementName = skill.Value.ToString() + " " + skill.Key.ToString();

          if (PlayerStats.Player[skill.Key].Level >= skill.Value) {
            req.RequirementStatus = "Strikethrough";
          } else {
            req.RequirementStatus = "";
          }
          Questrequirements.Add(req);
        }

        if (X.Value.PrerequisteQuests.Count > 0) {
          Requirements req = new Requirements();
          Questrequirements.Add(req);
        }

        foreach (var quests in X.Value.PrerequisteQuests) {
          Requirements req = new Requirements();

          req.RequirementName = quests.Name;

          if (quests.Completed == true) {
            req.RequirementStatus = "Strikethrough";
          } else {
            req.RequirementStatus = "";
          }
          Questrequirements.Add(req);
        }

        QuestList.Add(new QuestViewModel {
          Name = X.Value.Name,
          Completed = X.Value.Completed,
          PrerequisteQuests = X.Value.PrerequisteQuests,
          PrerequisteSkills = X.Value.PrerequisteSkills,
          Requirements = Questrequirements
        });
      }
    }
  }
}
