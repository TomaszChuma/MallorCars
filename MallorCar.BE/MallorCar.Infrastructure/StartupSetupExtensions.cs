using MallorCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MallorCar.Infrastructure;

public static class StartupSetupExtensions
{
    public static void AddDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MallorCarDbContext>(options =>
            options.UseNpgsql(connectionString,
                b => b.MigrationsAssembly(
                    typeof(MallorCarDbContextFactory).Assembly.GetName().Name
                )));
    }
}