using Application.Features.ArticleReports.Commands.Create;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleReportsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateArticleReportCommand createArticleReportCommand)
    {
        CustomResponseDto<CreatedArticleReportResponse> response = await Mediator.Send(createArticleReportCommand);
        return Created(uri: "", response);
    }

}