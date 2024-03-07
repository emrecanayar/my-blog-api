using Application.Features.UserUploadedFiles.Commands.Create;
using Application.Features.UserUploadedFiles.Commands.Delete;
using Application.Features.UserUploadedFiles.Commands.Update;
using Application.Features.UserUploadedFiles.Queries.GetById;
using Application.Features.UserUploadedFiles.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserUploadedFilesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserUploadedFileCommand createUserUploadedFileCommand)
    {
        CustomResponseDto<CreatedUserUploadedFileResponse> response = await Mediator.Send(createUserUploadedFileCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserUploadedFileCommand updateUserUploadedFileCommand)
    {
        CustomResponseDto<UpdatedUserUploadedFileResponse> response = await Mediator.Send(updateUserUploadedFileCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedUserUploadedFileResponse> response = await Mediator.Send(new DeleteUserUploadedFileCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdUserUploadedFileResponse> response = await Mediator.Send(new GetByIdUserUploadedFileQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserUploadedFileQuery getListUserUploadedFileQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListUserUploadedFileListItemDto>> response = await Mediator.Send(getListUserUploadedFileQuery);
        return Ok(response);
    }
}