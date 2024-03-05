using Application.Features.Footers.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Footers;

public class FootersManager : IFootersService
{
    private readonly IFooterRepository _footerRepository;
    private readonly FooterBusinessRules _footerBusinessRules;

    public FootersManager(IFooterRepository footerRepository, FooterBusinessRules footerBusinessRules)
    {
        _footerRepository = footerRepository;
        _footerBusinessRules = footerBusinessRules;
    }

    public async Task<Footer?> GetAsync(
        Expression<Func<Footer, bool>> predicate,
        Func<IQueryable<Footer>, IIncludableQueryable<Footer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Footer? footer = await _footerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return footer;
    }

    public async Task<IPaginate<Footer>?> GetListAsync(
        Expression<Func<Footer, bool>>? predicate = null,
        Func<IQueryable<Footer>, IOrderedQueryable<Footer>>? orderBy = null,
        Func<IQueryable<Footer>, IIncludableQueryable<Footer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Footer> footerList = await _footerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return footerList;
    }

    public async Task<Footer> AddAsync(Footer footer)
    {
        Footer addedFooter = await _footerRepository.AddAsync(footer);

        return addedFooter;
    }

    public async Task<Footer> UpdateAsync(Footer footer)
    {
        Footer updatedFooter = await _footerRepository.UpdateAsync(footer);

        return updatedFooter;
    }

    public async Task<Footer> DeleteAsync(Footer footer, bool permanent = false)
    {
        Footer deletedFooter = await _footerRepository.DeleteAsync(footer);

        return deletedFooter;
    }
}
