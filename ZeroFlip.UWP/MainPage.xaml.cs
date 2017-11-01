using Mendo.UWP.Common;
using System.Numerics;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
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
            this.InitializeComponent();

            // Extend the app into the titlebar so that we can apply acrylic
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(GamePage), true);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Exit();
        }

        private void HowToPlay_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(HowToPlayPage));
        }

        private void HighScores_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(HighScoresPage), true);
        }
    }
}
