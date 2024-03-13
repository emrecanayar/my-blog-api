using Application.Services.Notifications;
using AutoMapper;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace webAPI.Application.Features.Notifications.Queries.GetByUserId
{
    public class GetByUserIdNotificationQuery : IRequest<CustomResponseDto<GetListResponse<GetByUserIdNotificationResponse>>>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        public class GetByUserIdNotificationQueryHandler : IRequestHandler<GetByUserIdNotificationQuery, CustomResponseDto<GetListResponse<GetByUserIdNotificationResponse>>>
        {
            private readonly INotificationsService _notificationsService;
            private readonly IMapper _mapper;

            public GetByUserIdNotificationQueryHandler(INotificationsService notificationsService, IMapper mapper)
            {
                _notificationsService = notificationsService;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<GetListResponse<GetByUserIdNotificationResponse>>> Handle(GetByUserIdNotificationQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Notification> notifications = await _notificationsService.GetNotificationsAsync(request.UserId);
                GetListResponse<GetByUserIdNotificationResponse> response = _mapper.Map<GetListResponse<GetByUserIdNotificationResponse>>(notifications);

                return CustomResponseDto<GetListResponse<GetByUserIdNotificationResponse>>.Success((int)HttpStatusCode.OK, response, true);
            }
        }
    }
}
