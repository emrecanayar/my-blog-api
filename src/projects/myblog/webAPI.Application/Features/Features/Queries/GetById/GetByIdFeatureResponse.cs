using Core.Application.Responses;

namespace Application.Features.Features.Queries.GetById;

public class GetByIdFeatureResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
}