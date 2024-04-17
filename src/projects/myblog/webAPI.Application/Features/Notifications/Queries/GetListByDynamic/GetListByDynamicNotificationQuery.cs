using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace webAPI.Application.Features.Notifications.Queries.GetListByDynamic
{
    public class GetListByDynamicNotificationQuery : IRequest<CustomResponseDto<NotificationListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

        public GetListByDynamicNotificationQuery()
        {
            PageRequest = default!;
            DynamicQuery = default!;
        }

        public class GetListByDynamicNotificationQueryHandler : IRequestHandler<GetListByDynamicNotificationQuery, CustomResponseDto<NotificationListModel>>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;

            public GetListByDynamicNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<NotificationListModel>> Handle(GetListByDynamicNotificationQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Notification> notifications = await _notificationRepository.GetListByDynamicAsync(
                                                        dynamic: request.DynamicQuery,
                                                        include: x => x.Include(x => x.Comment),
                                                        index: request.PageRequest.PageIndex,
                                                        size: request.PageRequest.PageSize,
                                                        cancellationToken: cancellationToken);

                NotificationListModel mappedNotificationListModel = _mapper.Map<NotificationListModel>(notifications);

                return CustomResponseDto<NotificationListModel>.Success((int)HttpStatusCode.OK, mappedNotificationListModel, true);

            }
        }
    }
}
