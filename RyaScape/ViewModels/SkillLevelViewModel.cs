using RyaScape.Mvvm;

namespace RyaScape.ViewModels
{
    public class SkillLevelViewModel : BaseViewModel
    {
        private string _skill;
        private long _rank;
        private long _level;
        private long _xp;

        public string Skill
        {
            get => _skill;
            set => SetAndNotify(ref _skill, value);
        }

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