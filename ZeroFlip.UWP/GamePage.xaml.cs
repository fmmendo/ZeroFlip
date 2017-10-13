using Mendo.UWP.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Navigation;
using ZeroFlip.Lib;
using Mendo.UWP.Serialization;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZeroFlip.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : PageBase
    {
        Compositor _compositor;
        SpriteVisual _hostSprite;

        public Game Game
        {
            get { return (Game)GetValue(GameProperty); }
            set { SetValue(GameProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Game.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GameProperty =
            DependencyProperty.Register("Game", typeof(Game), typeof(GamePage), new PropertyMetadata(0));

        public GamePage()
        {
            Game = new Game();
            Game.GameEnded += Game_GameEnded;

            this.InitializeComponent();

            if (DeviceInformation.Instance.IsPhone)
                BackgroundGrid.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.LightGray);

            _compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;

            // Extend the app into the titlebar so that we can apply acrylic
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }

        protected override bool OnBackRequested(bool FromHardwareBackButton)
        {
            MessageDialog md = new MessageDialog("This will forfeit the game and take you back to the main menu, are you sure you want to proceed?", "Go back?");
            md.Commands.Clear();
            md.Commands.Add(new UICommand("Yes", (i) => { base.OnBackRequested(FromHardwareBackButton); }, 1));
            md.Commands.Add(new UICommand("No", null, 2));

            md.ShowAsync();

            return false;
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            TrySaveHighScoreAsync(Game.GameScore);

            base.OnNavigatedFrom(e);
        }

        private void TrySaveHighScoreAsync(int gameScore)
        {
            HighScores scores;

            var json = Settings.Get<string>(Constants.SETTINGS_HIGH_SCORE, SettingsLocation.Roaming);
            if (json == null && json is string s)
            {
                scores = Json.Instance.Deserialize<HighScores>(json);
                if (scores.Table == null)
                    scores.Table = new List<HighScoreItem>();
            }
            else
                scores = new HighScores() { Table = new List<HighScoreItem>() };

            scores.Table.Add(new HighScoreItem { Score = gameScore, Date = DateTime.Today });
            scores.Table = scores.Table.OrderBy(i => i.Score).Take(10).ToList();

            Settings.Set(Constants.SETTINGS_HIGH_SCORE, Json.Instance.Serialize(scores), SettingsLocation.Roaming, true);
        }

        private void UpdateEffect()
        {
            if (DeviceInformation.Instance.IsPhone)
                return;

            _hostSprite.Brush = _compositor.CreateHostBackdropBrush();
        }

        private void BackgroundGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!DeviceInformation.Instance.IsPhone && _hostSprite != null)
            {
                _hostSprite.Size = e.NewSize.ToVector2();
            }
        }

        private async void Game_GameEnded(object sender, GameEndedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                try
                {
                    var message = string.Empty;
                    if (e.NextLevel > Game.Level)
                        message = string.Format(e.Message, string.Format(Constants.LevelUpMessage, e.NextLevel));
                    else if (e.NextLevel < Game.Level)
                        message = string.Format(e.Message, string.Format(Constants.LevelDownMessage, e.NextLevel));
                    else
                        message = string.Format(e.Message, string.Empty);

                    MessageDialog md = new MessageDialog(message, e.Header);
                    var result = await md.ShowAsync();

                    Game.NewGame(e.NextLevel);
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }

        protected override void LoadState(object parameter, Dictionary<string, object> pageState)
        {
            base.LoadState(parameter, pageState);

            if (parameter is bool && (bool)parameter)
                Game.NewGame();
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Lib.Tile t && !t.Revealed)
                Game.TileClick(t);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var newLevel = Game.GiveUp();

            var message = Constants.GiveUpMessage;
            if (newLevel < Game.Level)
                message += "\n\n" + string.Format(Constants.LevelDownMessage, newLevel);

            MessageDialog md = new MessageDialog(message, Constants.GiveUpHeader);
            var result = await md.ShowAsync();

            Game.NewGame(newLevel);
        }

        private void PageBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (DeviceInformation.Instance.IsPhone)
                return;

            _hostSprite = _compositor.CreateSpriteVisual();
            _hostSprite.Size = new Vector2((float)BackgroundGrid.ActualWidth, (float)BackgroundGrid.ActualHeight);

            ElementCompositionPreview.SetElementChildVisual(BackgroundGrid, _hostSprite);

            UpdateEffect();
        }
    }
}
