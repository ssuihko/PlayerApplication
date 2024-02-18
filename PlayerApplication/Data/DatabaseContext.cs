using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PlayerApplication.Models;
using PlayerApplication.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace PlayerApplication.Data
{
    public class DatabaseContext : IdentityUserContext<Player>
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>().HasMany(e => e.Messages).WithOne(e => e.Player).HasForeignKey(e => e.PlayerId);
            modelBuilder.Entity<Chat>().HasMany(e => e.Messages).WithOne(e => e.Chat).HasForeignKey(e => e.ChatId);
            modelBuilder.Entity<Message>().HasKey(e => new { e.PlayerId, e.ChatId });


            // items
            string wi = Guid.NewGuid().ToString();
            string g1 = Guid.NewGuid().ToString();
            string g2 = Guid.NewGuid().ToString();
            string pli1 = Guid.NewGuid().ToString();
            string pli2 = Guid.NewGuid().ToString();

            Item wit1 = new Item { Id = Guid.NewGuid().ToString(), InventoryId = wi, Name = "Green herb", Description = "Heals 3 hp", Price = 2.5F };


            Item it1 = new Item { Id = Guid.NewGuid().ToString(), InventoryId = g1,  Name = "Small Healing Potion", Description = "Heals 5 hp", Price = 2.5F };
            Item it2 = new Item { Id = Guid.NewGuid().ToString(), InventoryId = g1, Name = "Large Healing Potion", Description = "Heals 20 hp", Price = 10.0F };
            Item it3 = new Item { Id = Guid.NewGuid().ToString(), InventoryId= g2, Name = "Two handed sword", Description = "Deals 5 damage", Price = 50.0F };
            Item it4 = new Item { Id = Guid.NewGuid().ToString(), InventoryId = g2, Name = "Magic staff", Description = "Deals 3 fire damage", Price = 60.0F };

            Item it5 = new Item { Id = Guid.NewGuid().ToString(), InventoryId = pli1, Name = "Small Healing Potion", Description = "Heals 5 hp", Price = 2.5F };
            Item it6 = new Item { Id = Guid.NewGuid().ToString(), InventoryId = pli2, Name = "Large Healing Potion", Description = "Heals 20 hp", Price = 10.0F };

            modelBuilder.Entity<Item>().HasData( wit1, it1, it2, it3, it4, it5, it6 );

            // inventories
            Inventory worldinv = new Inventory { Id = wi };
            Inventory inv1 = new Inventory { Id = g1 };
            Inventory inv2 = new Inventory { Id = g2 };
            Inventory pl1inv = new Inventory { Id = pli1 };
            Inventory pl2inv = new Inventory { Id = pli2 };

            modelBuilder.Entity<Inventory>().HasData(inv1, inv2, pl1inv, pl2inv, worldinv);


            // shops
            modelBuilder.Entity<Shop>().HasData(
                new Shop { Id = Guid.NewGuid().ToString(), Name = "Potion Dealer", InventoryId = g1 },
                new Shop { Id = Guid.NewGuid().ToString(), Name = "Weapons Shop", InventoryId = g2 }
                );

            string ch1 = Guid.NewGuid().ToString();

            // players
            string p3 = Guid.NewGuid().ToString();
            string p4 = Guid.NewGuid().ToString();

            // messages
            Message msg1 = new Message { PlayerId = p3, ChatId = ch1, Text = "Hi yall!", PostDate = DateTime.Now.ToUniversalTime() };
            Message msg2 = new Message { PlayerId = p4, ChatId = ch1, Text = "Hi new user!", PostDate = DateTime.Now.ToUniversalTime() };

            modelBuilder.Entity<Message>().HasData( msg1, msg2 );

            // chats
            modelBuilder.Entity<Chat>().HasData(
                new Chat { Id = ch1, Channel = "Global" }
                );

            // players
            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = p3,
                    UserName = "Juha88",
                    Email = "juha88@gmail.com",
                    Class = UserClass.Cleric,
                    Exp = 50,
                    Hp = 100,
                    Money=50.0F,
                    Race = UserRace.Dwarf,
                    Role = UserRole.Player,
                    InventoryId = pli1
                },
                new Player
                {
                    Id = p4,
                    UserName = "Tyler1",
                    Email = "tyler1@gmail.com",
                    Class = UserClass.Barbarian,
                    Exp = 70,
                    Hp = 150,          
                    Money=50.0F,
                    Race = UserRace.Human,
                    Role = UserRole.Player,
                    InventoryId = pli2
                }

                );


        }


    }
}