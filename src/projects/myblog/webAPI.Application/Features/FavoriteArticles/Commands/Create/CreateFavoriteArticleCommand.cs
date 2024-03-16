using Application.Features.FavoriteArticles.Constants;
using Application.Features.FavoriteArticles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Features.FavoriteArticles.Commands.Create;

public class CreateFavoriteArticleCommand : IRequest<CustomResponseDto<CreatedFavoriteArticleResponse>>, ISecuredRequest
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }

    public string[] Roles => [FavoriteArticlesOperationClaims.Write, FavoriteArticlesOperationClaims.Admin];

    public class CreateFavoriteArticleCommandHandler : IRequestHandler<CreateFavoriteArticleCommand, CustomResponseDto<CreatedFavoriteArticleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteArticleRepository _favoriteArticleRepository;
        private readonly FavoriteArticleBusinessRules _favoriteArticleBusinessRules;

        public CreateFavoriteArticleCommandHandler(IMapper mapper, IFavoriteArticleRepository favoriteArticleRepository,
                                         FavoriteArticleBusinessRules favoriteArticleBusinessRules)
        {
            _mapper = mapper;
            _favoriteArticleRepository = favoriteArticleRepository;
            _favoriteArticleBusinessRules = favoriteArticleBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedFavoriteArticleResponse>> Handle(CreateFavoriteArticleCommand request, CancellationToken cancellationToken)
        {
            FavoriteArticle favoriteArticle = _mapper.Map<FavoriteArticle>(request);
            await _favoriteArticleRepository.AddAsync(favoriteArticle);
            CreatedFavoriteArticleResponse response = _mapper.Map<CreatedFavoriteArticleResponse>(favoriteArticle);
            return CustomResponseDto<CreatedFavoriteArticleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}