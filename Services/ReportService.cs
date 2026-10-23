using Snackis1.Data.Entities;
using Snackis1.Data.Enum;
using Snackis1.Data.Repositories;

namespace Snackis1.Services
{
    public class ReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task AddReportAsync(Report report)
        {
            await _repository.AddReportAsync(report);
        }


        public async Task DeletePostAndCommentAsync(int postId)
        {
            await _repository.DeletePostAndCommentsAsync(postId);
        }

        public async Task<List<Report>> GetAllReportsAsync()
        {
            return await _repository.GetAllReportsAsync();
        }
        public async Task<Report?> GetReportByIdAsync(int reportId)
        {
            return await _repository.GetReportByIdAsync(reportId);
        }
        public async Task SetStatusAsync(int reportId, ReportStatus status)
        {
            await _repository.SetStatusAsync(reportId, status);
        }


    }
}
