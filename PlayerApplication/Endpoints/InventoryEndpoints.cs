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
    public static class InventoryEndpoints
    {

        public static void ConfigureInventoryEndpoints(this WebApplication app)
        {
            var gameGroup = app.MapGroup("inventories");

            gameGroup.MapGet("/", GetInventories);
            gameGroup.MapGet("/{Id}", GetInventory);
            gameGroup.MapPut("/{Id}", UpdateInventory);
            gameGroup.MapDelete("/{Id}", DeleteInventory);

        }

    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize()]
        public static async Task<IResult> GetInventories(IInventoryRepository repository)
        {

            var res = await repository.GetInventories();

            List<InventoryDTO> reslist = new List<InventoryDTO>();

            foreach (Inventory msg in res)
            {
                InventoryDTO dt = new InventoryDTO(msg);

                reslist.Add(dt);
            }

            return TypedResults.Ok(reslist);
        }


   

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Manager")]
        public static async Task<IResult> DeleteInventory(string playerId, IInventoryRepository repository, ClaimsPrincipal user)
        {

            Inventory? Inventory = await repository.DeleteInventory(playerId, PreloadPolicy.PreloadRelations);

            if (Inventory == null)
            {
                return Results.NotFound("Inventory not found");
            }

            var InventoryDTO = new InventoryDTO(Inventory);

            repository.SaveChanges();

            return TypedResults.Ok(InventoryDTO);
        }


        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> GetInventory(string invId, IInventoryRepository repository)
        {

            Inventory? Inventory = await repository.GetInventory(invId, PreloadPolicy.PreloadRelations);

            if (Inventory == null)
            {
                return Results.NotFound("Inventory not found");
            }

            var InventoryDTO = new InventoryDTO(Inventory);

            repository.SaveChanges();

            return TypedResults.Ok(InventoryDTO);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> UpdateInventory(string invId, InventoryUpdatePayload payload, IInventoryRepository repository, ClaimsPrincipal user)
        {


            var uid = user.UserId();
            string role = user.UserRole().ToString();
            var email = user.UserEmail();

            if (uid == null )
            {
                return Results.Unauthorized();
            }


            Inventory? ogInventory = await repository.GetInventory(invId, PreloadPolicy.PreloadRelations);

            if (ogInventory == null)
            {
                return Results.BadRequest("Inventory not found");
            }


            Inventory? Inventory = await repository.UpdateInventory(invId, PreloadPolicy.PreloadRelations);

            if (Inventory == null)
            {
                return Results.BadRequest("Failed to create Inventory.");
            }


            InventoryDTO mv = new InventoryDTO(Inventory);


            repository.SaveChanges();

            return TypedResults.Created($"/inventories{Inventory.Id}", mv);
        }

    }
}