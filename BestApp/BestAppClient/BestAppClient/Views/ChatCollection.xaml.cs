﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BestAppClient.ViewModels;
using BestAppClient.Model;

namespace BestAppClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatCollection : ContentPage
	{
		public ChatCollection ()
		{
			InitializeComponent ();
            BindingContext = new ListChatViewModel();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}