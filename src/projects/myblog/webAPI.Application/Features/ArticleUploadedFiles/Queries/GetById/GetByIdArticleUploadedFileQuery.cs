using Application.Features.ArticleUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.ArticleUploadedFiles.Queries.GetById;

public class GetByIdArticleUploadedFileQuery : IRequest<CustomResponseDto<GetByIdArticleUploadedFileResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdArticleUploadedFileQueryHandler : IRequestHandler<GetByIdArticleUploadedFileQuery, CustomResponseDto<GetByIdArticleUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleUploadedFileRepository _articleUploadedFileRepository;
        private readonly ArticleUploadedFileBusinessRules _articleUploadedFileBusinessRules;

        public GetByIdArticleUploadedFileQueryHandler(IMapper mapper, IArticleUploadedFileRepository articleUploadedFileRepository, ArticleUploadedFileBusinessRules articleUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _articleUploadedFileRepository = articleUploadedFileRepository;
            _articleUploadedFileBusinessRules = articleUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdArticleUploadedFileResponse>> Handle(GetByIdArticleUploadedFileQuery request, CancellationToken cancellationToken)
        {
            ArticleUploadedFile? articleUploadedFile = await _articleUploadedFileRepository.GetAsync(predicate: auf => auf.Id == request.Id, cancellationToken: cancellationToken);
            await _articleUploadedFileBusinessRules.ArticleUploadedFileShouldExistWhenSelected(articleUploadedFile);

            GetByIdArticleUploadedFileResponse response = _mapper.Map<GetByIdArticleUploadedFileResponse>(articleUploadedFile);

          return CustomResponseDto<GetByIdArticleUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}