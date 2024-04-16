using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;

namespace Application.Features.Notifications.Queries.GetList;

public class GetListNotificationQuery : IRequest<CustomResponseDto<GetListResponse<GetListNotificationListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public GetListNotificationQuery()
    {
        PageRequest = default!;
    }

    public class GetListNotificationQueryHandler : IRequestHandler<GetListNotificationQuery, CustomResponseDto<GetListResponse<GetListNotificationListItemDto>>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetListNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListNotificationListItemDto>>> Handle(GetListNotificationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Notification> notifications = await _notificationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListNotificationListItemDto> response = _mapper.Map<GetListResponse<GetListNotificationListItemDto>>(notifications);
            return CustomResponseDto<GetListResponse<GetListNotificationListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}