using Core.Application.Responses;

namespace Application.Features.ArticleReports.Commands.Create;

public class CreatedArticleReportResponse : IResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid ArticleId { get; set; }
}