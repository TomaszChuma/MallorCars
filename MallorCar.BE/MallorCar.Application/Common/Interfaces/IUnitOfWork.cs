using MediatR;

namespace MallorCarApplication.Common.Interfaces;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
    
    public Task<int> SaveChangesWithNotificationsAsync(INotification notification, CancellationToken cancellationToken = new());
}