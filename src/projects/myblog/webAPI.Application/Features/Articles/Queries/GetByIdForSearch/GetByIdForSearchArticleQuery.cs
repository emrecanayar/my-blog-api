using Application.Features.Articles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace webAPI.Application.Features.Articles.Queries.GetByIdForSearch
{
    public class GetByIdForSearchArticleQuery : IRequest<CustomResponseDto<GetByIdForSearchArticleResponse>>
    {
        public Guid Id { get; set; }

        public class GetByIdForSearchArticleQueryHandler : IRequestHandler<GetByIdForSearchArticleQuery, CustomResponseDto<GetByIdForSearchArticleResponse>>
        {
            private readonly IArticleRepository _articleRepository;
            private readonly IMapper _mapper;
            private readonly ArticleBusinessRules _articleBusinessRules;

            public GetByIdForSearchArticleQueryHandler(IArticleRepository articleRepository, IMapper mapper, ArticleBusinessRules articleBusinessRules)
            {
                _articleRepository = articleRepository;
                _mapper = mapper;
                _articleBusinessRules = articleBusinessRules;
            }

            public async Task<CustomResponseDto<GetByIdForSearchArticleResponse>> Handle(GetByIdForSearchArticleQuery request, CancellationToken cancellationToken)
            {
                Article? article = await _articleRepository.GetAsync(
                                   predicate: a => a.Id == request.Id,
                                   include: x => x.Include(x => x.User).ThenInclude(x => x.UserUploadedFiles)
                                   .Include(x => x.User).ThenInclude(x => x.FavoriteArticles)
                                   .Include(x => x.Category).Include(x => x.Tags).Include(x => x.ArticleUploadedFiles),
                                   cancellationToken: cancellationToken);

                await _articleBusinessRules.ArticleShouldExistWhenSelected(article);
                GetByIdForSearchArticleResponse response = _mapper.Map<GetByIdForSearchArticleResponse>(article);
                return CustomResponseDto<GetByIdForSearchArticleResponse>.Success((int)HttpStatusCode.OK, response, true);
            }
        }
    }
}
