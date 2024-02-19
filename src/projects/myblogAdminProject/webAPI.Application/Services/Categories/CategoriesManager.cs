using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Rules;
using Application.Services.CategoryUploadedFiles;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using webAPI.Application.Features.UploadedFiles.Dtos;

namespace Application.Services.Categories;

public class CategoriesManager : ICategoriesService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryUploadedFilesService _categoryUploadedFilesService;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public CategoriesManager(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules, IMapper mapper, ICategoryUploadedFilesService categoryUploadedFilesService)
    {
        _categoryRepository = categoryRepository;
        _categoryBusinessRules = categoryBusinessRules;
        _mapper = mapper;
        _categoryUploadedFilesService = categoryUploadedFilesService;
    }

    public async Task<Category?> GetAsync(
        Expression<Func<Category, bool>> predicate,
        Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Category? category = await _categoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return category;
    }

    public async Task<IPaginate<Category>?> GetListAsync(
        Expression<Func<Category, bool>>? predicate = null,
        Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
        Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Category> categoryList = await _categoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return categoryList;
    }

    public async Task<Category> AddAsync(Category category)
    {
        Category addedCategory = await _categoryRepository.AddAsync(category);

        return addedCategory;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        Category updatedCategory = await _categoryRepository.UpdateAsync(category);

        return updatedCategory;
    }

    public async Task<Category> DeleteAsync(Category category, bool permanent = false)
    {
        Category deletedCategory = await _categoryRepository.DeleteAsync(category);

        return deletedCategory;
    }

    public async Task<Category> AddCategoryWithFileAsync(CreateCategoryCommand createCategoryCommand)
    {
        UploadedFileResponseDto uploadedFileResponseDto = await _categoryBusinessRules.CheckCategoryForAddAsync(createCategoryCommand);
        Category category = _mapper.Map<Category>(createCategoryCommand);
        MappedCategoryItem(uploadedFileResponseDto, category);

        Category addedCategory = await _categoryRepository.AddAsync(category);
        await AddUploadedFileInformationAsync(uploadedFileResponseDto, addedCategory);
        return addedCategory;
    }
    public async Task<Category> UpdateCategoryWithFileAsync(UpdateCategoryCommand updateCategoryCommand)
    {
        UploadedFileResponseDto uploadedFileResponseDto = await _categoryBusinessRules.CheckCategoryForUpdateAsync(updateCategoryCommand);
        Category category = _mapper.Map<Category>(updateCategoryCommand);
        MappedCategoryItem(uploadedFileResponseDto, category);
        Category uploadedCategory = await _categoryRepository.UpdateAsync(category);
        await AddUploadedFileInformationAsync(uploadedFileResponseDto, uploadedCategory);
        return uploadedCategory;
    }

    private async Task AddUploadedFileInformationAsync(UploadedFileResponseDto uploadedFileResponse, Category category)
    {
        string fileName = Path.GetFileName(uploadedFileResponse.Path);
        string newPath = BuildNewPath(fileName);

        await _categoryUploadedFilesService.AddAsync(new CategoryUploadedFile
        {
            CategoryId = category.Id,
            UploadedFileId = uploadedFileResponse.Id,
            OldPath = uploadedFileResponse.Path,
            NewPath = newPath,
        });
    }

    private string BuildNewPath(string fileName)
    {
        return Path.Combine(_categoryBusinessRules.IMG_FOLDER, fileName).Replace("\\", "/");
    }

    private static void MappedCategoryItem(UploadedFileResponseDto uploadedFile, Category category)
    {
        category.UploadedFileId = uploadedFile.Id;
    }


}

