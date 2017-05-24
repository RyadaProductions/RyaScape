using NanoMVVM.ViewModels;
using RyaScape.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Linq;

namespace RyaScape.ViewModel
{
  public class QuestingViewModel : BaseViewModel
  {
    public ObservableCollection<QuestViewModel> QuestList { get; } = new ObservableCollection<QuestViewModel>();

    public QuestingViewModel()
    {
      Load();
    }

    //public ICommand UpdateCommand => new DelegateCommand(Update);

    public void Update(object sender, PropertyChangedEventArgs e)
    {
      foreach (var Questvm in QuestList)
      {
        Questvm.Requirements.Clear();

        foreach (var skill in Questvm.PrerequisteSkills)
        {
          Requirements req = new Requirements();

          req.RequirementName = skill.Value.ToString() + " " + skill.Key.ToString();
          req.RequirementStatus = PlayerStats.Player[skill.Key].Level >= skill.Value ? TextDecorations.Strikethrough : null;

          Questvm.Requirements.Add(req);
        }

        if (Questvm.PrerequisteQuests.Count > 0)
        {
          Requirements req = new Requirements();
          Questvm.Requirements.Add(req);
        }

        foreach (var quest in Questvm.PrerequisteQuests)
        {
          var tmpQuest = QuestList.FirstOrDefault(x => x.Name == quest.Name);

          Requirements req = new Requirements();

          req.RequirementName = tmpQuest.Name;
          req.RequirementStatus = tmpQuest.Completed == true ? TextDecorations.Strikethrough : null;

          Questvm.Requirements.Add(req);
        }
      }
    }

    public void Load()
    {
      var loader = new Quests();
      Dictionary<string, Quest> tempquestList = loader.GetQuests();

      QuestList.Clear();

      foreach (var quest in tempquestList)
      {
        List<Requirements> Questrequirements = new List<Requirements>();

        foreach (var skill in quest.Value.PrerequisteSkills)
        {
          Requirements req = new Requirements();

          req.RequirementName = skill.Value.ToString() + " " + skill.Key.ToString();
          req.RequirementStatus = PlayerStats.Player[skill.Key].Level >= skill.Value ? TextDecorations.Strikethrough : null;

          Questrequirements.Add(req);
        }

        if (quest.Value.PrerequisteQuests.Count > 0)
        {
          Requirements req = new Requirements();
          Questrequirements.Add(req);
        }

        foreach (var quests in quest.Value.PrerequisteQuests)
        {
          Requirements req = new Requirements();

          req.RequirementName = quests.Name;
          req.RequirementStatus = quests.Completed == true ? TextDecorations.Strikethrough : null;

          Questrequirements.Add(req);
        }

        QuestViewModel newQuest = new QuestViewModel {
          Name = quest.Value.Name,
          Completed = quest.Value.Completed,
          PrerequisteQuests = quest.Value.PrerequisteQuests,
          PrerequisteSkills = quest.Value.PrerequisteSkills,
          Requirements = Questrequirements
        };
        newQuest.PropertyChanged += new PropertyChangedEventHandler(Update);

        QuestList.Add(newQuest);
      }
    }
  }
}
