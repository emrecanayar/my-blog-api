using Application.Features.EditorArticlePicks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.EditorArticlePicks.Queries.GetById;

public class GetByIdEditorArticlePickQuery : IRequest<CustomResponseDto<GetByIdEditorArticlePickResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdEditorArticlePickQueryHandler : IRequestHandler<GetByIdEditorArticlePickQuery, CustomResponseDto<GetByIdEditorArticlePickResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEditorArticlePickRepository _editorArticlePickRepository;
        private readonly EditorArticlePickBusinessRules _editorArticlePickBusinessRules;

        public GetByIdEditorArticlePickQueryHandler(IMapper mapper, IEditorArticlePickRepository editorArticlePickRepository, EditorArticlePickBusinessRules editorArticlePickBusinessRules)
        {
            _mapper = mapper;
            _editorArticlePickRepository = editorArticlePickRepository;
            _editorArticlePickBusinessRules = editorArticlePickBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdEditorArticlePickResponse>> Handle(GetByIdEditorArticlePickQuery request, CancellationToken cancellationToken)
        {
            EditorArticlePick? editorArticlePick = await _editorArticlePickRepository.GetAsync(predicate: eap => eap.Id == request.Id, cancellationToken: cancellationToken);
            await _editorArticlePickBusinessRules.EditorArticlePickShouldExistWhenSelected(editorArticlePick);

            GetByIdEditorArticlePickResponse response = _mapper.Map<GetByIdEditorArticlePickResponse>(editorArticlePick);

          return CustomResponseDto<GetByIdEditorArticlePickResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}