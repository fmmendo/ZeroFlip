using Mendo.UWP.Common;
using Mendo.UWP.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ZeroFlip.Lib;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZeroFlip.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HighScoresPage : PageBase
    {
        public HighScores Scores { get; private set; }

        public HighScoresPage()
        {
            LoadHighScoresAsync();

            this.InitializeComponent();
        }

        public async Task LoadHighScoresAsync()
        {
            var json = Settings.Get<string>(Constants.SETTINGS_HIGH_SCORE, SettingsLocation.Roaming);
            if (json != null && json is string s)
            {
                Scores = Json.Instance.Deserialize<HighScores>(json);
                if (Scores.Table == null)
                    Scores.Table = new List<HighScoreItem>();
            }
            else
                Scores = new HighScores() { Table = new List<HighScoreItem>() };

            Scores.Table = Scores.Table.OrderByDescending(i => i.Score).ToList();
        }

    }
}
