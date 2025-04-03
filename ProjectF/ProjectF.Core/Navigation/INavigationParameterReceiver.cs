namespace ProjectF.Core.Navigation;

public interface INavigationParameterReceiver
{
    Task OnNavigatedTo(Dictionary<string, object> parameters);
}