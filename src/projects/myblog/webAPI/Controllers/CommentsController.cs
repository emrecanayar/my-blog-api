using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Application.Features.Comments.Queries.GetById;
using Application.Features.Comments.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Comments.Commands.CreateReply;
using webAPI.Application.Features.Comments.Commands.Edit;
using webAPI.Application.Features.Comments.Queries.GetListByDynamic;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCommentCommand createCommentCommand)
    {
        CustomResponseDto<CreatedCommentResponse> response = await Mediator.Send(createCommentCommand);

        return Created(uri: "", response);
    }

    [HttpPost("AddReplyComment")]
    public async Task<IActionResult> AddReplyComment([FromBody] CreateReplyCommentCommand createReplyCommentCommand)
    {
        CustomResponseDto<CreatedReplyCommentResponse> response = await Mediator.Send(createReplyCommentCommand);
        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCommentCommand updateCommentCommand)
    {
        CustomResponseDto<UpdatedCommentResponse> response = await Mediator.Send(updateCommentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedCommentResponse> response = await Mediator.Send(new DeleteCommentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdCommentResponse> response = await Mediator.Send(new GetByIdCommentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCommentQuery getListCommentQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListCommentListItemDto>> response = await Mediator.Send(getListCommentQuery);
        return Ok(response);
    }


    [HttpPost("GetListByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
                                                      [FromBody] DynamicQuery? dynamicQuery = null)
    {
        GetListByDynamicCommentQuery getListByDynamicCommentQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        CustomResponseDto<CommentListModel> result = await Mediator.Send(getListByDynamicCommentQuery);
        return Ok(result);
    }

    [HttpPut("EditComment")]
    public async Task<IActionResult> EditComment([FromBody] EditCommentCommand editCommentCommand)
    {
        CustomResponseDto<EditCommentResponse> response = await Mediator.Send(editCommentCommand);

        return Ok(response);
    }
}