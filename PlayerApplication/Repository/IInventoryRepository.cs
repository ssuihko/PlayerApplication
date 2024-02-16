using PlayerApplication.Models;
using PlayerApplication.Enums;

namespace PlayerApplication.Repository
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventories();
        Task<Inventory?> GetInventory(string InventoryId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        Task<Inventory?> DeleteInventory(string invId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Inventory?> UpdateInventory(string invId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        public void SaveChanges();
    }
}
