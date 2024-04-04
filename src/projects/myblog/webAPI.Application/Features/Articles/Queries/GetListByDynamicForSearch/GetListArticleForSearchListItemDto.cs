using Core.Application.Dtos;

namespace webAPI.Application.Features.Articles.Queries.GetListByDynamicForSearch
{
    public class GetListArticleForSearchListItemDto : IDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
    }
}
