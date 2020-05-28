using KeepInControl.Renderers;
using Xamarin.Forms;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Platform = Xamarin.Essentials.Platform;
using System;

[assembly: Dependency(typeof(KeepInControl.Droid.Renderers.StatusBarRenderer))]
namespace KeepInControl.Droid.Renderers
{
    public class StatusBarRenderer : IStatusBarRenderer
    {
        public void SetStatusBarColor(Color color)
        {
            try
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop && !color.IsDefault)
                {
                    Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
                    {
                        var androidColor = color.AddLuminosity(-0.1).ToAndroid();
                        Platform.CurrentActivity.Window.SetStatusBarColor(androidColor);
                    });
                }
            }
            catch (Exception ex)
            {
                //TODO Add log for crash
                Console.WriteLine(ex.Message);
            }
        }
    }
}