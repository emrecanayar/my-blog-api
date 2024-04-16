using Core.Application.Dtos;

namespace Application.Features.Notifications.Queries.GetList;

public class GetListNotificationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public Guid ArticleId { get; set; }
}