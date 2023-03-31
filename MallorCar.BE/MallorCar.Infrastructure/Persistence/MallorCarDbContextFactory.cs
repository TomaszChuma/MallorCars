using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MallorCar.Infrastructure.Persistence;

public class MallorCarDbContextFactory : IDesignTimeDbContextFactory<MallorCarDbContext>
{
    public MallorCarDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var configuration = configurationBuilder.Build();

        var dbContextBuilder = new DbContextOptionsBuilder<MallorCarDbContext>();
        dbContextBuilder.UseNpgsql(configuration["ConnectionString"]);

        return new MallorCarDbContext(dbContextBuilder.Options);
    }
}