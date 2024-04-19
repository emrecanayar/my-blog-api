using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Like : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; }
        public bool IsLiked { get; set; }
        public ICollection<Notification> Notifications { get; set; }

        public Like()
        {
            User = default!;
            Comment = default!;
            Notifications = [];
        }

        public Like(Guid id, Guid userId, Guid commentId, bool isLiked)
        {
            Id = id;
            UserId = userId;
            CommentId = commentId;
            User = default!;
            Comment = default!;
            IsLiked = isLiked;
            Notifications = [];
        }
    }
}
