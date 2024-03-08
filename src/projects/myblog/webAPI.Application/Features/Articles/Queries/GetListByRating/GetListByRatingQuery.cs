using Application.Features.Articles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace webAPI.Application.Features.Articles.Queries.GetListByRating
{
    public class GetListByRatingQuery : IRequest<CustomResponseDto<GetListResponse<GetListByRatingItemDto>>>
    {
        public PageRequest PageRequest { get; set; }

        public GetListByRatingQuery()
        {
            PageRequest = default!;
        }
        public class GetListByRatingQueryHandler : IRequestHandler<GetListByRatingQuery, CustomResponseDto<GetListResponse<GetListByRatingItemDto>>>
        {
            private readonly IArticleRepository _articleRepository;
            private readonly IMapper _mapper;
            private readonly ArticleBusinessRules _articleBusinessRules;

            public GetListByRatingQueryHandler(IArticleRepository articleRepository, IMapper mapper, ArticleBusinessRules articleBusinessRules)
            {
                _articleRepository = articleRepository;
                _mapper = mapper;
                _articleBusinessRules = articleBusinessRules;
            }

            public async Task<CustomResponseDto<GetListResponse<GetListByRatingItemDto>>> Handle(GetListByRatingQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Article> articles = await _articleRepository.GetListAsync(null,
                    orderBy: x => x.OrderByDescending(x => x.Ratings.Average(r => r.Score)),
                    include: x => x.Include(x => x.User).Include(x => x.Category).Include(x => x.Tags).Include(x => x.ArticleUploadedFiles).Include(x => x.Ratings),
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    enableTracking: false,
                    cancellationToken: cancellationToken);

                GetListResponse<GetListByRatingItemDto> response = _mapper.Map<GetListResponse<GetListByRatingItemDto>>(articles);
                return CustomResponseDto<GetListResponse<GetListByRatingItemDto>>.Success((int)HttpStatusCode.OK, response, true);
            }
        }
    }
}
