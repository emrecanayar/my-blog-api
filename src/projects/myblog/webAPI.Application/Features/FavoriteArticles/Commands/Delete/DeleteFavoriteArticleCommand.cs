using Application.Features.FavoriteArticles.Constants;
using Application.Features.FavoriteArticles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.FavoriteArticles.Commands.Delete;

public class DeleteFavoriteArticleCommand : IRequest<CustomResponseDto<DeletedFavoriteArticleResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [FavoriteArticlesOperationClaims.Delete, FavoriteArticlesOperationClaims.Admin];
    public class DeleteFavoriteArticleCommandHandler : IRequestHandler<DeleteFavoriteArticleCommand, CustomResponseDto<DeletedFavoriteArticleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteArticleRepository _favoriteArticleRepository;
        private readonly FavoriteArticleBusinessRules _favoriteArticleBusinessRules;

        public DeleteFavoriteArticleCommandHandler(IMapper mapper, IFavoriteArticleRepository favoriteArticleRepository,
                                         FavoriteArticleBusinessRules favoriteArticleBusinessRules)
        {
            _mapper = mapper;
            _favoriteArticleRepository = favoriteArticleRepository;
            _favoriteArticleBusinessRules = favoriteArticleBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedFavoriteArticleResponse>> Handle(DeleteFavoriteArticleCommand request, CancellationToken cancellationToken)
        {
            FavoriteArticle? favoriteArticle = await _favoriteArticleRepository.GetAsync(predicate: fa => fa.Id == request.Id, cancellationToken: cancellationToken);

            await _favoriteArticleBusinessRules.FavoriteArticleShouldExistWhenSelected(favoriteArticle);
            await _favoriteArticleRepository.DeleteAsync(favoriteArticle!);
            DeletedFavoriteArticleResponse response = _mapper.Map<DeletedFavoriteArticleResponse>(favoriteArticle);
            return CustomResponseDto<DeletedFavoriteArticleResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}