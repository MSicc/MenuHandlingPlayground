using Foundation;
using ObjCRuntime;
using UIKit;

namespace MenuHandlingPlayground;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    
    
    public override void BuildMenu(IUIMenuBuilder builder)
    {
        base.BuildMenu(builder);
        
        //Hiding unneeded menu entries is easy:
        builder.RemoveMenu(UIMenuIdentifier.Edit.GetConstant());
         builder.RemoveMenu(UIMenuIdentifier.Font.GetConstant());
         builder.RemoveMenu(UIMenuIdentifier.Format.GetConstant());
         builder.RemoveMenu(UIMenuIdentifier.About.GetConstant());
         builder.RemoveMenu(UIMenuIdentifier.Services.GetConstant());
         builder.RemoveMenu(UIMenuIdentifier.Hide.GetConstant());
        
         builder.RemoveMenu(UIMenuIdentifier.Close.GetConstant());
         builder.RemoveMenu(UIMenuIdentifier.Document.GetConstant());
 
        builder.System.SetNeedsRebuild();
    }
}
