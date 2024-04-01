using Application.Features.ArticleVotes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Features.ArticleVotes.Commands.Create;

public class CreateArticleVoteCommand : IRequest<CustomResponseDto<CreatedArticleVoteResponse>>, ISecuredRequest
{
    public Guid ArticleId { get; set; }
    [JsonIgnore]
    public Guid UserId { get; set; }
    public VoteType Vote { get; set; }
    public string[] Roles => [ArticleVotesOperationClaims.Admin, ArticleVotesOperationClaims.Create];

    public class CreateArticleVoteCommandHandler : IRequestHandler<CreateArticleVoteCommand, CustomResponseDto<CreatedArticleVoteResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleVoteRepository _articleVoteRepository;

        public CreateArticleVoteCommandHandler(IMapper mapper, IArticleVoteRepository articleVoteRepository)
        {
            _mapper = mapper;
            _articleVoteRepository = articleVoteRepository;
        }

        public async Task<CustomResponseDto<CreatedArticleVoteResponse>> Handle(CreateArticleVoteCommand request, CancellationToken cancellationToken)
        {
            ArticleVote articleVote = _mapper.Map<ArticleVote>(request);
            ArticleVote addedArticleVote = await _articleVoteRepository.AddAsync(articleVote);
            CreatedArticleVoteResponse response = _mapper.Map<CreatedArticleVoteResponse>(addedArticleVote);
            return CustomResponseDto<CreatedArticleVoteResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}