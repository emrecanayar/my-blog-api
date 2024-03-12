using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Commands.UpdateFromAuth;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Users.Commands.ChangePassword;
using webAPI.Application.Features.Users.Commands.UpdateUserInformation;
using webAPI.Controllers.Base;

namespace webAPI.Controllers;

public class UsersController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
    {
        CustomResponseDto<GetByIdUserResponse> result = await Mediator.Send(getByIdUserQuery);
        return Ok(result);
    }

    [HttpGet("GetFromAuth")]
    public async Task<IActionResult> GetFromAuth()
    {
        GetByIdUserQuery getByIdUserQuery = new() { Id = getUserIdFromRequest() };
        CustomResponseDto<GetByIdUserResponse> result = await Mediator.Send(getByIdUserQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListUserListItemDto>> result = await Mediator.Send(getListUserQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
    {
        CustomResponseDto<CreatedUserResponse> result = await Mediator.Send(createUserCommand);
        return Created(uri: "", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
    {
        CustomResponseDto<UpdatedUserResponse> result = await Mediator.Send(updateUserCommand);
        return Ok(result);
    }

    [HttpPut("UpdateUserInformation")]
    public async Task<IActionResult> UpdateUserInformation([FromBody] UpdateUserInformationCommand updateUserInformationCommand)
    {
        CustomResponseDto<UpdatedUserResponse> result = await Mediator.Send(updateUserInformationCommand);
        return Ok(result);
    }


    [HttpPut("FromAuth")]
    public async Task<IActionResult> UpdateFromAuth([FromBody] UpdateUserFromAuthCommand updateUserFromAuthCommand)
    {
        updateUserFromAuthCommand.Id = getUserIdFromRequest();
        CustomResponseDto<UpdatedUserFromAuthResponse> result = await Mediator.Send(updateUserFromAuthCommand);
        return Ok(result);
    }

    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand changePasswordCommand)
    {
        changePasswordCommand.Id = getUserIdFromRequest();
        CustomResponseDto<ChangePasswordUserResponse> result = await Mediator.Send(changePasswordCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUserCommand)
    {
        CustomResponseDto<DeletedUserResponse> result = await Mediator.Send(deleteUserCommand);
        return Ok(result);
    }
}
