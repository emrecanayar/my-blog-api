using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserUploadedFiles.Queries.GetList;

public class GetListUserUploadedFileQuery : IRequest<CustomResponseDto<GetListResponse<GetListUserUploadedFileListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserUploadedFileQueryHandler : IRequestHandler<GetListUserUploadedFileQuery, CustomResponseDto<GetListResponse<GetListUserUploadedFileListItemDto>>>
    {
        private readonly IUserUploadedFileRepository _userUploadedFileRepository;
        private readonly IMapper _mapper;

        public GetListUserUploadedFileQueryHandler(IUserUploadedFileRepository userUploadedFileRepository, IMapper mapper)
        {
            _userUploadedFileRepository = userUploadedFileRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListUserUploadedFileListItemDto>>> Handle(GetListUserUploadedFileQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserUploadedFile> userUploadedFiles = await _userUploadedFileRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserUploadedFileListItemDto> response = _mapper.Map<GetListResponse<GetListUserUploadedFileListItemDto>>(userUploadedFiles);
             return CustomResponseDto<GetListResponse<GetListUserUploadedFileListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}