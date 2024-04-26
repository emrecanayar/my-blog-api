using Application.Features.Articles.Commands.Create;
using Application.Features.Articles.Constants;
using Application.Features.Articles.Queries.GetById;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;
using webAPI.Application.Features.UploadedFiles.Dtos;
using webAPI.Application.Services.UploadedFileService;

namespace Application.Features.Articles.Rules;

public class ArticleBusinessRules : BaseBusinessRules
{
    private readonly IArticleRepository _articleRepository;
    private readonly IUploadedFileService _uploadedFileService;
    public readonly string IMG_FOLDER = Path.Combine("Resources", "Files", typeof(Article).Name);

    public ArticleBusinessRules(IArticleRepository articleRepository, IUploadedFileService uploadedFileService)
    {
        _articleRepository = articleRepository;
        _uploadedFileService = uploadedFileService;
    }

    public Task ArticleShouldExistWhenSelected(Article? article)
    {
        if (article == null)
            throw new BusinessException(ArticlesBusinessMessages.ArticleNotExists);
        return Task.CompletedTask;
    }

    public async Task ArticleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Article? article = await _articleRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ArticleShouldExistWhenSelected(article);
    }
    public async Task<UploadedFileResponseDto> CheckArticleForAddAsync(CreateArticleCommand createArticleCommand)
    {
        if (createArticleCommand.Tokens?.Count > 0)
        {
            UploadedFileResponseDto? uploadedFile = await _uploadedFileService.TransferFile(createArticleCommand.Tokens[0], IMG_FOLDER, createArticleCommand.WebRootPath);


            if (uploadedFile is not null) return uploadedFile;

            throw new BusinessException("Makale için yüklenen dosya bulunamadý.");

        }

        throw new BusinessException("Makale için yüklenen token bulunamadý.");
    }

    public Task CheckAddedTagsForArticleAsync(IList<Tag> tags)
    {
        if (tags is null || tags.Count is 0)
        {
            throw new BusinessException("Makale oluþtururken eklenecek etiket bulunamadý");
        }
        return Task.CompletedTask;
    }

    public Task<CreateArticleCommand> MappedForArticleAddAsync(CreateArticleCommand createArticleCommand)
    {
        createArticleCommand.Date = DateTime.Now;
        createArticleCommand.ViewCount = 0;
        createArticleCommand.CommentCount = 0;
        createArticleCommand.SeoDescription = createArticleCommand.Content.Length > 150 ? createArticleCommand.Content.Substring(0, 150) : createArticleCommand.Content;

        return Task.FromResult(createArticleCommand);
    }

    public double CalculateAverageRating(GetByIdArticleResponse byIdArticleResponse)
    {
        if (byIdArticleResponse.Ratings.Count == 0)
        {
            return 0;
        }

        return byIdArticleResponse.Ratings.Average(r => r.Score);
    }

    public Task MappedArticleAverageRatingAsync(GetByIdArticleResponse byIdArticleResponse)
    {
        byIdArticleResponse.AverageRating = CalculateAverageRating(byIdArticleResponse);
        return Task.CompletedTask;
    }
}