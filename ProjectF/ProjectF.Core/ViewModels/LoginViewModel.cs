using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectF.Core.Models.User;
using ProjectF.Core.Navigation;

namespace ProjectF.Core.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    #region Field

    private readonly INavigationService _navigationService;
    
    #endregion
    
    #region Properties

    [ObservableProperty]
    private string _username = "";

    [ObservableProperty]
    private string _password = "";
    
    #endregion
    
    #region Commands

    [RelayCommand]
    private async Task OnLogin()
    {
        if (Username.Length is > 0 && Password.Length is > 0)
        {
            Username = string.Empty;
            Password = string.Empty;
            await _navigationService.NavigateToMainMenuAsync(new User() { Name = Username});
        }
    }

    #endregion

    public LoginViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
}