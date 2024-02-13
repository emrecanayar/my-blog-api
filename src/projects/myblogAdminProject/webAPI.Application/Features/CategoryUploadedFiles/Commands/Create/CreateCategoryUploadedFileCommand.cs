using Application.Features.CategoryUploadedFiles.Constants;
using Application.Features.CategoryUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CategoryUploadedFiles.Constants.CategoryUploadedFilesOperationClaims;

namespace Application.Features.CategoryUploadedFiles.Commands.Create;

public class CreateCategoryUploadedFileCommand : IRequest<CustomResponseDto<CreatedCategoryUploadedFileResponse>>, ISecuredRequest
{
    public Guid CategoryId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }

    public string[] Roles => new[] { Admin, Write, CategoryUploadedFilesOperationClaims.Create };

    public class CreateCategoryUploadedFileCommandHandler : IRequestHandler<CreateCategoryUploadedFileCommand, CustomResponseDto<CreatedCategoryUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryUploadedFileRepository _categoryUploadedFileRepository;
        private readonly CategoryUploadedFileBusinessRules _categoryUploadedFileBusinessRules;

        public CreateCategoryUploadedFileCommandHandler(IMapper mapper, ICategoryUploadedFileRepository categoryUploadedFileRepository,
                                         CategoryUploadedFileBusinessRules categoryUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _categoryUploadedFileRepository = categoryUploadedFileRepository;
            _categoryUploadedFileBusinessRules = categoryUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCategoryUploadedFileResponse>> Handle(CreateCategoryUploadedFileCommand request, CancellationToken cancellationToken)
        {
            CategoryUploadedFile categoryUploadedFile = _mapper.Map<CategoryUploadedFile>(request);

            await _categoryUploadedFileRepository.AddAsync(categoryUploadedFile);

            CreatedCategoryUploadedFileResponse response = _mapper.Map<CreatedCategoryUploadedFileResponse>(categoryUploadedFile);
         return CustomResponseDto<CreatedCategoryUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}