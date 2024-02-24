using Application.Features.ArticleUploadedFiles.Constants;
using Application.Features.ArticleUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.ArticleUploadedFiles.Commands.Delete;

public class DeleteArticleUploadedFileCommand : IRequest<CustomResponseDto<DeletedArticleUploadedFileResponse>>
{
    public Guid Id { get; set; }

    public class DeleteArticleUploadedFileCommandHandler : IRequestHandler<DeleteArticleUploadedFileCommand, CustomResponseDto<DeletedArticleUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleUploadedFileRepository _articleUploadedFileRepository;
        private readonly ArticleUploadedFileBusinessRules _articleUploadedFileBusinessRules;

        public DeleteArticleUploadedFileCommandHandler(IMapper mapper, IArticleUploadedFileRepository articleUploadedFileRepository,
                                         ArticleUploadedFileBusinessRules articleUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _articleUploadedFileRepository = articleUploadedFileRepository;
            _articleUploadedFileBusinessRules = articleUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedArticleUploadedFileResponse>> Handle(DeleteArticleUploadedFileCommand request, CancellationToken cancellationToken)
        {
            ArticleUploadedFile? articleUploadedFile = await _articleUploadedFileRepository.GetAsync(predicate: auf => auf.Id == request.Id, cancellationToken: cancellationToken);
            await _articleUploadedFileBusinessRules.ArticleUploadedFileShouldExistWhenSelected(articleUploadedFile);

            await _articleUploadedFileRepository.DeleteAsync(articleUploadedFile!);

            DeletedArticleUploadedFileResponse response = _mapper.Map<DeletedArticleUploadedFileResponse>(articleUploadedFile);

             return CustomResponseDto<DeletedArticleUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}