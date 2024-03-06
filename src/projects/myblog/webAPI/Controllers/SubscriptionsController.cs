using Application.Features.Subscriptions.Commands.Create;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSubscriptionCommand createSubscriptionCommand)
    {
        CustomResponseDto<CreatedSubscriptionResponse> response = await Mediator.Send(createSubscriptionCommand);
        return Created(uri: "", response);
    }

}