using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RyaScape.Mvvm;
using RyaScape.Models;
using System.Linq;

namespace RyaScape.ViewModels
{
    public class HighscoreViewModel : BaseViewModel
    {
        private readonly MainViewModel _mainModel;
        private HighscoreResult _highscore;

        public HighscoreResult Highscore
        {
            get => _highscore;
            set => SetAndNotify(ref _highscore, value);
        }

        public ICommand LoadCommand => new AwaitableDelegateCommand(Load);

        public HighscoreViewModel(MainViewModel mainModel)
        {
            _mainModel = mainModel;
            Highscore = new HighscoreResult();
        }

        public async Task Load()
        {
            await new HighscoreLoader().ReadHighscore(Highscore);
            
            _mainModel.QuestingModel.Update(string.Empty, new System.ComponentModel.PropertyChangedEventArgs(string.Empty));
        }
    }
}
