using Microsoft.Maui;
using Microsoft.Maui.Controls;
using CommonCode.Services;
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



//#if ANDROID
//            MainPage = new Android();
//#else
//            MainPage = new MainPage();
//#endif



        }



    }
}