using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ArticleUploadedFiles.Queries.GetList;

public class GetListArticleUploadedFileQuery : IRequest<CustomResponseDto<GetListResponse<GetListArticleUploadedFileListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListArticleUploadedFileQueryHandler : IRequestHandler<GetListArticleUploadedFileQuery, CustomResponseDto<GetListResponse<GetListArticleUploadedFileListItemDto>>>
    {
        private readonly IArticleUploadedFileRepository _articleUploadedFileRepository;
        private readonly IMapper _mapper;

        public GetListArticleUploadedFileQueryHandler(IArticleUploadedFileRepository articleUploadedFileRepository, IMapper mapper)
        {
            _articleUploadedFileRepository = articleUploadedFileRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListArticleUploadedFileListItemDto>>> Handle(GetListArticleUploadedFileQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ArticleUploadedFile> articleUploadedFiles = await _articleUploadedFileRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListArticleUploadedFileListItemDto> response = _mapper.Map<GetListResponse<GetListArticleUploadedFileListItemDto>>(articleUploadedFiles);
             return CustomResponseDto<GetListResponse<GetListArticleUploadedFileListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}