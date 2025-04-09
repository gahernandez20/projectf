using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectF.Core.Models;

public partial class GridSquare(int row, int column, bool isSelected) : ObservableObject
{
    public int Row { get; } = row;
    public int Column { get; } = column;
    
    [ObservableProperty]
    private bool _isSelected = isSelected;

    public void Deconstruct(out int row, out int column, out bool isSelected)
    {
        row = Row;
        column = Column;
        isSelected = IsSelected;
    }
}