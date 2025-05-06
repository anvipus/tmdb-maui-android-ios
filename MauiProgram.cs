using Microsoft.Extensions.Logging;
using MyMauiApp.Services;
using MyMauiApp.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Maui.Hosting;

namespace MyMauiApp;

public static class MauiProgram
{
    public static IServiceProvider ServiceProvider { get; private set; } = default!;

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit() // <- CommunityToolkit.Maui ready
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // ✅ Register your services and viewmodels here
        builder.Services.AddSingleton<IMovieApiService, MovieApiService>();
        builder.Services.AddSingleton<ExploreViewModel>();

        var app = builder.Build();
        ServiceProvider = app.Services;

        return app;
    }
}