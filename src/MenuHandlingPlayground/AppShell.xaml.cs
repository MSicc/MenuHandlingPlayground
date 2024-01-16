
using MenuHandlingPlayground.ViewModel;
using Microsoft.Maui.Platform;

#if MACCATALYST
using UIKit;
#endif

namespace MenuHandlingPlayground;

public partial class AppShell : Shell
{
    public AppShell(AppShellViewModel appShellVm)
    {
        InitializeComponent();

        this.BindingContext = appShellVm;
    }
}