using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ratings;

public interface IRatingsService
{
    Task<Rating?> GetAsync(
        Expression<Func<Rating, bool>> predicate,
        Func<IQueryable<Rating>, IIncludableQueryable<Rating, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Rating>?> GetListAsync(
        Expression<Func<Rating, bool>>? predicate = null,
        Func<IQueryable<Rating>, IOrderedQueryable<Rating>>? orderBy = null,
        Func<IQueryable<Rating>, IIncludableQueryable<Rating, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Rating> AddAsync(Rating rating);
    Task<Rating> UpdateAsync(Rating rating);
    Task<Rating> DeleteAsync(Rating rating, bool permanent = false);
}
