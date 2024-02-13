using Application.Features.CategoryUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.CategoryUploadedFiles.Commands.Update;

public class UpdateCategoryUploadedFileCommand : IRequest<CustomResponseDto<UpdatedCategoryUploadedFileResponse>>
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }

    public class UpdateCategoryUploadedFileCommandHandler : IRequestHandler<UpdateCategoryUploadedFileCommand, CustomResponseDto<UpdatedCategoryUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryUploadedFileRepository _categoryUploadedFileRepository;
        private readonly CategoryUploadedFileBusinessRules _categoryUploadedFileBusinessRules;

        public UpdateCategoryUploadedFileCommandHandler(IMapper mapper, ICategoryUploadedFileRepository categoryUploadedFileRepository,
                                         CategoryUploadedFileBusinessRules categoryUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _categoryUploadedFileRepository = categoryUploadedFileRepository;
            _categoryUploadedFileBusinessRules = categoryUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCategoryUploadedFileResponse>> Handle(UpdateCategoryUploadedFileCommand request, CancellationToken cancellationToken)
        {
            CategoryUploadedFile? categoryUploadedFile = await _categoryUploadedFileRepository.GetAsync(predicate: cuf => cuf.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryUploadedFileBusinessRules.CategoryUploadedFileShouldExistWhenSelected(categoryUploadedFile);
            categoryUploadedFile = _mapper.Map(request, categoryUploadedFile);

            await _categoryUploadedFileRepository.UpdateAsync(categoryUploadedFile!);

            UpdatedCategoryUploadedFileResponse response = _mapper.Map<UpdatedCategoryUploadedFileResponse>(categoryUploadedFile);

          return CustomResponseDto<UpdatedCategoryUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}