using Application.Features.Subscriptions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Subscriptions.Rules;

public class SubscriptionBusinessRules : BaseBusinessRules
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionBusinessRules(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public Task SubscriptionShouldExistWhenSelected(Subscription? subscription)
    {
        if (subscription == null)
            throw new BusinessException(SubscriptionsBusinessMessages.SubscriptionNotExists);
        return Task.CompletedTask;
    }

    public async Task SubscriptionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Subscription? subscription = await _subscriptionRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SubscriptionShouldExistWhenSelected(subscription);
    }

    public async Task CheckControlDuplicateEmailAddressForAddAsync(string email, CancellationToken cancellationToken)
    {
        Subscription? subscription = await _subscriptionRepository.GetAsync(
                       predicate: s => s.Email == email,
                       enableTracking: false,
                       cancellationToken: cancellationToken);

        if (subscription != null)
            throw new BusinessException(SubscriptionsBusinessMessages.EmailAddressAlreadyExists);
    }
}