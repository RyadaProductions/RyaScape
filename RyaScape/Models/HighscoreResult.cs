using RyaScape.Mvvm;
using RyaScape.ViewModels;
using System.Collections.Generic;

namespace RyaScape.Models
{
    public class HighscoreResult : BaseViewModel
    {
        private string _username = string.Empty;
        private string _error = string.Empty;

        public string Username {
            get => _username;
            set => SetAndNotify(ref _username, value);
        }

        public string Error {
            get => _error;
            set => SetAndNotify(ref _error, value);
        }

        public Dictionary<SkillTypes, SkillLevelViewModel> Skills { get; }

        public HighscoreResult()
        {
            Skills = new Dictionary<SkillTypes, SkillLevelViewModel>()
            {
                [SkillTypes.Total] = new SkillLevelViewModel(SkillTypes.Total),
                [SkillTypes.Attack] = new SkillLevelViewModel(SkillTypes.Attack),
                [SkillTypes.Defence] = new SkillLevelViewModel(SkillTypes.Defence),
                [SkillTypes.Strength] = new SkillLevelViewModel(SkillTypes.Strength),
                [SkillTypes.Hitpoints] = new SkillLevelViewModel(SkillTypes.Hitpoints),
                [SkillTypes.Ranged] = new SkillLevelViewModel(SkillTypes.Ranged),
                [SkillTypes.Prayer] = new SkillLevelViewModel(SkillTypes.Prayer),
                [SkillTypes.Magic] = new SkillLevelViewModel(SkillTypes.Magic),
                [SkillTypes.Cooking] = new SkillLevelViewModel(SkillTypes.Cooking),
                [SkillTypes.Woodcutting] = new SkillLevelViewModel(SkillTypes.Woodcutting),
                [SkillTypes.Fletching] = new SkillLevelViewModel(SkillTypes.Fletching),
                [SkillTypes.Fishing] = new SkillLevelViewModel(SkillTypes.Fishing),
                [SkillTypes.Firemaking] = new SkillLevelViewModel(SkillTypes.Firemaking),
                [SkillTypes.Crafting] = new SkillLevelViewModel(SkillTypes.Crafting),
                [SkillTypes.Smithing] = new SkillLevelViewModel(SkillTypes.Smithing),
                [SkillTypes.Mining] = new SkillLevelViewModel(SkillTypes.Mining),
                [SkillTypes.Herblore] = new SkillLevelViewModel(SkillTypes.Herblore),
                [SkillTypes.Agility] = new SkillLevelViewModel(SkillTypes.Agility),
                [SkillTypes.Thieving] = new SkillLevelViewModel(SkillTypes.Thieving),
                [SkillTypes.Slayer] = new SkillLevelViewModel(SkillTypes.Slayer),
                [SkillTypes.Farming] = new SkillLevelViewModel(SkillTypes.Farming),
                [SkillTypes.Runecraft] = new SkillLevelViewModel(SkillTypes.Runecraft),
                [SkillTypes.Hunter] = new SkillLevelViewModel(SkillTypes.Hunter),
                [SkillTypes.Construction] = new SkillLevelViewModel(SkillTypes.Construction)
            };
        }
    }
}
