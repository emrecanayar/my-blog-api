using Application.Features.Subscriptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.Subscriptions.Commands.Create;

public class CreateSubscriptionCommand : IRequest<CustomResponseDto<CreatedSubscriptionResponse>>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid? UserId { get; set; }

    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, CustomResponseDto<CreatedSubscriptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

        public CreateSubscriptionCommandHandler(IMapper mapper, ISubscriptionRepository subscriptionRepository,
                                         SubscriptionBusinessRules subscriptionBusinessRules)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
            _subscriptionBusinessRules = subscriptionBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedSubscriptionResponse>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            await _subscriptionBusinessRules.CheckControlDuplicateEmailAddressForAddAsync(request.Email, cancellationToken);
            Subscription subscription = _mapper.Map<Subscription>(request);
            await _subscriptionRepository.AddAsync(subscription);
            CreatedSubscriptionResponse response = _mapper.Map<CreatedSubscriptionResponse>(subscription);
            return CustomResponseDto<CreatedSubscriptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}