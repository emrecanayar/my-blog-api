using Application.Features.ArticleUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.ArticleUploadedFiles.Commands.Create;

public class CreateArticleUploadedFileCommand : IRequest<CustomResponseDto<CreatedArticleUploadedFileResponse>>
{
    public Guid ArticleId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }

    public class CreateArticleUploadedFileCommandHandler : IRequestHandler<CreateArticleUploadedFileCommand, CustomResponseDto<CreatedArticleUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleUploadedFileRepository _articleUploadedFileRepository;
        private readonly ArticleUploadedFileBusinessRules _articleUploadedFileBusinessRules;

        public CreateArticleUploadedFileCommandHandler(IMapper mapper, IArticleUploadedFileRepository articleUploadedFileRepository,
                                         ArticleUploadedFileBusinessRules articleUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _articleUploadedFileRepository = articleUploadedFileRepository;
            _articleUploadedFileBusinessRules = articleUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedArticleUploadedFileResponse>> Handle(CreateArticleUploadedFileCommand request, CancellationToken cancellationToken)
        {
            ArticleUploadedFile articleUploadedFile = _mapper.Map<ArticleUploadedFile>(request);

            await _articleUploadedFileRepository.AddAsync(articleUploadedFile);

            CreatedArticleUploadedFileResponse response = _mapper.Map<CreatedArticleUploadedFileResponse>(articleUploadedFile);
         return CustomResponseDto<CreatedArticleUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}