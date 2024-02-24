using Application.Features.Articles.Constants;
using Application.Features.Articles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Articles.Commands.Delete;

public class DeleteArticleCommand : IRequest<CustomResponseDto<DeletedArticleResponse>>
{
    public Guid Id { get; set; }

    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, CustomResponseDto<DeletedArticleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;
        private readonly ArticleBusinessRules _articleBusinessRules;

        public DeleteArticleCommandHandler(IMapper mapper, IArticleRepository articleRepository,
                                         ArticleBusinessRules articleBusinessRules)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
            _articleBusinessRules = articleBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedArticleResponse>> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            Article? article = await _articleRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _articleBusinessRules.ArticleShouldExistWhenSelected(article);

            await _articleRepository.DeleteAsync(article!);

            DeletedArticleResponse response = _mapper.Map<DeletedArticleResponse>(article);

             return CustomResponseDto<DeletedArticleResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}