using Application.Features.Notifications.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Notifications.Rules;

public class NotificationBusinessRules : BaseBusinessRules
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationBusinessRules(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public Task NotificationShouldExistWhenSelected(Notification? notification)
    {
        if (notification == null)
            throw new BusinessException(NotificationsBusinessMessages.NotificationNotExists);
        return Task.CompletedTask;
    }

    public async Task NotificationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Notification? notification = await _notificationRepository.GetAsync(
            predicate: n => n.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await NotificationShouldExistWhenSelected(notification);
    }
}