using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MauiBlazorApp.Services;
using MauiBlazorApp.Pages;
using Xamarin.Essentials;
using Microsoft.AspNetCore.Components;


namespace MauiBlazorApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

//#if ANDROID || IOS
//       MainPage = new NavigationPage(new AndroidIndex());

//#else
//            MainPage = new MainPage();

//#endif



        }



    }
}