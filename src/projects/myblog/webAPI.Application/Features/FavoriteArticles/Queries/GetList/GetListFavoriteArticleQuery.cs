using Application.Features.FavoriteArticles.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Features.FavoriteArticles.Queries.GetList;

public class GetListFavoriteArticleQuery : IRequest<CustomResponseDto<GetListResponse<GetListFavoriteArticleListItemDto>>>, ISecuredRequest
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [FavoriteArticlesOperationClaims.Read, FavoriteArticlesOperationClaims.Admin];

    public GetListFavoriteArticleQuery()
    {
        PageRequest = default!;
    }

    public class GetListFavoriteArticleQueryHandler : IRequestHandler<GetListFavoriteArticleQuery, CustomResponseDto<GetListResponse<GetListFavoriteArticleListItemDto>>>
    {
        private readonly IFavoriteArticleRepository _favoriteArticleRepository;
        private readonly IMapper _mapper;

        public GetListFavoriteArticleQueryHandler(IFavoriteArticleRepository favoriteArticleRepository, IMapper mapper)
        {
            _favoriteArticleRepository = favoriteArticleRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListFavoriteArticleListItemDto>>> Handle(GetListFavoriteArticleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FavoriteArticle> favoriteArticles = await _favoriteArticleRepository.GetListAsync(
                predicate: x => x.UserId == request.UserId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: x => x.Include(x => x.User).Include(x => x.Article).ThenInclude(x => x.Category).Include(x => x.Article).ThenInclude(x => x.ArticleUploadedFiles),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFavoriteArticleListItemDto> response = _mapper.Map<GetListResponse<GetListFavoriteArticleListItemDto>>(favoriteArticles);
            return CustomResponseDto<GetListResponse<GetListFavoriteArticleListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}