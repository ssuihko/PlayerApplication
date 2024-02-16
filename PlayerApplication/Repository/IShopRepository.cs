using PlayerApplication.Models;
using PlayerApplication.Enums;

namespace PlayerApplication.Repository
{
    public interface IShopRepository
    {
        Task<IEnumerable<Shop>> GetShops();
        Task<Shop?> GetShop(string ShopId, PreloadPolicy preloadPolicy = PreloadPolicy.PreloadRelations);
        Task<Shop?> CreateShop(string name, Inventory inventory);
        Task<Shop?> DeleteShop(string shopId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Shop?> UpdateShop(string shopId, string name, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        Task<Player?> BuyItem(Player player, Shop shop, Item item, PreloadPolicy preloadPolicy = PreloadPolicy.PreloadRelations);

        Task<Shop?> GetShopInventory(string ShopId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        public void SaveChanges();
    }
}
