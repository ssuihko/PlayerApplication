using Microsoft.EntityFrameworkCore;
using PlayerApplication.Data;
using PlayerApplication.Models;
using PlayerApplication.Enums;

namespace PlayerApplication.Repository
{
    public class ChatRepository : IChatRepository
    {
        private DatabaseContext _db;

        public ChatRepository(DatabaseContext db)
        {
            _db = db;
        }


        /// ChatS
        public async Task<IEnumerable<Chat>> GetChats()
        {
            return await _db.Chats.Include(x => x.Messages).ThenInclude(y => y.Player).ToListAsync();
        }

        public async Task<Chat?> GetChat(string ChatId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _db.Chats.Include(x => x.Messages).ThenInclude(y => y.Player).FirstOrDefaultAsync(s => s.Id == ChatId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _db.Chats.FirstOrDefaultAsync(s => s.Id == ChatId);
                default:
                    return null;
            }
        }

        public async Task<Chat?> DeleteChat(string ChatId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = await _db.Chats.FirstOrDefaultAsync(s => s.Id == ChatId);

            if (mv == null)
            {
                return null;
            }

            _db.Chats.Remove(mv);

            return mv;
        }

        public async Task<Chat?> CreateChat(string channel)
        {

            var Chat = new Chat { Id = Guid.NewGuid().ToString(), Channel = channel };
            await _db.Chats.AddAsync(Chat);
            return Chat;
        }


        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}