using TechTraining3_02June.Dtos;
using TechTraining3_02June.Entities;

namespace TechTraining3_02June.Extensions;

public static class CompanyDtoExtension
{
    public static Company ToEntity(this CompanyDto dto)
    {
        return new Company
        {
            Id = dto.Id,
            Name = dto.Name,
            NIP = dto.NIP,
            REGON = dto.REGON,
            PhoneNumber = dto.PhoneNumber,
            Address = new CompanyAddress
            {
                CompanyId = dto.Id,
                FlatNumber = dto.FlatNumber,
                HouseNumber = dto.HouseNumber,
                Street = dto.Street,
                City = dto.City,
            }
        };
    }
}