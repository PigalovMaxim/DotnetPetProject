using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Project.Domain.Models;

namespace Project.Infrastructure;
public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<Volunteer> Volunteers => Set<Volunteer>();

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
        optionsBuilder.UseCamelCaseNamingConvention();
        optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    private ILoggerFactory CreateLoggerFactory() =>
         LoggerFactory.Create(builder =>
         {
             builder.AddConsole();
         });
}