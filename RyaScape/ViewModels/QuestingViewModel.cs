using RyaScape.Mvvm;
using RyaScape.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.IO;
using RyaScape.Services;

namespace RyaScape.ViewModels
{
    public class QuestingViewModel : BaseViewModel
    {
        private bool _isBusy;
        private string _currentProfile;

        public Dictionary<SkillTypes, SkillLevelViewModel> Skills { get; }
        public ObservableCollection<QuestViewModel> QuestList { get; } = new ObservableCollection<QuestViewModel>();
        public ObservableCollection<string> Profiles { get; } = new ObservableCollection<string>();

        public bool IsBusy
        {
            get => _isBusy;
            set => SetAndNotify(ref _isBusy, value);
        }

        public string CurrentProfile
        {
            get => _currentProfile;
            set => SetAndNotify(ref _currentProfile, value);
        }

        public QuestingViewModel(Dictionary<SkillTypes, SkillLevelViewModel> skills)
        {
            Skills = skills;
            Load();
        }

        public void Update(object sender, PropertyChangedEventArgs e)
        {
            IsBusy = true;
            foreach (var questViewModel in QuestList)
            {
                questViewModel.Requirements.Clear();

                foreach (var skill in questViewModel.PrerequisiteSkills)
                {
                    var req = new Requirements
                    {
                        RequirementName = skill.Value + " " + skill.Key,
                        RequirementStatus = Skills[skill.Key].Level >= skill.Value
                        ? TextDecorations.Strikethrough
                        : null
                    };

                    questViewModel.Requirements.Add(req);
                }

                if (questViewModel.PrerequisiteQuests.Count > 0)
                {
                    var req = new Requirements();
                    questViewModel.Requirements.Add(req);
                }

                foreach (var quest in questViewModel.PrerequisiteQuests)
                {
                    var tmpQuest = QuestList.FirstOrDefault(x => x.Name == quest.Name);

                    var req = new Requirements();

                    if (tmpQuest != null)
                    {
                        req.RequirementName = tmpQuest.Name;
                        req.RequirementStatus = tmpQuest.Completed ? TextDecorations.Strikethrough : null;
                    }

                    questViewModel.Requirements.Add(req);
                }
            }
            SaveCompleted();

            IsBusy = false;
        }

        public void Load()
        {
            IsBusy = true;

            var loader = new QuestLoader();
            var tempQuestList = loader.LoadQuests();

            LoadProfiles();

            var completedQuests = new List<string>();
            if (File.Exists(Environment.CurrentDirectory + $"\\Resources\\Profiles\\{CurrentProfile}Completed.json"))
            {
                var input = File.ReadAllText(Environment.CurrentDirectory + $"\\Resources\\Profiles\\{CurrentProfile}Completed.json");
                var desList = JsonConvert.DeserializeObject<List<string>>(input);
                completedQuests.AddRange(desList);
            }

            foreach (var quest in tempQuestList)
            {
                var questRequirements = new ObservableCollection<Requirements>();

                foreach (var skill in quest.Value.PrerequisiteSkills)
                {
                    var req = new Requirements
                    {
                        RequirementName = skill.Value + " " + skill.Key,
                        RequirementStatus = Skills[skill.Key]?.Level >= skill.Value
                        ? TextDecorations.Strikethrough
                        : null
                    };


                    questRequirements.Add(req);
                }

                if (quest.Value.PrerequisiteQuests.Count > 0)
                {
                    var req = new Requirements();
                    questRequirements.Add(req);
                }

                foreach (var quests in quest.Value.PrerequisiteQuests)
                {
                    var req = new Requirements
                    {
                        RequirementName = quests.Name,
                        RequirementStatus = quests.Completed ? TextDecorations.Strikethrough : null
                    };


                    questRequirements.Add(req);
                }

                //Check if the quest has been saved as completed
                if (completedQuests.Contains(quest.Value.Name))
                {
                    quest.Value.Completed = true;
                }

                var newQuest = new QuestViewModel
                {
                    Name = quest.Value.Name,
                    Completed = quest.Value.Completed,
                    PrerequisiteQuests = quest.Value.PrerequisiteQuests,
                    PrerequisiteSkills = quest.Value.PrerequisiteSkills,
                    Requirements = questRequirements
                };
                newQuest.PropertyChanged += Update;

                QuestList.Add(newQuest);
            }

            IsBusy = false;
        }

        //Save the completed quest list to disk
        private void SaveCompleted()
        {
            var completedQuests = (from x in QuestList where x.Completed select x.Name).ToList();
            var json = JsonConvert.SerializeObject(completedQuests);
            File.WriteAllText(Environment.CurrentDirectory + $"\\Resources\\Profiles\\{CurrentProfile}Completed.json", json);
        }

        private void LoadProfiles()
        {
            var fileEntries = Directory.GetFiles(Environment.CurrentDirectory + "\\Resources\\Profiles");
            foreach (var file in fileEntries)
            {
                var lProfile = file.Substring(file.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                Profiles.Add(lProfile.Replace("Completed.json", string.Empty));
            }
            CurrentProfile = Profiles[0];
        }
    }
}
