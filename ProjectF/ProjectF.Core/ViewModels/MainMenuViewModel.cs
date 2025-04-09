using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectF.Core.Models.User;
using ProjectF.Core.Navigation;

namespace ProjectF.Core.ViewModels;

public partial class MainMenuViewModel : ObservableObject, INavigationParameterReceiver, INavigatedTo
{
    #region Fields
    
    private readonly INavigationService _navigationService;
    
    #endregion
    
    #region Properties

    [ObservableProperty]
    private User _currentUser;

    #endregion

    #region Commands

    [RelayCommand]
    private void NavigateToLogin()
        => _navigationService.NavigateBackAsync();
    
    [RelayCommand]
    private void NavigateToPlaybooks()
        => _navigationService.NavigateToPlaybooksAsync(CurrentUser);

    #endregion
    
    public MainMenuViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    
    #region Helper Methods

    private async Task LoadPlaybooks(User user)
    {
        // TODO: Add logic to retrieve the current user's playbooks
        await Task.CompletedTask;
    }
    
    #endregion
    
    #region Navigation

    public Task OnNavigatedTo(Dictionary<string, object> parameters)
    {
        if (parameters["User"] is not User user)
        {
            throw new ArgumentException("User must be passed as a parameter.");
        }

        CurrentUser = user;
        return LoadPlaybooks(user);
    }

    public Task OnNavigatedToAsync(NavigationType navigationType)
        => Task.CompletedTask;
    
    #endregion
}