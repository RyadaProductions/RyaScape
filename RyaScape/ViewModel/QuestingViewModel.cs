using NanoMVVM.ViewModels;
using RyaScape.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.IO;

namespace RyaScape.ViewModel {
  public class QuestingViewModel : BaseViewModel {
    public ObservableCollection<QuestViewModel> QuestList { get; } = new ObservableCollection<QuestViewModel>();
    public ObservableCollection<string> Profiles { get; } = new ObservableCollection<string>();
    private string _CurrentProfile;

    public string CurrentProfile
    {
      get { return _CurrentProfile; }
      set
      {
        _CurrentProfile = value;
        RaisePropertyChanged();
      }
    }

    public QuestingViewModel()
    {
      Load();
    }

    public void Update(object sender, PropertyChangedEventArgs e) {
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
      SaveCompleted();
    }

    public void Load()
    {
      var loader = new Quests();
      Dictionary<string, Quest> tempquestList = loader.GetQuests();

      LoadProfiles();

      List<string> completedQuests = new List<string>();
      if (File.Exists(Environment.CurrentDirectory + $"\\Resources\\Profiles\\{CurrentProfile}Completed.json"))
      {
        string input = File.ReadAllText(Environment.CurrentDirectory + $"\\Resources\\Profiles\\{CurrentProfile}Completed.json");
        var desList = JsonConvert.DeserializeObject<List<string>>(input);
        completedQuests.AddRange(desList);
      }

      foreach (var quest in tempquestList)
      {
        ObservableCollection<Requirements> Questrequirements = new ObservableCollection<Requirements>();

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

        //Check if the quest has been saved as completed
        if (completedQuests.Contains(quest.Value.Name))
        {
          quest.Value.Completed = true;
        }

        QuestViewModel newQuest = new QuestViewModel 
        {
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

    //Save the completed quest list to disk
    private void SaveCompleted()
    {
      List<string> completedQuests = new List<string>();
      foreach (QuestViewModel x in QuestList)
      {
        if (x.Completed == true)
        {
          completedQuests.Add(x.Name);
        }
      }
      string json = JsonConvert.SerializeObject(completedQuests);
      File.WriteAllText(Environment.CurrentDirectory + $"\\Resources\\Profiles\\{CurrentProfile}Completed.json", json);
    }

    private void LoadProfiles()
    {
      string[] fileEntries = Directory.GetFiles(Environment.CurrentDirectory + "\\Resources\\Profiles");
      foreach (string file in fileEntries)
      {
        string lProfile = file.Substring(file.LastIndexOf("\\") + 1);
        Profiles.Add(lProfile.Replace("Completed.json", ""));
      }
      CurrentProfile = Profiles[0];
    }
  }
}
