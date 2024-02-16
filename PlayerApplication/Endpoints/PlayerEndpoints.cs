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
    public static class PlayerEndpoints
    {

        public static void ConfigurePlayerEndpoints(this WebApplication app)
        {
            var gameGroup = app.MapGroup("players");

            gameGroup.MapGet("/", GetPlayers);
            gameGroup.MapGet("/{Id}", GetPlayer);
            gameGroup.MapDelete("/{Id}", DeletePlayer);
            
        }

    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize()]
        public static async Task<IResult> GetPlayers(IPlayerRepository repository)
        {

            var res = await repository.GetPlayers();

            List<PlayerDTO> reslist = new List<PlayerDTO>();

            foreach (Player msg in res)
            {
                PlayerDTO dt = new PlayerDTO(msg);

                reslist.Add(dt);
            }

            return TypedResults.Ok(reslist);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Manager")]
        public static async Task<IResult> DeletePlayer(string playerId, IPlayerRepository repository, ClaimsPrincipal user)
        {

            Player? Player = await repository.DeletePlayer(playerId, PreloadPolicy.PreloadRelations);

            if (Player == null)
            {
                return Results.NotFound("Player not found");
            }

            var PlayerDTO = new PlayerDTO(Player);

            repository.SaveChanges();

            return TypedResults.Ok(PlayerDTO);
        }


        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> GetPlayer(string playerId, IPlayerRepository repository)
        {

            Player? Player = repository.GetPlayer(playerId, PreloadPolicy.PreloadRelations);

            if (Player == null)
            {
                return Results.NotFound("Player not found");
            }

            var PlayerDTO = new PlayerDTO(Player);

            repository.SaveChanges();

            return TypedResults.Ok(PlayerDTO);
        }

    }
}