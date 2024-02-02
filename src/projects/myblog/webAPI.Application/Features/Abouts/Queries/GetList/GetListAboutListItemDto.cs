using Core.Application.Dtos;

namespace Application.Features.Abouts.Queries.GetList;

public class GetListAboutListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}