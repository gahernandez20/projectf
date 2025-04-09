namespace ProjectF.Core.Models.User;

public class Team
{
    #region Properties

    public string TeamName
    {
        get; set;
    }

    public int Id
    {
        get;
    }

    public List<Player> Players
    {
        get;
    } = [];

    #endregion
}