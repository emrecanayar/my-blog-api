using Core.Application.Dtos;

namespace Application.Features.Footers.Queries.GetList;

public class GetListFooterListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}