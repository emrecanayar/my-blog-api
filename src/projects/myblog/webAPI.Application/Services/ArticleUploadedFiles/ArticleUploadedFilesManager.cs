using Application.Features.ArticleUploadedFiles.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ArticleUploadedFiles;

public class ArticleUploadedFilesManager : IArticleUploadedFilesService
{
    private readonly IArticleUploadedFileRepository _articleUploadedFileRepository;
    private readonly ArticleUploadedFileBusinessRules _articleUploadedFileBusinessRules;

    public ArticleUploadedFilesManager(IArticleUploadedFileRepository articleUploadedFileRepository, ArticleUploadedFileBusinessRules articleUploadedFileBusinessRules)
    {
        _articleUploadedFileRepository = articleUploadedFileRepository;
        _articleUploadedFileBusinessRules = articleUploadedFileBusinessRules;
    }

    public async Task<ArticleUploadedFile?> GetAsync(
        Expression<Func<ArticleUploadedFile, bool>> predicate,
        Func<IQueryable<ArticleUploadedFile>, IIncludableQueryable<ArticleUploadedFile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ArticleUploadedFile? articleUploadedFile = await _articleUploadedFileRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return articleUploadedFile;
    }

    public async Task<IPaginate<ArticleUploadedFile>?> GetListAsync(
        Expression<Func<ArticleUploadedFile, bool>>? predicate = null,
        Func<IQueryable<ArticleUploadedFile>, IOrderedQueryable<ArticleUploadedFile>>? orderBy = null,
        Func<IQueryable<ArticleUploadedFile>, IIncludableQueryable<ArticleUploadedFile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ArticleUploadedFile> articleUploadedFileList = await _articleUploadedFileRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return articleUploadedFileList;
    }

    public async Task<ArticleUploadedFile> AddAsync(ArticleUploadedFile articleUploadedFile)
    {
        ArticleUploadedFile addedArticleUploadedFile = await _articleUploadedFileRepository.AddAsync(articleUploadedFile);

        return addedArticleUploadedFile;
    }

    public async Task<ArticleUploadedFile> UpdateAsync(ArticleUploadedFile articleUploadedFile)
    {
        ArticleUploadedFile updatedArticleUploadedFile = await _articleUploadedFileRepository.UpdateAsync(articleUploadedFile);

        return updatedArticleUploadedFile;
    }

    public async Task<ArticleUploadedFile> DeleteAsync(ArticleUploadedFile articleUploadedFile, bool permanent = false)
    {
        ArticleUploadedFile deletedArticleUploadedFile = await _articleUploadedFileRepository.DeleteAsync(articleUploadedFile);

        return deletedArticleUploadedFile;
    }
}
