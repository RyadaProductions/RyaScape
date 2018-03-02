using NanoMVVM.ViewModels;
using RyaScape.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace RyaScape.ViewModel
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
      set
      {
        _name = value;
        RaisePropertyChanged();
      }
    }

    public bool Completed
    {
      get => _completed;
      set
      {
        _completed = value;
        RaisePropertyChanged();
      }
    }

    public List<Quest> PrerequisteQuests
    {
      get => _prerequisteQuests;
      set
      {
        _prerequisteQuests = value;
        RaisePropertyChanged();
      }
    }

    public Dictionary<SkillType, int> PrerequisteSkills
    {
      get => _prerequisteSkills;
      set
      {
        _prerequisteSkills = value;
        RaisePropertyChanged();
      }
    }

    public ObservableCollection<Requirements> Requirements
    {
      get => _requirements;
      set
      {
        _requirements = value;
        RaisePropertyChanged();
      }
    }
  }

  public class Requirements : BaseViewModel
  {
    private string _requirementName = "";
    private TextDecorationCollection _requirementStatus;

    public string RequirementName
    {
      get => _requirementName;
      set
      {
        _requirementName = value;
        RaisePropertyChanged();
      }
    }

    public TextDecorationCollection RequirementStatus
    {
      get => _requirementStatus;
      set
      {
        _requirementStatus = value;
        RaisePropertyChanged();
      }
    }
  }
}
