using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
           // MainPage = new NavigationPage(new MainPage());
            // MainPage = new ChatCollection();
        }

        protected override void OnStart()
        {
            MainPage = new NavigationPage(new MainPage());
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
        /// Gets login credentials from device. Key for username, value for password
        /// </summary>
        /// <returns>Key: username, Value: password</returns>
        public static async Task<KeyValuePair<string, string>> GetLoginCredentialsAsync()
        {
            var username = await SecureStorage.GetAsync("username");
            var password = await SecureStorage.GetAsync("password");
            return new KeyValuePair<string, string>(username, password);
        }
        /// <summary>
        /// Store login credentials to device for automatic login. Data are encrypted.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static async void StoreCredentialsToDeviceAsync(string username, string password)
        {
            await SecureStorage.SetAsync("username", username);
            await SecureStorage.SetAsync("password", password);
        }
        /// <summary>
        /// Remove password from device's storage
        /// </summary>
        public static async void LogOutFromDevice()
        {
            SecureStorage.Remove("password");
        }
    }
}
