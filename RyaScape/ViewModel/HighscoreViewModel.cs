using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NanoMVVM.Commands;
using NanoMVVM.ViewModels;
using RyaScape.Models;

namespace RyaScape.ViewModel
{
  public class HighscoreViewModel : BaseViewModel
  {
    private string _user;
    private string _error;
    private readonly MainViewModel _mainModel;

    public string Username
    {
      get => _user;
      set
      {
        _user = value;
        RaisePropertyChanged();
      }
    }

    public string Error
    {
      get => _error;
      set
      {
        _error = value;
        RaisePropertyChanged();
      }
    }

    public ObservableCollection<SkillLevelViewModel> Skills { get; } = new ObservableCollection<SkillLevelViewModel>();

    public ICommand LoadCommand => new AwaitableDelegateCommand(Load);

    public HighscoreViewModel(MainViewModel mainModel)
    {
      _mainModel = mainModel;
    }

    public async Task Load()
    {
      var loader = new CsvLoader();
      var info = await loader.ReadHighscore(Username);

      Username = info.Username;
      Error = info.Error;

      Skills.Clear();
      foreach (var s in info.Skills)
        Skills.Add(s);

      _mainModel.QuestingModel.Update("", new System.ComponentModel.PropertyChangedEventArgs(""));
    }
  }
}
