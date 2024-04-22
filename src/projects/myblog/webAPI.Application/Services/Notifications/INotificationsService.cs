using Application.Features.Notifications.Commands.Create;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using webAPI.Application.Features.Notifications.Queries.GetNotificationCountByUserId;

namespace Application.Services.Notifications;

public interface INotificationsService
{
    Task<Notification?> GetAsync(
        Expression<Func<Notification, bool>> predicate,
        Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Notification>?> GetListAsync(
        Expression<Func<Notification, bool>>? predicate = null,
        Func<IQueryable<Notification>, IOrderedQueryable<Notification>>? orderBy = null,
        Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Notification> AddAsync(Notification notification);
    Task<Notification> UpdateAsync(Notification notification);
    Task<Notification> DeleteAsync(Notification notification, bool permanent = false);
    Task<Notification> CreateNotificationAsync(CreateNotificationCommand createNotificationCommand);
    Task<IPaginate<Notification>> GetNotificationsAsync(Guid userId);
    Task<Notification> MarkAsReadAsync(Guid notificationId);
    Task<GetNotificationCountDto> GetNotificationCountByUserId(Guid userId);
}
