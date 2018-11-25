using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Essentials;
using BestAppClient.Views;

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
                LoginAsync();
            }
        }
        private void ButtonClicked(object sender, EventArgs e)
        {
            var name = username.Text;
            var pass = password.Text;

            Validate(name, pass);
            if (Validate(name, pass))
            {
                App.StoreCredentialsToDeviceAsync(name, pass);
                LoginAsync();
            }
        }
        private async void LoginAsync()
        {
            await Navigation.PushModalAsync(new MainScreeen());
            await GetLocation();
        }
        private bool Validate(string username, string password)
        {
            //connect to database, get guid on succesful login
            //if successful
            //App.guid =  
            return true;
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
    }
}
