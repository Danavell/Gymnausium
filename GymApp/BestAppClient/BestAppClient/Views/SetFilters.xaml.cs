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
                WeightSliderMinimum.IsVisible = false;
                WeightSliderMaximum.IsVisible = false;
                WeightSwitch.Text = "Filter weight";
            }
        }

        private void WeightSliderMaximum_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            WeightSwitch.Text = "Filter weight: " + Convert.ToInt16(WeightSliderMinimum.Value) + " - " + Convert.ToInt16(WeightSliderMaximum.Value) + " kg";
            if (WeightSliderMaximum.Value < WeightSliderMinimum.Value)
            {
                WeightSliderMinimum.Value = WeightSliderMaximum.Value;
            }
        }
        private void WeightSliderMinimum_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            WeightSwitch.Text = "Filter weight: " + Convert.ToInt16(WeightSliderMinimum.Value) + " - " + Convert.ToInt16(WeightSliderMaximum.Value) + " kg";
            if (WeightSliderMinimum.Value > WeightSliderMaximum.Value)
            {
                WeightSliderMaximum.Value = WeightSliderMinimum.Value;
            }
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
        private void AgeSliderMaximum_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            AgeSwitch.Text = "Filter age: " + Convert.ToInt16(AgeSliderMinimum.Value) + " - " + Convert.ToInt16(AgeSliderMaximum.Value) + " years";
            if (AgeSliderMaximum.Value < AgeSliderMinimum.Value)
            {
                AgeSliderMinimum.Value = AgeSliderMaximum.Value;
            }
        }
        private void AgeSliderMinimum_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            AgeSwitch.Text = "Filter age: " + Convert.ToInt16(AgeSliderMinimum.Value) + " - " + Convert.ToInt16(AgeSliderMaximum.Value) + " years";
            if (AgeSliderMinimum.Value > AgeSliderMaximum.Value)
            {
                AgeSliderMaximum.Value = AgeSliderMinimum.Value;
            }
        }
    }
}