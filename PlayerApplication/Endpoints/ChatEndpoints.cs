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
    public static class ChatEndpoints
    {

        public static void ConfigureChatEndpoints(this WebApplication app)
        {
            var gameGroup = app.MapGroup("chats");

            gameGroup.MapPost("/", CreateChat);
            gameGroup.MapGet("/", GetChats);
            gameGroup.MapGet("/chat/{chatId}/player/{playerId}", GetChat);
            gameGroup.MapDelete("/chat/{chatId}/player/{playerId}", DeleteChat);

        }

    
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetChats(IChatRepository repository)
        {

            var res = await repository.GetChats();

            List<ChatDTO> reslist = new List<ChatDTO>();

            foreach (Chat msg in res)
            {
                ChatDTO dt = new ChatDTO(msg);

                reslist.Add(dt);
            }

            return TypedResults.Ok(reslist);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> CreateChat(ChatPostPayload payload,
            IChatRepository ChatRepository, IPlayerRepository playerRepository, IChatRepository chatRep)
        {

            if (payload.Channel == "" ||payload.Channel == null)
            {
                return Results.BadRequest("Proper field values required");
            }
    
            Chat? Chat = await ChatRepository.CreateChat(payload.Channel);

            if (Chat == null)
            {
                return Results.BadRequest("Failed to create chat.");
            }

          
            ChatRepository.SaveChanges();

            ChatDTO mdto = new ChatDTO(Chat);

            return TypedResults.Created($"/chat{Chat.Id}", mdto);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Manager")]
        public static async Task<IResult> DeleteChat(string chatId, IChatRepository repository, ClaimsPrincipal user)
        {

            Chat? Chat = await repository.DeleteChat(chatId, PreloadPolicy.PreloadRelations);

            if (Chat == null)
            {
                return Results.NotFound("Chat not found");
            }

            var ChatDTO = new ChatDTO(Chat);

            repository.SaveChanges();

            return TypedResults.Ok(ChatDTO);
        }


        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> GetChat(string chatId, IChatRepository repository)
        {

            Chat? Chat = await repository.GetChat(chatId, PreloadPolicy.PreloadRelations);

            if (Chat == null)
            {
                return Results.NotFound("Chat not found");
            }

            var ChatDTO = new ChatDTO(Chat);

            repository.SaveChanges();

            return TypedResults.Ok(ChatDTO);
        }

    }
}