using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(KeepInControl.iOS.Renderers.StatusBarRenderer))]
namespace KeepInControl.iOS.Renderers
{
    public class StatusBarRenderer
    {
        public void SetStatusBarColor(Color color)
        {
            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            {
                UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
                if (statusBar != null && statusBar.RespondsToSelector(
                new ObjCRuntime.Selector("setBackgroundColor:")))
                {
                    statusBar.BackgroundColor = color.ToUIColor();
                }
            });
        }
    }
}