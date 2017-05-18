using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using RyaScape.ViewModel;

namespace RyaScape.Models {
  public class CSVResult {
    public string Username { get; set; }
    public string Error { get; set; }
    public List<SkillLevelViewModel> Skills { get; } = new List<SkillLevelViewModel>();
  }

  public class CSVLoader {
    public async Task<CSVResult> ReadHighscore(string username) {
      var result = new CSVResult {
        Username = username
      };
      if (username == "") { result.Error = "Please enter a valid username."; return result; }
      try {
        using (var client = new WebClient()) {
          var data = await client.DownloadStringTaskAsync($"http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player={username}");

          await Task.Delay(1000);

          var line = data.Split('\n');

          for (var i = 0; i < 24; i++) {
            var skill = (SkillType)i;
            var value = line[i].Split(',');
            try {
              PlayerStats.Player[skill].Rank = long.Parse(value[0]);
              PlayerStats.Player[skill].Level = long.Parse(value[1]);
              PlayerStats.Player[skill].Exp = long.Parse(value[2]);
            } catch (Exception ex) {
              MessageBox.Show(ex.Message);
            }
          }
        }
        PlayerStats.PlayerName = username;
        FillStats(result);
        result.Error = $"{username} loaded successfully.";
      } catch (WebException wex) {
        var errorResponse = wex.Response as HttpWebResponse;
        if (errorResponse.StatusCode == HttpStatusCode.NotFound) {
          result.Error = $"404: {username} not found.";
        } else {
          result.Error = "Error: Something went terribly wrong.";
        }
      }

      return result;
    }

    private static T[] EnumToArray<T>() where T : struct, IConvertible {
      if (!typeof(T).IsEnum)
        throw new ArgumentException("T must be an enumerated type");

      return Enum.GetValues(typeof(T)).Cast<T>().ToArray<T>();
    }

    private static void FillStats(CSVResult highscore) {
      foreach (var skill in EnumToArray<SkillType>()) {
        highscore.Skills.Add(new SkillLevelViewModel() {
          Skill = skill.ToString(),
          Level = PlayerStats.Player[skill].Level,
          Rank = PlayerStats.Player[skill].Rank,
          Xp = PlayerStats.Player[skill].Exp
        });
      }
    }
  }
}