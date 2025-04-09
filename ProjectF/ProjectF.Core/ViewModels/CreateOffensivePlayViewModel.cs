using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectF.Core.Models;
using ProjectF.Core.Extensions;
using ProjectF.Core.Models.User;
using ProjectF.Core.Navigation;

namespace ProjectF.Core.ViewModels;

public partial class CreateOffensivePlayViewModel : ObservableObject, INavigationParameterReceiver, INavigatedTo
{
    #region Fields
    
    private readonly INavigationService _navigationService;
    
    #endregion
    
    #region Properties
    
    private User CurrentUser
    {
        get; set;
    } = new();

    public RouteViewModel Route
    {
        get;
        set;
    }

    [ObservableProperty]
    private PlayerType _selectedPlayerUnit;
    
    public IList<PlayerType> PlayerTypes
    {
        get;
    } = Enum.GetValues<PlayerType>();
    
    [ObservableProperty]
    private PresetRoutes _selectedPresetRoute;
    
    public IList<PresetRoutes> PresetRoutes
    {
        get;
    } = Enum.GetValues<PresetRoutes>();
    
    [ObservableProperty]
    private bool _isCreateRouteMode;

    #endregion
    
    #region Commands

    [RelayCommand]
    private void NavigateToPlaybooks()
        => _navigationService.NavigateBackAsync();
    
    [RelayCommand]
    private void ToggleCreateRouteMode()
        => IsCreateRouteMode = !IsCreateRouteMode;

    [RelayCommand]
    private void GridSquareSelected(object parameter)
    {
        if (parameter is not GridSquare gridSquare)
        {
            return;
        }

        Console.WriteLine($"Selected: {gridSquare.Row}, {gridSquare.Column}");
        gridSquare.IsSelected = !gridSquare.IsSelected;
        
        //Route.Add(gridSquare);
    }

    [RelayCommand]
    private void PlayerTypeSelected()
    {
        return;
    }

    #endregion

    public CreateOffensivePlayViewModel(INavigationService navigationService)
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