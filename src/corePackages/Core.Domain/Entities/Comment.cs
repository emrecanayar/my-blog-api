using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Comment : Entity<Guid>
    {
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorEmail { get; set; } = string.Empty;
        public string AuhorWebsite { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
        public bool SendNewPosts { get; set; }
        public bool SendNewComments { get; set; }
        public bool RememberMe { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Report> Reports { get; set; }

        public Comment()
        {
            Article = default!;
            User = default!;
            ParentComment = default!;
            Replies = [];
            Likes = [];
            Reports = [];
        }

        public Comment(Guid id, string authorName, string authorEmail, string auhorWebsite, string content, DateTime datePosted, bool sendNewPosts, bool sendNewComments, bool rememberMe, Guid articleId, Guid userId)
        {
            Id = id;
            AuthorName = authorName;
            AuthorEmail = authorEmail;
            AuhorWebsite = auhorWebsite;
            Content = content;
            DatePosted = datePosted;
            SendNewPosts = sendNewPosts;
            SendNewComments = sendNewComments;
            RememberMe = rememberMe;
            ArticleId = articleId;
            Article = default!;
            UserId = userId;
            User = default!;
            ParentComment = default!;
            Replies = [];
            Likes = [];
            Reports = [];
        }
    }
}
