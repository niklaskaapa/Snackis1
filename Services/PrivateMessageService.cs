using Snackis1.Data.Entities;
using Snackis1.Data.Repositories;

namespace Snackis1.Services
{
    public class PrivateMessageService
    {
        private readonly IPrivateMessageRepository _repository;

        public PrivateMessageService(IPrivateMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task AddMessageAsync(PrivateMessage message)
        {
            await _repository.AddMessageAsync(message);
        }

        public async Task<List<PrivateMessage>> GetReceivedMessagesAsync(string userId)
        {
            return await _repository.GetReceivedMessagesAsync(userId);
        }

        public async Task<List<PrivateMessage>> GetSentMessagesAsync(string userId)
        {
            return await _repository.GetSentMessagesAsync(userId);
        }

        public async Task<PrivateMessage?> GetMessageByIdAsync(int messageId)
        {
            return await _repository.GetMessageByIdAsync(messageId);
        }

        public async Task SetReadStatusAsync(int messageId, bool isRead)
        {
             await _repository.SetReadStatusAsync(messageId, isRead);
        }


    }
}
