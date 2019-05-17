using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using RyaScape.ViewModels;

namespace RyaScape.Models
{
    public class HighscoreLoader
    {
        public async Task<HighscoreResult> ReadHighscore(HighscoreResult highscore)
        {
            if (string.IsNullOrWhiteSpace(highscore.Username))
            {
                highscore.Error = "Please enter a valid username.";
                return highscore;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync($"http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player={highscore.Username}");

                    var lines = data.Split('\n');

                    for (var i = 0; i < 24; i++)
                    {
                        var skill = (SkillType)i;
                        var values = lines[i].Split(',');

                        try
                        {
                            highscore.Skills[skill].Rank = long.Parse(values[0]);
                            highscore.Skills[skill].Level = long.Parse(values[1]);
                            highscore.Skills[skill].Xp = long.Parse(values[2]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                highscore.Error = $"{highscore.Username} loaded successfully.";
            }
            catch (WebException wex)
            {

                if (wex.Response is HttpWebResponse errorResponse && errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    highscore.Error = $"404: {highscore.Username} not found.";
                }
                else
                {
                    highscore.Error = "Error: Something went terribly wrong.";
                }
            }

            return highscore;
        }
    }
}