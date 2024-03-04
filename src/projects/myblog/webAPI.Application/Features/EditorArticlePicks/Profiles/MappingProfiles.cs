using Application.Features.EditorArticlePicks.Queries.GetById;
using Application.Features.EditorArticlePicks.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.EditorArticlePicks.Queries.GetListByDynamic;

namespace Application.Features.EditorArticlePicks.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EditorArticlePick, GetByIdEditorArticlePickResponse>().ReverseMap();
        CreateMap<EditorArticlePick, GetListEditorArticlePickListItemDto>().ReverseMap();
        CreateMap<IPaginate<EditorArticlePick>, GetListResponse<GetListEditorArticlePickListItemDto>>().ReverseMap();
        CreateMap<IPaginate<EditorArticlePick>, EditorArticlePickListModel>().ReverseMap();
    }
}