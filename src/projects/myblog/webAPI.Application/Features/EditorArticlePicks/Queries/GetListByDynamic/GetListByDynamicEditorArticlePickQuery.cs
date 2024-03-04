using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace webAPI.Application.Features.EditorArticlePicks.Queries.GetListByDynamic
{
    public class GetListByDynamicEditorArticlePickQuery : IRequest<CustomResponseDto<EditorArticlePickListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

        public GetListByDynamicEditorArticlePickQuery()
        {
            PageRequest = default!;
            DynamicQuery = default!;
        }

        public class GetListByDynamicEditorArticlePickQueryHandler : IRequestHandler<GetListByDynamicEditorArticlePickQuery, CustomResponseDto<EditorArticlePickListModel>>
        {
            private readonly IEditorArticlePickRepository _editorArticlePickRepository;
            private readonly IMapper _mapper;

            public GetListByDynamicEditorArticlePickQueryHandler(IEditorArticlePickRepository editorArticlePickRepository, IMapper mapper)
            {
                _editorArticlePickRepository = editorArticlePickRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<EditorArticlePickListModel>> Handle(GetListByDynamicEditorArticlePickQuery request, CancellationToken cancellationToken)
            {
                IPaginate<EditorArticlePick> editorArticlePicks = await _editorArticlePickRepository.GetListByDynamicAsync(
                    dynamic: request.DynamicQuery,
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    include: x => x.Include(x => x.Article).Include(x => x.User),
                    cancellationToken: cancellationToken);

                EditorArticlePickListModel mappedEditorArticlePickListModel = _mapper.Map<EditorArticlePickListModel>(editorArticlePicks);
                return CustomResponseDto<EditorArticlePickListModel>.Success((int)HttpStatusCode.OK, mappedEditorArticlePickListModel, true);
            }
        }
    }
}
