using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoosePicture : ContentPage
    {
        public ChoosePicture()
        {
            InitializeComponent();
            Content = CreatePage();
        }

        private View CreatePage()
        {
            var stack = new StackLayout()
            {
                Padding = 30
            };

            Button pickPictureButton = new Button
            {
                Text = "Pick Photo",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            stack.Children.Add(pickPictureButton);

        
            return stack;
        }


    }
}