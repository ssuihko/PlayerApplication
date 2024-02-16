using Microsoft.AspNetCore.Mvc;
using PlayerApplication.Repository;
using PlayerApplication.Models;
using PlayerApplication.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IO.Pipes;
using System.Globalization;
using System.Net.Sockets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
using PlayerApplication.Enums;
using System.Security.Claims;
using PlayerApplication.Utils;

namespace PlayerApplication.Endpoints
{
    public static class ShopEndpoints
    {

        public static void ConfigureShopEndpoints(this WebApplication app)
        {
            var gameGroup = app.MapGroup("shops");

            gameGroup.MapPost("/", CreateShop);
            gameGroup.MapGet("/", GetShops);
            gameGroup.MapGet("/{Id}", GetShop);
            gameGroup.MapPut("/{Id}", UpdateShop);
            gameGroup.MapDelete("/{Id}", DeleteShop);
            gameGroup.MapGet("/{shopId}/item/{itemId}", BuyItem);

        }

    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize()]
        public static async Task<IResult> GetShops(IShopRepository repository)
        {

            var res = await repository.GetShops();

            List<ShopDTO> reslist = new List<ShopDTO>();

            foreach (Shop msg in res)
            {
                ShopDTO dt = new ShopDTO(msg);

                reslist.Add(dt);
            }

            return TypedResults.Ok(reslist);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Manager")]
        public static async Task<IResult> CreateShop(ShopPostPayload payload, 
            IShopRepository ShopRepository, IPlayerRepository playerRepository,  ClaimsPrincipal user)
        {
  
            var uid = user.UserId();

            if (uid == null )
            {
                return Results.Unauthorized();
            }

            
            if (payload.Name == "" )
            {
                return Results.BadRequest("Non-empty fields are required");
            }

            if (payload.Name == null)
            {
                return Results.BadRequest("Non-null fields are required");
            }

            Inventory inv = new Inventory {Id = Guid.NewGuid().ToString()};

            Shop? Shop = await ShopRepository.CreateShop(payload.Name, inv);

            if (Shop == null)
            {
                return Results.BadRequest("Failed to create Shop.");
            }

          
            ShopRepository.SaveChanges();

            ShopDTO mdto = new ShopDTO(Shop);

            return TypedResults.Created($"/{Shop.Id}", mdto);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Manager")]
        public static async Task<IResult> DeleteShop(string shopId, IShopRepository repository, ClaimsPrincipal user)
        {

            Shop? Shop = await repository.DeleteShop(shopId, PreloadPolicy.PreloadRelations);

            if (Shop == null)
            {
                return Results.NotFound("Shop not found");
            }

            var ShopDTO = new ShopDTO(Shop);

            repository.SaveChanges();

            return TypedResults.Ok(ShopDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> BuyItem(string shopId, string itemId, IItemRepository itemrep,
            IPlayerRepository playerRepository, IShopRepository repository, IInventoryRepository invrep, ClaimsPrincipal user)
        {

            var em = user.UserEmail();
            var pla = playerRepository.GetPlayerInventory(em);
            var shop = await repository.GetShopInventory(shopId, PreloadPolicy.PreloadRelations);
            var item = await itemrep.GetItem(itemId);


            if (pla == null || shop == null || item == null)
            {
                return Results.BadRequest("player, shop or item not found");
            }

            Player? pl = await repository.BuyItem(pla, shop, item);

            if (pl == null)
            {
                return Results.NotFound("Your inventory is full");
            }

            var PlayerDTO = new PlayerDTO(pl);

            repository.SaveChanges();
            playerRepository.SaveChanges();

            return TypedResults.Ok(PlayerDTO);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Manager")]
        public static async Task<IResult> GetShop(string shopId, IShopRepository repository)
        {

            Shop? Shop = await repository.GetShop(shopId, PreloadPolicy.PreloadRelations);

            if (Shop == null)
            {
                return Results.NotFound("Shop not found");
            }

            var ShopDTO = new ShopDTO(Shop);

            repository.SaveChanges();

            return TypedResults.Ok(ShopDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> UpdateShop(string shopId, ShopUpdatePayload payload, IShopRepository repository, ClaimsPrincipal user)
        {


            // nothing to update
            if (payload.Name == "")
            {
                return Results.BadRequest("Non-empty fields are required");
            }

            if (payload.Name == null)
            {
                return Results.BadRequest("Non-null fields are required");
            }


            Shop? ogShop = await repository.GetShop(shopId, PreloadPolicy.PreloadRelations);

            if (ogShop == null)
            {
                return Results.BadRequest("Shop not found");
            }

            string newName = (payload.Name.Length > 0) ? payload.Name : ogShop.Name;

            Shop? Shop = await repository.UpdateShop(shopId, newName, PreloadPolicy.PreloadRelations);

            if (Shop == null)
            {
                return Results.BadRequest("Failed to create Shop.");
            }


            ShopDTO mv = new ShopDTO(Shop);


            repository.SaveChanges();

            return TypedResults.Created($"/{Shop.Id}", mv);
        }

    }
}