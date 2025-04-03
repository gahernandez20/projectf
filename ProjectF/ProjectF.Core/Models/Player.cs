namespace ProjectF.Core.Models;

/// <summary>
/// Base class that describes all the common behaviors and attributes from all
/// the different player types
/// </summary>
public abstract class Player
{
    public string Name
    {
        get; set;
    } = string.Empty;
}