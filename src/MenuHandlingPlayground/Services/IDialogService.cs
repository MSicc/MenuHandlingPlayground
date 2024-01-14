namespace MenuHandlingPlayground.Services
{
    public interface IDialogService
    {
        void ShowMessage(string title, string message, string closeButtonText);
    }
}
