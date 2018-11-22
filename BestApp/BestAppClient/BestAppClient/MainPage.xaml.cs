using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;
using System.Diagnostics;
using Plugin.Geolocator.Abstractions;

namespace BestAppClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void ButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("dick");
            if (IsLocationAvailable())
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(100),null,true); //this shit gives an error

                //    Debug.WriteLine("Position Status: {0}", position.Timestamp);
                //    Debug.WriteLine("Position Latitude: {0}", position.Latitude);
                //    Debug.WriteLine("Position Longitude: {0}", position.Longitude);
               
            }

        }
        public bool IsLocationAvailable()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }

    }
}
