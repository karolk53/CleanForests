namespace API.DTOs;

public class ClubCreateDto
{
    //CLUB DATA
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Province { get; set; }
    public string County { get; set; }
    public string Borough { get; set; }
    public string Description { get; set; }
    
    //ADDRESS DATA
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string FlatNumber { get; set; }
    public string PostCode { get; set; }
    public string City { get; set; }
}