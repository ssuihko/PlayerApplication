﻿using PlayerApplication.Data;
using PlayerApplication.Models;
using PlayerApplication.Enums;
using Microsoft.EntityFrameworkCore;

namespace PlayerApplication.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private DatabaseContext _db;

        public PlayerRepository(DatabaseContext db)
        {
            _db = db;
        }

        public Player? GetPlayer(string id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {

            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return _db.Players.Include(x => x.Inventory).ThenInclude(y => y.Items).FirstOrDefault(s => s.Id == id);
                case PreloadPolicy.DoNotPreloadRelations:
                    return _db.Players.FirstOrDefault(s => s.Id == id);
                default:
                    return null;
            }
        }

        public Player? GetPlayerInventory(string email, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
             return _db.Players.Include(x => x.Inventory).ThenInclude(y => y.Items).FirstOrDefault(s => s.Email == email);      
        }

        public Player? GetPlayerByEmail(string email)
        {
            return _db.Players.FirstOrDefault(s => s.Email == email);   
        }


        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _db.Players.Include(x => x.Inventory).ThenInclude(y => y.Items).ToListAsync();
        }


        public async Task<Player?> DeletePlayer(string PlayerId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = _db.Players.FirstOrDefault(s => s.Id == PlayerId);

            if (mv == null)
            {
                return null;
            }

            _db.Players.Remove(mv);

            return mv;
        }


        public async Task<Player?> UpdatePlayer(string PlayerId, string name, string email, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            var mv = _db.Players.FirstOrDefault(s => s.Id == PlayerId);

            if (mv == null)
            {
                return null;
            }

            if (name != null) { mv.UserName = name; }

            if (email != null) { mv.Email = email; }

            return mv;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
