using Core.Application.Responses;

namespace webAPI.Application.Features.Comments.Commands.Edit
{
    public class EditCommentResponse : IResponse
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuhorWebsite { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
    }
}
