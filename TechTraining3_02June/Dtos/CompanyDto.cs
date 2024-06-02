namespace TechTraining3_02June.Dtos;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string NIP { get; set; } = null!;
    public string REGON { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    
    public string? FlatNumber { get; set; }
    public string? HouseNumber { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
}