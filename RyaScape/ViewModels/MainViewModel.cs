using RyaScape.Models;
using RyaScape.Mvvm;
using System.Net.Http;
using RyaScape.Services;

namespace RyaScape.ViewModels
{
    public class MainViewModel : BaseViewModel
    { 
        private static readonly HttpClient _httpClient = new HttpClient();

        public HighScoreViewModel HighScoreModel { get; }
        public QuestingViewModel QuestingViewModel { get; }

        public MainViewModel()
        {
            var highScore = new HighScoreResultViewModel();
            var highScoreLoader = new HighScoreLoader(_httpClient);

            QuestingViewModel = new QuestingViewModel(highScore.Skills);
            HighScoreModel = new HighScoreViewModel(QuestingViewModel, highScore, highScoreLoader);
        }
    }
}