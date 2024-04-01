using Application.Features.ArticleVotes.Commands.Create;
using Application.Features.ArticleVotes.Commands.Delete;
using Application.Features.ArticleVotes.Commands.Update;
using Application.Features.ArticleVotes.Queries.GetById;
using Application.Features.ArticleVotes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.ArticleVotes.Queries.GetByArticleIdUpvoteCount;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleVotesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateArticleVoteCommand createArticleVoteCommand)
    {
        createArticleVoteCommand.UserId = getUserIdFromRequest();
        CustomResponseDto<CreatedArticleVoteResponse> response = await Mediator.Send(createArticleVoteCommand);
        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateArticleVoteCommand updateArticleVoteCommand)
    {
        CustomResponseDto<UpdatedArticleVoteResponse> response = await Mediator.Send(updateArticleVoteCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedArticleVoteResponse> response = await Mediator.Send(new DeleteArticleVoteCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdArticleVoteResponse> response = await Mediator.Send(new GetByIdArticleVoteQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("GetByArticleIdArticleVoteUpvoteCount/{id}")]
    public async Task<IActionResult> GetByArticleIdArticleVoteUpvoteCount([FromRoute] Guid id)
    {
        CustomResponseDto<GetByArticleIdArticleVoteUpvoteCountResponse> response = await Mediator.Send(new GetByArticleIdArticleVoteUpvoteCountQuery { ArticleId = id, UserId = getUserIdFromRequest() });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListArticleVoteQuery getListArticleVoteQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListArticleVoteListItemDto>> response = await Mediator.Send(getListArticleVoteQuery);
        return Ok(response);
    }
}

