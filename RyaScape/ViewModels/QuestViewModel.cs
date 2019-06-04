using RyaScape.Mvvm;
using RyaScape.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RyaScape.ViewModels
{
    public class QuestViewModel : BaseViewModel
    {
        private string _name;
        private bool _completed;
        private List<Quest> _prerequisiteQuests;
        private Dictionary<SkillTypes, int> _prerequisiteSkills;
        private ObservableCollection<RequirementsViewModel> _requirements;

        public string Name
        {
            get => _name;
            set => SetAndNotify(ref _name, value);
        }

        public bool Completed
        {
            get => _completed;
            set => SetAndNotify(ref _completed, value);
        }

        public List<Quest> PrerequisiteQuests
        {
            get => _prerequisiteQuests;
            set => SetAndNotify(ref _prerequisiteQuests, value);
        }

        public Dictionary<SkillTypes, int> PrerequisiteSkills
        {
            get => _prerequisiteSkills;
            set => SetAndNotify(ref _prerequisiteSkills, value);
        }

        public ObservableCollection<RequirementsViewModel> Requirements
        {
            get => _requirements;
            set => SetAndNotify(ref _requirements, value);
        }
    }
}
