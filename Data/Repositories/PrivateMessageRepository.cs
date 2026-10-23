using Microsoft.EntityFrameworkCore;
using Snackis1.Data.Entities;

namespace Snackis1.Data.Repositories
{
    public class PrivateMessageRepository : IPrivateMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public PrivateMessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(PrivateMessage message)
        {
            _context.PrivateMessages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PrivateMessage>> GetReceivedMessagesAsync(string userId)
        {
            return await _context.PrivateMessages
                .Where(m => m.ReceiverId == userId)
                .Include(m => m.Sender)
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();
        }

        public async Task<List<PrivateMessage>> GetSentMessagesAsync(string userId)
        {
            return await _context.PrivateMessages
                .Where(m => m.SenderId == userId)
                .Include(m => m.Receiver)
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();

        }

        public async Task<PrivateMessage?> GetMessageByIdAsync(int messageId)
        {
            return await _context.PrivateMessages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .FirstOrDefaultAsync(m => m.Id == messageId);

        }

        public async Task SetReadStatusAsync(int messageId, bool isRead)
        {
            var message = await _context.PrivateMessages
                .FirstOrDefaultAsync(m => m.Id == messageId);

            if(message == null)
            {
                return;
            }

            message.IsRead = isRead;

            await _context.SaveChangesAsync();

        }
    }
}
