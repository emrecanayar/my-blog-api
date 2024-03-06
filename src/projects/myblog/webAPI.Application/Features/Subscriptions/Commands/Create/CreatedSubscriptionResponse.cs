using Core.Application.Responses;

namespace Application.Features.Subscriptions.Commands.Create;

public class CreatedSubscriptionResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}