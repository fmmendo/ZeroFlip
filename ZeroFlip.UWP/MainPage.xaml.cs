using Mendo.UWP.Common;
using Windows.UI.Core;
using Windows.UI.Xaml;

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
            //NavigationService.Navigate(typeof(GamePage), true);
        }
    }
}
