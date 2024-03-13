using Core.Application.Responses;

namespace webAPI.Application.Features.Notifications.Commands.MarkAsRead
{
    public class MarkAsReadNotificationResponse : IResponse
    {
        public Guid Id { get; set; }
    }
}
