using Application.Features.ArticleVotes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.ArticleVotes.Queries.GetById;

public class GetByIdArticleVoteQuery : IRequest<CustomResponseDto<GetByIdArticleVoteResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdArticleVoteQueryHandler : IRequestHandler<GetByIdArticleVoteQuery, CustomResponseDto<GetByIdArticleVoteResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleVoteRepository _articleVoteRepository;
        private readonly ArticleVoteBusinessRules _articleVoteBusinessRules;

        public GetByIdArticleVoteQueryHandler(IMapper mapper, IArticleVoteRepository articleVoteRepository, ArticleVoteBusinessRules articleVoteBusinessRules)
        {
            _mapper = mapper;
            _articleVoteRepository = articleVoteRepository;
            _articleVoteBusinessRules = articleVoteBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdArticleVoteResponse>> Handle(GetByIdArticleVoteQuery request, CancellationToken cancellationToken)
        {
            ArticleVote? articleVote = await _articleVoteRepository.GetAsync(predicate: av => av.Id == request.Id, cancellationToken: cancellationToken);
            await _articleVoteBusinessRules.ArticleVoteShouldExistWhenSelected(articleVote);

            GetByIdArticleVoteResponse response = _mapper.Map<GetByIdArticleVoteResponse>(articleVote);

          return CustomResponseDto<GetByIdArticleVoteResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}