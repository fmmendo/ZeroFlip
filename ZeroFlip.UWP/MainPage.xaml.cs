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
        Compositor _compositor;
        SpriteVisual _hostSprite;

        public MainPage()
        {
            this.InitializeComponent();

            _compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;

            if (DeviceInformation.Instance.IsPhone)
                BackgroundGrid.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.LightGray);

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
            //NavigationService.Navigate(typeof(GamePage), true);
        }

        private void root_Loaded(object sender, RoutedEventArgs e)
        {
            if (DeviceInformation.Instance.IsPhone)
                return;

                _hostSprite = _compositor.CreateSpriteVisual();
            _hostSprite.Size = new Vector2((float)BackgroundGrid.ActualWidth, (float)BackgroundGrid.ActualHeight);

            ElementCompositionPreview.SetElementChildVisual(BackgroundGrid, _hostSprite);

            UpdateEffect();
        }

        private void UpdateEffect()
        {
            if (DeviceInformation.Instance.IsPhone)
                return;

            _hostSprite.Brush = _compositor.CreateHostBackdropBrush();
        }

        private void root_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void BackgroundGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_hostSprite != null)
            {
                _hostSprite.Size = e.NewSize.ToVector2();
            }
        }
    }
}
