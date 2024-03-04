using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.HeadArticleFeatureUploadedFiles;

public interface IHeadArticleFeatureUploadedFilesService
{
    Task<HeadArticleFeatureUploadedFile?> GetAsync(
        Expression<Func<HeadArticleFeatureUploadedFile, bool>> predicate,
        Func<IQueryable<HeadArticleFeatureUploadedFile>, IIncludableQueryable<HeadArticleFeatureUploadedFile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<HeadArticleFeatureUploadedFile>?> GetListAsync(
        Expression<Func<HeadArticleFeatureUploadedFile, bool>>? predicate = null,
        Func<IQueryable<HeadArticleFeatureUploadedFile>, IOrderedQueryable<HeadArticleFeatureUploadedFile>>? orderBy = null,
        Func<IQueryable<HeadArticleFeatureUploadedFile>, IIncludableQueryable<HeadArticleFeatureUploadedFile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<HeadArticleFeatureUploadedFile> AddAsync(HeadArticleFeatureUploadedFile headArticleFeatureUploadedFile);
    Task<HeadArticleFeatureUploadedFile> UpdateAsync(HeadArticleFeatureUploadedFile headArticleFeatureUploadedFile);
    Task<HeadArticleFeatureUploadedFile> DeleteAsync(HeadArticleFeatureUploadedFile headArticleFeatureUploadedFile, bool permanent = false);
}
