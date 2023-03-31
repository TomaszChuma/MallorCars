using Autofac;
using MallorCar.Infrastructure.Persistence;
using MallorCar.Infrastructure.Persistence.Repositories;
using MallorCarApplication.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MallorCar.Infrastructure.Autofac;

public class DbContextAutofacModule : Module
{
    private readonly string _connectionString;

    public DbContextAutofacModule(string? connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void Load(
        ContainerBuilder builder
    )
    {
        builder.Register(context =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<MallorCarDbContext>();
                dbContextOptionsBuilder.UseNpgsql(
                    _connectionString,
                    b => b.MigrationsAssembly(
                        typeof(MallorCarDbContextFactory).Assembly.GetName().Name));
                
                return new MallorCarDbContext(
                    dbContextOptionsBuilder.Options,
                    context.Resolve<IMediator>()
                );
            })
            .As(typeof(IUnitOfWork))
            .As<DbContext>()
            .AsSelf()
            .InstancePerLifetimeScope();

        builder.RegisterGeneric(typeof(Repository<>))
            .As(typeof(IRepository<>))
            .InstancePerLifetimeScope();
    }
}