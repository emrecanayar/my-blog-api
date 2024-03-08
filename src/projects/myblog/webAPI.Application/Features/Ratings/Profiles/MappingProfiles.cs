using Application.Features.Ratings.Commands.Create;
using Application.Features.Ratings.Commands.Update;
using Application.Features.Ratings.Queries.GetList;
using AutoMapper;
using Core.Domain.Entities;

namespace Application.Features.Ratings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Rating, CreateRatingCommand>().ReverseMap();
        CreateMap<Rating, CreatedRatingResponse>().ReverseMap();
        CreateMap<Rating, UpdateRatingCommand>().ReverseMap();
        CreateMap<Rating, UpdatedRatingResponse>().ReverseMap();
        CreateMap<Rating, GetListRatingListItemDto>().ReverseMap();
    }
}