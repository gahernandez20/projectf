using ProjectF.Core.Models;

namespace ProjectF.Core.ViewModels;

public class RouteViewModel
{
    #region Properties
    public Route PlayerRoute
    {
        get;
        set;
    }

    #endregion

    public RouteViewModel(PlayerType playerType)
    {
        PlayerRoute = new Route(playerType);
    }
    
    public void Add(GridSquare gridSquare)
    {
        PlayerRoute.AddLast(gridSquare);
    }
}