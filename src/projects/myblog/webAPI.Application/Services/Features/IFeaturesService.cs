using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Features;

public interface IFeaturesService
{
    Task<Feature?> GetAsync(
        Expression<Func<Feature, bool>> predicate,
        Func<IQueryable<Feature>, IIncludableQueryable<Feature, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Feature>?> GetListAsync(
        Expression<Func<Feature, bool>>? predicate = null,
        Func<IQueryable<Feature>, IOrderedQueryable<Feature>>? orderBy = null,
        Func<IQueryable<Feature>, IIncludableQueryable<Feature, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Feature> AddAsync(Feature feature);
    Task<Feature> UpdateAsync(Feature feature);
    Task<Feature> DeleteAsync(Feature feature, bool permanent = false);
}
