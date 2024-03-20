using Core.Application.Responses;

namespace webAPI.Application.Features.Comments.Commands.CreateReply
{
    public class CreatedReplyCommentResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
    }
}
