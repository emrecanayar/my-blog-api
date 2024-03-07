using Application.Features.UserUploadedFiles.Commands.Create;
using Application.Features.UserUploadedFiles.Commands.Delete;
using Application.Features.UserUploadedFiles.Commands.Update;
using Application.Features.UserUploadedFiles.Queries.GetById;
using Application.Features.UserUploadedFiles.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.UserUploadedFiles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserUploadedFile, CreateUserUploadedFileCommand>().ReverseMap();
        CreateMap<UserUploadedFile, CreatedUserUploadedFileResponse>().ReverseMap();
        CreateMap<UserUploadedFile, UpdateUserUploadedFileCommand>().ReverseMap();
        CreateMap<UserUploadedFile, UpdatedUserUploadedFileResponse>().ReverseMap();
        CreateMap<UserUploadedFile, DeleteUserUploadedFileCommand>().ReverseMap();
        CreateMap<UserUploadedFile, DeletedUserUploadedFileResponse>().ReverseMap();
        CreateMap<UserUploadedFile, GetByIdUserUploadedFileResponse>().ReverseMap();
        CreateMap<UserUploadedFile, GetListUserUploadedFileListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserUploadedFile>, GetListResponse<GetListUserUploadedFileListItemDto>>().ReverseMap();
    }
}