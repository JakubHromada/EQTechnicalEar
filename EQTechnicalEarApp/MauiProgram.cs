using EQTechnicalEarApp.Data;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;
using EQTechnicalEarApp.Platforms;
using CommunityToolkit.Maui;

namespace EQTechnicalEarApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddTransient<IAudioPlayerService, AudioPlayerService>();

            #if DEBUG
		    builder.Services.AddBlazorWebViewDeveloperTools();
		    builder.Logging.AddDebug();
            #endif

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddSingleton(FilePicker.Default);

            return builder.Build();
        }
    }
}