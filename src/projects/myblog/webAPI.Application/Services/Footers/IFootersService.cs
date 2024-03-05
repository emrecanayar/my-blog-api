using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Footers;

public interface IFootersService
{
    Task<Footer?> GetAsync(
        Expression<Func<Footer, bool>> predicate,
        Func<IQueryable<Footer>, IIncludableQueryable<Footer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Footer>?> GetListAsync(
        Expression<Func<Footer, bool>>? predicate = null,
        Func<IQueryable<Footer>, IOrderedQueryable<Footer>>? orderBy = null,
        Func<IQueryable<Footer>, IIncludableQueryable<Footer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Footer> AddAsync(Footer footer);
    Task<Footer> UpdateAsync(Footer footer);
    Task<Footer> DeleteAsync(Footer footer, bool permanent = false);
}
