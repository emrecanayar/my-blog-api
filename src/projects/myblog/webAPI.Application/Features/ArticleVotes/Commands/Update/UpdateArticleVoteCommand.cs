using Application.Features.ArticleVotes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.ArticleVotes.Commands.Update;

public class UpdateArticleVoteCommand : IRequest<CustomResponseDto<UpdatedArticleVoteResponse>>
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }

    public class UpdateArticleVoteCommandHandler : IRequestHandler<UpdateArticleVoteCommand, CustomResponseDto<UpdatedArticleVoteResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleVoteRepository _articleVoteRepository;
        private readonly ArticleVoteBusinessRules _articleVoteBusinessRules;

        public UpdateArticleVoteCommandHandler(IMapper mapper, IArticleVoteRepository articleVoteRepository,
                                         ArticleVoteBusinessRules articleVoteBusinessRules)
        {
            _mapper = mapper;
            _articleVoteRepository = articleVoteRepository;
            _articleVoteBusinessRules = articleVoteBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedArticleVoteResponse>> Handle(UpdateArticleVoteCommand request, CancellationToken cancellationToken)
        {
            ArticleVote? articleVote = await _articleVoteRepository.GetAsync(predicate: av => av.Id == request.Id, cancellationToken: cancellationToken);
            await _articleVoteBusinessRules.ArticleVoteShouldExistWhenSelected(articleVote);
            articleVote = _mapper.Map(request, articleVote);

            await _articleVoteRepository.UpdateAsync(articleVote!);

            UpdatedArticleVoteResponse response = _mapper.Map<UpdatedArticleVoteResponse>(articleVote);

          return CustomResponseDto<UpdatedArticleVoteResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}