using Application.Features.UserUploadedFiles.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.UserUploadedFiles.Rules;

public class UserUploadedFileBusinessRules : BaseBusinessRules
{
    private readonly IUserUploadedFileRepository _userUploadedFileRepository;

    public UserUploadedFileBusinessRules(IUserUploadedFileRepository userUploadedFileRepository)
    {
        _userUploadedFileRepository = userUploadedFileRepository;
    }

    public Task UserUploadedFileShouldExistWhenSelected(UserUploadedFile? userUploadedFile)
    {
        if (userUploadedFile == null)
            throw new BusinessException(UserUploadedFilesBusinessMessages.UserUploadedFileNotExists);
        return Task.CompletedTask;
    }

    public async Task UserUploadedFileIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserUploadedFile? userUploadedFile = await _userUploadedFileRepository.GetAsync(
            predicate: uuf => uuf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserUploadedFileShouldExistWhenSelected(userUploadedFile);
    }
}