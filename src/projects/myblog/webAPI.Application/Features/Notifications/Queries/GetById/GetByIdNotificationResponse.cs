using Core.Application.Responses;

namespace Application.Features.Notifications.Queries.GetById;

public class GetByIdNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public Guid ArticleId { get; set; }
}