using Application.Features.ArticleReports.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ArticleReports;

public class ArticleReportsManager : IArticleReportsService
{
    private readonly IArticleReportRepository _articleReportRepository;
    private readonly ArticleReportBusinessRules _articleReportBusinessRules;

    public ArticleReportsManager(IArticleReportRepository articleReportRepository, ArticleReportBusinessRules articleReportBusinessRules)
    {
        _articleReportRepository = articleReportRepository;
        _articleReportBusinessRules = articleReportBusinessRules;
    }

    public async Task<ArticleReport?> GetAsync(
        Expression<Func<ArticleReport, bool>> predicate,
        Func<IQueryable<ArticleReport>, IIncludableQueryable<ArticleReport, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ArticleReport? articleReport = await _articleReportRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return articleReport;
    }

    public async Task<IPaginate<ArticleReport>?> GetListAsync(
        Expression<Func<ArticleReport, bool>>? predicate = null,
        Func<IQueryable<ArticleReport>, IOrderedQueryable<ArticleReport>>? orderBy = null,
        Func<IQueryable<ArticleReport>, IIncludableQueryable<ArticleReport, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ArticleReport> articleReportList = await _articleReportRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return articleReportList;
    }

    public async Task<ArticleReport> AddAsync(ArticleReport articleReport)
    {
        ArticleReport addedArticleReport = await _articleReportRepository.AddAsync(articleReport);

        return addedArticleReport;
    }

    public async Task<ArticleReport> UpdateAsync(ArticleReport articleReport)
    {
        ArticleReport updatedArticleReport = await _articleReportRepository.UpdateAsync(articleReport);

        return updatedArticleReport;
    }

    public async Task<ArticleReport> DeleteAsync(ArticleReport articleReport, bool permanent = false)
    {
        ArticleReport deletedArticleReport = await _articleReportRepository.DeleteAsync(articleReport);

        return deletedArticleReport;
    }
}
