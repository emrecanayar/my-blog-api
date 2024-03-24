using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class ReportRepository : EfRepositoryBase<Report, Guid, BaseDbContext>, IReportRepository
{
    public ReportRepository(BaseDbContext context) : base(context)
    {
    }
}