using Application.Features.HeadArticleFeatureUploadedFiles.Queries.GetById;
using Application.Features.HeadArticleFeatureUploadedFiles.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeadArticleFeatureUploadedFilesController : BaseController
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdHeadArticleFeatureUploadedFileResponse> response = await Mediator.Send(new GetByIdHeadArticleFeatureUploadedFileQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListHeadArticleFeatureUploadedFileQuery getListHeadArticleFeatureUploadedFileQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListHeadArticleFeatureUploadedFileListItemDto>> response = await Mediator.Send(getListHeadArticleFeatureUploadedFileQuery);
        return Ok(response);
    }
}