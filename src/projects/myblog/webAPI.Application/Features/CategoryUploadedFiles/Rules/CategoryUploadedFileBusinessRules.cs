using Application.Features.CategoryUploadedFiles.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CategoryUploadedFiles.Rules;

public class CategoryUploadedFileBusinessRules : BaseBusinessRules
{
    private readonly ICategoryUploadedFileRepository _categoryUploadedFileRepository;

    public CategoryUploadedFileBusinessRules(ICategoryUploadedFileRepository categoryUploadedFileRepository)
    {
        _categoryUploadedFileRepository = categoryUploadedFileRepository;
    }

    public Task CategoryUploadedFileShouldExistWhenSelected(CategoryUploadedFile? categoryUploadedFile)
    {
        if (categoryUploadedFile == null)
            throw new BusinessException(CategoryUploadedFilesBusinessMessages.CategoryUploadedFileNotExists);
        return Task.CompletedTask;
    }

    public async Task CategoryUploadedFileIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CategoryUploadedFile? categoryUploadedFile = await _categoryUploadedFileRepository.GetAsync(
            predicate: cuf => cuf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CategoryUploadedFileShouldExistWhenSelected(categoryUploadedFile);
    }
}