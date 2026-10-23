using Microsoft.EntityFrameworkCore;
using Snackis1.Data.Entities;
using Snackis1.Data.Enum;

namespace Snackis1.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddReportAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAndCommentsAsync(int postId)
        {
            var comments = await _context.Comments
                .Where(c => c.PostId == postId)
                .ToListAsync();

            _context.Comments.RemoveRange(comments);

            var post = await _context.Posts
                .FirstOrDefaultAsync(p => p.Id == postId);

            if(post == null)
            {
                return;
            }

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();



        }

        public async Task<List<Report>> GetAllReportsAsync()
        {
            return await _context.Reports
                .Include(r => r.Reporter)
                .Include(r => r.Post)
                    .ThenInclude(p => p.User)
                .ToListAsync();
        }

        public async Task<Report?> GetReportByIdAsync(int reportId)
        {
            return await _context.Reports
                .Include(r => r.Reporter)
                .Include(r => r.Post)
                .FirstOrDefaultAsync(r => r.Id == reportId);

        }

        public async Task SetStatusAsync(int reportId, ReportStatus status)
        {
            var report = await _context.Reports
                .FirstOrDefaultAsync(r => r.Id == reportId);

            if (report == null)
            {
                return;
            }

            report.Status = status;

            await _context.SaveChangesAsync();

        }



    }
}
