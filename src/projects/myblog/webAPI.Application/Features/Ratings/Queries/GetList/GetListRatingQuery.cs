using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Ratings.Queries.GetList;

public class GetListRatingQuery : IRequest<CustomResponseDto<GetListResponse<GetListRatingListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRatingQueryHandler : IRequestHandler<GetListRatingQuery, CustomResponseDto<GetListResponse<GetListRatingListItemDto>>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public GetListRatingQueryHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListRatingListItemDto>>> Handle(GetListRatingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Rating> ratings = await _ratingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRatingListItemDto> response = _mapper.Map<GetListResponse<GetListRatingListItemDto>>(ratings);
             return CustomResponseDto<GetListResponse<GetListRatingListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}