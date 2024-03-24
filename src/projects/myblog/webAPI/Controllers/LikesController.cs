using Application.Features.Likes.Commands.Create;
using Application.Features.Likes.Queries.GetById;
using Application.Features.Likes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Likes.Queries.GetByCommentIdDislike;
using webAPI.Application.Features.Likes.Queries.GetByCommentIdLike;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLikeCommand createLikeCommand)
    {
        createLikeCommand.UserId = getUserIdFromRequest();
        CustomResponseDto<CreatedLikeResponse> response = await Mediator.Send(createLikeCommand);
        return Created(uri: "", response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdLikeResponse> response = await Mediator.Send(new GetByIdLikeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("GetByCommentIdLike")]
    public async Task<IActionResult> GetByCommentIdLike([FromQuery] Guid commentId)
    {
        CustomResponseDto<GetByCommentIdLikeResponse> response = await Mediator.Send(new GetByCommentIdLikeQuery { CommentId = commentId });
        return Ok(response);
    }

    [HttpGet("GetByCommentIdDislike")]
    public async Task<IActionResult> GetByCommentIdDislike([FromQuery] Guid commentId)
    {
        CustomResponseDto<GetByCommentIdDislikeResponse> response = await Mediator.Send(new GetByCommentIdDislikeQuery { CommentId = commentId });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLikeQuery getListLikeQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListLikeListItemDto>> response = await Mediator.Send(getListLikeQuery);
        return Ok(response);
    }
}