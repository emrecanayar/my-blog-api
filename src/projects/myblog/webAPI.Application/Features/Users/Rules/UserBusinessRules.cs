using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;
using Core.Security.Hashing;
using webAPI.Application.Features.UploadedFiles.Dtos;
using webAPI.Application.Services.UploadedFileService;

namespace Application.Features.Users.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;
    private readonly IUploadedFileService _uploadedFileService;
    public readonly string IMG_FOLDER = Path.Combine("Resources", "Files", typeof(User).Name);

    public UserBusinessRules(IUserRepository userRepository, IUploadedFileService uploadedFileService)
    {
        _userRepository = userRepository;
        _uploadedFileService = uploadedFileService;
    }

    public Task UserShouldBeExistsWhenSelected(User? user)
    {
        if (user == null)
            throw new BusinessException(AuthMessages.UserDontExists);
        return Task.CompletedTask;
    }

    public async Task UserIdShouldBeExistsWhenSelected(Guid id)
    {
        bool doesExist = await _userRepository.AnyAsync(predicate: u => u.Id == id, enableTracking: false);
        if (doesExist)
            throw new BusinessException(AuthMessages.UserDontExists);
    }

    public Task UserPasswordShouldBeMatched(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(AuthMessages.PasswordDontMatch);
        return Task.CompletedTask;
    }

    public async Task UserEmailShouldNotExistsWhenInsert(string email)
    {
        bool doesExists = await _userRepository.AnyAsync(predicate: u => u.Email == email, enableTracking: false);
        if (doesExists)
            throw new BusinessException(AuthMessages.UserMailAlreadyExists);
    }

    public async Task UserEmailShouldNotExistsWhenUpdate(Guid id, string email)
    {
        bool doesExists = await _userRepository.AnyAsync(predicate: u => u.Id != id && u.Email == email, enableTracking: false);
        if (doesExists)
            throw new BusinessException(AuthMessages.UserMailAlreadyExists);
    }

    public async Task<UploadedFileResponseDto> CheckUserForAddAsync(RegisterCommand registerCommand)
    {
        if (registerCommand.Tokens?.Count > 0)
        {
            UploadedFileResponseDto? uploadedFile = await _uploadedFileService.TransferFile(registerCommand.Tokens[0], IMG_FOLDER, registerCommand.WebRootPath);

            if (uploadedFile is not null) return uploadedFile;

            throw new BusinessException("User için yüklenen dosya bulunamadý.");

        }

        throw new BusinessException("User için yüklenen token bulunamadý.");
    }
}
