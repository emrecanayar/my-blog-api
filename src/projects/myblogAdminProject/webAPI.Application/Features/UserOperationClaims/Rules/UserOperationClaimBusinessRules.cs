﻿using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;
using webAPI.Application.Features.UserOperationClaims.Profiles;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules : BaseBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public Task UserOperationClaimShouldExistWhenSelected(UserOperationClaim? userOperationClaim)
        {
            if (userOperationClaim == null)
                throw new BusinessException(UserOperationClaimsMessages.UserOperationClaimNotExists);
            return Task.CompletedTask;
        }

        public async Task UserOperationClaimIdShouldExistWhenSelected(Guid id)
        {
            bool doesExist = await _userOperationClaimRepository.AnyAsync(predicate: b => b.Id == id);
            if (!doesExist)
                throw new BusinessException(UserOperationClaimsMessages.UserOperationClaimNotExists);
        }

        public Task UserOperationClaimShouldNotExistWhenSelected(UserOperationClaim? userOperationClaim)
        {
            if (userOperationClaim != null)
                throw new BusinessException(UserOperationClaimsMessages.UserOperationClaimAlreadyExists);
            return Task.CompletedTask;
        }

        public async Task UserShouldNotHasOperationClaimAlreadyWhenInsert(Guid userId, Guid operationClaimId)
        {
            bool doesExist = await _userOperationClaimRepository.AnyAsync(u => u.UserId == userId && u.OperationClaimId == operationClaimId);
            if (doesExist)
                throw new BusinessException(UserOperationClaimsMessages.UserOperationClaimAlreadyExists);
        }

        public async Task UserShouldNotHasOperationClaimAlreadyWhenUpdated(Guid id, Guid userId, Guid operationClaimId)
        {
            bool doesExist = await _userOperationClaimRepository.AnyAsync(
                predicate: uoc => uoc.Id == id && uoc.UserId == userId && uoc.OperationClaimId == operationClaimId
            );
            if (doesExist)
                throw new BusinessException(UserOperationClaimsMessages.UserOperationClaimAlreadyExists);
        }
    }
}
