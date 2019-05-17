using RyaScape.Mvvm;

namespace RyaScape.ViewModels
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