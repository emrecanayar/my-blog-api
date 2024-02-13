using Application.Features.CategoryUploadedFiles.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryUploadedFiles;

public class CategoryUploadedFilesManager : ICategoryUploadedFilesService
{
    private readonly ICategoryUploadedFileRepository _categoryUploadedFileRepository;
    private readonly CategoryUploadedFileBusinessRules _categoryUploadedFileBusinessRules;

    public CategoryUploadedFilesManager(ICategoryUploadedFileRepository categoryUploadedFileRepository, CategoryUploadedFileBusinessRules categoryUploadedFileBusinessRules)
    {
        _categoryUploadedFileRepository = categoryUploadedFileRepository;
        _categoryUploadedFileBusinessRules = categoryUploadedFileBusinessRules;
    }

    public async Task<CategoryUploadedFile?> GetAsync(
        Expression<Func<CategoryUploadedFile, bool>> predicate,
        Func<IQueryable<CategoryUploadedFile>, IIncludableQueryable<CategoryUploadedFile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CategoryUploadedFile? categoryUploadedFile = await _categoryUploadedFileRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return categoryUploadedFile;
    }

    public async Task<IPaginate<CategoryUploadedFile>?> GetListAsync(
        Expression<Func<CategoryUploadedFile, bool>>? predicate = null,
        Func<IQueryable<CategoryUploadedFile>, IOrderedQueryable<CategoryUploadedFile>>? orderBy = null,
        Func<IQueryable<CategoryUploadedFile>, IIncludableQueryable<CategoryUploadedFile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CategoryUploadedFile> categoryUploadedFileList = await _categoryUploadedFileRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return categoryUploadedFileList;
    }

    public async Task<CategoryUploadedFile> AddAsync(CategoryUploadedFile categoryUploadedFile)
    {
        CategoryUploadedFile addedCategoryUploadedFile = await _categoryUploadedFileRepository.AddAsync(categoryUploadedFile);

        return addedCategoryUploadedFile;
    }

    public async Task<CategoryUploadedFile> UpdateAsync(CategoryUploadedFile categoryUploadedFile)
    {
        CategoryUploadedFile updatedCategoryUploadedFile = await _categoryUploadedFileRepository.UpdateAsync(categoryUploadedFile);

        return updatedCategoryUploadedFile;
    }

    public async Task<CategoryUploadedFile> DeleteAsync(CategoryUploadedFile categoryUploadedFile, bool permanent = false)
    {
        CategoryUploadedFile deletedCategoryUploadedFile = await _categoryUploadedFileRepository.DeleteAsync(categoryUploadedFile);

        return deletedCategoryUploadedFile;
    }
}
