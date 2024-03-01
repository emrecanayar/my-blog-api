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
                              dynamic: request.DynamicQuery,
                              index: request.PageRequest.PageIndex,
                              size: request.PageRequest.PageSize,
                              include: x => x.Include(x => x.Article).Include(x => x.User),
                              cancellationToken: cancellationToken);

                CommentListModel mappedCommentListModel = _mapper.Map<CommentListModel>(comments);

                return CustomResponseDto<CommentListModel>.Success((int)HttpStatusCode.OK, mappedCommentListModel, true);
            }
        }
    }
}
