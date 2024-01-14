using MenuHandlingPlayground.Services;
using MenuHandlingPlayground.ViewModel;
using Microsoft.Extensions.Logging;

namespace MenuHandlingPlayground;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        CreateService(builder.Services);
        CreateViewModels(builder.Services);
        

        return builder.Build();
    }



    private static void CreateService(IServiceCollection services)
    {
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<IMenuService, MenuService>();
    }
    
    private static void CreateViewModels(IServiceCollection services)
    {
        services.AddSingleton<AppShellViewModel>();
    }
}
