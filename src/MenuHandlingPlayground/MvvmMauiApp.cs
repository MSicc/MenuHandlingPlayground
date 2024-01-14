using CommunityToolkit.Mvvm.DependencyInjection;
namespace MenuHandlingPlayground
{
    public class MvvmMauiApp: Microsoft.Maui.Controls.Application
    {
        public MvvmMauiApp(IServiceProvider services)
        {
            Ioc.Default.ConfigureServices(services);
        }
    }
}
