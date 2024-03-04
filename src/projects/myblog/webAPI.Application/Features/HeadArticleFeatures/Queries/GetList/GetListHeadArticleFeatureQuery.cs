using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Features.HeadArticleFeatures.Queries.GetList;

public class GetListHeadArticleFeatureQuery : IRequest<CustomResponseDto<GetListResponse<GetListHeadArticleFeatureListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public GetListHeadArticleFeatureQuery()
    {
        PageRequest = default!;
    }

    public class GetListHeadArticleFeatureQueryHandler : IRequestHandler<GetListHeadArticleFeatureQuery, CustomResponseDto<GetListResponse<GetListHeadArticleFeatureListItemDto>>>
    {
        private readonly IHeadArticleFeatureRepository _headArticleFeatureRepository;
        private readonly IMapper _mapper;

        public GetListHeadArticleFeatureQueryHandler(IHeadArticleFeatureRepository headArticleFeatureRepository, IMapper mapper)
        {
            _headArticleFeatureRepository = headArticleFeatureRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListHeadArticleFeatureListItemDto>>> Handle(GetListHeadArticleFeatureQuery request, CancellationToken cancellationToken)
        {
            IPaginate<HeadArticleFeature> headArticleFeatures = await _headArticleFeatureRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: x => x.Include(x => x.HeadArticleFeatureUploadedFiles),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListHeadArticleFeatureListItemDto> response = _mapper.Map<GetListResponse<GetListHeadArticleFeatureListItemDto>>(headArticleFeatures);
            return CustomResponseDto<GetListResponse<GetListHeadArticleFeatureListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}