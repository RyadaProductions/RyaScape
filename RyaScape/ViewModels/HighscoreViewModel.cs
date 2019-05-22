using System.Threading.Tasks;
using System.Windows.Input;
using RyaScape.Mvvm;
using RyaScape.Models;

namespace RyaScape.ViewModels
{
    public class HighscoreViewModel : BaseViewModel
    {
        private readonly HighscoreLoader _highscoreLoader;
        private readonly MainViewModel _mainModel;
        private HighscoreResult _highscore;

        public HighscoreResult Highscore
        {
            get => _highscore;
            set => SetAndNotify(ref _highscore, value);
        }

        public ICommand LoadCommand => new AwaitableDelegateCommand(Load);

        public HighscoreViewModel(MainViewModel mainModel, HighscoreResult highscore, HighscoreLoader highscoreLoader)
        {
            _mainModel = mainModel;
            _highscoreLoader = highscoreLoader;
            Highscore = highscore;
        }

        public async Task Load()
        {
            await _highscoreLoader.ReadHighscore(Highscore);

            _mainModel.QuestingModel.Update(string.Empty, new System.ComponentModel.PropertyChangedEventArgs(string.Empty));
        }
    }
}
