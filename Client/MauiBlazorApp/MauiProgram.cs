using CommonCode.Services;
using Microsoft.Extensions.Logging;
using CurrieTechnologies.Razor.SweetAlert2;
using MauiBlazorApp.Pages;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;

namespace MauiBlazorApp
{

    public static class MauiProgram
    {

        public static MauiApp CreateMauiApp()
        {

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()


                // Initialize the .NET MAUI Community Toolkit by adding the below line of code

                .UseMauiCommunityToolkit()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSweetAlert2();
         
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IPersonService, PersonService>();

            return builder.Build();

        }
    }
}