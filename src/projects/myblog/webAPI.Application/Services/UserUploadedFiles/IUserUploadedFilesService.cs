using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserUploadedFiles;

public interface IUserUploadedFilesService
{
    Task<UserUploadedFile?> GetAsync(
        Expression<Func<UserUploadedFile, bool>> predicate,
        Func<IQueryable<UserUploadedFile>, IIncludableQueryable<UserUploadedFile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserUploadedFile>?> GetListAsync(
        Expression<Func<UserUploadedFile, bool>>? predicate = null,
        Func<IQueryable<UserUploadedFile>, IOrderedQueryable<UserUploadedFile>>? orderBy = null,
        Func<IQueryable<UserUploadedFile>, IIncludableQueryable<UserUploadedFile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserUploadedFile> AddAsync(UserUploadedFile userUploadedFile);
    Task<UserUploadedFile> UpdateAsync(UserUploadedFile userUploadedFile);
    Task<UserUploadedFile> DeleteAsync(UserUploadedFile userUploadedFile, bool permanent = false);
}
