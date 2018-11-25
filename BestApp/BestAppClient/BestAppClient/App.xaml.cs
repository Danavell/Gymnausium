using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BestAppClient.Views;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BestAppClient
{
    public partial class App : Application
    {
        public static Guid guid;
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
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
        /// <summary>
        /// Gets login credentials stored from device. Key: username, Value: password
        /// </summary>
        /// <returns></returns>
        public static async Task<KeyValuePair<string, string>> GetLoginCredentialsAsync()
        {
            var username = await SecureStorage.GetAsync("username");
            var password = await SecureStorage.GetAsync("password");
            return new KeyValuePair<string, string>(username, password);
        }
        /// <summary>
        /// Store login credential for automatic login. Data is encrypted.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static async void StoreCredentialsToDeviceAsync(string username, string password)
        {
            await SecureStorage.SetAsync("username", username);
            await SecureStorage.SetAsync("password", password);
        }
        /// <summary>
        /// Call this method when logging out
        /// </summary>
        public static void LogOutFromDevice()
        {
            SecureStorage.Remove("password");
        }
    }
}
