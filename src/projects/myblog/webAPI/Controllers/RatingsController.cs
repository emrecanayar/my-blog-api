using Application.Features.Ratings.Commands.Create;
using Application.Features.Ratings.Commands.Update;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Ratings.Queries.GetRatingInformation;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RatingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRatingCommand createRatingCommand)
    {
        createRatingCommand.UserId = getUserIdFromRequest();
        CustomResponseDto<CreatedRatingResponse> response = await Mediator.Send(createRatingCommand);
        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRatingCommand updateRatingCommand)
    {
        updateRatingCommand.UserId = getUserIdFromRequest();
        CustomResponseDto<UpdatedRatingResponse> response = await Mediator.Send(updateRatingCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetRatingInformation([FromQuery] Guid articleId)
    {
        CustomResponseDto<GetRatingInformationResponse> response = await Mediator.Send(new GetRatingInformationQuery { ArticleId = articleId, UserId = getUserIdFromRequest() });
        return Ok(response);
    }

}