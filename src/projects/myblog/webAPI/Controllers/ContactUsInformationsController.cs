using Application.Features.ContactUsInformations.Commands.Create;
using Application.Features.ContactUsInformations.Commands.Delete;
using Application.Features.ContactUsInformations.Commands.Update;
using Application.Features.ContactUsInformations.Queries.GetById;
using Application.Features.ContactUsInformations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactUsInformationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateContactUsInformationCommand createContactUsInformationCommand)
    {
        CustomResponseDto<CreatedContactUsInformationResponse> response = await Mediator.Send(createContactUsInformationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateContactUsInformationCommand updateContactUsInformationCommand)
    {
        CustomResponseDto<UpdatedContactUsInformationResponse> response = await Mediator.Send(updateContactUsInformationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedContactUsInformationResponse> response = await Mediator.Send(new DeleteContactUsInformationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdContactUsInformationResponse> response = await Mediator.Send(new GetByIdContactUsInformationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListContactUsInformationQuery getListContactUsInformationQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListContactUsInformationListItemDto>> response = await Mediator.Send(getListContactUsInformationQuery);
        return Ok(response);
    }
}