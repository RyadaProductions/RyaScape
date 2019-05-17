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

            if (string.IsNullOrWhiteSpace(username))
            {
                result.Error = "Please enter a valid username.";
                return result;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync($"http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player={username}");

                    var lines = data.Split('\n');

                    for (var i = 0; i < 24; i++)
                    {
                        var skill = (SkillType)i;
                        var values = lines[i].Split(',');

                        try
                        {
                            var skillLevel = new SkillLevelViewModel()
                            {
                                Skill = skill.ToString(),
                                Rank = long.Parse(values[0]),
                                Level = long.Parse(values[1]),
                                Xp = long.Parse(values[2])
                            };
                            result.Skills.Add(skillLevel);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                result.Error = $"{username} loaded successfully.";
            }
            catch (WebException wex)
            {

                if (wex.Response is HttpWebResponse errorResponse && errorResponse.StatusCode == HttpStatusCode.NotFound)
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
    }
}