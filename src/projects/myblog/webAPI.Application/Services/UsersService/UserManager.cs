using Application.Features.Auth.Commands.Register;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Application.Services.UserUploadedFiles;
using AutoMapper;
using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using webAPI.Application.Features.UploadedFiles.Dtos;

namespace Application.Services.UsersService;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUserUploadedFilesService _userUploadedFilesService;
    private readonly UserBusinessRules _userBusinessRules;

    public UserManager(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper, IUserUploadedFilesService userUploadedFilesService)
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
        _mapper = mapper;
        _userUploadedFilesService = userUploadedFilesService;
    }

    public async Task<User?> GetAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        User? user = await _userRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return user;
    }

    public async Task<IPaginate<User>?> GetListAsync(
        Expression<Func<User, bool>>? predicate = null,
        Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<User> userList = await _userRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userList;
    }

    public async Task<User> AddAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(user.Email);

        User addedUser = await _userRepository.AddAsync(user);

        return addedUser;
    }

    public async Task<User> UpdateAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user.Id, user.Email);

        User updatedUser = await _userRepository.UpdateAsync(user);

        return updatedUser;
    }

    public async Task<User> DeleteAsync(User user, bool permanent = false)
    {
        User deletedUser = await _userRepository.DeleteAsync(user);

        return deletedUser;
    }

    public async Task<User> AddUserForWithFileAsync(RegisterCommand registerCommand)
    {
        UploadedFileResponseDto uploadedFileResponseDto = await _userBusinessRules.CheckUserForAddAsync(registerCommand);

        HashingHelper.CreatePasswordHash(
             registerCommand.UserForRegisterDto.Password,
             passwordHash: out byte[] passwordHash,
             passwordSalt: out byte[] passwordSalt
         );

        User newUser = new()
        {
            Email = registerCommand.UserForRegisterDto.Email,
            FirstName = registerCommand.UserForRegisterDto.FirstName,
            LastName = registerCommand.UserForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = RecordStatu.Active
        };

        User createdUser = await _userRepository.AddAsync(newUser);
        await AddUploadedUserFileInformationAsync(uploadedFileResponseDto, createdUser);
        return createdUser;
    }

    private async Task AddUploadedUserFileInformationAsync(UploadedFileResponseDto uploadedFileResponseDto, User user)
    {
        string fileName = Path.GetFileName(uploadedFileResponseDto.Path);
        string newPath = BuildNewPath(fileName);

        await _userUploadedFilesService.AddAsync(new UserUploadedFile
        {
            UserId = user.Id,
            UploadedFileId = uploadedFileResponseDto.Id,
            OldPath = uploadedFileResponseDto.Path,
            NewPath = newPath
        });
    }

    private string BuildNewPath(string fileName)
    {
        return Path.Combine(_userBusinessRules.IMG_FOLDER, fileName).Replace("\\", "/");
    }
}
