using ProjectF.Core.Models.User;
using ProjectF.Core.Navigation;

namespace ProjectF.UI.Navigation;

public class NavigationService : INavigationService
{
    public Task NavigateToMainMenuAsync(User user)
        => Navigate("MainMenu", new Dictionary<string, object> {{ "User", user}});

    public Task NavigateToPlaybooksAsync(User user)
        => Navigate("Playbooks", new Dictionary<string, object> {{ "User", user}});
    
    public Task NavigateToCreateOffensivePlayAsync(User user)
        => Navigate("CreateOffensivePlay", new Dictionary<string, object> {{ "User", user}});
    
    public Task NavigateBackAsync()
        => Shell.Current.GoToAsync("..");
    
    private static async Task Navigate(string pageName,
                                       Dictionary<string, object> parameters)
    {
        await Shell.Current.GoToAsync(pageName);

        if (Shell.Current.CurrentPage.BindingContext is INavigationParameterReceiver receiver)
        {
            await receiver.OnNavigatedTo(parameters);
        }
    }
}