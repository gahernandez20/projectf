using ProjectF.Core.ViewModels;

namespace ProjectF.UI;

public partial class MainMenu : ContentPage
{
    public MainMenu(MainMenuViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}