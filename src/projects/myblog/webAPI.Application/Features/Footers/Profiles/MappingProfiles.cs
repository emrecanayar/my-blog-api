using Application.Features.Footers.Queries.GetById;
using Application.Features.Footers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Footers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Footer, GetByIdFooterResponse>().ReverseMap();
        CreateMap<Footer, GetListFooterListItemDto>().ReverseMap();
        CreateMap<IPaginate<Footer>, GetListResponse<GetListFooterListItemDto>>().ReverseMap();
    }
}