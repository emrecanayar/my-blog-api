using Application.Services.Notifications;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace webAPI.Application.Features.Notifications.Commands.MarkAsRead
{
    public class MarkAsReadNotificationCommand : IRequest<CustomResponseDto<MarkAsReadNotificationResponse>>
    {
        public Guid Id { get; set; }

        public class MarkAsReadNotificationCommandHandler : IRequestHandler<MarkAsReadNotificationCommand, CustomResponseDto<MarkAsReadNotificationResponse>>
        {
            private readonly INotificationsService _notificationsService;

            public MarkAsReadNotificationCommandHandler(INotificationsService notificationsService)
            {
                _notificationsService = notificationsService;
            }

            public async Task<CustomResponseDto<MarkAsReadNotificationResponse>> Handle(MarkAsReadNotificationCommand request, CancellationToken cancellationToken)
            {
                Notification readNotification = await _notificationsService.MarkAsReadAsync(request.Id);
                return CustomResponseDto<MarkAsReadNotificationResponse>.Success((int)HttpStatusCode.OK, new MarkAsReadNotificationResponse { Id = readNotification.Id }, true);
            }
        }
    }
}
