using Application.Features.CategoryUploadedFiles.Commands.Create;
using Application.Features.CategoryUploadedFiles.Commands.Delete;
using Application.Features.CategoryUploadedFiles.Commands.Update;
using Application.Features.CategoryUploadedFiles.Queries.GetById;
using Application.Features.CategoryUploadedFiles.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryUploadedFilesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryUploadedFileCommand createCategoryUploadedFileCommand)
    {
        CustomResponseDto<CreatedCategoryUploadedFileResponse> response = await Mediator.Send(createCategoryUploadedFileCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryUploadedFileCommand updateCategoryUploadedFileCommand)
    {
        CustomResponseDto<UpdatedCategoryUploadedFileResponse> response = await Mediator.Send(updateCategoryUploadedFileCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedCategoryUploadedFileResponse> response = await Mediator.Send(new DeleteCategoryUploadedFileCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdCategoryUploadedFileResponse> response = await Mediator.Send(new GetByIdCategoryUploadedFileQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryUploadedFileQuery getListCategoryUploadedFileQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCategoryUploadedFileListItemDto>> response = await Mediator.Send(getListCategoryUploadedFileQuery);
        return Ok(response);
    }
}