using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BestAppClient.Views;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BestAppClient
{
    public partial class App : Application
    {
        public static Guid guid;
        public App()
        {
            InitializeComponent();
            //LogOutFromDevice(); // Uncomment to disable staying logged
            if (IsLoggedInDevice())
            {
                MainPage = new MainScreeen();
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {     
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public void SetMainPage(Page page)
        {
            MainPage = page;
        }
        private bool IsLoggedInDevice()
        {
            return Preferences.Get("IsLogged", false);
        }
        public static void LoginToDevice()
        {
            Preferences.Set("IsLogged", true);
        }
        /// <summary>
        /// Call this method when logging out
        /// </summary>
        public static void LogOutFromDevice()
        {
            Preferences.Set("IsLogged", false);
        }
    }
}
