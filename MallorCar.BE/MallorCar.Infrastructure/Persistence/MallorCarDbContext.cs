using MallorCar.Domain.Entities;
using MallorCarApplication.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MallorCar.Infrastructure.Persistence;

public class MallorCarDbContext : DbContext, IUnitOfWork
{
    private readonly IMediator? _mediator;
    public MallorCarDbContext(DbContextOptions<MallorCarDbContext> options) : base(options)
    {
    }
    
    public MallorCarDbContext(
        DbContextOptions options,
        IMediator mediator)  : base(options)
    {
        _mediator = mediator;
    }

    public DbSet<Car> Cars { get; set; } = default!;
    public DbSet<Client> Clients { get; set; } = default!;
    public DbSet<Location> Locations { get; set; } = default!;
    public DbSet<Rental> Rentals { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> SaveChangesWithNotificationsAsync(INotification notification,
        CancellationToken cancellationToken = new())
    {
        await base.SaveChangesAsync(cancellationToken);
        await _mediator!.Publish(notification, cancellationToken);
        return await base.SaveChangesAsync(cancellationToken);
    }
}