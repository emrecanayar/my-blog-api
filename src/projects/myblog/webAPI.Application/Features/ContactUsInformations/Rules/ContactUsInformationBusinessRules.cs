using Application.Features.ContactUsInformations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.ContactUsInformations.Rules;

public class ContactUsInformationBusinessRules : BaseBusinessRules
{
    private readonly IContactUsInformationRepository _contactUsInformationRepository;

    public ContactUsInformationBusinessRules(IContactUsInformationRepository contactUsInformationRepository)
    {
        _contactUsInformationRepository = contactUsInformationRepository;
    }

    public Task ContactUsInformationShouldExistWhenSelected(ContactUsInformation? contactUsInformation)
    {
        if (contactUsInformation == null)
            throw new BusinessException(ContactUsInformationsBusinessMessages.ContactUsInformationNotExists);
        return Task.CompletedTask;
    }

    public async Task ContactUsInformationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ContactUsInformation? contactUsInformation = await _contactUsInformationRepository.GetAsync(
            predicate: cui => cui.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ContactUsInformationShouldExistWhenSelected(contactUsInformation);
    }
}