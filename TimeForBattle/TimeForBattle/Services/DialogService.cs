
namespace TimeForBattle.Services;

public class DialogService
{
    public Task ShowAlertAsync(Page page, string title, string message, string cancel = "OK")
    {
        return page.DisplayAlert(title, message, cancel);
    }

    public Task<bool> ShowConfirmationAsync(Page page, string title, string message, string accept = "Yes", string cancel = "No")
    {
        return page.DisplayAlert(title, message, accept, cancel);
    }
}