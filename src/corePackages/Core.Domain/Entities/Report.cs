using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Report : Entity<Guid>
    {
        public string Reason { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime DateReported { get; set; }
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; }

        public Report()
        {
            User = default!;
            Comment = default!;
        }

        public Report(Guid id, string reason, Guid userId, DateTime dateReported, Guid commentId)
        {
            Id = id;
            Reason = reason;
            UserId = userId;
            DateReported = dateReported;
            CommentId = commentId;
            User = default!;
            Comment = default!;
        }
    }
}
