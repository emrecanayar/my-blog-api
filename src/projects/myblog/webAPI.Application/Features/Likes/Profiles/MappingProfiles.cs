using Application.Features.Likes.Commands.Create;
using Application.Features.Likes.Queries.GetById;
using Application.Features.Likes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Likes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Like, CreateLikeCommand>().ReverseMap();
        CreateMap<Like, CreatedLikeResponse>().ReverseMap();
        CreateMap<Like, GetByIdLikeResponse>().ReverseMap();
        CreateMap<Like, GetListLikeListItemDto>().ReverseMap();
        CreateMap<IPaginate<Like>, GetListResponse<GetListLikeListItemDto>>().ReverseMap();
    }
}