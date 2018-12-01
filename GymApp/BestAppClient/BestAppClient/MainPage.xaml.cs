using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Essentials;
using BestAppClient.Views;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace BestAppClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var pair = App.GetLoginCredentialsAsync().Result;

            if (Validate(pair.Key, pair.Value))
            {
                /*LoginAsync()*/; //Comment to disable auto login
            }
        }
        private async void SignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpManually());
        }
        private void ButtonClicked(object sender, EventArgs e)
        {
            var name = username.Text;
            var pass = password.Text;
            //var pass = Encrypt.EncryptString(password.Text);

            Validate(name, pass);
            if (Validate(name, pass))
            {
                App.StoreCredentialsToDeviceAsync(name, pass); // throws exception when name or pass is null. In production it is not possible.                
                LoginAsync();
            }
        }
        /// <summary>
        /// Shows home screen.
        /// </summary>
        private async void LoginAsync()
        {
            await Navigation.PushModalAsync(new MainScreeen());
            await GetLocation();
        }
        /// <summary>
        /// Returns true if username and password are correct.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool Validate(string username, string password)
        {
            WebClient proxy = new WebClient();
            proxy.DownloadStringAsync(new Uri("http://localhost:52703/Service1.svc/DisableUser/1"));
            proxy.DownloadStringCompleted += proxy_DownloadLoginCompleted;

              
            //if (username == "123" && password == "123")
                return true;
            //else
            //    return false;
        }
        private void proxy_DownloadLoginCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(Task<Guid?>));
            Task<bool> result = obj.ReadObject(stream) as Task<bool>;
            Debug.Write(result);
        }

        private async Task GetLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Debug.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    LabelLongLat.Text = "Latitude: " + location.Latitude + " Longitude: " + location.Longitude;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Debug.WriteLine(fnsEx.Message);
            }
            catch (PermissionException pEx)
            {
                Debug.WriteLine(pEx.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
