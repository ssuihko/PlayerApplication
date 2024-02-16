using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayerApplication.DTOs;
using PlayerApplication.Services;
using PlayerApplication.Enums;
using PlayerApplication.Repository;
using PlayerApplication.Models;
using PlayerApplication.Utils;
using PlayerApplication.Enums;
using PlayerApplication.Services;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayerApplication.Endpoints
{
    public static class AuthEndpoints
    {
        public static void ConfigureAuthEndpoints(this WebApplication app)
        {
            var taskGroup = app.MapGroup("auth");
            taskGroup.MapPost("/register", Register);
            taskGroup.MapPost("/registeradmin", RegisterAdmin);
            taskGroup.MapPost("/login", Login);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> Register(
          RegisterDto registerPayload,
          UserManager<Player> userManager)
        {
            if (registerPayload.Email == null) return TypedResults.BadRequest("Email is required.");
            if (registerPayload.Password == null) return TypedResults.BadRequest("Password is required.");

            string newID = Guid.NewGuid().ToString();

            Inventory inv = new Inventory { Id = Guid.NewGuid().ToString() };

            if(!Enum.IsDefined(typeof(UserClass), registerPayload.Class) || !Enum.IsDefined(typeof(UserRace), registerPayload.Race))
            {
                return TypedResults.BadRequest("Class or race entered does not exist.");
            }

            var result = await userManager.CreateAsync(

         
                new Player { Id = newID, UserName = registerPayload.Email, Email = registerPayload.Email, Role = UserRole.Player,
                    Class = Enum.Parse<UserClass>(registerPayload.Class), Race = Enum.Parse<UserRace>(registerPayload.Race), Exp = 1, Hp = 10, Money=50.0F, InventoryId = inv.Id, Inventory = inv},

              registerPayload.Password!
            ); 

            if (result.Succeeded)
            {
                return TypedResults.Created($"/auth/", new { email = registerPayload.Email, role = UserRole.Player });
            }
            return Results.BadRequest(result.Errors);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> RegisterAdmin(
            RegisterAdminDto registerPayload,
            UserManager<Player> userManager)
        {
            if (registerPayload.Email == null) return TypedResults.BadRequest("Email is required.");
            if (registerPayload.Password == null) return TypedResults.BadRequest("Password is required.");

            string newID = Guid.NewGuid().ToString();

            Inventory inv = new Inventory { Id = Guid.NewGuid().ToString() };

            var result = await userManager.CreateAsync(

                new Player
                {
                    Id = newID,
                    UserName = registerPayload.Email,
                    Email = registerPayload.Email,
                    Role = UserRole.Admin,
                    Class = UserClass.Mage,
                    Race = UserRace.Human,
                    Exp = 100,
                    Hp = 100,
                    Money=50.0F,
                    InventoryId = inv.Id,
                    Inventory = inv
                },

              registerPayload.Password!
            );

            if (result.Succeeded)
            {
                return TypedResults.Created($"/auth/", new { email = registerPayload.Email, role = UserRole.Admin });
            }
            return Results.BadRequest(result.Errors);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> Login(
          LoginDto loginPayload,
          UserManager<Player> userManager,
          TokenService tokenService,
          IPlayerRepository repository)
        {
            if (loginPayload.Email == null) return TypedResults.BadRequest("Email is required.");
            if (loginPayload.Password == null) return TypedResults.BadRequest("Password is required.");

            var user = await userManager.FindByEmailAsync(loginPayload.Email!);
            if (user == null)
            {
                return TypedResults.BadRequest("Invalid email or password.");
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(user, loginPayload.Password);
            if (!isPasswordValid)
            {
                return TypedResults.BadRequest("Invalid email or password.");
            }

            var userInDb = repository.GetPlayerByEmail(loginPayload.Email);

            if (userInDb is null)
            {
                return Results.Unauthorized();
            }

            var accessToken = tokenService.CreateToken(userInDb);
            return TypedResults.Ok(new AuthResponseDto(accessToken, userInDb.Email, userInDb.Role));
        }

    }
}