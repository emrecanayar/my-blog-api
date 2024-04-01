using Application.Features.ArticleVotes.Constants;
using Application.Services.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace webAPI.Application.Features.ArticleVotes.Queries.GetByArticleIdUpvoteCount
{
    public class GetByArticleIdArticleVoteUpvoteCountQuery : IRequest<CustomResponseDto<GetByArticleIdArticleVoteUpvoteCountResponse>>, ISecuredRequest
    {
        public Guid ArticleId { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }

        public string[] Roles => [ArticleVotesOperationClaims.Admin, ArticleVotesOperationClaims.Read];

        public class GetByArticleIdArticleVoteUpvoteCountQueryHandler : IRequestHandler<GetByArticleIdArticleVoteUpvoteCountQuery, CustomResponseDto<GetByArticleIdArticleVoteUpvoteCountResponse>>
        {
            private readonly IArticleVoteRepository _articleVoteRepository;


            public GetByArticleIdArticleVoteUpvoteCountQueryHandler(IArticleVoteRepository articleVoteRepository)
            {
                _articleVoteRepository = articleVoteRepository;
            }

            public async Task<CustomResponseDto<GetByArticleIdArticleVoteUpvoteCountResponse>> Handle(GetByArticleIdArticleVoteUpvoteCountQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ArticleVote> articleVote = await _articleVoteRepository.GetListAsync(predicate: av => av.ArticleId == request.ArticleId && av.UserId == request.UserId && av.Vote == VoteType.Upvote, cancellationToken: cancellationToken);

                return CustomResponseDto<GetByArticleIdArticleVoteUpvoteCountResponse>.Success((int)HttpStatusCode.OK, new GetByArticleIdArticleVoteUpvoteCountResponse { UpvoteCount = articleVote.Count }, true);

            }
        }
    }
}
