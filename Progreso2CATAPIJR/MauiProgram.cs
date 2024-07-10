using Microsoft.Extensions.Logging;
using Progreso2CATAPIJR.Models;
using Progreso2CATAPIJR.ViewModels;
using Progreso2CATAPIJR.Services;
using Progreso2CATAPIJR.Views;


namespace Progreso2CATAPIJR
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
            builder.Services.AddSingleton<CatImageServiceJR>();
            builder.Services.AddSingleton<SQLiteServiceJR>();

            // Registrar ViewModels
            builder.Services.AddTransient<CatImageViewModelJR>();
            builder.Services.AddTransient<SavedCatImagesViewModelJR>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
