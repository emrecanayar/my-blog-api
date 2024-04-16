using Application.Features.Auth.Commands.Login;

namespace webAPI.Application.Features.Notifications.Queries.GetByUserId
{
    public class GetByUserIdNotificationResponse : IResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public Guid ArticleId { get; set; }
    }
}
