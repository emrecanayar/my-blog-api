using Application.Features.Auth.Commands.Login;

namespace webAPI.Application.Features.Likes.Queries.GetByCommentIdDislike
{
    public class GetByCommentIdDislikeResponse : IResponse
    {
        public int DislikeCount { get; set; }
    }
}
