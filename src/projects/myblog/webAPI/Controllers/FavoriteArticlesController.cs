using Application.Features.FavoriteArticles.Commands.Create;
using Application.Features.FavoriteArticles.Commands.Delete;
using Application.Features.FavoriteArticles.Commands.Update;
using Application.Features.FavoriteArticles.Queries.GetById;
using Application.Features.FavoriteArticles.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.FavoriteArticles.Commands.DeleteByArticleId;
using webAPI.Application.Features.FavoriteArticles.Queries.GetByArticleId;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavoriteArticlesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFavoriteArticleCommand createFavoriteArticleCommand)
    {
        createFavoriteArticleCommand.UserId = getUserIdFromRequest();
        CustomResponseDto<CreatedFavoriteArticleResponse> response = await Mediator.Send(createFavoriteArticleCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFavoriteArticleCommand updateFavoriteArticleCommand)
    {
        CustomResponseDto<UpdatedFavoriteArticleResponse> response = await Mediator.Send(updateFavoriteArticleCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedFavoriteArticleResponse> response = await Mediator.Send(new DeleteFavoriteArticleCommand { Id = id });

        return Ok(response);
    }

    [HttpDelete("DeleteByArticleId/{id}")]
    public async Task<IActionResult> DeleteByArticleId([FromRoute] Guid id)
    {
        CustomResponseDto<DeleteFavoriteArticleByArticleIdResponse> response = await Mediator.Send(new DeleteFavoriteArticleByArticleIdCommand { UserId = getUserIdFromRequest(), ArticleId = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdFavoriteArticleResponse> response = await Mediator.Send(new GetByIdFavoriteArticleQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("GetByArticleId")]
    public async Task<IActionResult> GetByArticleId([FromQuery] Guid articleId)
    {
        CustomResponseDto<GetByArticleIdFavoriteArticleResponse> response = await Mediator.Send(new GetByArticleIdFavoriteArticleQuery { ArticleId = articleId, UserId = getUserIdFromRequest() });
        return Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFavoriteArticleQuery getListFavoriteArticleQuery = new() { PageRequest = pageRequest, UserId = getUserIdFromRequest() };
        CustomResponseDto<GetListResponse<GetListFavoriteArticleListItemDto>> response = await Mediator.Send(getListFavoriteArticleQuery);
        return Ok(response);
    }
}