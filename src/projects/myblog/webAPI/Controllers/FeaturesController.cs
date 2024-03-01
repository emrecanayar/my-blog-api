using Application.Features.Features.Queries.GetById;
using Application.Features.Features.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController : BaseController
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdFeatureResponse> response = await Mediator.Send(new GetByIdFeatureQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFeatureQuery getListFeatureQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListFeatureListItemDto>> response = await Mediator.Send(getListFeatureQuery);
        return Ok(response);
    }
}