using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BestAppClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetFilters : ContentPage
	{
		public SetFilters ()
		{
			InitializeComponent();
		}

        private void GenderSwitch_OnChanged(object sender, ToggledEventArgs e)
        {
            if (GenderSwitch.On == true)
            {
                GengerPicker.IsVisible = true;
                GengerPicker.Focus();
            }
            else
                GengerPicker.IsVisible = false;

        }

        private void WeightSwitch_OnChanged(object sender, ToggledEventArgs e)
        {
            if (WeightSwitch.On == true)
            {
                WeightSliderMinimum.IsVisible = true;
                WeightSliderMaximum.IsVisible = true;
                WeightSwitch.Text = "Filter weight: " + Convert.ToInt16(WeightSliderMinimum.Value) + " - " + Convert.ToInt16(WeightSliderMaximum.Value) + " kg";
            }
            else
            {
                WeightSliderMinimum.IsVisible = true;
                WeightSliderMaximum.IsVisible = true;
                WeightSwitch.Text = "Filter weight";
            }
        }

        private void WeightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            WeightSwitch.Text = "Filter weight: " + Convert.ToInt16(WeightSliderMinimum.Value) + " - " + Convert.ToInt16(WeightSliderMaximum.Value) + " kg";
        }
        private void AgeSwitch_OnChanged(object sender, ToggledEventArgs e)
        {
            if (AgeSwitch.On == true)
            {
                AgeSliderMinimum.IsVisible = true;
                AgeSliderMaximum.IsVisible = true;
                AgeSwitch.Text = "Filter age: " + Convert.ToInt16(AgeSliderMinimum.Value) + " - " + Convert.ToInt16(AgeSliderMaximum.Value) + " years";
            }
            else
            {
                AgeSliderMinimum.IsVisible = false;
                AgeSliderMaximum.IsVisible = false;
                AgeSwitch.Text = "Filter age";
            }
        }

        private void AgeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            AgeSwitch.Text = "Filter age: " + Convert.ToInt16(AgeSliderMinimum.Value) + " - " + Convert.ToInt16(AgeSliderMaximum.Value) + " years";
        }

        private void AgeSlider_ValueChanged_1(object sender, ValueChangedEventArgs e)
        {

        }
    }
}