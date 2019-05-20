using RyaScape.Models;
using RyaScape.Mvvm;

namespace RyaScape.ViewModels
{
    public class SkillLevelViewModel : BaseViewModel
    {
        private long _rank;
        private long _level;
        private long _xp;

        public SkillLevelViewModel(SkillTypes skill)
        {
            Skill = skill.ToString();
        }

        public string Skill { get; }

        public long Rank
        {
            get => _rank;
            set => SetAndNotify(ref _rank, value);
        }

        public long Level
        {
            get => _level;
            set => SetAndNotify(ref _level, value);
        }

        public long Xp
        {
            get => _xp;
            set => SetAndNotify(ref _xp, value);
        }
    }
}