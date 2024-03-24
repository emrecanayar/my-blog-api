using Application.Features.Auth.Commands.Login;

namespace webAPI.Application.Features.Likes.Queries.GetByCommentIdLike
{
    public class GetByCommentIdLikeResponse : IResponse
    {
        public int LikeCount { get; set; }
    }
}
