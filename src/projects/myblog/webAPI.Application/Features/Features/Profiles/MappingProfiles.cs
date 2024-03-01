using Application.Features.Features.Queries.GetById;
using Application.Features.Features.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Features.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Feature, GetByIdFeatureResponse>().ReverseMap();
        CreateMap<Feature, GetListFeatureListItemDto>().ReverseMap();
        CreateMap<IPaginate<Feature>, GetListResponse<GetListFeatureListItemDto>>().ReverseMap();
    }
}