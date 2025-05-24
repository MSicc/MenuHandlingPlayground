using MenuHandlingPlayground.Services;
using MenuHandlingPlayground.ViewModel;
namespace MenuHandlingPlayground;

public partial class App : MvvmMauiApp
{
    public App(IServiceProvider services) : base(services)
    {
        InitializeComponent();
        
        var menuService = services.GetService<IMenuService>();
        this.MainPage = new AppShell(services.GetService<AppShellViewModel>()!, menuService!);

        menuService!.MenuHostingPage = this.MainPage;
    }
}
