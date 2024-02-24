using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ArticleUploadedFiles;

public interface IArticleUploadedFilesService
{
    Task<ArticleUploadedFile?> GetAsync(
        Expression<Func<ArticleUploadedFile, bool>> predicate,
        Func<IQueryable<ArticleUploadedFile>, IIncludableQueryable<ArticleUploadedFile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ArticleUploadedFile>?> GetListAsync(
        Expression<Func<ArticleUploadedFile, bool>>? predicate = null,
        Func<IQueryable<ArticleUploadedFile>, IOrderedQueryable<ArticleUploadedFile>>? orderBy = null,
        Func<IQueryable<ArticleUploadedFile>, IIncludableQueryable<ArticleUploadedFile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ArticleUploadedFile> AddAsync(ArticleUploadedFile articleUploadedFile);
    Task<ArticleUploadedFile> UpdateAsync(ArticleUploadedFile articleUploadedFile);
    Task<ArticleUploadedFile> DeleteAsync(ArticleUploadedFile articleUploadedFile, bool permanent = false);
}
