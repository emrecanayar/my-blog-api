using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface INotificationRepository : IAsyncRepository<Notification, Guid>, IRepository<Notification, Guid>
{
}