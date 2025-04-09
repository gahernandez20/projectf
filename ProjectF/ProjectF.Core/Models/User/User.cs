namespace ProjectF.Core.Models.User;

public class User
{
    public string Name { get; set; }

    public Team Team { get; }
    
    public Playbooks Playbooks { get; }
}