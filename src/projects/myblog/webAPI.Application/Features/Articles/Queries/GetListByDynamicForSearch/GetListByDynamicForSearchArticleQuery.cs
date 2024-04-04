using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace webAPI.Application.Features.Articles.Queries.GetListByDynamicForSearch
{
    public class GetListByDynamicForSearchArticleQuery : IRequest<CustomResponseDto<ArticleSearchListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery? DynamicQuery { get; set; }

        public GetListByDynamicForSearchArticleQuery()
        {
            PageRequest = default!;
            DynamicQuery = default!;
        }

        public class GetListByDynamicForSearchArticleQueryHandler : IRequestHandler<GetListByDynamicForSearchArticleQuery, CustomResponseDto<ArticleSearchListModel>>
        {
            private readonly IArticleRepository _articleRepository;
            private readonly IMapper _mapper;

            public GetListByDynamicForSearchArticleQueryHandler(IArticleRepository articleRepository, IMapper mapper)
            {
                _articleRepository = articleRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<ArticleSearchListModel>> Handle(GetListByDynamicForSearchArticleQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Article> articles = await _articleRepository.GetListByDynamicAsync(
                  dynamic: request.DynamicQuery,
                  index: request.PageRequest.PageIndex,
                  size: request.PageRequest.PageSize,
                  include: x => x.Include(x => x.User)
                                 .Include(x => x.Category),
                  cancellationToken: cancellationToken);

                ArticleSearchListModel mappedArticleSearchListModel = _mapper.Map<ArticleSearchListModel>(articles);
                return CustomResponseDto<ArticleSearchListModel>.Success((int)HttpStatusCode.OK, mappedArticleSearchListModel, true);
            }
        }
    }
}
