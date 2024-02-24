using Application.Services.Articles;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Features.Articles.Commands.Create;

public class CreateArticleCommand : BaseFileTokenDto, IRequest<CustomResponseDto<CreatedArticleResponse>>
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    [JsonIgnore]
    public DateTime Date { get; set; }
    [JsonIgnore]
    public int ViewCount { get; set; } = 0;
    [JsonIgnore]
    public int CommentCount { get; set; } = 0;
    [JsonIgnore]
    public string SeoAuthor { get; set; } = string.Empty;
    [JsonIgnore]
    public string SeoDescription { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    [JsonIgnore]
    public Guid UserId { get; set; }
    public string[] Tags { get; set; } = [];

    [JsonIgnore]
    public string WebRootPath { get; set; } = string.Empty;


    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CustomResponseDto<CreatedArticleResponse>>
    {
        private readonly IArticlesService _articlesService;
        private readonly IMapper _mapper;

        public CreateArticleCommandHandler(IArticlesService articlesService, IMapper mapper)
        {
            _articlesService = articlesService;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CreatedArticleResponse>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            Article addedArticle = await _articlesService.AddArticleWithFileAsync(request);
            CreatedArticleResponse response = _mapper.Map<CreatedArticleResponse>(addedArticle);
            return CustomResponseDto<CreatedArticleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}