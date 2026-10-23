using Snackis1.Data.Entities;

namespace Snackis1.Data.Repositories
{
    public interface IPrivateMessageRepository
    {
        Task AddMessageAsync(PrivateMessage message);
        Task<PrivateMessage?> GetMessageByIdAsync(int messageId);
        Task<List<PrivateMessage>> GetReceivedMessagesAsync(string userId);
        Task<List<PrivateMessage>> GetSentMessagesAsync(string userId);

        Task SetReadStatusAsync(int messageId, bool isRead);


    }
}