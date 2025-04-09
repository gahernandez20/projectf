namespace ProjectF.Core;

public enum TightEndAction
{
    Block,
    CatchPass
}

public enum PlayType
{
    Run,
    Pass,
    PlayAction,
    Kneel
}

public enum NavigationType
{
    Unknown,
    Forward,
    Back,
    SectionChange
}

public enum PlayerType
{
    [EnumLabel("G")]
    Guard,
    
    [EnumLabel("OT")]
    Tackle,
    
    [EnumLabel("C")]
    Center,
    
    [EnumLabel("WR")]
    WideReceiver,
    
    [Backfield]
    [EnumLabel("TE")]
    TightEnd,
    
    [Backfield]
    [EnumLabel("HB")]
    Halfback,
    
    [Backfield]
    [EnumLabel("FB")]
    Fullback,
    
    [Backfield]
    [EnumLabel("QB")]
    Quarterback,
}

public enum PresetRoutes
{
    Corner,
    Streak,
    Drag,
    Post,
}