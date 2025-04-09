namespace ProjectF.Core.Navigation;

public interface INavigatedTo
{
    Task OnNavigatedToAsync(NavigationType navigationType);
}