using Application.Features.Articles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Features.Articles.Queries.GetById;

public class GetByIdArticleQuery : IRequest<CustomResponseDto<GetByIdArticleResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdArticleQueryHandler : IRequestHandler<GetByIdArticleQuery, CustomResponseDto<GetByIdArticleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;
        private readonly ArticleBusinessRules _articleBusinessRules;

        public GetByIdArticleQueryHandler(IMapper mapper, IArticleRepository articleRepository, ArticleBusinessRules articleBusinessRules)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
            _articleBusinessRules = articleBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdArticleResponse>> Handle(GetByIdArticleQuery request, CancellationToken cancellationToken)
        {
            Article? article = await _articleRepository.GetAsync(
                predicate: a => a.Id == request.Id,
                include: x => x.Include(x => x.User).Include(x => x.Category).Include(x => x.Tags).Include(x => x.ArticleUploadedFiles).Include(x => x.Ratings),
                cancellationToken: cancellationToken);

            await _articleBusinessRules.ArticleShouldExistWhenSelected(article);
            GetByIdArticleResponse response = _mapper.Map<GetByIdArticleResponse>(article);
            await _articleBusinessRules.MappedArticleAverageRatingAsync(response);
            return CustomResponseDto<GetByIdArticleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}