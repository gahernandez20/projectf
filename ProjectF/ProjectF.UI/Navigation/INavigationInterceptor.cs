namespace ProjectF.UI.Navigation;

public interface INavigationInterceptor
{
    Task OnNavigatedTo(object bindingContext);
    
    Task<bool> CanNavigate(object bindingContext);
}