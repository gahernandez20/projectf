using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectF.Core.Navigation;

namespace ProjectF.Core.ViewModels;

public partial class PlaybooksViewModel : ObservableObject
{
    #region Fields
    
    private readonly INavigationService _navigationService;
    
    #endregion
    
    #region Commands

    [RelayCommand]
    private void NavigateToCreateOffensivePlay()
    {
        return;
    }

    [RelayCommand]
    private void NavigateToPlaybooks()
        => _navigationService.NavigateBackAsync();
    
    #endregion

    public PlaybooksViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
}