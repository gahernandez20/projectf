using ProjectF.Core.Models.User;

namespace ProjectF.Core.Navigation;

public interface INavigationService
{
    Task NavigateToMainMenuAsync(User user);
    Task NavigateToPlaybooksAsync(User user);
    Task NavigateToCreateOffensivePlayAsync(User user);
    Task NavigateBackAsync();
}