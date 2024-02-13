using Core.Application.Responses;

namespace Application.Features.Categories.Commands.Create;

public class CreatedCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsPopular { get; set; }
}