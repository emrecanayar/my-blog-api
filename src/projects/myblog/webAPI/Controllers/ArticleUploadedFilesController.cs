using Application.Features.ArticleUploadedFiles.Commands.Create;
using Application.Features.ArticleUploadedFiles.Commands.Delete;
using Application.Features.ArticleUploadedFiles.Commands.Update;
using Application.Features.ArticleUploadedFiles.Queries.GetById;
using Application.Features.ArticleUploadedFiles.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleUploadedFilesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateArticleUploadedFileCommand createArticleUploadedFileCommand)
    {
        CustomResponseDto<CreatedArticleUploadedFileResponse> response = await Mediator.Send(createArticleUploadedFileCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateArticleUploadedFileCommand updateArticleUploadedFileCommand)
    {
        CustomResponseDto<UpdatedArticleUploadedFileResponse> response = await Mediator.Send(updateArticleUploadedFileCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedArticleUploadedFileResponse> response = await Mediator.Send(new DeleteArticleUploadedFileCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdArticleUploadedFileResponse> response = await Mediator.Send(new GetByIdArticleUploadedFileQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListArticleUploadedFileQuery getListArticleUploadedFileQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListArticleUploadedFileListItemDto>> response = await Mediator.Send(getListArticleUploadedFileQuery);
        return Ok(response);
    }
}