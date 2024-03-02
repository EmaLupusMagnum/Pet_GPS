using Microsoft.Extensions.Logging;
using PetGPS.MVVM.Models;
using PetGPS.Repositories;

namespace PetGPS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiMaps()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Nexa-Heavy.ttf", "Nexa");
                    fonts.AddFont("Lato-Bold.ttf", "Lato");
                    fonts.AddFont("icons.ttf", "Icons");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<BaseRepository<User>>();

            return builder.Build();
        }
    }
}
