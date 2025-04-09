using ProjectF.Core.Models;
using ProjectF.Core.ViewModels;

namespace ProjectF.UI;

public partial class CreateOffensivePlayPage
{
    #region Fields
    
    private const int numCols = 41;
    private const int numRows = 60;
    private const int cellSize = 12;
    private const int endZoneSize = 4;
    
    #endregion
    
    public CreateOffensivePlayPage(CreateOffensivePlayViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        CreateField();
    }
    
    private void CreateField()
    {
        GridLength gridLength = new (cellSize, GridUnitType.Absolute);
        
        GridField.RowDefinitions.Clear();
        GridField.ColumnDefinitions.Clear();
        GridField.Children.Clear();
        
        GridField.WidthRequest = numCols * cellSize;
        GridField.HeightRequest = numRows * cellSize;
        
        GridField.HorizontalOptions = LayoutOptions.Center;
        GridField.VerticalOptions = LayoutOptions.Center;
        
        GridField.RowSpacing = 0;
        GridField.ColumnSpacing = 0;
        GridField.Padding = 0;
        
        for (var i = 0; i < numRows; i++)
        {
            GridField.RowDefinitions.Add(new RowDefinition { Height = gridLength });
        }
        
        // Define the columns
        for (var i = 0; i < numCols; i++)
        {
            GridField.ColumnDefinitions.Add(new ColumnDefinition { Width = gridLength });
        }
    
        // Loop to create and add buttons to the grid
        for (var row = 0; row < numRows; row++)
        {
            for (var col = 0; col < numCols; col++)
            {
                // Create a new button
                var button = CreateGridSquare(row, col);
                
                // Set the row and column indices for the button
                Grid.SetRow(button, row);
                Grid.SetColumn(button, col);
                
                // Add the button to the grid
                GridField.Children.Add(button);
            }
        }
        
        GridField.WidthRequest = numCols * cellSize;
        GridField.HeightRequest = numRows * cellSize;
    }

    private Button CreateGridSquare(int row, int col)
    {
        GridSquare square = new(row, col, false);
        Button button = new()
        {
            Padding = 0,
            Margin = 0,
            MinimumHeightRequest = cellSize,
            MinimumWidthRequest = cellSize,
            WidthRequest = cellSize, // Set button width
            HeightRequest = cellSize, // Set button height
            BorderColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            BorderWidth = 1,
            CornerRadius = 0, // Set button corners to be square
            CommandParameter = square,
            Command = ((CreateOffensivePlayViewModel)BindingContext).GridSquareSelectedCommand,
            BindingContext = square
        };
        
        SetCorrectColor(button, square);
        
        return button;
    }

    private void SetCorrectColor(Button button, GridSquare square)
    {
        switch (square.Row, square.Column)
        {
            case (numRows - 13, numCols - 26):
            case (numRows - 13, numCols - 23):
            case (numRows - 14, numCols - 20): // Center position
            case (numRows - 13, numCols - 17):
            case (numRows - 13, numCols - 14):
                button.BackgroundColor = Colors.Gold;
                break;
            default:
                button.SetBinding(BackgroundColorProperty,
                                  new Binding(nameof(square.IsSelected), BindingMode.TwoWay, converter: GetCorrectColorConverter(square)));
                break;
        }
    }

    private IValueConverter GetCorrectColorConverter(GridSquare square)
        => square.Row switch
        {
            < endZoneSize or >= numRows - endZoneSize => (IValueConverter)Resources["IsEndZoneSquareSelectedConverter"],
            _ => (IValueConverter)Resources["IsSquareSelectedConverter"],
        };
}