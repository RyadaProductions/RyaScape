using NanoMVVM.ViewModels;
using RyaScape.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RyaScape.ViewModel
{
  public class QuestViewModel : BaseViewModel, INotifyPropertyChanged
  {
    private string _Name;
    private bool _Completed;
    private List<Quest> _PrerequisteQuests;
    private Dictionary<SkillType, int> _PrerequisteSkills;
    private ObservableCollection<Requirements> _Requirements;

    public string Name
    {
      get { return _Name; }
      set
      {
        _Name = value;
        RaisePropertyChanged();
      }
    }

    public bool Completed
    {
      get { return _Completed; }
      set
      {
        _Completed = value;
        RaisePropertyChanged();
      }
    }

    public List<Quest> PrerequisteQuests
    {
      get { return _PrerequisteQuests; }
      set
      {
        _PrerequisteQuests = value;
        RaisePropertyChanged();
      }
    }

    public Dictionary<SkillType, int> PrerequisteSkills
    {
      get { return _PrerequisteSkills; }
      set
      {
        _PrerequisteSkills = value;
        RaisePropertyChanged();
      }
    }

    public ObservableCollection<Requirements> Requirements
    {
      get { return _Requirements; }
      set
      {
        _Requirements = value;
        RaisePropertyChanged();
      }
    }
  }

  public class Requirements : BaseViewModel, INotifyPropertyChanged
  {
    private string _RequirementName = "";
    private TextDecorationCollection _RequirementStatus;

    public string RequirementName
    {
      get { return _RequirementName; }
      set
      {
        _RequirementName = value;
        RaisePropertyChanged();
      }
    }

    public TextDecorationCollection RequirementStatus
    {
      get { return _RequirementStatus; }
      set
      {
        _RequirementStatus = value;
        RaisePropertyChanged();
      }
    }
  }
}
