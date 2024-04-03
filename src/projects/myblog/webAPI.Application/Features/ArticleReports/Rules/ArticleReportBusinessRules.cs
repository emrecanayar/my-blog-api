using Application.Features.ArticleReports.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.ArticleReports.Rules;

public class ArticleReportBusinessRules : BaseBusinessRules
{
    private readonly IArticleReportRepository _articleReportRepository;

    public ArticleReportBusinessRules(IArticleReportRepository articleReportRepository)
    {
        _articleReportRepository = articleReportRepository;
    }

    public Task ArticleReportShouldExistWhenSelected(ArticleReport? articleReport)
    {
        if (articleReport == null)
            throw new BusinessException(ArticleReportsBusinessMessages.ArticleReportNotExists);
        return Task.CompletedTask;
    }

    public async Task ArticleReportIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ArticleReport? articleReport = await _articleReportRepository.GetAsync(
            predicate: ar => ar.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ArticleReportShouldExistWhenSelected(articleReport);
    }
}