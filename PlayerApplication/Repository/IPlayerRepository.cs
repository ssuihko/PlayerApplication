using PlayerApplication.Enums;
using PlayerApplication.Models;

namespace PlayerApplication.Repository
{
    public interface IPlayerRepository
    {
        public Player? GetPlayer(string id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        public Player? GetPlayerInventory(string email, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        public Player? GetPlayerByEmail(string email);

        Task<IEnumerable<Player>> GetPlayers();

        Task<Player?> DeletePlayer(string playerId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        Task<Player?> DropItemFromInventory(Player player, Item item, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        public void SaveChanges();
    }
}
