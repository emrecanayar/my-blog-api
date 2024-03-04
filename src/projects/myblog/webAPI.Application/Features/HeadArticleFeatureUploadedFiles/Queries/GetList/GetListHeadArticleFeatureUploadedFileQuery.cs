using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;

namespace Application.Features.HeadArticleFeatureUploadedFiles.Queries.GetList;

public class GetListHeadArticleFeatureUploadedFileQuery : IRequest<CustomResponseDto<GetListResponse<GetListHeadArticleFeatureUploadedFileListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public GetListHeadArticleFeatureUploadedFileQuery()
    {
        PageRequest = default!;
    }

    public class GetListHeadArticleFeatureUploadedFileQueryHandler : IRequestHandler<GetListHeadArticleFeatureUploadedFileQuery, CustomResponseDto<GetListResponse<GetListHeadArticleFeatureUploadedFileListItemDto>>>
    {
        private readonly IHeadArticleFeatureUploadedFileRepository _headArticleFeatureUploadedFileRepository;
        private readonly IMapper _mapper;

        public GetListHeadArticleFeatureUploadedFileQueryHandler(IHeadArticleFeatureUploadedFileRepository headArticleFeatureUploadedFileRepository, IMapper mapper)
        {
            _headArticleFeatureUploadedFileRepository = headArticleFeatureUploadedFileRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListHeadArticleFeatureUploadedFileListItemDto>>> Handle(GetListHeadArticleFeatureUploadedFileQuery request, CancellationToken cancellationToken)
        {
            IPaginate<HeadArticleFeatureUploadedFile> headArticleFeatureUploadedFiles = await _headArticleFeatureUploadedFileRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListHeadArticleFeatureUploadedFileListItemDto> response = _mapper.Map<GetListResponse<GetListHeadArticleFeatureUploadedFileListItemDto>>(headArticleFeatureUploadedFiles);
            return CustomResponseDto<GetListResponse<GetListHeadArticleFeatureUploadedFileListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}