using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;
using webAPI.Application.Features.UploadedFiles.Dtos;
using webAPI.Application.Services.UploadedFileService;

namespace Application.Features.Categories.Rules;

public class CategoryBusinessRules : BaseBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUploadedFileService _uploadedFileService;
    public readonly string IMG_FOLDER = Path.Combine("Resources", "Files", typeof(Category).Name);

    public CategoryBusinessRules(ICategoryRepository categoryRepository, IUploadedFileService uploadedFileService)
    {
        _categoryRepository = categoryRepository;
        _uploadedFileService = uploadedFileService;
    }

    public Task CategoryShouldExistWhenSelected(Category? category)
    {
        if (category == null)
            throw new BusinessException(CategoriesBusinessMessages.CategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task CategoryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CategoryShouldExistWhenSelected(category);
    }

    public async Task<UploadedFileResponseDto> CheckCategoryForAddAsync(CreateCategoryCommand createCategoryCommand)
    {
        if (createCategoryCommand.Tokens?.Count > 0)
        {
            UploadedFileResponseDto? uploadedFile = await _uploadedFileService.TransferFile(createCategoryCommand.Tokens[0], IMG_FOLDER, createCategoryCommand.WebRootPath);

            if (uploadedFile is not null) return uploadedFile;

            throw new BusinessException("Kategori için yüklenen dosya bulunamadý.");

        }

        throw new BusinessException("Kategori için yüklenen token bulunamadý.");
    }
}