using Core.Application.Responses;

namespace Application.Features.ContactUsInformations.Queries.GetById;

public class GetByIdContactUsInformationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AddressText { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string GithubLink { get; set; } = string.Empty;
    public string LinkedInLink { get; set; } = string.Empty;
    public string TwitterLink { get; set; } = string.Empty;
    public string WhatsAppLink { get; set; } = string.Empty;
}