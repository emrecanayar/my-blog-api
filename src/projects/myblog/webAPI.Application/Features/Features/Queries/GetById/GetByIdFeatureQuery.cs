using Application.Features.Features.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.Features.Queries.GetById;

public class GetByIdFeatureQuery : IRequest<CustomResponseDto<GetByIdFeatureResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdFeatureQueryHandler : IRequestHandler<GetByIdFeatureQuery, CustomResponseDto<GetByIdFeatureResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFeatureRepository _featureRepository;
        private readonly FeatureBusinessRules _featureBusinessRules;

        public GetByIdFeatureQueryHandler(IMapper mapper, IFeatureRepository featureRepository, FeatureBusinessRules featureBusinessRules)
        {
            _mapper = mapper;
            _featureRepository = featureRepository;
            _featureBusinessRules = featureBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdFeatureResponse>> Handle(GetByIdFeatureQuery request, CancellationToken cancellationToken)
        {
            Feature? feature = await _featureRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            await _featureBusinessRules.FeatureShouldExistWhenSelected(feature);

            GetByIdFeatureResponse response = _mapper.Map<GetByIdFeatureResponse>(feature);

            return CustomResponseDto<GetByIdFeatureResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}