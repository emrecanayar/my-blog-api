using Application.Features.ArticleVotes.Commands.Create;
using Application.Features.ArticleVotes.Commands.Delete;
using Application.Features.ArticleVotes.Commands.Update;
using Application.Features.ArticleVotes.Queries.GetById;
using Application.Features.ArticleVotes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ArticleVotes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ArticleVote, CreateArticleVoteCommand>().ReverseMap();
        CreateMap<ArticleVote, CreatedArticleVoteResponse>().ReverseMap();
        CreateMap<ArticleVote, UpdateArticleVoteCommand>().ReverseMap();
        CreateMap<ArticleVote, UpdatedArticleVoteResponse>().ReverseMap();
        CreateMap<ArticleVote, DeleteArticleVoteCommand>().ReverseMap();
        CreateMap<ArticleVote, DeletedArticleVoteResponse>().ReverseMap();
        CreateMap<ArticleVote, GetByIdArticleVoteResponse>().ReverseMap();
        CreateMap<ArticleVote, GetListArticleVoteListItemDto>().ReverseMap();
        CreateMap<IPaginate<ArticleVote>, GetListResponse<GetListArticleVoteListItemDto>>().ReverseMap();
    }
}