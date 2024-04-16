using Application.Features.Notifications.Commands.Create;
using Application.Features.Notifications.Commands.Delete;
using Application.Features.Notifications.Commands.Update;
using Application.Features.Notifications.Queries.GetById;
using Application.Features.Notifications.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.Notifications.Queries.GetByUserId;
using webAPI.Application.Features.Notifications.Queries.GetListByDynamic;

namespace Application.Features.Notifications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Notification, CreateNotificationCommand>().ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString())).ReverseMap();
        CreateMap<Notification, CreatedNotificationResponse>().ReverseMap();
        CreateMap<Notification, UpdateNotificationCommand>().ReverseMap();
        CreateMap<Notification, UpdatedNotificationResponse>().ReverseMap();
        CreateMap<Notification, DeleteNotificationCommand>().ReverseMap();
        CreateMap<Notification, DeletedNotificationResponse>().ReverseMap();
        CreateMap<Notification, GetByIdNotificationResponse>().ReverseMap();
        CreateMap<Notification, GetByUserIdNotificationResponse>().ReverseMap();
        CreateMap<Notification, GetListNotificationListItemDto>().ReverseMap();
        CreateMap<IPaginate<Notification>, GetListResponse<GetListNotificationListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Notification>, GetListResponse<GetByUserIdNotificationResponse>>().ReverseMap();
        CreateMap<IPaginate<Notification>, NotificationListModel>().ReverseMap();
    }
}