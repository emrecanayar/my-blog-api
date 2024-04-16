using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Article : Entity<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ViewCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public string SeoAuthor { get; set; } = string.Empty;
        public string SeoDescription { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<ArticleUploadedFile> ArticleUploadedFiles { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<EditorArticlePick> EditorArticlePicks { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<FavoriteArticle> FavoriteArticles { get; set; }
        public ICollection<ArticleVote> ArticleVotes { get; set; }
        public ICollection<ArticleReport> ArticleReports { get; set; }
        public ICollection<Notification> Notifications { get; set; }

        public Article()
        {
            Category = default!;
            User = default!;
            Tags = [];
            ArticleUploadedFiles = [];
            Comments = [];
            EditorArticlePicks = [];
            Ratings = [];
            FavoriteArticles = [];
            ArticleVotes = [];
            ArticleReports = [];
            Notifications = [];
        }

        public Article(string title, string content, DateTime date, int viewCount, int commentCount, string seoAuthor, string seoDescription, Guid categoryId, Guid userId)
        {
            Title = title;
            Content = content;
            Date = date;
            ViewCount = viewCount;
            CommentCount = commentCount;
            SeoAuthor = seoAuthor;
            SeoDescription = seoDescription;
            CategoryId = categoryId;
            UserId = userId;
            Category = default!;
            User = default!;
            Tags = [];
            ArticleUploadedFiles = [];
            Comments = [];
            EditorArticlePicks = [];
            Ratings = [];
            FavoriteArticles = [];
            ArticleVotes = [];
            ArticleReports = [];
            Notifications = [];
        }
    }
}
