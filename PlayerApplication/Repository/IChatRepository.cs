using PlayerApplication.Models;
using PlayerApplication.Enums;

namespace PlayerApplication.Repository
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> GetChats();
        Task<Chat?> GetChat(string ChatId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Chat?> CreateChat(string channel);
        Task<Chat?> DeleteChat(string chatId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        public void SaveChanges();
    }
}
