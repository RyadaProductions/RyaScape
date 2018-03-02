using NanoMVVM.ViewModels;

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
      set
      {
        _skill = value;
        RaisePropertyChanged();
      }
    }

    public long Rank
    {
      get => _rank;
      set
      {
        _rank = value;
        RaisePropertyChanged();
      }
    }

    public long Level
    {
      get => _level;
      set
      {
        _level = value;
        RaisePropertyChanged();
      }
    }

    public long Xp
    {
      get => _xp;
      set
      {
        _xp = value;
        RaisePropertyChanged();
      }
    }
  }
}