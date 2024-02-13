using Application.Features.CategoryUploadedFiles.Constants;
using Application.Features.CategoryUploadedFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.CategoryUploadedFiles.Commands.Delete;

public class DeleteCategoryUploadedFileCommand : IRequest<CustomResponseDto<DeletedCategoryUploadedFileResponse>>
{
    public Guid Id { get; set; }

    public class DeleteCategoryUploadedFileCommandHandler : IRequestHandler<DeleteCategoryUploadedFileCommand, CustomResponseDto<DeletedCategoryUploadedFileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryUploadedFileRepository _categoryUploadedFileRepository;
        private readonly CategoryUploadedFileBusinessRules _categoryUploadedFileBusinessRules;

        public DeleteCategoryUploadedFileCommandHandler(IMapper mapper, ICategoryUploadedFileRepository categoryUploadedFileRepository,
                                         CategoryUploadedFileBusinessRules categoryUploadedFileBusinessRules)
        {
            _mapper = mapper;
            _categoryUploadedFileRepository = categoryUploadedFileRepository;
            _categoryUploadedFileBusinessRules = categoryUploadedFileBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCategoryUploadedFileResponse>> Handle(DeleteCategoryUploadedFileCommand request, CancellationToken cancellationToken)
        {
            CategoryUploadedFile? categoryUploadedFile = await _categoryUploadedFileRepository.GetAsync(predicate: cuf => cuf.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryUploadedFileBusinessRules.CategoryUploadedFileShouldExistWhenSelected(categoryUploadedFile);

            await _categoryUploadedFileRepository.DeleteAsync(categoryUploadedFile!);

            DeletedCategoryUploadedFileResponse response = _mapper.Map<DeletedCategoryUploadedFileResponse>(categoryUploadedFile);

             return CustomResponseDto<DeletedCategoryUploadedFileResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}