using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace PersonalContactInformation
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()

            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

            builder.UseMauiApp<App>().UseMauiCommunityToolkit();
            
            //// initialize the .net maui community toolkit by adding the below line of code
            //.usemauicommunitytoolkit()
            //// after initializing the .net maui community toolkit, optionally add additional fonts
            //// continue initializing your .net maui app here

            //return builder.build();



#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
               


        }
    }
}