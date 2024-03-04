using Application.Features.HeadArticleFeatureUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.HeadArticleFeatureUploadedFiles.Queries.GetById;

public class GetByIdHeadArticleFeatureUploadedFileQuery : IRequest<CustomResponseDto<GetByIdHeadArticleFeatureUploadedFileResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdHeadArticleFeatureUploadedFileQueryHandler : IRequestHandler<GetByIdHeadArticleFeatureUploadedFileQuery, CustomResponseDto<GetByIdHeadArticleFeatureUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IHeadArticleFeatureUploadedFileRepository _headArticleFeatureUploadedFileRepository;
        private readonly HeadArticleFeatureUploadedFileBusinessRules _headArticleFeatureUploadedFileBusinessRules;

        public GetByIdHeadArticleFeatureUploadedFileQueryHandler(IMapper mapper, IHeadArticleFeatureUploadedFileRepository headArticleFeatureUploadedFileRepository, HeadArticleFeatureUploadedFileBusinessRules headArticleFeatureUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _headArticleFeatureUploadedFileRepository = headArticleFeatureUploadedFileRepository;
            _headArticleFeatureUploadedFileBusinessRules = headArticleFeatureUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdHeadArticleFeatureUploadedFileResponse>> Handle(GetByIdHeadArticleFeatureUploadedFileQuery request, CancellationToken cancellationToken)
        {
            HeadArticleFeatureUploadedFile? headArticleFeatureUploadedFile = await _headArticleFeatureUploadedFileRepository.GetAsync(predicate: hafuf => hafuf.Id == request.Id, cancellationToken: cancellationToken);
            await _headArticleFeatureUploadedFileBusinessRules.HeadArticleFeatureUploadedFileShouldExistWhenSelected(headArticleFeatureUploadedFile);

            GetByIdHeadArticleFeatureUploadedFileResponse response = _mapper.Map<GetByIdHeadArticleFeatureUploadedFileResponse>(headArticleFeatureUploadedFile);

          return CustomResponseDto<GetByIdHeadArticleFeatureUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}