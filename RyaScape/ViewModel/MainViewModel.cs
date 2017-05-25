using NanoMVVM.Commands;
using NanoMVVM.ViewModels;
using RyaScape.Models;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RyaScape.ViewModel
{
  public class MainViewModel : BaseViewModel
  {
    public HighscoreViewModel HighscoreModel { get; }
    public QuestingViewModel QuestingModel { get; }

    public MainViewModel()
    {
      HighscoreModel = new HighscoreViewModel(this);
      QuestingModel = new QuestingViewModel();
    }
  }
}