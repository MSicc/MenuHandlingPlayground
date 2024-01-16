using MenuHandlingPlayground.Services;
using MenuHandlingPlayground.ViewModel;
namespace MenuHandlingPlayground;

public partial class App : MvvmMauiApp
{
    public App(IServiceProvider services) : base(services)
    {
        InitializeComponent();
        
        this.MainPage = new AppShell(services.GetService<AppShellViewModel>()!);

        services.GetService<IMenuService>()!.MenuHostingPage = this.MainPage;
    }
}
