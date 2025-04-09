using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectF.Core.Models.User;
using ProjectF.Core.Navigation;

namespace ProjectF.Core.ViewModels;

public partial class PlaybooksViewModel : ObservableObject, INavigationParameterReceiver, INavigatedTo
{
    #region Fields
    
    private readonly INavigationService _navigationService;
    
    #endregion
    
    #region Properties

    private User CurrentUser
    {
        get;
        set;
    }
    
    #endregion
    
    #region Commands
    
    [RelayCommand]
    private void NavigateToMainMenu()
        => _navigationService.NavigateBackAsync();
    
    [RelayCommand]
    private void NavigateToCreateOffensivePlay()
        => _navigationService.NavigateToCreateOffensivePlayAsync(CurrentUser);
    
    #endregion

    public PlaybooksViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public Task OnNavigatedTo(Dictionary<string, object> parameters)
    {
        if (parameters["User"] is not User user)
        {
            throw new ArgumentException("User must be passed as a parameter.");
        }

        CurrentUser = user;
        return Task.CompletedTask;
    }

    public Task OnNavigatedToAsync(NavigationType navigationType)
        => Task.CompletedTask;
}