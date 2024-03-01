using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;

namespace Application.Features.Features.Queries.GetList;

public class GetListFeatureQuery : IRequest<CustomResponseDto<GetListResponse<GetListFeatureListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public GetListFeatureQuery()
    {
        PageRequest = default!;
    }

    public class GetListFeatureQueryHandler : IRequestHandler<GetListFeatureQuery, CustomResponseDto<GetListResponse<GetListFeatureListItemDto>>>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;

        public GetListFeatureQueryHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListFeatureListItemDto>>> Handle(GetListFeatureQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Feature> features = await _featureRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFeatureListItemDto> response = _mapper.Map<GetListResponse<GetListFeatureListItemDto>>(features);
            return CustomResponseDto<GetListResponse<GetListFeatureListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}