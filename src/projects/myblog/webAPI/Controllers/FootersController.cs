using Application.Features.Footers.Queries.GetById;
using Application.Features.Footers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FootersController : BaseController
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdFooterResponse> response = await Mediator.Send(new GetByIdFooterQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFooterQuery getListFooterQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListFooterListItemDto>> response = await Mediator.Send(getListFooterQuery);
        return Ok(response);
    }
}