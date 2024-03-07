using Application.Features.UserUploadedFiles.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserUploadedFiles;

public class UserUploadedFilesManager : IUserUploadedFilesService
{
    private readonly IUserUploadedFileRepository _userUploadedFileRepository;
    private readonly UserUploadedFileBusinessRules _userUploadedFileBusinessRules;

    public UserUploadedFilesManager(IUserUploadedFileRepository userUploadedFileRepository, UserUploadedFileBusinessRules userUploadedFileBusinessRules)
    {
        _userUploadedFileRepository = userUploadedFileRepository;
        _userUploadedFileBusinessRules = userUploadedFileBusinessRules;
    }

    public async Task<UserUploadedFile?> GetAsync(
        Expression<Func<UserUploadedFile, bool>> predicate,
        Func<IQueryable<UserUploadedFile>, IIncludableQueryable<UserUploadedFile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserUploadedFile? userUploadedFile = await _userUploadedFileRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userUploadedFile;
    }

    public async Task<IPaginate<UserUploadedFile>?> GetListAsync(
        Expression<Func<UserUploadedFile, bool>>? predicate = null,
        Func<IQueryable<UserUploadedFile>, IOrderedQueryable<UserUploadedFile>>? orderBy = null,
        Func<IQueryable<UserUploadedFile>, IIncludableQueryable<UserUploadedFile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserUploadedFile> userUploadedFileList = await _userUploadedFileRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUploadedFileList;
    }

    public async Task<UserUploadedFile> AddAsync(UserUploadedFile userUploadedFile)
    {
        UserUploadedFile addedUserUploadedFile = await _userUploadedFileRepository.AddAsync(userUploadedFile);

        return addedUserUploadedFile;
    }

    public async Task<UserUploadedFile> UpdateAsync(UserUploadedFile userUploadedFile)
    {
        UserUploadedFile updatedUserUploadedFile = await _userUploadedFileRepository.UpdateAsync(userUploadedFile);

        return updatedUserUploadedFile;
    }

    public async Task<UserUploadedFile> DeleteAsync(UserUploadedFile userUploadedFile, bool permanent = false)
    {
        UserUploadedFile deletedUserUploadedFile = await _userUploadedFileRepository.DeleteAsync(userUploadedFile);

        return deletedUserUploadedFile;
    }
}
