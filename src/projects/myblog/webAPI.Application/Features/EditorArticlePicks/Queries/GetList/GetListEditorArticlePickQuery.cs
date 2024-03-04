using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.EditorArticlePicks.Queries.GetList;

public class GetListEditorArticlePickQuery : IRequest<CustomResponseDto<GetListResponse<GetListEditorArticlePickListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListEditorArticlePickQueryHandler : IRequestHandler<GetListEditorArticlePickQuery, CustomResponseDto<GetListResponse<GetListEditorArticlePickListItemDto>>>
    {
        private readonly IEditorArticlePickRepository _editorArticlePickRepository;
        private readonly IMapper _mapper;

        public GetListEditorArticlePickQueryHandler(IEditorArticlePickRepository editorArticlePickRepository, IMapper mapper)
        {
            _editorArticlePickRepository = editorArticlePickRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListEditorArticlePickListItemDto>>> Handle(GetListEditorArticlePickQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EditorArticlePick> editorArticlePicks = await _editorArticlePickRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEditorArticlePickListItemDto> response = _mapper.Map<GetListResponse<GetListEditorArticlePickListItemDto>>(editorArticlePicks);
             return CustomResponseDto<GetListResponse<GetListEditorArticlePickListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}