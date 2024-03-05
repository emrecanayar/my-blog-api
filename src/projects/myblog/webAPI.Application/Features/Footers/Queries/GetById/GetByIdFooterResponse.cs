using Core.Application.Responses;

namespace Application.Features.Footers.Queries.GetById;

public class GetByIdFooterResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}