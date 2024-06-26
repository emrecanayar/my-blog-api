using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Application.Features.Comments.Queries.GetById;
using Application.Features.Comments.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.Comments.Commands.CreateReply;
using webAPI.Application.Features.Comments.Commands.Edit;
using webAPI.Application.Features.Comments.Queries.GetListByDynamic;

namespace Application.Features.Comments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Comment, CreateCommentCommand>().ReverseMap();
        CreateMap<Comment, CreateReplyCommentCommand>().ReverseMap();
        CreateMap<Comment, CreatedCommentResponse>().ReverseMap();
        CreateMap<Comment, CreatedReplyCommentResponse>().ReverseMap();
        CreateMap<Comment, UpdateCommentCommand>().ReverseMap();
        CreateMap<Comment, UpdatedCommentResponse>().ReverseMap();
        CreateMap<Comment, DeleteCommentCommand>().ReverseMap();
        CreateMap<Comment, DeletedCommentResponse>().ReverseMap();
        CreateMap<Comment, GetByIdCommentResponse>().ReverseMap();
        CreateMap<Comment, EditCommentCommand>().ReverseMap();
        CreateMap<Comment, EditCommentResponse>().ReverseMap();
        CreateMap<Comment, GetListCommentListItemDto>()
                 .ForMember(dest => dest.Replies, opt => opt.Ignore());
        CreateMap<IPaginate<Comment>, GetListResponse<GetListCommentListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Comment>, CommentListModel>().ReverseMap();
    }
}