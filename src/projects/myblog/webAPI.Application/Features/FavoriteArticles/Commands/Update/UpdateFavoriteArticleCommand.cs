using Application.Features.FavoriteArticles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.FavoriteArticles.Commands.Update;

public class UpdateFavoriteArticleCommand : IRequest<CustomResponseDto<UpdatedFavoriteArticleResponse>>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }

    public class UpdateFavoriteArticleCommandHandler : IRequestHandler<UpdateFavoriteArticleCommand, CustomResponseDto<UpdatedFavoriteArticleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteArticleRepository _favoriteArticleRepository;
        private readonly FavoriteArticleBusinessRules _favoriteArticleBusinessRules;

        public UpdateFavoriteArticleCommandHandler(IMapper mapper, IFavoriteArticleRepository favoriteArticleRepository,
                                         FavoriteArticleBusinessRules favoriteArticleBusinessRules)
        {
            _mapper = mapper;
            _favoriteArticleRepository = favoriteArticleRepository;
            _favoriteArticleBusinessRules = favoriteArticleBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedFavoriteArticleResponse>> Handle(UpdateFavoriteArticleCommand request, CancellationToken cancellationToken)
        {
            FavoriteArticle? favoriteArticle = await _favoriteArticleRepository.GetAsync(predicate: fa => fa.Id == request.Id, cancellationToken: cancellationToken);
            await _favoriteArticleBusinessRules.FavoriteArticleShouldExistWhenSelected(favoriteArticle);
            favoriteArticle = _mapper.Map(request, favoriteArticle);

            await _favoriteArticleRepository.UpdateAsync(favoriteArticle!);

            UpdatedFavoriteArticleResponse response = _mapper.Map<UpdatedFavoriteArticleResponse>(favoriteArticle);

          return CustomResponseDto<UpdatedFavoriteArticleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}