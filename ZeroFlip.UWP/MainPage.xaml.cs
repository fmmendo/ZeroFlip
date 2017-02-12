using Mendo.UWP.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ZeroFlip.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : PageBase
    {



        public MainPage()
        {
            //Game = new GameViewModel();

            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(GamePage), true);
            //Game.NewGame();
        }

        //private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    (e.ClickedItem as Lib.Tile).Revealed = true;
        //    if (e.ClickedItem is Lib.Tile)
        //        Game.TileClick((e.ClickedItem as Lib.Tile));
        //}
    }
}
