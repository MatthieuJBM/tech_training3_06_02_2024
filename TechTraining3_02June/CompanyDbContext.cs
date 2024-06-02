using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TechTraining3_02June.Entities;

namespace TechTraining3_02June;

public class CompanyDbContext : DbContext
{
    private IConfiguration _configuration { get; }

    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<CompanyAddress> CompanyAddresses { get; set; } = null!;

    public CompanyDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase(databaseName: "AuthorDb");
        //options.UseInMemoryDatabase(@"server = 10.200.2.28; Database = company-dev-w66049; User Id = stud; Password =wsiz;",
        //options.UseSqlServer(@"server = 10.200.2.28; Database = kol_dev_nrAlbumu; User Id = stud; Passowrd = wsiz; ",
        //options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=szk3Z-company;Trusted_Connection=True;",
            // x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Company"));

        options.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    // }



}