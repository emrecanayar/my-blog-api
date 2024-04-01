using Core.Application.Responses;

namespace webAPI.Application.Features.ArticleVotes.Queries.GetByArticleIdUpvoteCount
{
    public class GetByArticleIdArticleVoteUpvoteCountResponse : IResponse
    {
        public int UpvoteCount { get; set; }
    }
}
