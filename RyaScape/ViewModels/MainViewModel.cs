using RyaScape.Models;
using RyaScape.Mvvm;
using System.Net.Http;

namespace RyaScape.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public HighscoreViewModel HighscoreModel { get; }
        public QuestingViewModel QuestingModel { get; }

        private static readonly HttpClient _httpClient = new HttpClient();

        public MainViewModel()
        {
            var highscore = new HighscoreResult();
            var highscoreLoader = new HighscoreLoader(_httpClient);

            HighscoreModel = new HighscoreViewModel(this, highscore, highscoreLoader);
            QuestingModel = new QuestingViewModel(highscore.Skills);
        }
    }
}