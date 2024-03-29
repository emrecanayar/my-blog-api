﻿using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using webAPI.Application.Features.Auth.Constants;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.Users.Rules
{
    public class UserBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
    }
}
