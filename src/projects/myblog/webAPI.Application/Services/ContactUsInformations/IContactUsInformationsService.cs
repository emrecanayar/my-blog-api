using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ContactUsInformations;

public interface IContactUsInformationsService
{
    Task<ContactUsInformation?> GetAsync(
        Expression<Func<ContactUsInformation, bool>> predicate,
        Func<IQueryable<ContactUsInformation>, IIncludableQueryable<ContactUsInformation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ContactUsInformation>?> GetListAsync(
        Expression<Func<ContactUsInformation, bool>>? predicate = null,
        Func<IQueryable<ContactUsInformation>, IOrderedQueryable<ContactUsInformation>>? orderBy = null,
        Func<IQueryable<ContactUsInformation>, IIncludableQueryable<ContactUsInformation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ContactUsInformation> AddAsync(ContactUsInformation contactUsInformation);
    Task<ContactUsInformation> UpdateAsync(ContactUsInformation contactUsInformation);
    Task<ContactUsInformation> DeleteAsync(ContactUsInformation contactUsInformation, bool permanent = false);
}
