using Application.Features.Reports.Commands.Create;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateReportCommand createReportCommand)
    {
        createReportCommand.UserId = getUserIdFromRequest();
        CustomResponseDto<CreatedReportResponse> response = await Mediator.Send(createReportCommand);
        return Created(uri: "", response);
    }

}