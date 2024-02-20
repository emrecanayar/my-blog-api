using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.Categories.Queries.GetListByDynamic;

namespace Application.Features.Categories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, GetByIdCategoryResponse>().ReverseMap();
        CreateMap<Category, GetListCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<Category>, GetListResponse<GetListCategoryListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Category>, CategoryListModel>().ReverseMap();
    }
}