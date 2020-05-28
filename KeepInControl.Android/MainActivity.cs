using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using KeepInControl.Constants;
using KeepInControl.Renderers;
using Xamarin.Forms;
using Xamarin.Essentials;

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
    }
}