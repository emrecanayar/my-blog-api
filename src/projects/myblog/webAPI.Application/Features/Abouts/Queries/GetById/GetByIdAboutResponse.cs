using Core.Application.Responses;

namespace Application.Features.Abouts.Queries.GetById;

public class GetByIdAboutResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}