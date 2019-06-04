using System.ComponentModel;
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

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetAndNotify(ref _isBusy, value);
        }

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
            IsBusy = true;

            await _highscoreLoader.ReadHighscore(Highscore);

            _mainModel.QuestingModel.Update(this, new PropertyChangedEventArgs(string.Empty));

            IsBusy = false;
        }
    }
}
