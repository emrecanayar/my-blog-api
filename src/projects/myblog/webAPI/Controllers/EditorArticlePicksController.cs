using Application.Features.EditorArticlePicks.Queries.GetById;
using Application.Features.EditorArticlePicks.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.EditorArticlePicks.Queries.GetListByDynamic;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EditorArticlePicksController : BaseController
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdEditorArticlePickResponse> response = await Mediator.Send(new GetByIdEditorArticlePickQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEditorArticlePickQuery getListEditorArticlePickQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListEditorArticlePickListItemDto>> response = await Mediator.Send(getListEditorArticlePickQuery);
        return Ok(response);
    }

    [HttpPost("GetListByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
                                                      [FromBody] DynamicQuery? dynamicQuery = null)
    {
        GetListByDynamicEditorArticlePickQuery getListByDynamicEditorArticlePickQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        CustomResponseDto<EditorArticlePickListModel> result = await Mediator.Send(getListByDynamicEditorArticlePickQuery);
        return Ok(result);
    }
}