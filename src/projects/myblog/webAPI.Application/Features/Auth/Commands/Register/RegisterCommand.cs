using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Application.Dtos;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using Core.Security.JWT;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : BaseFileTokenDto, IRequest<CustomResponseDto<RegisteredResponse>>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    [JsonIgnore]
    public string IpAddress { get; set; }
    [JsonIgnore]
    public string WebRootPath { get; set; }

    public RegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
        WebRootPath = string.Empty;
    }

    public RegisterCommand(UserForRegisterDto userForRegisterDto, string ipAddress, string webRootPath)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
        WebRootPath = webRootPath;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, CustomResponseDto<RegisteredResponse>>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public RegisterCommandHandler(IAuthService authService, AuthBusinessRules authBusinessRules, IUserService userService)
        {
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _userService = userService;
        }

        public async Task<CustomResponseDto<RegisteredResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            User createdUser = await _userService.AddUserForWithFileAsync(request);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            Core.Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
            Core.Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return CustomResponseDto<RegisteredResponse>.Success((int)HttpStatusCode.OK, registeredResponse, true);
        }
    }
}
