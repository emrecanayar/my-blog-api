using Application.Features.Notifications.Commands.Create;
using Application.Features.Notifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using webAPI.Application.Features.Notifications.Queries.GetNotificationCountByUserId;

namespace Application.Services.Notifications;

public class NotificationsManager : INotificationsService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;
    private readonly NotificationBusinessRules _notificationBusinessRules;

    public NotificationsManager(INotificationRepository notificationRepository, NotificationBusinessRules notificationBusinessRules, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _notificationBusinessRules = notificationBusinessRules;
        _mapper = mapper;
    }

    public async Task<Notification?> GetAsync(
        Expression<Func<Notification, bool>> predicate,
        Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Notification? notification = await _notificationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return notification;
    }

    public async Task<IPaginate<Notification>?> GetListAsync(
        Expression<Func<Notification, bool>>? predicate = null,
        Func<IQueryable<Notification>, IOrderedQueryable<Notification>>? orderBy = null,
        Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Notification> notificationList = await _notificationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return notificationList;
    }

    public async Task<Notification> AddAsync(Notification notification)
    {
        Notification addedNotification = await _notificationRepository.AddAsync(notification);

        return addedNotification;
    }

    public async Task<Notification> UpdateAsync(Notification notification)
    {
        Notification updatedNotification = await _notificationRepository.UpdateAsync(notification);

        return updatedNotification;
    }

    public async Task<Notification> DeleteAsync(Notification notification, bool permanent = false)
    {
        Notification deletedNotification = await _notificationRepository.DeleteAsync(notification);

        return deletedNotification;
    }

    public async Task<Notification> CreateNotificationAsync(CreateNotificationCommand createNotificationCommand)
    {
        Notification notification = _mapper.Map<Notification>(createNotificationCommand);
        Notification addedNotification = await _notificationRepository.AddAsync(notification);
        return addedNotification;
    }

    public async Task<IPaginate<Notification>> GetNotificationsAsync(Guid userId)
    {
        IPaginate<Notification> notifications = await _notificationRepository.GetListAsync(x => x.UserId == userId);
        return notifications;
    }

    public async Task<Notification> MarkAsReadAsync(Guid notificationId)
    {
        Notification? notification = await _notificationRepository.GetAsync(x => x.Id == notificationId);
        await _notificationBusinessRules.NotificationShouldExistWhenSelected(notification);
        notification.IsRead = true;
        Notification readedNotification = await _notificationRepository.UpdateAsync(notification);
        return readedNotification;
    }

    public async Task<GetNotificationCountDto> GetNotificationCountByUserId(Guid userId)
    {
        int notificationsCount = await _notificationRepository.CountAsync(x => x.UserId == userId && !x.IsRead);
        return new GetNotificationCountDto { TotalCount = notificationsCount };
    }
}
