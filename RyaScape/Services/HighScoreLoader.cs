using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using RyaScape.Models;
using RyaScape.ViewModels;

namespace RyaScape.Services
{
    public class HighScoreLoader : IDisposable
    {
        private readonly HttpClient _httpClient;

        public HighScoreLoader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<HighScoreResultViewModel> ReadHighScore(HighScoreResultViewModel highScore)
        {
            if (string.IsNullOrWhiteSpace(highScore.Username))
            {
                highScore.Error = "Please enter a valid username.";
                return highScore;
            }

            try
            {
                var data = await _httpClient.GetStringAsync($"http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player={highScore.Username}");

                var lines = data.Split('\n');

                for (var i = 0; i < 24; i++)
                {
                    var skill = (SkillTypes)i;
                    var values = lines[i].Split(',');

                    try
                    {
                        highScore.Skills[skill].Rank = long.Parse(values[0]);
                        highScore.Skills[skill].Level = long.Parse(values[1]);
                        highScore.Skills[skill].Xp = long.Parse(values[2]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                highScore.Error = $"{highScore.Username} loaded successfully.";
            }
            catch (WebException wex)
            {

                if (wex.Response is HttpWebResponse errorResponse && errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    highScore.Error = $"404: {highScore.Username} not found.";
                }
                else
                {
                    highScore.Error = "Error: Something went terribly wrong.";
                }
            }

            return highScore;
        }
    }
}