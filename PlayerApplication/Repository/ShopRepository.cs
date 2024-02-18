using Microsoft.EntityFrameworkCore;
using PlayerApplication.Data;
using PlayerApplication.Models;
using PlayerApplication.Enums;

namespace PlayerApplication.Repository
{
    public class ShopRepository : IShopRepository
    {
        private DatabaseContext _db;

        public ShopRepository(DatabaseContext db)
        {
            _db = db;
        }


        /// ShopS
        public async Task<IEnumerable<Shop>> GetShops()
        {
            return await _db.Shops.Include(x => x.Inventory).ThenInclude(y => y.Items).ToListAsync();
        }

        public async Task<Shop?> GetShop(string ShopId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _db.Shops.Include(x => x.Inventory).ThenInclude(y => y.Items).FirstOrDefaultAsync(s => s.Id == ShopId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _db.Shops.FirstOrDefaultAsync(s => s.Id == ShopId);
                default:
                    return null;
            }
        }

        public async Task<Shop?> GetShopInventory(string ShopId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {  
             return await _db.Shops.Include(x => x.Inventory).ThenInclude(y => y.Items).FirstOrDefaultAsync(s => s.Id == ShopId);     
        }

        public async Task<Shop?> DeleteShop(string ShopId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = await _db.Shops.FirstOrDefaultAsync(s => s.Id == ShopId);

            if (mv == null)
            {
                return null;
            }

            _db.Shops.Remove(mv);

            return mv;
        }


        public async Task<Player?> BuyItem(Player player, Shop shop, Item item, PreloadPolicy preloadPolicy = PreloadPolicy.PreloadRelations)
        {

            var invsize = player.Inventory.Items.Count;

            if (invsize >= 3) 
            {
                return null;
            }

            if (item.Price > player.Money)
            {
                return null;
            }

            player.Money = player.Money - item.Price;
     
            player.Inventory.Items.Add(item);
            shop.Inventory.Items.Remove(item);
    
            return player;
        }

        public async Task<Shop?> CreateShop(string name, Inventory inventory)
        {

            if (name == "") return null;
           
            var Shop = new Shop { Id = Guid.NewGuid().ToString(), Name = name, InventoryId = inventory.Id, Inventory = inventory };
            await _db.Shops.AddAsync(Shop);
            return Shop;
        }

        public async Task<Shop?> UpdateShop(string ShopId, string name, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = await _db.Shops.FirstOrDefaultAsync(s => s.Id == ShopId);

            if (mv == null)
            {
                return null;
            }

            if (name != null) { mv.Name = name; }

            return mv;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}