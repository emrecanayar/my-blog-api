using Application.Features.Abouts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Abouts.Rules;

public class AboutBusinessRules : BaseBusinessRules
{
    private readonly IAboutRepository _aboutRepository;
    public AboutBusinessRules(IAboutRepository aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }

    public Task AboutShouldExistWhenSelected(About? about)
    {
        if (about == null)
            throw new BusinessException(AboutsBusinessMessages.AboutNotExists);
        return Task.CompletedTask;
    }

    public async Task AboutIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        About? about = await _aboutRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AboutShouldExistWhenSelected(about);
    }
}