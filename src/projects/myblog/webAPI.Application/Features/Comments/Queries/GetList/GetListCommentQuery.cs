using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;

namespace Application.Features.Comments.Queries.GetList;

public class GetListCommentQuery : IRequest<CustomResponseDto<GetListResponse<GetListCommentListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public GetListCommentQuery()
    {
        PageRequest = default!;
    }

    public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, CustomResponseDto<GetListResponse<GetListCommentListItemDto>>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetListCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCommentListItemDto>>> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Comment> comments = await _commentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCommentListItemDto> response = _mapper.Map<GetListResponse<GetListCommentListItemDto>>(comments);
            return CustomResponseDto<GetListResponse<GetListCommentListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}