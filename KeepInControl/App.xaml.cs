using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KeepInControl.Services;
using KeepInControl.Views;

[assembly: ExportFont("fa-solid-900.ttf", Alias = "FontAwesome")]
namespace KeepInControl
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        public static bool UseMockDataStore = true;
        public static AppTheme Theme { get; set; }

        public App()
        {
            InitializeComponent();
            Initialize();
            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();

            SetMainPage();
        }

        public static void Initialize()
        {
        }

        private void SetMainPage()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var userService = new UserService();
                if (await userService.IsLoggedAsync()) MainPage = new AppShell();
                else MainPage = new LoginPage();
            });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
