using PlayerApplication.Data;
using PlayerApplication.Models;
using PlayerApplication.Enums;
using Microsoft.EntityFrameworkCore;

namespace PlayerApplication.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private DatabaseContext _db;

        public InventoryRepository(DatabaseContext db)
        {
            _db = db;
        }


        /// Inventory
        /// MessageS
        public async Task<IEnumerable<Inventory>> GetInventories()
        {
            return await _db.Inventories.ToListAsync();
        }

        public async Task<Inventory?> GetInventory(string invId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _db.Inventories.FirstOrDefaultAsync(s => s.Id == invId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _db.Inventories.FirstOrDefaultAsync(s => s.Id == invId);
                default:
                    return null;
            }
        }


        public async Task<Inventory?> DeleteInventory(string invId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = await _db.Inventories.FirstOrDefaultAsync(s => s.Id == invId);

            if (mv == null)
            {
                return null;
            }

            _db.Inventories.Remove(mv);

            return mv;
        }


        public async Task<Inventory?> UpdateInventory(string invId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = await _db.Inventories.FirstOrDefaultAsync(s => s.Id == invId);

            if (mv == null)
            {
                return null;
            }

            return mv;
        }

        public async Task<Inventory?>CreateInventory()
        {
            var inventory = new Inventory { Id = Guid.NewGuid().ToString(), Items = new List<Item> { } };
            await _db.Inventories.AddAsync(inventory);
            return inventory;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
