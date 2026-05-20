using Blazored.Toast;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;

namespace WhiteFlexo;

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

        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            var ex = (Exception)e.ExceptionObject;
            System.Diagnostics.Debug.WriteLine($"UNHANDLED EX: {ex}");
        };
        TaskScheduler.UnobservedTaskException += (s, e) =>
        {
            System.Diagnostics.Debug.WriteLine($"TASK EXCEPTION: {e.Exception}");
        };

        builder.Services.AddMauiBlazorWebView();

        // Your existing singletons
        builder.Services.AddSingleton<ReadDTOService>();
        builder.Services.AddSingleton<OpcUaClient>();
        builder.Services.AddSingleton<ModuleDataService>();

        // Add localization
        builder.Services.AddLocalization(); // Needed for IStringLocalizer
        builder.Services.AddSingleton<CultureResources>();

        builder.Services.AddBlazoredToast();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
