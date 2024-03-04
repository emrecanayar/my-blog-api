using Application.Features.HeadArticleFeatures.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Features.HeadArticleFeatures.Queries.GetById;

public class GetByIdHeadArticleFeatureQuery : IRequest<CustomResponseDto<GetByIdHeadArticleFeatureResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdHeadArticleFeatureQueryHandler : IRequestHandler<GetByIdHeadArticleFeatureQuery, CustomResponseDto<GetByIdHeadArticleFeatureResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IHeadArticleFeatureRepository _headArticleFeatureRepository;
        private readonly HeadArticleFeatureBusinessRules _headArticleFeatureBusinessRules;

        public GetByIdHeadArticleFeatureQueryHandler(IMapper mapper, IHeadArticleFeatureRepository headArticleFeatureRepository, HeadArticleFeatureBusinessRules headArticleFeatureBusinessRules)
        {
            _mapper = mapper;
            _headArticleFeatureRepository = headArticleFeatureRepository;
            _headArticleFeatureBusinessRules = headArticleFeatureBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdHeadArticleFeatureResponse>> Handle(GetByIdHeadArticleFeatureQuery request, CancellationToken cancellationToken)
        {
            HeadArticleFeature? headArticleFeature = await _headArticleFeatureRepository.GetAsync(predicate: haf => haf.Id == request.Id, include: x => x.Include(x => x.HeadArticleFeatureUploadedFiles), cancellationToken: cancellationToken);
            await _headArticleFeatureBusinessRules.HeadArticleFeatureShouldExistWhenSelected(headArticleFeature);

            GetByIdHeadArticleFeatureResponse response = _mapper.Map<GetByIdHeadArticleFeatureResponse>(headArticleFeature);

            return CustomResponseDto<GetByIdHeadArticleFeatureResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}