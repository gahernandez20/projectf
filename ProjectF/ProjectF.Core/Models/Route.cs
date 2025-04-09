namespace ProjectF.Core.Models;

public class Route(PlayerType player) : LinkedList<GridSquare>
{
    #region Properties

    public PlayerType PlayerKey
    {
        get;
    } = player;

    #endregion
}