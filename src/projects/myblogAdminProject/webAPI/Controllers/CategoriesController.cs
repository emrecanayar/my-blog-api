using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{
    private readonly IConfiguration _configuration;

    public CategoriesController(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        createCategoryCommand.WebRootPath = _configuration.GetValue<string>("WebRootPath");
        CustomResponseDto<CreatedCategoryResponse> response = await Mediator.Send(createCategoryCommand);
        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
    {
        updateCategoryCommand.WebRootPath = _configuration.GetValue<string>("WebRootPath");
        CustomResponseDto<UpdatedCategoryResponse> response = await Mediator.Send(updateCategoryCommand);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedCategoryResponse> response = await Mediator.Send(new DeleteCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdCategoryResponse> response = await Mediator.Send(new GetByIdCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryQuery getListCategoryQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListCategoryListItemDto>> response = await Mediator.Send(getListCategoryQuery);
        return Ok(response);
    }
}