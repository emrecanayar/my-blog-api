using Core.Application.Responses;

namespace Application.Features.Ratings.Commands.Create;

public class CreatedRatingResponse : IResponse
{
    public Guid Id { get; set; }
    public int Score { get; set; }
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }
}