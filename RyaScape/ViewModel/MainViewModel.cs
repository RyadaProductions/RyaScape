using NanoMVVM.ViewModels;
using RyaScape.Models;
using System.Threading.Tasks;

namespace RyaScape.ViewModel {
  public class MainViewModel : BaseViewModel {

    public HighscoreViewModel HighscoreModel { get; }
    public QuestingViewModel QuestingModel { get; }

    public MainViewModel() {
      HighscoreModel = new HighscoreViewModel();
      QuestingModel = new QuestingViewModel();
    }
  }
}