using PlayerApplication.Models;
using PlayerApplication.Enums;

namespace PlayerApplication.Repository
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItems(string invId);
        Task<IEnumerable<Item>> GetAllItems();
        Task<Item?> GetItem(string ItemId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Item?> CreateItem(string name, string description, float price, Inventory inv);
        Task<Item?> DeleteItem(string itemId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Item?> UpdateItem(string itemId, string name, string description, float price, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        public void SaveChanges();
    }
}
