using Application.Features.Auth.Rules;
using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace webAPI.Application.Features.Users.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<CustomResponseDto<ChangePasswordUserResponse>>, ISecuredRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string[] Roles => new[] { UsersOperationClaims.Admin, UsersOperationClaims.Write, UsersOperationClaims.Update };

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, CustomResponseDto<ChangePasswordUserResponse>>
        {
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly AuthBusinessRules _authBusinessRules;

            public ChangePasswordCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<CustomResponseDto<ChangePasswordUserResponse>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(predicate: u => u.Id == request.Id, enableTracking: false, cancellationToken: cancellationToken);
                await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
                await _authBusinessRules.UserPasswordShouldBeMatch(request.Id, request.CurrentPassword);
                await _userBusinessRules.CheckControlChangePassword(request.NewPassword, request.ConfirmPassword);

                HashingHelper.CreatePasswordHash(
                    request.ConfirmPassword,
                    passwordHash: out byte[] passwordHash,
                    passwordSalt: out byte[] passwordSalt
                );

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                await _userRepository.UpdateAsync(user);
                return CustomResponseDto<ChangePasswordUserResponse>.Success((int)HttpStatusCode.OK, new ChangePasswordUserResponse { Id = user.Id }, true);

            }
        }
    }
}
