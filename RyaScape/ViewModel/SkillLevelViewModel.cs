using NanoMVVM.ViewModels;

namespace RyaScape.ViewModel
{
  public class SkillLevelViewModel : BaseViewModel
  {
    private string _skill;
    private long _rank;
    private long _level;
    private long _xp;

    public string Skill
    {
      get { return _skill; }
      set
      {
        _skill = value;
        RaisePropertyChanged();
      }
    }

    public long Rank
    {
      get { return _rank; }
      set
      {
        _rank = value;
        RaisePropertyChanged();
      }
    }

    public long Level
    {
      get { return _level; }
      set
      {
        _level = value;
        RaisePropertyChanged();
      }
    }

    public long Xp
    {
      get { return _xp; }
      set
      {
        _xp = value;
        RaisePropertyChanged();
      }
    }
  }
}