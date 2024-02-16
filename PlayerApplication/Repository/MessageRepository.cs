using Microsoft.EntityFrameworkCore;
using PlayerApplication.Data;
using PlayerApplication.Models;
using PlayerApplication.Enums;

namespace PlayerApplication.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private DatabaseContext _db;

        public MessageRepository(DatabaseContext db)
        {
            _db = db;
        }


        /// MessageS
        public async Task<IEnumerable<Message>> GetMessages()
        {
            return await _db.Messages.Include(x => x.Player).ToListAsync();
        }

        public async Task<Message?> GetMessage(string playerId, string chatId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _db.Messages.Include(x => x.Player).Where(x => x.ChatId == chatId).FirstOrDefaultAsync(s => s.PlayerId == playerId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _db.Messages.Where(x => x.ChatId == chatId).FirstOrDefaultAsync(s => s.PlayerId == playerId);
                default:
                    return null;
            }
        }

        public async Task<Message?> DeleteMessage(string playerId, string chatId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = await _db.Messages.Where(x => x.ChatId == chatId).FirstOrDefaultAsync(s => s.PlayerId == playerId);

            if (mv == null)
            {
                return null;
            }

            _db.Messages.Remove(mv);

            return mv;
        }

        public async Task<Message?> CreateMessage(string playerId, string chatId, string text)
        {
            var plr = _db.Players.FirstOrDefault(x => x.Id == playerId);
            var cht = _db.Chats.FirstOrDefault(x => x.Id == chatId);

            if (plr == null || cht == null)
            {
                return null;
            }

            if (text == "" ) return null;
            var Message = new Message { PlayerId = playerId, Player= plr, ChatId = chatId, Chat = cht, Text = text, PostDate = DateTime.Now.ToUniversalTime() };
            await _db.Messages.AddAsync(Message);
            return Message;
        }

        public async Task<Message?> UpdateMessage(string playerId, string chatId, string text, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = await _db.Messages.Where(x => x.ChatId == chatId).FirstOrDefaultAsync(s => s.PlayerId == playerId);

            if (mv == null)
            {
                return null;
            }

            if (text != null || text != "") { mv.Text = text; }

            return mv;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}