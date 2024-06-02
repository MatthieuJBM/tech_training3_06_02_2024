using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace TechTraining3_02June.Entities;

[Table("CompanyAddresses", Schema = "Company")]
public class CompanyAddress
{
    [Key] public int Id { get; set; }
    
    public int CompanyId { get; set; }

    [JsonIgnore] public Company Company { get; set; } = null!;

    [MaxLength(256)] [Required] public string City { get; set; } = null!;

    [MaxLength(256)] [Required] public string Street { get; set; } = null!;
    
    public string? FlatNumber { get; set; }
    
    public string? HouseNumber { get; set; }


}