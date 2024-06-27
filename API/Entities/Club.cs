namespace API.Entities;

public class Club
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Province { get; set; }
    public string County { get; set; }
    public string Borough { get; set; }
    public string Description { get; set; }

    public Address Address { get; set; }
}