using Application.Features.ArticleVotes.Constants;
using Application.Features.ArticleVotes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.ArticleVotes.Commands.Delete;

public class DeleteArticleVoteCommand : IRequest<CustomResponseDto<DeletedArticleVoteResponse>>
{
    public Guid Id { get; set; }

    public class DeleteArticleVoteCommandHandler : IRequestHandler<DeleteArticleVoteCommand, CustomResponseDto<DeletedArticleVoteResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleVoteRepository _articleVoteRepository;
        private readonly ArticleVoteBusinessRules _articleVoteBusinessRules;

        public DeleteArticleVoteCommandHandler(IMapper mapper, IArticleVoteRepository articleVoteRepository,
                                         ArticleVoteBusinessRules articleVoteBusinessRules)
        {
            _mapper = mapper;
            _articleVoteRepository = articleVoteRepository;
            _articleVoteBusinessRules = articleVoteBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedArticleVoteResponse>> Handle(DeleteArticleVoteCommand request, CancellationToken cancellationToken)
        {
            ArticleVote? articleVote = await _articleVoteRepository.GetAsync(predicate: av => av.Id == request.Id, cancellationToken: cancellationToken);
            await _articleVoteBusinessRules.ArticleVoteShouldExistWhenSelected(articleVote);

            await _articleVoteRepository.DeleteAsync(articleVote!);

            DeletedArticleVoteResponse response = _mapper.Map<DeletedArticleVoteResponse>(articleVote);

             return CustomResponseDto<DeletedArticleVoteResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}