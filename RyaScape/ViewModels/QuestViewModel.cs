using RyaScape.Mvvm;
using RyaScape.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace RyaScape.ViewModels
{
    public class QuestViewModel : BaseViewModel
    {
        private string _name;
        private bool _completed;
        private List<Quest> _prerequisteQuests;
        private Dictionary<SkillType, int> _prerequisteSkills;
        private ObservableCollection<Requirements> _requirements;

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

        public List<Quest> PrerequisteQuests
        {
            get => _prerequisteQuests;
            set => SetAndNotify(ref _prerequisteQuests, value);
        }

        public Dictionary<SkillType, int> PrerequisteSkills
        {
            get => _prerequisteSkills;
            set => SetAndNotify(ref _prerequisteSkills, value);
        }

        public ObservableCollection<Requirements> Requirements
        {
            get => _requirements;
            set => SetAndNotify(ref _requirements, value);
        }
    }
}
