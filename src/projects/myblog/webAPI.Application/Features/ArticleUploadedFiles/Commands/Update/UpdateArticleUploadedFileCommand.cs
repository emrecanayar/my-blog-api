using Application.Features.ArticleUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.ArticleUploadedFiles.Commands.Update;

public class UpdateArticleUploadedFileCommand : IRequest<CustomResponseDto<UpdatedArticleUploadedFileResponse>>
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }

    public class UpdateArticleUploadedFileCommandHandler : IRequestHandler<UpdateArticleUploadedFileCommand, CustomResponseDto<UpdatedArticleUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleUploadedFileRepository _articleUploadedFileRepository;
        private readonly ArticleUploadedFileBusinessRules _articleUploadedFileBusinessRules;

        public UpdateArticleUploadedFileCommandHandler(IMapper mapper, IArticleUploadedFileRepository articleUploadedFileRepository,
                                         ArticleUploadedFileBusinessRules articleUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _articleUploadedFileRepository = articleUploadedFileRepository;
            _articleUploadedFileBusinessRules = articleUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedArticleUploadedFileResponse>> Handle(UpdateArticleUploadedFileCommand request, CancellationToken cancellationToken)
        {
            ArticleUploadedFile? articleUploadedFile = await _articleUploadedFileRepository.GetAsync(predicate: auf => auf.Id == request.Id, cancellationToken: cancellationToken);
            await _articleUploadedFileBusinessRules.ArticleUploadedFileShouldExistWhenSelected(articleUploadedFile);
            articleUploadedFile = _mapper.Map(request, articleUploadedFile);

            await _articleUploadedFileRepository.UpdateAsync(articleUploadedFile!);

            UpdatedArticleUploadedFileResponse response = _mapper.Map<UpdatedArticleUploadedFileResponse>(articleUploadedFile);

          return CustomResponseDto<UpdatedArticleUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}