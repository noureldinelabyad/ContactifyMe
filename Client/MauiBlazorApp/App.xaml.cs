using Microsoft.Maui;
using Microsoft.Maui.Controls;
namespace MauiBlazorApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            //MainPage = new Microsoft.Maui.Controls.NavigationPage(new MainPage());

        }
    }


}