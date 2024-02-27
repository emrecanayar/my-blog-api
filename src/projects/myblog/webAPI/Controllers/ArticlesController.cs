using Application.Features.Articles.Commands.Create;
using Application.Features.Articles.Commands.Delete;
using Application.Features.Articles.Commands.Update;
using Application.Features.Articles.Queries.GetById;
using Application.Features.Articles.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Articles.Queries.GetListByDynamic;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : BaseController
{
    private readonly IConfiguration _configuration;

    public ArticlesController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateArticleCommand createArticleCommand)
    {
        createArticleCommand.WebRootPath = _configuration.GetValue<string>("WebRootPath") ?? throw new ArgumentException("WebRootPath bulunamadý");
        createArticleCommand.UserId = Guid.Parse("C70CD0E4-A393-4139-B4C9-CB2B7BC3DD02"); //getUserIdFromRequest() 
        createArticleCommand.SeoAuthor = "Admin Admin";//getUserFromRequest().FirstName + " " + getUserFromRequest().LastName;
        CustomResponseDto<CreatedArticleResponse> response = await Mediator.Send(createArticleCommand);
        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateArticleCommand updateArticleCommand)
    {
        CustomResponseDto<UpdatedArticleResponse> response = await Mediator.Send(updateArticleCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedArticleResponse> response = await Mediator.Send(new DeleteArticleCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdArticleResponse> response = await Mediator.Send(new GetByIdArticleQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListArticleQuery getListArticleQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListArticleListItemDto>> response = await Mediator.Send(getListArticleQuery);
        return Ok(response);
    }

    [HttpPost("GetListByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
                                                      [FromBody] DynamicQuery? dynamicQuery = null)
    {
        GetListByDynamicArticleQuery getListByDynamicArticleQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        CustomResponseDto<ArticleListModel> result = await Mediator.Send(getListByDynamicArticleQuery);
        return Ok(result);
    }
}