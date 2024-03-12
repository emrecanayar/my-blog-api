using Application.Features.Users.Commands.Update;
using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace webAPI.Application.Features.Users.Commands.UpdateUserInformation
{
    public class UpdateUserInformationCommand : IRequest<CustomResponseDto<UpdatedUserResponse>>, ISecuredRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public CultureType CultureType { get; set; }

        public string[] Roles => new[] { UsersOperationClaims.Admin, UsersOperationClaims.Write, UsersOperationClaims.Update };

        public class UpdateUserInformationCommandHandler : IRequestHandler<UpdateUserInformationCommand, CustomResponseDto<UpdatedUserResponse>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public UpdateUserInformationCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<CustomResponseDto<UpdatedUserResponse>> Handle(UpdateUserInformationCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(predicate: u => u.Id == request.Id, enableTracking: false, cancellationToken: cancellationToken);
                await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
                await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user!.Id, user.Email);
                User updateUser = _mapper.Map<User>(request);
                updateUser.PasswordHash = user.PasswordHash;
                updateUser.PasswordSalt = user.PasswordSalt;
                await _userRepository.UpdateAsync(updateUser);

                UpdatedUserResponse response = _mapper.Map<UpdatedUserResponse>(user);
                return CustomResponseDto<UpdatedUserResponse>.Success((int)HttpStatusCode.OK, response, true);
            }
        }
    }
}
