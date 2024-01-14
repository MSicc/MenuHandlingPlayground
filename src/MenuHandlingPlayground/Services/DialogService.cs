namespace MenuHandlingPlayground.Services
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string title, string message, string closeButtonText) =>
            Application.Current.MainPage.DisplayAlert(title, message, closeButtonText);
    }
}
