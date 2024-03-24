using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;

namespace Application.Features.Likes.Queries.GetList;

public class GetListLikeQuery : IRequest<CustomResponseDto<GetListResponse<GetListLikeListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLikeQueryHandler : IRequestHandler<GetListLikeQuery, CustomResponseDto<GetListResponse<GetListLikeListItemDto>>>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public GetListLikeQueryHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListLikeListItemDto>>> Handle(GetListLikeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Like> likes = await _likeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLikeListItemDto> response = _mapper.Map<GetListResponse<GetListLikeListItemDto>>(likes);
            return CustomResponseDto<GetListResponse<GetListLikeListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}