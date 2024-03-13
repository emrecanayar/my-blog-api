using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class NotificationRepository : EfRepositoryBase<Notification, Guid, BaseDbContext>, INotificationRepository
{
    public NotificationRepository(BaseDbContext context) : base(context)
    {
    }
}