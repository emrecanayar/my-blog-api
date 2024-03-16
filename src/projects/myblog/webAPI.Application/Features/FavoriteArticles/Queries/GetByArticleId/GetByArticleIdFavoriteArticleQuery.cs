using Application.Features.FavoriteArticles.Rules;
using Application.Services.Repositories;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace webAPI.Application.Features.FavoriteArticles.Queries.GetByArticleId
{
    public class GetByArticleIdFavoriteArticleQuery : IRequest<CustomResponseDto<GetByArticleIdFavoriteArticleResponse>>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public Guid ArticleId { get; set; }

        public class GetByArticleIdFavoriteArticleQueryHandler : IRequestHandler<GetByArticleIdFavoriteArticleQuery, CustomResponseDto<GetByArticleIdFavoriteArticleResponse>>
        {
            private readonly IFavoriteArticleRepository _favoriteArticleRepository;
            private readonly FavoriteArticleBusinessRules _favoriteArticleBusinessRules;

            public GetByArticleIdFavoriteArticleQueryHandler(IFavoriteArticleRepository favoriteArticleRepository, FavoriteArticleBusinessRules favoriteArticleBusinessRules)
            {
                _favoriteArticleRepository = favoriteArticleRepository;
                _favoriteArticleBusinessRules = favoriteArticleBusinessRules;
            }

            public async Task<CustomResponseDto<GetByArticleIdFavoriteArticleResponse>> Handle(GetByArticleIdFavoriteArticleQuery request, CancellationToken cancellationToken)
            {
                FavoriteArticle? favoriteArticle = await _favoriteArticleRepository.GetAsync(predicate: fa => fa.UserId == request.UserId && fa.ArticleId == request.ArticleId, cancellationToken: cancellationToken);
                await _favoriteArticleBusinessRules.FavoriteArticleShouldExistWhenSelected(favoriteArticle);

                GetByArticleIdFavoriteArticleResponse response = new GetByArticleIdFavoriteArticleResponse { Id = favoriteArticle.Id, IsThere = true };

                return CustomResponseDto<GetByArticleIdFavoriteArticleResponse>.Success((int)HttpStatusCode.OK, response, true);
            }
        }
    }
}
