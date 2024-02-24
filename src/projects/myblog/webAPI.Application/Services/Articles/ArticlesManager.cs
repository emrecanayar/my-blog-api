using Application.Features.Articles.Commands.Create;
using Application.Features.Articles.Rules;
using Application.Services.ArticleUploadedFiles;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using webAPI.Application.Features.UploadedFiles.Dtos;

namespace Application.Services.Articles;

public class ArticlesManager : IArticlesService
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;
    private readonly IArticleUploadedFilesService _articleUploadedFilesService;
    private readonly ITagRepository _tagRepository;
    private readonly ArticleBusinessRules _articleBusinessRules;

    public ArticlesManager(IArticleRepository articleRepository, ArticleBusinessRules articleBusinessRules, IMapper mapper, IArticleUploadedFilesService articleUploadedFilesService, ITagRepository tagRepository)
    {
        _articleRepository = articleRepository;
        _articleBusinessRules = articleBusinessRules;
        _mapper = mapper;
        _articleUploadedFilesService = articleUploadedFilesService;
        _tagRepository = tagRepository;
    }

    public async Task<Article?> GetAsync(
        Expression<Func<Article, bool>> predicate,
        Func<IQueryable<Article>, IIncludableQueryable<Article, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Article? article = await _articleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return article;
    }

    public async Task<IPaginate<Article>?> GetListAsync(
        Expression<Func<Article, bool>>? predicate = null,
        Func<IQueryable<Article>, IOrderedQueryable<Article>>? orderBy = null,
        Func<IQueryable<Article>, IIncludableQueryable<Article, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Article> articleList = await _articleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return articleList;
    }

    public async Task<Article> AddAsync(Article article)
    {
        Article addedArticle = await _articleRepository.AddAsync(article);

        return addedArticle;
    }

    public async Task<Article> UpdateAsync(Article article)
    {
        Article updatedArticle = await _articleRepository.UpdateAsync(article);

        return updatedArticle;
    }

    public async Task<Article> DeleteAsync(Article article, bool permanent = false)
    {
        Article deletedArticle = await _articleRepository.DeleteAsync(article);

        return deletedArticle;
    }

    public async Task<Article> AddArticleWithFileAsync(CreateArticleCommand createArticleCommand)
    {
        UploadedFileResponseDto uploadedFileResponseDto = await _articleBusinessRules.CheckArticleForAddAsync(createArticleCommand);
        createArticleCommand = await _articleBusinessRules.MappedForArticleAddAsync(createArticleCommand);
        Article article = _mapper.Map<Article>(createArticleCommand);
        Article addedArticle = await _articleRepository.AddAsync(article);
        IList<Tag> addedTagForArticle = await AddTagForArticle(createArticleCommand, addedArticle.Id);
        await _articleBusinessRules.CheckAddedTagsForArticleAsync(addedTagForArticle);
        await AddUploadedFileInformationAsync(uploadedFileResponseDto, addedArticle);
        return addedArticle;
    }

    private async Task AddUploadedFileInformationAsync(UploadedFileResponseDto uploadedFileResponse, Article article)
    {
        string fileName = Path.GetFileName(uploadedFileResponse.Path);
        string newPath = BuildNewPath(fileName);

        await _articleUploadedFilesService.AddAsync(new ArticleUploadedFile
        {
            ArticleId = article.Id,
            UploadedFileId = uploadedFileResponse.Id,
            OldPath = uploadedFileResponse.Path,
            NewPath = newPath,
        });
    }

    private async Task<IList<Tag>> AddTagForArticle(CreateArticleCommand createArticleCommand, Guid articleId)
    {
        ICollection<Tag> addedTags = await _tagRepository.AddRangeAsync(createArticleCommand.Tags.Select(tag => new Tag { Name = tag, ArticleId = articleId }).ToList());

        return [.. addedTags];
    }

    private string BuildNewPath(string fileName)
    {
        return Path.Combine(_articleBusinessRules.IMG_FOLDER, fileName).Replace("\\", "/");
    }

}
