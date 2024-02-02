using Application.Features.Contacts.Commands.Create;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateContactCommand createContactCommand)
    {
        CustomResponseDto<CreatedContactResponse> response = await Mediator.Send(createContactCommand);

        return Created(uri: "", response);
    }

}