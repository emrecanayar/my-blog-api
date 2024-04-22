using Core.Application.Dtos;

namespace webAPI.Application.Features.Notifications.Queries.GetNotificationCountByUserId
{
    public class GetNotificationCountDto : IDto
    {
        public int TotalCount { get; set; }
    }
}
