namespace API.Entities;

public class Address
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string FlatNumber { get; set; }
    public string PostCode { get; set; }
    public string City { get; set; }

    public Club Club { get; set; }
    public int ClubId { get; set; }
}