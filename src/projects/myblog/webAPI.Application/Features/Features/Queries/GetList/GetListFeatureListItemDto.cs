using Core.Application.Dtos;

namespace Application.Features.Features.Queries.GetList;

public class GetListFeatureListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
}