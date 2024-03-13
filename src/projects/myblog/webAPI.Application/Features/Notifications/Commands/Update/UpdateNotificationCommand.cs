using Application.Features.Notifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Commands.Update;

public class UpdateNotificationCommand : IRequest<CustomResponseDto<UpdatedNotificationResponse>>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Type { get; set; }
    public string Content { get; set; }
    public bool IsRead { get; set; }

    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, CustomResponseDto<UpdatedNotificationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly NotificationBusinessRules _notificationBusinessRules;

        public UpdateNotificationCommandHandler(IMapper mapper, INotificationRepository notificationRepository,
                                         NotificationBusinessRules notificationBusinessRules)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _notificationBusinessRules = notificationBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedNotificationResponse>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            Notification? notification = await _notificationRepository.GetAsync(predicate: n => n.Id == request.Id, cancellationToken: cancellationToken);
            await _notificationBusinessRules.NotificationShouldExistWhenSelected(notification);
            notification = _mapper.Map(request, notification);

            await _notificationRepository.UpdateAsync(notification!);

            UpdatedNotificationResponse response = _mapper.Map<UpdatedNotificationResponse>(notification);

          return CustomResponseDto<UpdatedNotificationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}