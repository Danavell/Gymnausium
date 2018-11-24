﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BestAppClient.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BestAppClient
{
    public partial class App : Application
    {
        public static Guid guid;
        public App()
        {
            InitializeComponent();

            MainPage = new ChatCollection();
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
    }
}
