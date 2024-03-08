using Application.Features.ArticleUploadedFiles.Queries.GetList;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Tags.Queries.GetList;
using Application.Features.Users.Queries.GetById;
using Core.Application.Dtos;

namespace webAPI.Application.Features.Articles.Queries.GetListByRating
{
    public class GetListByRatingItemDto : IDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ViewCount { get; set; }
        public int CommentCount { get; set; }
        public string SeoAuthor { get; set; } = string.Empty;
        public string SeoDescription { get; set; } = string.Empty;
        public double AverageRating { get; set; }
        public GetByIdCategoryResponse Category { get; set; }
        public GetByIdUserResponse User { get; set; }
        public IList<GetListArticleUploadedFileListItemDto> ArticleUploadedFiles { get; set; }
        public IList<GetListTagListItemDto> Tags { get; set; }

        public GetListByRatingItemDto()
        {
            User = default!;
            Category = default!;
            ArticleUploadedFiles = [];
            Tags = [];
        }
    }
}
