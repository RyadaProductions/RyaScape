using NanoMVVM.ViewModels;
using RyaScape.Models;
using System;
using System.Collections.Generic;
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
    private List<Requirements> _Requirements;

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

    public List<Requirements> Requirements
    {
      get { return _Requirements; }
      set
      {
        _Requirements = value;
        RaisePropertyChanged();
      }
    }
  }

  public class Requirements
  {
    public string RequirementName { get; set; }
    public TextDecorationCollection RequirementStatus { get; set; }
  }
}
