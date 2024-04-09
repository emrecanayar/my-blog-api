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

namespace webAPI.Application.Features.Articles.Queries.GetListByDynamic
{
    public class GetListByDynamicArticleQuery : IRequest<CustomResponseDto<ArticleListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery? DynamicQuery { get; set; }

        public GetListByDynamicArticleQuery()
        {
            PageRequest = default!;
            DynamicQuery = default!;
        }

        public class GetListByDynamicArticleQueryHandler : IRequestHandler<GetListByDynamicArticleQuery, CustomResponseDto<ArticleListModel>>
        {
            private readonly IArticleRepository _articleRepository;
            private readonly IMapper _mapper;

            public GetListByDynamicArticleQueryHandler(IArticleRepository articleRepository, IMapper mapper)
            {
                _articleRepository = articleRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<ArticleListModel>> Handle(GetListByDynamicArticleQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Article> articles = await _articleRepository.GetListByDynamicAsync(
                    dynamic: request.DynamicQuery,
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    include: x => x.Include(x => x.User).ThenInclude(x => x.UserUploadedFiles)
                                   .Include(x => x.User).ThenInclude(x => x.FavoriteArticles)
                                   .Include(x => x.Category).Include(x => x.Tags).Include(x => x.ArticleUploadedFiles)
                                   .Include(x => x.ArticleVotes),
                    cancellationToken: cancellationToken);

                ArticleListModel mappedArticleListModel = _mapper.Map<ArticleListModel>(articles);

                return CustomResponseDto<ArticleListModel>.Success((int)HttpStatusCode.OK, mappedArticleListModel, true);


            }
        }
    }
}
