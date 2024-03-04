using Application.Features.HeadArticleFeatures.Queries.GetById;
using Application.Features.HeadArticleFeatures.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.HeadArticleFeatures.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<HeadArticleFeature, GetByIdHeadArticleFeatureResponse>().ReverseMap();
        CreateMap<HeadArticleFeature, GetListHeadArticleFeatureListItemDto>().ReverseMap();
        CreateMap<IPaginate<HeadArticleFeature>, GetListResponse<GetListHeadArticleFeatureListItemDto>>().ReverseMap();
    }
}