using Application.Features.Notifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Features.Notifications.Queries.GetById;

public class GetByIdNotificationQuery : IRequest<CustomResponseDto<GetByIdNotificationResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdNotificationQueryHandler : IRequestHandler<GetByIdNotificationQuery, CustomResponseDto<GetByIdNotificationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly NotificationBusinessRules _notificationBusinessRules;

        public GetByIdNotificationQueryHandler(IMapper mapper, INotificationRepository notificationRepository, NotificationBusinessRules notificationBusinessRules)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _notificationBusinessRules = notificationBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdNotificationResponse>> Handle(GetByIdNotificationQuery request, CancellationToken cancellationToken)
        {
            Notification? notification = await _notificationRepository.GetAsync(predicate: n => n.Id == request.Id,
                                                                                include: x => x.Include(x => x.Article).Include(x => x.User).Include(x => x.Comment), cancellationToken: cancellationToken);
            await _notificationBusinessRules.NotificationShouldExistWhenSelected(notification);

            GetByIdNotificationResponse response = _mapper.Map<GetByIdNotificationResponse>(notification);
            return CustomResponseDto<GetByIdNotificationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}