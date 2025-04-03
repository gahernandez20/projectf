using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ProjectF.Core.Navigation;
using ProjectF.Core.ViewModels;
using ProjectF.UI.Navigation;

namespace ProjectF.UI;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<App>();
        
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<MainMenu>();
        builder.Services.AddTransient<MainMenuViewModel>();

        builder.Services.AddTransient<Playbooks>();
        builder.Services.AddTransient<PlaybooksViewModel>();
        
        builder.Services.AddSingleton<NavigationService>();
        builder.Services.AddSingleton<INavigationService>(c => c.GetRequiredService<NavigationService>());

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MainMenu), typeof(MainMenu));
        Routing.RegisterRoute(nameof(Playbooks), typeof(Playbooks));
        

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}