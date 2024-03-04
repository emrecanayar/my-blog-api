using Application.Features.HeadArticleFeatureUploadedFiles.Queries.GetById;
using Application.Features.HeadArticleFeatureUploadedFiles.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.HeadArticleFeatureUploadedFiles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<HeadArticleFeatureUploadedFile, GetByIdHeadArticleFeatureUploadedFileResponse>().ReverseMap();
        CreateMap<HeadArticleFeatureUploadedFile, GetListHeadArticleFeatureUploadedFileListItemDto>().ReverseMap();
        CreateMap<IPaginate<HeadArticleFeatureUploadedFile>, GetListResponse<GetListHeadArticleFeatureUploadedFileListItemDto>>().ReverseMap();
    }
}