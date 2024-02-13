using Application.Features.CategoryUploadedFiles.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CategoryUploadedFiles.Constants.CategoryUploadedFilesOperationClaims;

namespace Application.Features.CategoryUploadedFiles.Queries.GetList;

public class GetListCategoryUploadedFileQuery : IRequest<CustomResponseDto<GetListResponse<GetListCategoryUploadedFileListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCategoryUploadedFileQueryHandler : IRequestHandler<GetListCategoryUploadedFileQuery, CustomResponseDto<GetListResponse<GetListCategoryUploadedFileListItemDto>>>
    {
        private readonly ICategoryUploadedFileRepository _categoryUploadedFileRepository;
        private readonly IMapper _mapper;

        public GetListCategoryUploadedFileQueryHandler(ICategoryUploadedFileRepository categoryUploadedFileRepository, IMapper mapper)
        {
            _categoryUploadedFileRepository = categoryUploadedFileRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCategoryUploadedFileListItemDto>>> Handle(GetListCategoryUploadedFileQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CategoryUploadedFile> categoryUploadedFiles = await _categoryUploadedFileRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCategoryUploadedFileListItemDto> response = _mapper.Map<GetListResponse<GetListCategoryUploadedFileListItemDto>>(categoryUploadedFiles);
             return CustomResponseDto<GetListResponse<GetListCategoryUploadedFileListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}