using TechTraining3_02June.Services;

namespace TechTraining3_02June.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCompanyServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<CompanyService>();
        serviceCollection.AddDbContext<CompanyDbContext, CompanyDbContext>();
        return serviceCollection;
    }
}