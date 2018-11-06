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
        }

        private void GetPicture(object sender, EventArgs e)
        {
            
        }
    }
}