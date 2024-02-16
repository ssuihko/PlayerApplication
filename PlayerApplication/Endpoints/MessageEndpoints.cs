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
    public static class MessageEndpoints
    {

        public static void ConfigureMessageEndpoints(this WebApplication app)
        {
            var gameGroup = app.MapGroup("messages");

            gameGroup.MapPost("/", CreateMessage);
            gameGroup.MapGet("/", GetMessages);
            gameGroup.MapGet("/chat/{chatId}/player/{playerId}", GetMessage);
            gameGroup.MapPut("/chat/{chatId}/player/{playerId}", UpdateMessage);
            gameGroup.MapDelete("/chat/{chatId}/player/{playerId}", DeleteMessage);

        }

    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize()]
        public static async Task<IResult> GetMessages(IMessageRepository repository)
        {

            var res = await repository.GetMessages();

            List<MessageDTO> reslist = new List<MessageDTO>();

            foreach (Message msg in res)
            {
                MessageDTO dt = new MessageDTO(msg);

                reslist.Add(dt);
            }

            return TypedResults.Ok(reslist);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> CreateMessage(MessagePostPayload payload, 
            IMessageRepository MessageRepository, IPlayerRepository playerRepository, IChatRepository chatRep, ClaimsPrincipal user)
        {
            var uid = user.UserId();
            string role = user.UserRole().ToString();
            var email = user.UserEmail();

            var ch = await chatRep.GetChat(payload.ChatId);
            var usr = playerRepository.GetPlayerByEmail(email);

            if (uid == null || ch == null || usr == null)
            {
                return Results.Unauthorized();
            }
            
            if (payload.Text == "" || payload.ChatId == "" )
            {
                return Results.BadRequest("Non-empty fields are required");
            }

            if (payload.Text == null || payload.ChatId == null )
            {
                return Results.BadRequest("Non-null fields are required");
            }

            Message? Message = await MessageRepository.CreateMessage(usr.Id, ch.Id, payload.Text);

            if (Message == null)
            {
                return Results.BadRequest("Failed to create Message.");
            }

          
            MessageRepository.SaveChanges();

            MessageDTO mdto = new MessageDTO(Message);

            return TypedResults.Created($"/chat/{Message.ChatId}/players/{Message.PlayerId}", mdto);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> DeleteMessage(string playerId, string chatId, IMessageRepository repository, ClaimsPrincipal user)
        {

            Message? Message = await repository.DeleteMessage(playerId, chatId, PreloadPolicy.PreloadRelations);

            if (Message == null)
            {
                return Results.NotFound("Message not found");
            }

            var MessageDTO = new MessageDTO(Message);

            repository.SaveChanges();

            return TypedResults.Ok(MessageDTO);
        }


        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> GetMessage(string playerId, string chatId, IMessageRepository repository)
        {

            Message? Message = await repository.GetMessage(playerId, chatId, PreloadPolicy.PreloadRelations);

            if (Message == null)
            {
                return Results.NotFound("Message not found");
            }

            var MessageDTO = new MessageDTO(Message);

            repository.SaveChanges();

            return TypedResults.Ok(MessageDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public static async Task<IResult> UpdateMessage(string playerId, string chatId, MessageUpdatePayload payload, IMessageRepository repository, ClaimsPrincipal user)
        {


            // nothing to update
            if (payload.Text == "")
            {
                return Results.BadRequest("Non-empty fields are required");
            }

            if (payload.Text == null)
            {
                return Results.BadRequest("Non-null fields are required");
            }


            Message? ogMessage = await repository.GetMessage(playerId, chatId, PreloadPolicy.PreloadRelations);

            if (ogMessage == null)
            {
                return Results.BadRequest("Message not found");
            }

            string newText = (payload.Text.Length > 0) ? payload.Text : ogMessage.Text;

            Message? Message = await repository.UpdateMessage(ogMessage.PlayerId, ogMessage.ChatId, newText);

            if (Message == null)
            {
                return Results.BadRequest("Failed to create Message.");
            }


            MessageDTO mv = new MessageDTO(Message);


            repository.SaveChanges();

            return TypedResults.Created($"/chat/{Message.ChatId}/players/{Message.PlayerId}", mv);
        }

    }
}