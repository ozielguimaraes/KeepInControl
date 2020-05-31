using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using KeepInControl.Constants;
using KeepInControl.Renderers;
using Xamarin.Forms;
using Xamarin.Essentials;
using Android.Content.Res;
using KeepInControl.Resources.Themes;

namespace KeepInControl.Droid
{
    [Activity(Label = "KeepInControl", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());

            ColorConstant.Init();
            SetStatusBarColor();
        }

        private void SetStatusBarColor() => DependencyService.Get<IStatusBarRenderer>().SetStatusBarColor(ColorConstant.PrimaryDark);

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            if ((newConfig.UiMode & UiMode.NightNo) != 0)
            {
                if (App.Theme != AppTheme.Dark) return;
                Xamarin.Forms.Application.Current.Resources = new LightTheme();
                App.Theme = AppTheme.Light;
            }
            else
            {
                // Night mode is active, we're using dark theme
                if (App.Theme != AppTheme.Dark) return;
                //Add a Check for App Theme since this is called even when not changed really

                Xamarin.Forms.Application.Current.Resources = new DarkTheme();
                App.Theme = AppTheme.Dark;
            }
        }
    }
}