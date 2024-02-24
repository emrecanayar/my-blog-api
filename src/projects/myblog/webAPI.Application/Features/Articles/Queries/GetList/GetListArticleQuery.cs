using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Articles.Queries.GetList;

public class GetListArticleQuery : IRequest<CustomResponseDto<GetListResponse<GetListArticleListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListArticleQueryHandler : IRequestHandler<GetListArticleQuery, CustomResponseDto<GetListResponse<GetListArticleListItemDto>>>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public GetListArticleQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListArticleListItemDto>>> Handle(GetListArticleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Article> articles = await _articleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListArticleListItemDto> response = _mapper.Map<GetListResponse<GetListArticleListItemDto>>(articles);
             return CustomResponseDto<GetListResponse<GetListArticleListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}