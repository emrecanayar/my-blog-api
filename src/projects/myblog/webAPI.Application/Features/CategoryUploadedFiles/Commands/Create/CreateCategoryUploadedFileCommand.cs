using Application.Features.CategoryUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.CategoryUploadedFiles.Commands.Create;

public class CreateCategoryUploadedFileCommand : IRequest<CustomResponseDto<CreatedCategoryUploadedFileResponse>>
{
    public Guid CategoryId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }

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