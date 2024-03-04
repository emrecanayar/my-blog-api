using Application.Features.HeadArticleFeatureUploadedFiles.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.HeadArticleFeatureUploadedFiles;

public class HeadArticleFeatureUploadedFilesManager : IHeadArticleFeatureUploadedFilesService
{
    private readonly IHeadArticleFeatureUploadedFileRepository _headArticleFeatureUploadedFileRepository;
    private readonly HeadArticleFeatureUploadedFileBusinessRules _headArticleFeatureUploadedFileBusinessRules;

    public HeadArticleFeatureUploadedFilesManager(IHeadArticleFeatureUploadedFileRepository headArticleFeatureUploadedFileRepository, HeadArticleFeatureUploadedFileBusinessRules headArticleFeatureUploadedFileBusinessRules)
    {
        _headArticleFeatureUploadedFileRepository = headArticleFeatureUploadedFileRepository;
        _headArticleFeatureUploadedFileBusinessRules = headArticleFeatureUploadedFileBusinessRules;
    }

    public async Task<HeadArticleFeatureUploadedFile?> GetAsync(
        Expression<Func<HeadArticleFeatureUploadedFile, bool>> predicate,
        Func<IQueryable<HeadArticleFeatureUploadedFile>, IIncludableQueryable<HeadArticleFeatureUploadedFile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        HeadArticleFeatureUploadedFile? headArticleFeatureUploadedFile = await _headArticleFeatureUploadedFileRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return headArticleFeatureUploadedFile;
    }

    public async Task<IPaginate<HeadArticleFeatureUploadedFile>?> GetListAsync(
        Expression<Func<HeadArticleFeatureUploadedFile, bool>>? predicate = null,
        Func<IQueryable<HeadArticleFeatureUploadedFile>, IOrderedQueryable<HeadArticleFeatureUploadedFile>>? orderBy = null,
        Func<IQueryable<HeadArticleFeatureUploadedFile>, IIncludableQueryable<HeadArticleFeatureUploadedFile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<HeadArticleFeatureUploadedFile> headArticleFeatureUploadedFileList = await _headArticleFeatureUploadedFileRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return headArticleFeatureUploadedFileList;
    }

    public async Task<HeadArticleFeatureUploadedFile> AddAsync(HeadArticleFeatureUploadedFile headArticleFeatureUploadedFile)
    {
        HeadArticleFeatureUploadedFile addedHeadArticleFeatureUploadedFile = await _headArticleFeatureUploadedFileRepository.AddAsync(headArticleFeatureUploadedFile);

        return addedHeadArticleFeatureUploadedFile;
    }

    public async Task<HeadArticleFeatureUploadedFile> UpdateAsync(HeadArticleFeatureUploadedFile headArticleFeatureUploadedFile)
    {
        HeadArticleFeatureUploadedFile updatedHeadArticleFeatureUploadedFile = await _headArticleFeatureUploadedFileRepository.UpdateAsync(headArticleFeatureUploadedFile);

        return updatedHeadArticleFeatureUploadedFile;
    }

    public async Task<HeadArticleFeatureUploadedFile> DeleteAsync(HeadArticleFeatureUploadedFile headArticleFeatureUploadedFile, bool permanent = false)
    {
        HeadArticleFeatureUploadedFile deletedHeadArticleFeatureUploadedFile = await _headArticleFeatureUploadedFileRepository.DeleteAsync(headArticleFeatureUploadedFile);

        return deletedHeadArticleFeatureUploadedFile;
    }
}
