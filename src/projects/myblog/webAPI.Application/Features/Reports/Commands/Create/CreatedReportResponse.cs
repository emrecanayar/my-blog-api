using Core.Application.Responses;

namespace Application.Features.Reports.Commands.Create;

public class CreatedReportResponse : IResponse
{
    public Guid Id { get; set; }
    public string Reason { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public DateTime DateReported { get; set; }
    public Guid CommentId { get; set; }
}