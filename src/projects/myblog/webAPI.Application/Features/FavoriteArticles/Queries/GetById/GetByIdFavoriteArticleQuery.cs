using Application.Features.FavoriteArticles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.FavoriteArticles.Queries.GetById;

public class GetByIdFavoriteArticleQuery : IRequest<CustomResponseDto<GetByIdFavoriteArticleResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdFavoriteArticleQueryHandler : IRequestHandler<GetByIdFavoriteArticleQuery, CustomResponseDto<GetByIdFavoriteArticleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteArticleRepository _favoriteArticleRepository;
        private readonly FavoriteArticleBusinessRules _favoriteArticleBusinessRules;

        public GetByIdFavoriteArticleQueryHandler(IMapper mapper, IFavoriteArticleRepository favoriteArticleRepository, FavoriteArticleBusinessRules favoriteArticleBusinessRules)
        {
            _mapper = mapper;
            _favoriteArticleRepository = favoriteArticleRepository;
            _favoriteArticleBusinessRules = favoriteArticleBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdFavoriteArticleResponse>> Handle(GetByIdFavoriteArticleQuery request, CancellationToken cancellationToken)
        {
            FavoriteArticle? favoriteArticle = await _favoriteArticleRepository.GetAsync(predicate: fa => fa.Id == request.Id, cancellationToken: cancellationToken);
            await _favoriteArticleBusinessRules.FavoriteArticleShouldExistWhenSelected(favoriteArticle);

            GetByIdFavoriteArticleResponse response = _mapper.Map<GetByIdFavoriteArticleResponse>(favoriteArticle);

            return CustomResponseDto<GetByIdFavoriteArticleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}