using Core.Application.Responses;

namespace Application.Features.Likes.Commands.Create;

public class CreatedLikeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CommentId { get; set; }
    public bool IsLiked { get; set; }
}