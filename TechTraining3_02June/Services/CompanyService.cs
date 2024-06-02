using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TechTraining3_02June.Dtos;
using TechTraining3_02June.Entities;
using TechTraining3_02June.Extensions;
using TechTraining3_02June.ServiceBusPublisher;

namespace TechTraining3_02June.Services;

public class CompanyService
{
    private static string connectionStringSb =
        @"Endpoint=sb://szkolenietechniczne.servicebus.windows.net/;SharedAccessKeyName=country;SharedAccessKey=7mJtFANhxaVWTrpx7Yk80oWc71SMMCMK/+ASbMRPcWA=;EntityPath=country-new";

    private static string queueName = "country-new";
    private readonly ServiceBusQueueSender _sbPublisher;

    private CompanyDbContext _companyDbContext;

    public CompanyService(CompanyDbContext companyDbContext)
    {
        _companyDbContext = companyDbContext;
        _sbPublisher = new ServiceBusQueueSender(connectionStringSb, queueName);
    }

    public async Task<CompanyDto> GetById(int id)
    {
        var company = await _companyDbContext
            .Set<Company>()
            .Include(x => x.Address)
            .AsNoTracking()
            .Where(e => e.Id!.Equals(id))
            .SingleOrDefaultAsync();
        return company == null ? new CompanyDto() : company.ToDto();
    }

    public async Task<IEnumerable<CompanyDto>> Get()
    {
        var companies = await _companyDbContext
            .Set<Company>()
            .Include(x => x.Address)
            .AsNoTracking()
            .ToListAsync();
        return companies.Select(e => e.ToDto());
    }

    public async Task Delete(int id)
    {
        var entity = await _companyDbContext
            .Set<Entities.Company>()
            .SingleOrDefaultAsync(e => e.Id!.Equals(id));
        if (entity == null)
        {
            return;
        }

        _companyDbContext.Set<Entities.Company>().Remove(entity);
        await _companyDbContext.SaveChangesAsync();
    }

    public async Task<int> Create(CompanyDto dto)
    {
        var entity = dto.ToEntity();
        _companyDbContext
            .Set<Entities.Company>()
            .Add(entity);

        await _companyDbContext.SaveChangesAsync();

        var messageContent = JsonConvert.SerializeObject(entity);
        await _sbPublisher.SendAsync(messageContent);

        return entity.Id;
    }

    public async Task<int> Update(CompanyDto dto)
    {
        var entityBeforeUpdate = await GetById(dto.Id);

        if (entityBeforeUpdate == null)
        {
            return 0;
        }

        var newEntity = dto.ToEntity();
        _companyDbContext.Entry(newEntity).State = EntityState.Modified;

        await _companyDbContext.SaveChangesAsync();
        return dto.Id;
    }
}