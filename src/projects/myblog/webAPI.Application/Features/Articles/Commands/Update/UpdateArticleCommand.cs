using Application.Features.Articles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Articles.Commands.Update;

public class UpdateArticleCommand : IRequest<CustomResponseDto<UpdatedArticleResponse>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public int ViewCount { get; set; }
    public int CommentCount { get; set; }
    public string SeoAuthor { get; set; }
    public string SeoDescription { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }

    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, CustomResponseDto<UpdatedArticleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;
        private readonly ArticleBusinessRules _articleBusinessRules;

        public UpdateArticleCommandHandler(IMapper mapper, IArticleRepository articleRepository,
                                         ArticleBusinessRules articleBusinessRules)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
            _articleBusinessRules = articleBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedArticleResponse>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            Article? article = await _articleRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _articleBusinessRules.ArticleShouldExistWhenSelected(article);
            article = _mapper.Map(request, article);

            await _articleRepository.UpdateAsync(article!);

            UpdatedArticleResponse response = _mapper.Map<UpdatedArticleResponse>(article);

          return CustomResponseDto<UpdatedArticleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}