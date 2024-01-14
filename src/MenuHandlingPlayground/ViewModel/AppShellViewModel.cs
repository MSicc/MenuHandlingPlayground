using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuHandlingPlayground.Services;
namespace MenuHandlingPlayground.ViewModel
{
    public class AppShellViewModel : ObservableObject
    {
        private readonly IDialogService _dialogService;
        private readonly IMenuService _menuService;

        public AppShellViewModel(IDialogService dialogService, IMenuService menuService)
        {
            _dialogService = dialogService;
            _menuService = menuService;

            this.AboutCommand = new RelayCommand(() => ShowSelectedMessage(nameof(this.AboutCommand)));
            this.SettingsCommand = new RelayCommand(() => ShowSelectedMessage(nameof(this.SettingsCommand)));
            this.OpenFileCommand = new RelayCommand(() => ShowSelectedMessage(nameof(this.OpenFileCommand)));
            this.CloseFileCommand = new RelayCommand(() => ShowSelectedMessage(nameof(this.CloseFileCommand)));

            this.Account1LoginCommand = new RelayCommand(() =>FakeAccountLogin(1));
            this.Account2LoginCommand = new RelayCommand(()=> FakeAccountLogin(2));

            this.ListMenuBarItemCommand = new RelayCommand<int>((number) => HandleListMenuBarItem(number));
        }

        private void HandleListMenuBarItem(int number)
        {
            var menubarName = "List";
            var insertedName = "Inserted Item";
            var addedName = "Added Item";
            
            if (number == 0)
            {
                if (_menuService.MenuFlyoutItemExists(insertedName))
                {
                    _menuService.RemoveMenuFlyoutItem(menubarName, insertedName);
                }
                else
                {
                    _menuService.AddMenuFlyoutItem(menubarName, insertedName, ()=> ShowSelectedMessage(insertedName), 1);
                }
            }
            else if (number == 2)
            {
                if (_menuService.MenuFlyoutItemExists(addedName))
                {
                    _menuService.RemoveMenuFlyoutItem(menubarName, addedName);
                }
                else
                {
                    _menuService.AddMenuFlyoutItem(menubarName, addedName, ()=> ShowSelectedMessage(addedName));
                }
            }
        }

        private void FakeAccountLogin(int id)
        {
            var subMenuParent = $"Account {id}";
            var sampleAccountName = $"SampleAccount {id}";
            
            if (_menuService.MenuFlyoutItemInSubMenuExists(subMenuParent, sampleAccountName))
                return;
            
            _menuService.AddMenuFlyoutItemToSubItem(subMenuParent, sampleAccountName, () => ShowSelectedMessage($"{nameof(FakeAccountLogin)} for id {id}"));
            
            if (_menuService.MenuFlyoutItemInSubMenuExists(subMenuParent, "Login"))
                _menuService.RemoveMenuFlyoutItemFromSubMenu(subMenuParent, "Login");
            
            if (!_menuService.MenuFlyoutItemInSubMenuExists(subMenuParent, "Logout"))
                _menuService.AddMenuFlyoutItemToSubItem(subMenuParent, "Logout", ()=> Logout(id), modifiers: KeyboardAcceleratorModifiers.Cmd | KeyboardAcceleratorModifiers.Shift, shortCutKey: id.ToString());
        }

        private void Logout(int id)
        {
            var subMenuParent = $"Account {id}";
            var sampleAccountName = $"SampleAccount {id}";
            
            if (_menuService.MenuFlyoutItemInSubMenuExists(subMenuParent, sampleAccountName))
                _menuService.RemoveMenuFlyoutItemFromSubMenu(subMenuParent, sampleAccountName);
            else
                return;
            
            if (_menuService.MenuFlyoutItemInSubMenuExists(subMenuParent, "Logout"))
                _menuService.RemoveMenuFlyoutItemFromSubMenu(subMenuParent, "Logout");
            else
                return;
            
            if (!_menuService.MenuFlyoutItemInSubMenuExists(subMenuParent, "Login"))
                _menuService.AddMenuFlyoutItemToSubItem(subMenuParent, "Login", () => FakeAccountLogin(id));
        }



        private void ShowSelectedMessage(string commandName) =>
            _dialogService.ShowMessage("MenuFlyoutItem clicked", $"Executing {commandName} showing this message.", "OK");

        public ICommand AboutCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand OpenFileCommand { get; }
        public ICommand CloseFileCommand { get; }
        public ICommand Account1LoginCommand { get; }
        public ICommand Account2LoginCommand { get; }
        public ICommand ListMenuBarItemCommand { get; }
    }
}
