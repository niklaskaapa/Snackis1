using Snackis1.Data.Entities;
using Snackis1.Data.Enum;

namespace Snackis1.Data.Repositories
{
    public interface IReportRepository
    {
        Task AddReportAsync(Report report);
        Task<List<Report>> GetAllReportsAsync();
        Task<Report?> GetReportByIdAsync(int reportId);
        Task SetStatusAsync(int reportId, ReportStatus status);

        Task DeletePostAndCommentsAsync(int postId);

    }
}