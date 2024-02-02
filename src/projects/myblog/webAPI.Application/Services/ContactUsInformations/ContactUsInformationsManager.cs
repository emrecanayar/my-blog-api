using Application.Features.ContactUsInformations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ContactUsInformations;

public class ContactUsInformationsManager : IContactUsInformationsService
{
    private readonly IContactUsInformationRepository _contactUsInformationRepository;
    private readonly ContactUsInformationBusinessRules _contactUsInformationBusinessRules;

    public ContactUsInformationsManager(IContactUsInformationRepository contactUsInformationRepository, ContactUsInformationBusinessRules contactUsInformationBusinessRules)
    {
        _contactUsInformationRepository = contactUsInformationRepository;
        _contactUsInformationBusinessRules = contactUsInformationBusinessRules;
    }

    public async Task<ContactUsInformation?> GetAsync(
        Expression<Func<ContactUsInformation, bool>> predicate,
        Func<IQueryable<ContactUsInformation>, IIncludableQueryable<ContactUsInformation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ContactUsInformation? contactUsInformation = await _contactUsInformationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return contactUsInformation;
    }

    public async Task<IPaginate<ContactUsInformation>?> GetListAsync(
        Expression<Func<ContactUsInformation, bool>>? predicate = null,
        Func<IQueryable<ContactUsInformation>, IOrderedQueryable<ContactUsInformation>>? orderBy = null,
        Func<IQueryable<ContactUsInformation>, IIncludableQueryable<ContactUsInformation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ContactUsInformation> contactUsInformationList = await _contactUsInformationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return contactUsInformationList;
    }

    public async Task<ContactUsInformation> AddAsync(ContactUsInformation contactUsInformation)
    {
        ContactUsInformation addedContactUsInformation = await _contactUsInformationRepository.AddAsync(contactUsInformation);

        return addedContactUsInformation;
    }

    public async Task<ContactUsInformation> UpdateAsync(ContactUsInformation contactUsInformation)
    {
        ContactUsInformation updatedContactUsInformation = await _contactUsInformationRepository.UpdateAsync(contactUsInformation);

        return updatedContactUsInformation;
    }

    public async Task<ContactUsInformation> DeleteAsync(ContactUsInformation contactUsInformation, bool permanent = false)
    {
        ContactUsInformation deletedContactUsInformation = await _contactUsInformationRepository.DeleteAsync(contactUsInformation);

        return deletedContactUsInformation;
    }
}
