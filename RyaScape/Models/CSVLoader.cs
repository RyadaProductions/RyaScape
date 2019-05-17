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
    public class CsvResult
    {
        public string Username { get; set; }
        public string Error { get; set; }
        public List<SkillLevelViewModel> Skills { get; } = new List<SkillLevelViewModel>();
    }

    public class CsvLoader
    {
        public async Task<CsvResult> ReadHighscore(string username)
        {
            var result = new CsvResult
            {
                Username = username
            };

            if (username == "")
            {
                result.Error = "Please enter a valid username.";
                return result;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync($"http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player={username}");

                    var line = data.Split('\n');

                    for (var i = 0; i < 24; i++)
                    {
                        var skill = (SkillType)i;
                        var values = line[i].Split(',');

                        try
                        {
                            PlayerStats.Player[skill].Rank = long.Parse(values[0]);
                            PlayerStats.Player[skill].Level = long.Parse(values[1]);
                            PlayerStats.Player[skill].Exp = long.Parse(values[2]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                PlayerStats.PlayerName = username;
                FillStats(result);
                result.Error = $"{username} loaded successfully.";
            }
            catch (WebException wex)
            {
                var errorResponse = wex.Response as HttpWebResponse;

                if (errorResponse != null && errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    result.Error = $"404: {username} not found.";
                }
                else
                {
                    result.Error = "Error: Something went terribly wrong.";
                }
            }

            return result;
        }

        private static T[] EnumToArray<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }

        private static void FillStats(CsvResult highscore)
        {
            foreach (var skill in EnumToArray<SkillType>())
            {
                highscore.Skills.Add(new SkillLevelViewModel()
                {
                    Skill = skill.ToString(),
                    Level = PlayerStats.Player[skill].Level,
                    Rank = PlayerStats.Player[skill].Rank,
                    Xp = PlayerStats.Player[skill].Exp
                });
            }
        }
    }
}