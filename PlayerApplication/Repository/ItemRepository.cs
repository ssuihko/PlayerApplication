using Microsoft.EntityFrameworkCore;
using PlayerApplication.Data;
using PlayerApplication.Models;
using PlayerApplication.Enums;

namespace PlayerApplication.Repository
{
    public class ItemRepository : IItemRepository
    {
        private DatabaseContext _db;

        public ItemRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Item>> GetItems(string invId)
        {
            return await _db.Items.Where(x => x.InventoryId == invId).ToListAsync();
        }

        public async Task<Item?> GetItem(string ItemId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _db.Items.FirstOrDefaultAsync(s => s.Id == ItemId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _db.Items.FirstOrDefaultAsync(s => s.Id == ItemId);
                default:
                    return null;
            }
        }

        public async Task<Item?> DeleteItem(string ItemId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = await _db.Items.FirstOrDefaultAsync(s => s.Id == ItemId);

            if (mv == null)
            {
                return null;
            }

            _db.Items.Remove(mv);

            return mv;
        }

        public async Task<Item?> CreateItem(string name, string description, float price, Inventory inv)
        {

            if (name == "" || description == "" || price <= 0.0F) return null;
            var Item = new Item { Id = Guid.NewGuid().ToString(), Name = name, Description = description, Price = price, InventoryId = inv.Id, Inventory = inv };
            await _db.Items.AddAsync(Item);
            return Item;
        }

        public async Task<Item?> UpdateItem(string itemId, string name, string description, float price, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = await _db.Items.FirstOrDefaultAsync(s => s.Id == itemId);

            if (mv == null)
            {
                return null;
            }

            if (name != null) { mv.Name = name; }

            if (description != null) { mv.Description = description; }

            if (price != null) { mv.Price = price; }


            return mv;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}