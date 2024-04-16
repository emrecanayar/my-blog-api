using Application.Services.Notifications;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommand : IRequest<CustomResponseDto<CreatedNotificationResponse>>
{

    public Guid UserId { get; set; }
    public NotificationType Type { get; set; }
    public string Content { get; set; } = string.Empty;
    public Guid ArticleId { get; set; }

    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, CustomResponseDto<CreatedNotificationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly INotificationsService _notificationsService;

        public CreateNotificationCommandHandler(IMapper mapper, INotificationsService notificationsService)
        {
            _mapper = mapper;
            _notificationsService = notificationsService;
        }

        public async Task<CustomResponseDto<CreatedNotificationResponse>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            Notification addedNotification = await _notificationsService.CreateNotificationAsync(request);
            CreatedNotificationResponse response = _mapper.Map<CreatedNotificationResponse>(addedNotification);
            return CustomResponseDto<CreatedNotificationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}