using Application.Features.Comments.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace webAPI.Application.Features.Comments.Queries.GetListByDynamic
{
    public class GetListByDynamicCommentQuery : IRequest<CustomResponseDto<CommentListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery? DynamicQuery { get; set; }

        public GetListByDynamicCommentQuery()
        {
            PageRequest = default!;
            DynamicQuery = default!;
        }

        public class GetListByDynamicCommentQueryHandler : IRequestHandler<GetListByDynamicCommentQuery, CustomResponseDto<CommentListModel>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;

            public GetListByDynamicCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<CommentListModel>> Handle(GetListByDynamicCommentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Comment> comments = await _commentRepository.GetListByDynamicAsync(
                                            predicate: x => x.ParentCommentId == null,
                                            dynamic: request.DynamicQuery,
                                            index: request.PageRequest.PageIndex,
                                            size: request.PageRequest.PageSize,
                                            include: x => x.Include(x => x.Article)
                                                           .Include(x => x.User).ThenInclude(x => x.UserUploadedFiles)
                                                           .Include(x => x.Replies)
                                                           .Include(x => x.Likes),
                                            cancellationToken: cancellationToken);

                var commentDtoList = _mapper.Map<List<GetListCommentListItemDto>>(comments.Items); // Doğru: Items üzerinden dönüşüm

                // Her bir üst düzey yorum için alt yorumları işle
                foreach (GetListCommentListItemDto commentDto in commentDtoList)
                {
                    commentDto.Replies = await ProcessReplies(commentDto.Id, cancellationToken);
                }

                CommentListModel mappedCommentListModel = new()
                {
                    Items = commentDtoList,
                    Size = comments.Size,
                    Count = comments.Count,
                    HasNext = comments.HasNext,
                    HasPrevious = comments.HasPrevious,
                    Index = comments.Index,
                    Pages = comments.Pages,
                };

                return CustomResponseDto<CommentListModel>.Success((int)HttpStatusCode.OK, mappedCommentListModel, true);
            }

            private async Task<List<GetListCommentListItemDto>> ProcessReplies(Guid parentId, CancellationToken cancellationToken)
            {
                IPaginate<Comment> replies = await _commentRepository.GetListAsync(
                    predicate: x => x.ParentCommentId == parentId,
                    include: x => x.Include(x => x.User).ThenInclude(x => x.UserUploadedFiles)
                    .Include(x => x.Likes),
                    cancellationToken: cancellationToken);

                List<GetListCommentListItemDto> repliesDto = _mapper.Map<List<GetListCommentListItemDto>>(replies.Items);

                foreach (var replyDto in repliesDto)
                {
                    replyDto.Replies = await ProcessReplies(replyDto.Id, cancellationToken);
                }

                return repliesDto;
            }
        }
    }
}
