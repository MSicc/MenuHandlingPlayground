
using MenuHandlingPlayground.Services;
using MenuHandlingPlayground.ViewModel;
using Microsoft.Maui.Platform;

#if MACCATALYST
using UIKit;
#endif

namespace MenuHandlingPlayground;

public partial class AppShell : Shell
{
    private readonly IMenuService _menuService;

    public AppShell(AppShellViewModel appShellVm, IMenuService menuService)
    {
        _menuService = menuService;
        InitializeComponent();

        this.BindingContext = appShellVm;
    }

    protected override void OnAppearing()
    {
        _menuService.ForceMenuRebuild();
    }
}