using Application.Features.ArticleUploadedFiles.Commands.Create;
using Application.Features.ArticleUploadedFiles.Commands.Delete;
using Application.Features.ArticleUploadedFiles.Commands.Update;
using Application.Features.ArticleUploadedFiles.Queries.GetById;
using Application.Features.ArticleUploadedFiles.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ArticleUploadedFiles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ArticleUploadedFile, CreateArticleUploadedFileCommand>().ReverseMap();
        CreateMap<ArticleUploadedFile, CreatedArticleUploadedFileResponse>().ReverseMap();
        CreateMap<ArticleUploadedFile, UpdateArticleUploadedFileCommand>().ReverseMap();
        CreateMap<ArticleUploadedFile, UpdatedArticleUploadedFileResponse>().ReverseMap();
        CreateMap<ArticleUploadedFile, DeleteArticleUploadedFileCommand>().ReverseMap();
        CreateMap<ArticleUploadedFile, DeletedArticleUploadedFileResponse>().ReverseMap();
        CreateMap<ArticleUploadedFile, GetByIdArticleUploadedFileResponse>().ReverseMap();
        CreateMap<ArticleUploadedFile, GetListArticleUploadedFileListItemDto>().ReverseMap();
        CreateMap<IPaginate<ArticleUploadedFile>, GetListResponse<GetListArticleUploadedFileListItemDto>>().ReverseMap();
    }
}