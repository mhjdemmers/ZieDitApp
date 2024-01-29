using Microsoft.Extensions.Logging;
using Camera.MAUI;
using ZieDitApp.Repositories;
using ZieDitApp.Model;

namespace ZieDitApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCameraView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("IBMPlexSans-Bold.ttf", "IBMPlexSans-Bold");
                    fonts.AddFont("IBMPlexSans-Bold.ttf", "IBMPlexSans-Bold");
                    fonts.AddFont("IBMPlexSerif-Regular.ttf", "IBMPlexSerif-Regular");
                    fonts.AddFont("AvenirNextLTPro-Regular.ttf", "AvenirNextLTPro-Regular");
                });
            builder.Services.AddSingleton<BaseRepository<User>>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
