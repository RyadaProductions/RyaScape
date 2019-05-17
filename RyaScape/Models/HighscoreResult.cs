using RyaScape.Mvvm;
using RyaScape.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RyaScape.Models
{
    public class HighscoreResult : BaseViewModel
    {
        private string _username;
        private string _error;

        public string Username {
            get => _username;
            set => SetAndNotify(ref _username, value);
        }

        public string Error {
            get => _error;
            set => SetAndNotify(ref _error, value);
        }

        public ObservableDictionary<SkillType, SkillLevelViewModel> Skills { get; }

        public HighscoreResult()
        {
            Skills = new ObservableDictionary<SkillType, SkillLevelViewModel>()
            {
                [SkillType.Total] = new SkillLevelViewModel(SkillType.Total),
                [SkillType.Attack] = new SkillLevelViewModel(SkillType.Attack),
                [SkillType.Defence] = new SkillLevelViewModel(SkillType.Defence),
                [SkillType.Strength] = new SkillLevelViewModel(SkillType.Strength),
                [SkillType.Hitpoints] = new SkillLevelViewModel(SkillType.Hitpoints),
                [SkillType.Ranged] = new SkillLevelViewModel(SkillType.Ranged),
                [SkillType.Prayer] = new SkillLevelViewModel(SkillType.Prayer),
                [SkillType.Magic] = new SkillLevelViewModel(SkillType.Magic),
                [SkillType.Cooking] = new SkillLevelViewModel(SkillType.Cooking),
                [SkillType.Woodcutting] = new SkillLevelViewModel(SkillType.Woodcutting),
                [SkillType.Fletching] = new SkillLevelViewModel(SkillType.Fletching),
                [SkillType.Fishing] = new SkillLevelViewModel(SkillType.Fishing),
                [SkillType.Firemaking] = new SkillLevelViewModel(SkillType.Firemaking),
                [SkillType.Crafting] = new SkillLevelViewModel(SkillType.Crafting),
                [SkillType.Smithing] = new SkillLevelViewModel(SkillType.Smithing),
                [SkillType.Mining] = new SkillLevelViewModel(SkillType.Mining),
                [SkillType.Herblore] = new SkillLevelViewModel(SkillType.Herblore),
                [SkillType.Agility] = new SkillLevelViewModel(SkillType.Agility),
                [SkillType.Thieving] = new SkillLevelViewModel(SkillType.Thieving),
                [SkillType.Slayer] = new SkillLevelViewModel(SkillType.Slayer),
                [SkillType.Farming] = new SkillLevelViewModel(SkillType.Farming),
                [SkillType.Runecraft] = new SkillLevelViewModel(SkillType.Runecraft),
                [SkillType.Hunter] = new SkillLevelViewModel(SkillType.Hunter),
                [SkillType.Construction] = new SkillLevelViewModel(SkillType.Construction)
            };
        }
    }
}
