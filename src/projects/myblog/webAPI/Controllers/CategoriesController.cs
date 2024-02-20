using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Categories.Queries.GetListByDynamic;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{

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

    [HttpPost("GetListByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
                                                      [FromBody] DynamicQuery? dynamicQuery = null)
    {
        GetListByDynamicCategoryQuery getListByDynamicCategoryQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        CustomResponseDto<CategoryListModel> result = await Mediator.Send(getListByDynamicCategoryQuery);
        return Ok(result);
    }

}