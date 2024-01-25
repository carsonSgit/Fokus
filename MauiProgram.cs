using Fokus.ViewModel;
using Microsoft.Extensions.Logging;

namespace Fokus
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

            // Passing in the connectivity service
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            // Main Page
            // Singleton made once and then kept in memory
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            // Task Page
            builder.Services.AddSingleton<TaskPage>();
            builder.Services.AddSingleton<TaskViewModel>();

            // Detail Page
            // Transient made every time it is recalled
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();

            #if DEBUG
            builder.Logging.AddDebug();
            #endif

            return builder.Build();
        }
    }
}