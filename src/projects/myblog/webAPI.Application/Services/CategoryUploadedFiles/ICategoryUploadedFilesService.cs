using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryUploadedFiles;

public interface ICategoryUploadedFilesService
{
    Task<CategoryUploadedFile?> GetAsync(
        Expression<Func<CategoryUploadedFile, bool>> predicate,
        Func<IQueryable<CategoryUploadedFile>, IIncludableQueryable<CategoryUploadedFile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CategoryUploadedFile>?> GetListAsync(
        Expression<Func<CategoryUploadedFile, bool>>? predicate = null,
        Func<IQueryable<CategoryUploadedFile>, IOrderedQueryable<CategoryUploadedFile>>? orderBy = null,
        Func<IQueryable<CategoryUploadedFile>, IIncludableQueryable<CategoryUploadedFile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CategoryUploadedFile> AddAsync(CategoryUploadedFile categoryUploadedFile);
    Task<CategoryUploadedFile> UpdateAsync(CategoryUploadedFile categoryUploadedFile);
    Task<CategoryUploadedFile> DeleteAsync(CategoryUploadedFile categoryUploadedFile, bool permanent = false);
}
