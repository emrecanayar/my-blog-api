using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Notification : Entity<Guid>
    {
        public Guid? UserId { get; set; }
        public Guid? ArticleId { get; set; }
        public Guid? CommentId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public User User { get; set; }
        public Article Article { get; set; }
        public Comment Comment { get; set; }

        public Notification()
        {
            User = default!;
            Article = default!;
            Comment = default!;
        }

        public Notification(Guid userId, string type, string content, bool isRead)
        {
            UserId = userId;
            Type = type;
            Content = content;
            IsRead = isRead;
            User = default!;
            Article = default!;
            Comment = default!;
        }
    }
}
