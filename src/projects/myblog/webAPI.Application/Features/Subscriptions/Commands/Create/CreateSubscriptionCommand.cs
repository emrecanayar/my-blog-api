using Application.Features.Notifications.Commands.Create;
using Application.Features.Subscriptions.Rules;
using Application.Features.Users.Queries.GetList;
using Application.Services.Notifications;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.ComplexTypes.Enums;
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
        private readonly IUserService _userService;
        private readonly INotificationsService _notificationsService;
        private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

        public CreateSubscriptionCommandHandler(IMapper mapper, ISubscriptionRepository subscriptionRepository,
                                         SubscriptionBusinessRules subscriptionBusinessRules, IUserService userService, INotificationsService notificationsService)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
            _subscriptionBusinessRules = subscriptionBusinessRules;
            _userService = userService;
            _notificationsService = notificationsService;
        }

        public async Task<CustomResponseDto<CreatedSubscriptionResponse>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            await _subscriptionBusinessRules.CheckControlDuplicateEmailAddressForAddAsync(request.Email, cancellationToken);
            Subscription subscription = _mapper.Map<Subscription>(request);
            Subscription addedSubscription = await _subscriptionRepository.AddAsync(subscription);

            await SendNotificationAsync(request, addedSubscription);
            CreatedSubscriptionResponse response = _mapper.Map<CreatedSubscriptionResponse>(subscription);
            return CustomResponseDto<CreatedSubscriptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }

        private async Task SendNotificationAsync(CreateSubscriptionCommand request, Subscription addedSubscription)
        {
            //Bildirim gönderme iþlemleri önce admin kullanýcýlarýný getirelim.
            IList<GetListUserListItemDto> adminUsers = await _userService.GetAdminUsersAsync();

            //Bildirim gönderme iþlemleri
            foreach (var adminUser in adminUsers)
            {
                await _notificationsService.CreateNotificationAsync(new CreateNotificationCommand
                {
                    Content = CheckNotificationContent(request.FirstName, request.LastName, request.Email),
                    Type = NotificationType.Subscription,
                    UserId = adminUser.Id,
                    SubscriptionId = addedSubscription.Id
                });
            }
        }

        private string CheckNotificationContent(string firstName, string lastName, string email)
        {
            string content = string.Empty;
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                content = $"Tebrikler! Bloðunuz fark ediliyor. {email} email adresli kullanýcý abone oldu ve güncellemeleri almaya baþladý.";
            }
            else
            {
                content = $"Tebrikler! Bloðunuz fark ediliyor. {firstName} {lastName} isimli kullanýcý abone oldu ve güncellemeleri almaya baþladý.";
            }

            return content;
        }
    }
}