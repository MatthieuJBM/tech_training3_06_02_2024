using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTraining3_02June.Entities;

[Table("Companies", Schema = "Company")]
public class Company
{
    [Key] public int Id { get; set; }

    [MaxLength(256)] [Required] public string Name { get; set; } = null!;

    [MaxLength(32)] public string PhoneNumber { get; set; } = null!;

    [MaxLength(32)] public string NIP { get; set; } = null!;

    [MaxLength(16)] public string REGON { get; set; } = null!;

    public CompanyAddress Address { get; set; } = null!;


}