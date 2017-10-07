using Mendo.UWP.Common;
using System.Numerics;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZeroFlip.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HowToPlayPage : PageBase
    {
        Compositor _compositor;
        SpriteVisual _hostSprite;

        public HowToPlayPage()
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (DeviceInformation.Instance.IsPhone)
                return;

            _hostSprite = _compositor.CreateSpriteVisual();
            _hostSprite.Size = new Vector2((float)BackgroundGrid.ActualWidth, (float)BackgroundGrid.ActualHeight);

            ElementCompositionPreview.SetElementChildVisual(BackgroundGrid, _hostSprite);

            UpdateEffect();
        }

        private void BackgroundGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!DeviceInformation.Instance.IsPhone && _hostSprite != null)
            {
                _hostSprite.Size = e.NewSize.ToVector2();
            }
        }

        private void UpdateEffect()
        {
            if (DeviceInformation.Instance.IsPhone)
                return;

            _hostSprite.Brush = _compositor.CreateHostBackdropBrush();
        }
    }
}
