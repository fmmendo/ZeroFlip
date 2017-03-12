using Mendo.UWP.Common;
using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ZeroFlip.Lib;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZeroFlip.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : PageBase
    {
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
        }

        private async void Game_GameEnded(object sender, GameEndedEventArgs e)
        {
            MessageDialog md = new MessageDialog(e.Message);

            var result = await md.ShowAsync();
        }

        protected override void LoadState(object parameter, Dictionary<string, object> pageState)
        {
            base.LoadState(parameter, pageState);

            if (parameter is bool && (bool)parameter)
                Game.NewGame();
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            (e.ClickedItem as Lib.Tile).Revealed = true;
            if (e.ClickedItem is Lib.Tile)
                Game.TileClick((e.ClickedItem as Lib.Tile));
        }
    }
}
