using Application.Features.Abouts.Commands.Create;
using Application.Features.Abouts.Commands.Delete;
using Application.Features.Abouts.Commands.Update;
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
    private readonly IConfiguration _configuration;

    public AboutsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAboutCommand createAboutCommand)
    {
        createAboutCommand.WebRootPath = _configuration.GetSection("WebRootPath").Value;
        CustomResponseDto<CreatedAboutResponse> response = await Mediator.Send(createAboutCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAboutCommand updateAboutCommand)
    {
        CustomResponseDto<UpdatedAboutResponse> response = await Mediator.Send(updateAboutCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedAboutResponse> response = await Mediator.Send(new DeleteAboutCommand { Id = id });

        return Ok(response);
    }

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