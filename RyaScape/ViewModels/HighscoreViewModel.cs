using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RyaScape.Mvvm;
using RyaScape.Models;

namespace RyaScape.ViewModels
{
    public class HighscoreViewModel : BaseViewModel
    {
        private string _user;
        private string _error;
        private readonly MainViewModel _mainModel;

        public string Username
        {
            get => _user;
            set => SetAndNotify(ref _user, value);
        }

        public string Error
        {
            get => _error;
            set => SetAndNotify(ref _error, value);
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

            _mainModel.QuestingModel.Skills = info.Skills;
            _mainModel.QuestingModel.Update(string.Empty, new System.ComponentModel.PropertyChangedEventArgs(string.Empty));
        }
    }
}
