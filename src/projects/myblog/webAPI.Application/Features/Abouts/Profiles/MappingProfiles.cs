using Application.Features.Abouts.Queries.GetById;
using Application.Features.Abouts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Abouts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<About, GetByIdAboutResponse>().ReverseMap();
        CreateMap<About, GetListAboutListItemDto>().ReverseMap();
        CreateMap<IPaginate<About>, GetListResponse<GetListAboutListItemDto>>().ReverseMap();
    }
}