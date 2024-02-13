using Application.Features.CategoryUploadedFiles.Commands.Create;
using Application.Features.CategoryUploadedFiles.Commands.Delete;
using Application.Features.CategoryUploadedFiles.Commands.Update;
using Application.Features.CategoryUploadedFiles.Queries.GetById;
using Application.Features.CategoryUploadedFiles.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CategoryUploadedFiles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoryUploadedFile, CreateCategoryUploadedFileCommand>().ReverseMap();
        CreateMap<CategoryUploadedFile, CreatedCategoryUploadedFileResponse>().ReverseMap();
        CreateMap<CategoryUploadedFile, UpdateCategoryUploadedFileCommand>().ReverseMap();
        CreateMap<CategoryUploadedFile, UpdatedCategoryUploadedFileResponse>().ReverseMap();
        CreateMap<CategoryUploadedFile, DeleteCategoryUploadedFileCommand>().ReverseMap();
        CreateMap<CategoryUploadedFile, DeletedCategoryUploadedFileResponse>().ReverseMap();
        CreateMap<CategoryUploadedFile, GetByIdCategoryUploadedFileResponse>().ReverseMap();
        CreateMap<CategoryUploadedFile, GetListCategoryUploadedFileListItemDto>().ReverseMap();
        CreateMap<IPaginate<CategoryUploadedFile>, GetListResponse<GetListCategoryUploadedFileListItemDto>>().ReverseMap();
    }
}