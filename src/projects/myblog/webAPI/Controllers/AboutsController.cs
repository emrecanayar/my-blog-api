using Application.Features.Abouts.Queries.GetById;
using Application.Features.Abouts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutsController : BaseController
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdAboutResponse> response = await Mediator.Send(new GetByIdAboutQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAboutQuery getListAboutQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListAboutListItemDto>> response = await Mediator.Send(getListAboutQuery);
        return Ok(response);
    }
}