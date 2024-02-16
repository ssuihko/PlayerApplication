using PlayerApplication.Models;
using PlayerApplication.Enums;

namespace PlayerApplication.Repository
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessages();
        Task<Message?> GetMessage(string playerId, string chatId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Message?> CreateMessage(string playerId, string chatId, string text);
        Task<Message?> DeleteMessage(string playerId, string chatId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Message?> UpdateMessage(string playerId, string chatId, string text, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        public void SaveChanges();
    }
}
