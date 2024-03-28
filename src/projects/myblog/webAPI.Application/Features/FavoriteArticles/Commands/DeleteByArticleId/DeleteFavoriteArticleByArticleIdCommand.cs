using Application.Features.FavoriteArticles.Constants;
using Application.Features.FavoriteArticles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace webAPI.Application.Features.FavoriteArticles.Commands.DeleteByArticleId
{
    public class DeleteFavoriteArticleByArticleIdCommand : IRequest<CustomResponseDto<DeleteFavoriteArticleByArticleIdResponse>>, ISecuredRequest
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public Guid ArticleId { get; set; }

        public string[] Roles => [FavoriteArticlesOperationClaims.Delete, FavoriteArticlesOperationClaims.Admin];

        public class DeleteFavoriteArticleByArticleIdCommandHandler : IRequestHandler<DeleteFavoriteArticleByArticleIdCommand, CustomResponseDto<DeleteFavoriteArticleByArticleIdResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IFavoriteArticleRepository _favoriteArticleRepository;
            private readonly FavoriteArticleBusinessRules _favoriteArticleBusinessRules;

            public DeleteFavoriteArticleByArticleIdCommandHandler(IMapper mapper, IFavoriteArticleRepository favoriteArticleRepository, FavoriteArticleBusinessRules favoriteArticleBusinessRules)
            {
                _mapper = mapper;
                _favoriteArticleRepository = favoriteArticleRepository;
                _favoriteArticleBusinessRules = favoriteArticleBusinessRules;
            }

            public async Task<CustomResponseDto<DeleteFavoriteArticleByArticleIdResponse>> Handle(DeleteFavoriteArticleByArticleIdCommand request, CancellationToken cancellationToken)
            {
                FavoriteArticle? favoriteArticle = await _favoriteArticleRepository.GetAsync(predicate: fa => fa.UserId == request.UserId && fa.ArticleId == request.ArticleId, cancellationToken: cancellationToken);
                await _favoriteArticleBusinessRules.FavoriteArticleShouldExistWhenSelected(favoriteArticle);
                FavoriteArticle deletedFavoriteArticle = await _favoriteArticleRepository.DeleteAsync(favoriteArticle!);
                return CustomResponseDto<DeleteFavoriteArticleByArticleIdResponse>.Success((int)HttpStatusCode.OK, new DeleteFavoriteArticleByArticleIdResponse { Id = deletedFavoriteArticle.Id }, true);
            }
        }
    }
}
