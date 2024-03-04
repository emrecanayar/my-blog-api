using Application.Features.HeadArticleFeatures.Queries.GetById;
using Application.Features.HeadArticleFeatures.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeadArticleFeaturesController : BaseController
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdHeadArticleFeatureResponse> response = await Mediator.Send(new GetByIdHeadArticleFeatureQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListHeadArticleFeatureQuery getListHeadArticleFeatureQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListHeadArticleFeatureListItemDto>> response = await Mediator.Send(getListHeadArticleFeatureQuery);
        return Ok(response);
    }
}