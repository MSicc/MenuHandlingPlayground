using System.Windows.Input;
namespace MenuHandlingPlayground.Services
{
    public interface IMenuService
    {
        IMenuFlyoutItem? GetMenuFlyoutItem(string name);
        IMenuFlyoutSubItem? GetSubMenu(string name);
        IMenuFlyoutItem? GetSubMenuFlyoutItem(string parentSubMenu, string name);
        void AddMenuFlyoutItem(string menu, string name, Action execute, int position = -1, KeyboardAcceleratorModifiers modifiers = KeyboardAcceleratorModifiers.None, string? shortCutKey = null);
        void AddMenuFlyoutItemToSubMenu(string parentSubMenu, string name, Action execute, int position = -1, KeyboardAcceleratorModifiers modifiers = KeyboardAcceleratorModifiers.None, string? shortCutKey = null);
        void RemoveMenuFlyoutItemFromSubMenu(string parentSubMenu, string name);
        void RemoveMenuFlyoutItem(string menu, string name);
        bool MenuFlyoutItemExists(string name);
        bool SubMenuExists(string name);
        bool MenuFlyoutItemInSubMenuExists(string parentSubMenu, string name);
        Page? MenuHostingPage { get;  set; }
        void ForceMenuRebuild();
    }
}
