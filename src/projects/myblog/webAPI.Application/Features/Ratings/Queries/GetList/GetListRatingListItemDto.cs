using Core.Application.Dtos;

namespace Application.Features.Ratings.Queries.GetList;

public class GetListRatingListItemDto : IDto
{
    public Guid Id { get; set; }
    public int Score { get; set; }
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }
}