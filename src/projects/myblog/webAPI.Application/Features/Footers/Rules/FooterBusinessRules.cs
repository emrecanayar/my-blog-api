using Application.Features.Footers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Footers.Rules;

public class FooterBusinessRules : BaseBusinessRules
{
    private readonly IFooterRepository _footerRepository;

    public FooterBusinessRules(IFooterRepository footerRepository)
    {
        _footerRepository = footerRepository;
    }

    public Task FooterShouldExistWhenSelected(Footer? footer)
    {
        if (footer == null)
            throw new BusinessException(FootersBusinessMessages.FooterNotExists);
        return Task.CompletedTask;
    }

    public async Task FooterIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Footer? footer = await _footerRepository.GetAsync(
            predicate: f => f.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FooterShouldExistWhenSelected(footer);
    }
}