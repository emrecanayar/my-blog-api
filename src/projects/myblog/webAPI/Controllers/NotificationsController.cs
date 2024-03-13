using Application.Features.Notifications.Commands.Create;
using Application.Features.Notifications.Commands.Delete;
using Application.Features.Notifications.Commands.Update;
using Application.Features.Notifications.Queries.GetById;
using Application.Features.Notifications.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Notifications.Commands.MarkAsRead;
using webAPI.Application.Features.Notifications.Queries.GetByUserId;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateNotificationCommand createNotificationCommand)
    {
        CustomResponseDto<CreatedNotificationResponse> response = await Mediator.Send(createNotificationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateNotificationCommand updateNotificationCommand)
    {
        CustomResponseDto<UpdatedNotificationResponse> response = await Mediator.Send(updateNotificationCommand);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> MarkAsRead([FromBody] MarkAsReadNotificationCommand markAsReadNotificationCommand)
    {
        CustomResponseDto<MarkAsReadNotificationResponse> response = await Mediator.Send(markAsReadNotificationCommand);
        return Ok(response);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedNotificationResponse> response = await Mediator.Send(new DeleteNotificationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdNotificationResponse> response = await Mediator.Send(new GetByIdNotificationQuery { Id = id });
        return Ok(response);
    }


    [HttpGet("GetByUserId")]
    public async Task<IActionResult> GetByUserId()
    {
        Guid userId = getUserIdFromRequest();
        CustomResponseDto<GetListResponse<GetByUserIdNotificationResponse>> response = await Mediator.Send(new GetByUserIdNotificationQuery { UserId = userId });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListNotificationQuery getListNotificationQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListNotificationListItemDto>> response = await Mediator.Send(getListNotificationQuery);
        return Ok(response);
    }
}