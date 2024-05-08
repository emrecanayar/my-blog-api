using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Update;
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
    private readonly ICategoryUploadedFileRepository _categoryUploadedFileRepository;
    public readonly string IMG_FOLDER = Path.Combine("Resources", "Files", typeof(Category).Name);

    public CategoryBusinessRules(ICategoryRepository categoryRepository, IUploadedFileService uploadedFileService, ICategoryUploadedFileRepository categoryUploadedFileRepository)
    {
        _categoryRepository = categoryRepository;
        _uploadedFileService = uploadedFileService;
        _categoryUploadedFileRepository = categoryUploadedFileRepository;
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
            UploadedFileResponseDto? uploadedFile = await _uploadedFileService.AzureTransferFileAsync(createCategoryCommand.Tokens[0], IMG_FOLDER);

            if (uploadedFile is not null) return uploadedFile;

            throw new BusinessException("Kategori için yüklenen dosya bulunamadý.");

        }

        throw new BusinessException("Kategori için yüklenen token bulunamadý.");
    }

    public async Task<UploadedFileResponseDto> CheckCategoryForUpdateAsync(UpdateCategoryCommand updateCategoryCommand)
    {
        if (updateCategoryCommand.Tokens?.Count > 0)
        {
            CategoryUploadedFile? categoryUploadedFile = await _categoryUploadedFileRepository.GetAsync(x => x.CategoryId == updateCategoryCommand.Id);

            if (categoryUploadedFile is not null)
            {
                await _categoryUploadedFileRepository.DeleteAsync(categoryUploadedFile);
            }

            UploadedFileResponseDto? uploadedFile = await _uploadedFileService.AzureTransferFileAsync(updateCategoryCommand.Tokens[0], IMG_FOLDER);

            if (uploadedFile is not null) return uploadedFile;

            throw new BusinessException("Kategori için yüklenen dosya bulunamadý.");

        }

        throw new BusinessException("Kategori için yüklenen token bulunamadý.");
    }
}