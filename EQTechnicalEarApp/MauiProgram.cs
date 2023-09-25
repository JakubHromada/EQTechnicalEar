using EQTechnicalEarApp.Data;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace EQTechnicalEarApp
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
                });

            builder.Services.AddMauiBlazorWebView();

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