using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IReportRepository : IAsyncRepository<Report, Guid>, IRepository<Report, Guid>
{
}