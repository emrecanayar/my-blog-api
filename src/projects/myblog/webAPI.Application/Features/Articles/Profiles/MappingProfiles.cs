using Application.Features.Articles.Commands.Create;
using Application.Features.Articles.Commands.Delete;
using Application.Features.Articles.Commands.Update;
using Application.Features.Articles.Queries.GetById;
using Application.Features.Articles.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.Articles.Queries.GetByIdForSearch;
using webAPI.Application.Features.Articles.Queries.GetListByDynamic;
using webAPI.Application.Features.Articles.Queries.GetListByDynamicForSearch;
using webAPI.Application.Features.Articles.Queries.GetListByRating;

namespace Application.Features.Articles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Article, CreateArticleCommand>().ForMember(dest => dest.Tags, opt => opt.Ignore()).ReverseMap().ForMember(dest => dest.Tags, opt => opt.Ignore());
        CreateMap<Article, CreatedArticleResponse>().ReverseMap();
        CreateMap<Article, UpdateArticleCommand>().ReverseMap();
        CreateMap<Article, UpdatedArticleResponse>().ReverseMap();
        CreateMap<Article, DeleteArticleCommand>().ReverseMap();
        CreateMap<Article, DeletedArticleResponse>().ReverseMap();
        CreateMap<Article, GetByIdArticleResponse>().ReverseMap();
        CreateMap<Article, GetListArticleListItemDto>().ReverseMap();
        CreateMap<Article, GetListByRatingItemDto>().ReverseMap();
        CreateMap<IPaginate<Article>, GetListResponse<GetListArticleListItemDto>>().ReverseMap();
        CreateMap<Article, GetListArticleListItemDto>()
            .AfterMap((src, dest, context) =>
            {
                if (src.User != null && src.User.FavoriteArticles != null)
                {
                    dest.IsUserFavoriteArticle = src.User.FavoriteArticles.Any(fa => fa.ArticleId == src.Id);
                }
                else dest.IsUserFavoriteArticle = false;
            });
        CreateMap<Article, GetListArticleForSearchListItemDto>().ReverseMap();
        CreateMap<IPaginate<Article>, GetListResponse<GetListArticleForSearchListItemDto>>().ReverseMap();
        CreateMap<Article, GetListArticleForSearchListItemDto>()
          .AfterMap((src, dest, context) =>
          {
              if (src.User is not null && src.Category is not null)
              {
                  dest.CategoryName = src.Category.Name;
                  dest.AuthorName = src.User.FirstName + " " + src.User.LastName;
              }
              else
              {
                  dest.CategoryName = string.Empty;
                  dest.AuthorName = string.Empty;
              }
          });
        CreateMap<IPaginate<Article>, GetListResponse<GetListByRatingItemDto>>().ReverseMap();
        CreateMap<IPaginate<Article>, GetListByRatingItemDto>().ReverseMap();
        CreateMap<IPaginate<Article>, ArticleListModel>().ReverseMap();
        CreateMap<IPaginate<Article>, ArticleSearchListModel>().ReverseMap();
        CreateMap<Article, GetByIdForSearchArticleResponse>().ReverseMap();
    }
}