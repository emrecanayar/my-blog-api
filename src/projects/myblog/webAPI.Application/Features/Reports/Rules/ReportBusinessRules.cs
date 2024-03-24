using Application.Features.Reports.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Reports.Rules;

public class ReportBusinessRules : BaseBusinessRules
{
    private readonly IReportRepository _reportRepository;

    public ReportBusinessRules(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public Task ReportShouldExistWhenSelected(Report? report)
    {
        if (report == null)
            throw new BusinessException(ReportsBusinessMessages.ReportNotExists);
        return Task.CompletedTask;
    }

    public async Task ReportIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Report? report = await _reportRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ReportShouldExistWhenSelected(report);
    }
}