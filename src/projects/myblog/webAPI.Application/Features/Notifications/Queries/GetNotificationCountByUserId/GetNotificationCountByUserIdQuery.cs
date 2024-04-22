using Application.Services.Notifications;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;

namespace webAPI.Application.Features.Notifications.Queries.GetNotificationCountByUserId
{
    public class GetNotificationCountByUserIdQuery : IRequest<CustomResponseDto<GetNotificationCountDto>>
    {
        public Guid UserId { get; set; }

        public class GetNotificationCountByUserIdQueryHandler : IRequestHandler<GetNotificationCountByUserIdQuery, CustomResponseDto<GetNotificationCountDto>>
        {
            private readonly INotificationsService _notificationsService;

            public GetNotificationCountByUserIdQueryHandler(INotificationsService notificationsService)
            {
                _notificationsService = notificationsService;
            }

            public async Task<CustomResponseDto<GetNotificationCountDto>> Handle(GetNotificationCountByUserIdQuery request, CancellationToken cancellationToken)
            {
                GetNotificationCountDto result = await _notificationsService.GetNotificationCountByUserId(request.UserId);
                return CustomResponseDto<GetNotificationCountDto>.Success(statusCode: (int)HttpStatusCode.OK, data: result, isSuccess: true);
            }
        }
    }
}
