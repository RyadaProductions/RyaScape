using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RyaScape.Mvvm;
using RyaScape.Models;
using RyaScape.Services;

namespace RyaScape.ViewModels
{
    public class HighScoreViewModel : BaseViewModel
    {
        private readonly HighScoreLoader _highScoreLoader;
        private readonly QuestingViewModel _questingViewModel;
        private HighScoreResultViewModel _highScore;
        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetAndNotify(ref _isBusy, value);
        }

        public HighScoreResultViewModel HighScore
        {
            get => _highScore;
            set => SetAndNotify(ref _highScore, value);
        }

        public ICommand LoadCommand => new AwaitableDelegateCommand(Load);

        public HighScoreViewModel(QuestingViewModel questingViewModel, HighScoreResultViewModel highScore, HighScoreLoader highScoreLoader)
        {
            _questingViewModel = questingViewModel;
            _highScoreLoader = highScoreLoader;
            HighScore = highScore;
        }

        public async Task Load()
        {
            IsBusy = true;

            await _highScoreLoader.ReadHighScore(HighScore);

            _questingViewModel.Update(this, new PropertyChangedEventArgs(string.Empty));

            IsBusy = false;
        }
    }
}
