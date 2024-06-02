using TechTraining3_02June.Dtos;
using TechTraining3_02June.Entities;

namespace TechTraining3_02June.Extensions;

public static class CompanyExtension
{
    public static CompanyDto ToDto(this Company entity)
    {
        return new CompanyDto
        {
            Id = entity.Id,
            Name = entity.Name,
            NIP = entity.NIP,
            REGON = entity.REGON,
            PhoneNumber = entity.PhoneNumber,
            FlatNumber = entity.Address.FlatNumber,
            HouseNumber = entity.Address.HouseNumber,
            Street = entity.Address.Street,
            City = entity.Address.City,
        };
    }
}