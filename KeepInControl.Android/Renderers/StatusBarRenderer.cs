using KeepInControl.Renderers;
using Xamarin.Forms;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Platform = Xamarin.Essentials.Platform;

[assembly: Dependency(typeof(KeepInControl.Droid.Renderers.StatusBarRenderer))]
namespace KeepInControl.Droid.Renderers
{
    public class StatusBarRenderer : IStatusBarRenderer
    {
        public void SetStatusBarColor(Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var androidColor = color.AddLuminosity(-0.1).ToAndroid();
                Platform.CurrentActivity.Window.SetStatusBarColor(androidColor);
            }
        }
    }
}