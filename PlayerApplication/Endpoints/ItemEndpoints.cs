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
    public static class ItemEndpoints
    {

        public static void ConfigureItemEndpoints(this WebApplication app)
        {
            var gameGroup = app.MapGroup("items");

            gameGroup.MapPost("/", CreateItem);
            gameGroup.MapGet("/inventory/{invId}", GetItemsFromInventory);
            gameGroup.MapGet("/", GetAllItems);
            gameGroup.MapGet("/{Id}", GetItem);
            gameGroup.MapPut("/{Id}", UpdateItem);
            gameGroup.MapDelete("/{Id}", DeleteItem);

        }

    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize()]
        public static async Task<IResult> GetItemsFromInventory(string invId, IItemRepository repository)
        {

            var res = await repository.GetItems(invId);

            List<ItemDTO> reslist = new List<ItemDTO>();

            foreach (Item msg in res)
            {
                ItemDTO dt = new ItemDTO(msg);

                reslist.Add(dt);
            }

            return TypedResults.Ok(reslist);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Admin")]
        public static async Task<IResult> GetAllItems(IItemRepository repository)
        {

            var res = await repository.GetAllItems();

            List<ItemDTO> reslist = new List<ItemDTO>();

            foreach (Item msg in res)
            {
                ItemDTO dt = new ItemDTO(msg);

                reslist.Add(dt);
            }

            return TypedResults.Ok(reslist);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public static async Task<IResult> CreateItem(string shopId, ItemPostPayload payload, 
            IItemRepository ItemRepository, IShopRepository shopRep, ClaimsPrincipal user)
        {
            var uid = user.UserId();
            string role = user.UserRole().ToString();
            var email = user.UserEmail();


            if (uid == null )
            {
                return Results.Unauthorized();
            }

            
            if (payload.Name == "" || payload.Description == "" || payload.Price <= 0.0F )
            {
                return Results.BadRequest("Non-empty fields are required");
            }

            if (payload.Name == null || payload.Description == null || payload.Price == null )
            {
                return Results.BadRequest("Non-null fields are required");
            }

            var inv = await shopRep.GetShopInventory(shopId, PreloadPolicy.PreloadRelations);
            if (inv == null) return Results.NotFound("Shop not found");

            Item? Item = await ItemRepository.CreateItem(payload.Name, payload.Description, payload.Price, inv.Inventory );

            if (Item == null)
            {
                return Results.BadRequest("Failed to create Item.");
            }

            inv.Inventory.Items.Add(Item);

            ItemRepository.SaveChanges();
            shopRep.SaveChanges();

            ItemDTO mdto = new ItemDTO(Item);

            return TypedResults.Created($"/{Item.Id}", mdto);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Manager")]
        public static async Task<IResult> DeleteItem(string itemId, IItemRepository repository, ClaimsPrincipal user)
        {

            Item? Item = await repository.DeleteItem(itemId, PreloadPolicy.PreloadRelations);

            if (Item == null)
            {
                return Results.NotFound("Item not found");
            }

            var ItemDTO = new ItemDTO(Item);

            repository.SaveChanges();

            return TypedResults.Ok(ItemDTO);
        }


        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> GetItem(string itemId, IItemRepository repository)
        {

            Item? Item = await repository.GetItem(itemId, PreloadPolicy.PreloadRelations);

            if (Item == null)
            {
                return Results.NotFound("Item not found");
            }

            var ItemDTO = new ItemDTO(Item);

            repository.SaveChanges();

            return TypedResults.Ok(ItemDTO);
        }




        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> UpdateItem(string itemId, ItemUpdatePayload payload, IItemRepository repository, ClaimsPrincipal user)
        {


            // nothing to update
            if (payload.Name == "" ||payload.Description == "" || payload.Price <= 0.0F)
            {
                return Results.BadRequest("Non-empty fields are required");
            }

            if (payload.Name == null || payload.Description == null ||payload.Price == null)
            {
                return Results.BadRequest("Non-null fields are required");
            }


            Item? ogItem = await repository.GetItem(itemId, PreloadPolicy.PreloadRelations);

            if (ogItem == null)
            {
                return Results.BadRequest("Item not found");
            }

            string newName = (payload.Name.Length > 0) ? payload.Name : ogItem.Name;
            string newDescription = (payload.Description.Length > 0) ? payload.Description : ogItem.Description;
            float newPrice = (payload.Price >= 0.0F) ? (float)payload.Price : (float)ogItem.Price;

            Item? Item = await repository.UpdateItem(itemId, newName, newDescription, newPrice);

            if (Item == null)
            {
                return Results.BadRequest("Failed to create Item.");
            }


            ItemDTO mv = new ItemDTO(Item);


            repository.SaveChanges();

            return TypedResults.Created($"/items{Item.Id}", mv);
        }

    }
}