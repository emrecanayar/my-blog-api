using Application.Features.FavoriteArticles.Commands.Create;
using Application.Features.FavoriteArticles.Commands.Delete;
using Application.Features.FavoriteArticles.Commands.Update;
using Application.Features.FavoriteArticles.Queries.GetById;
using Application.Features.FavoriteArticles.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.FavoriteArticles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FavoriteArticle, CreateFavoriteArticleCommand>().ReverseMap();
        CreateMap<FavoriteArticle, CreatedFavoriteArticleResponse>().ReverseMap();
        CreateMap<FavoriteArticle, UpdateFavoriteArticleCommand>().ReverseMap();
        CreateMap<FavoriteArticle, UpdatedFavoriteArticleResponse>().ReverseMap();
        CreateMap<FavoriteArticle, DeleteFavoriteArticleCommand>().ReverseMap();
        CreateMap<FavoriteArticle, DeletedFavoriteArticleResponse>().ReverseMap();
        CreateMap<FavoriteArticle, GetByIdFavoriteArticleResponse>().ReverseMap();
        CreateMap<FavoriteArticle, GetListFavoriteArticleListItemDto>().ReverseMap();
        CreateMap<IPaginate<FavoriteArticle>, GetListResponse<GetListFavoriteArticleListItemDto>>().ReverseMap();
    }
}