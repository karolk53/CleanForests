namespace Domain.Entities;

public class Team
{
    public string Name { get; set; }
    public AppUser Owner { get; set; }
    public List<AppUser> Members { get; set; }
}