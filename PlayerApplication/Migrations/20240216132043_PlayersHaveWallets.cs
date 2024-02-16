using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlayerApplication.Migrations
{
    /// <inheritdoc />
    public partial class PlayersHaveWallets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "22f0caf7-e36b-4b66-bb02-f72f86e34b7b");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "342d436b-0445-465d-b7af-f1f52fbd3c73");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "60f59f55-5aba-4535-8c59-026f1498e350");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "9a200cec-b53d-4120-91d6-e8e014a8f9bb");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "c3a101ce-30e9-41d6-9afa-9d78a8d49c99");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "ffc9a8f9-4b67-4a43-a161-70a89d169506");

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumns: new[] { "chat_id", "player_id" },
                keyValues: new object[] { "feb339e0-2b59-4bf8-9a9a-2a5a8746abc8", "b0afa3d2-2a85-4668-84fc-6234649a57b6" });

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumns: new[] { "chat_id", "player_id" },
                keyValues: new object[] { "feb339e0-2b59-4bf8-9a9a-2a5a8746abc8", "d775d10a-ab21-439e-8fb6-75506a5095e2" });

            migrationBuilder.DeleteData(
                table: "shops",
                keyColumn: "id",
                keyValue: "40d3db10-a79e-4119-9051-0488c270ba4b");

            migrationBuilder.DeleteData(
                table: "shops",
                keyColumn: "id",
                keyValue: "dc88c684-7494-42a8-8c75-53b5bd6a0016");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0afa3d2-2a85-4668-84fc-6234649a57b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d775d10a-ab21-439e-8fb6-75506a5095e2");

            migrationBuilder.DeleteData(
                table: "chat",
                keyColumn: "id",
                keyValue: "feb339e0-2b59-4bf8-9a9a-2a5a8746abc8");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "2f4dbcef-d865-4525-8233-26142f311aee");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "b100ae64-7302-4ac5-b389-3c13b1eeb76b");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "d2c21b88-3f84-4645-8e71-10b69c537bc5");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "f55b1758-bcec-4679-b11b-0158813a66a7");

            migrationBuilder.AddColumn<float>(
                name: "money",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "chat",
                columns: new[] { "id", "channel" },
                values: new object[] { "20301f3d-0c30-43d8-af58-607fc1680b09", "Global" });

            migrationBuilder.InsertData(
                table: "inventories",
                column: "id",
                values: new object[]
                {
                    "03671655-9f56-4966-bdda-559762aac41f",
                    "9210233a-a3b1-4f61-a18f-07f94c5525e1",
                    "9d3604b6-dbc2-4f66-941d-b163f6f98cf8",
                    "c566d097-7560-4a8f-b19b-d01c031857cf"
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "class", "ConcurrencyStamp", "Email", "EmailConfirmed", "exp", "hp", "inventory_id", "LockoutEnabled", "LockoutEnd", "money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "race", "role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1e6c048e-c80d-4b93-898a-9880e4880bcc", 0, 6, "b87c48f2-e1e6-4560-9678-acff6da00a82", "tyler1@gmail.com", false, 70, 150, "03671655-9f56-4966-bdda-559762aac41f", false, null, 50f, null, null, null, null, false, 0, 1, "b5f0b76d-5b79-4a72-a02d-b10ec6af6454", false, "Tyler1" },
                    { "b85fbdbc-cea6-47ce-9d0e-18cbe49d48de", 0, 1, "86539d50-abae-46cd-a4d3-aa19f14c580d", "juha88@gmail.com", false, 50, 100, "9d3604b6-dbc2-4f66-941d-b163f6f98cf8", false, null, 50f, null, null, null, null, false, 1, 1, "88754046-870e-445d-a043-944651165db6", false, "Juha88" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "description", "inventory_id", "name", "price" },
                values: new object[,]
                {
                    { "13a1bd68-9705-4724-bf31-c91fb35fc3fb", "Heals 20 hp", "9210233a-a3b1-4f61-a18f-07f94c5525e1", "Large Healing Potion", 10f },
                    { "147016b1-c866-4776-8bf4-a499d31ef4db", "Heals 5 hp", "9210233a-a3b1-4f61-a18f-07f94c5525e1", "Small Healing Potion", 2.5f },
                    { "689bee58-bb77-4983-ac94-641f275e4b7c", "Deals 3 fire damage", "c566d097-7560-4a8f-b19b-d01c031857cf", "Magic staff", 60f },
                    { "8bfbc896-0066-4c15-85ed-377840b49d81", "Heals 20 hp", "03671655-9f56-4966-bdda-559762aac41f", "Large Healing Potion", 10f },
                    { "96fd0f06-a8d2-469c-b634-aa90616a9780", "Deals 5 damage", "c566d097-7560-4a8f-b19b-d01c031857cf", "Two handed sword", 50f },
                    { "b9a6ed1a-b68f-4778-8603-1fdeee6e52c0", "Heals 5 hp", "9d3604b6-dbc2-4f66-941d-b163f6f98cf8", "Small Healing Potion", 2.5f }
                });

            migrationBuilder.InsertData(
                table: "shops",
                columns: new[] { "id", "inventory_id", "name" },
                values: new object[,]
                {
                    { "41776c73-bb90-4c25-83b1-4e954366364b", "c566d097-7560-4a8f-b19b-d01c031857cf", "Weapons Shop" },
                    { "dcb5b575-7473-48d5-9da5-66aa1537f2fa", "9210233a-a3b1-4f61-a18f-07f94c5525e1", "Potion Dealer" }
                });

            migrationBuilder.InsertData(
                table: "messages",
                columns: new[] { "chat_id", "player_id", "post_date", "text" },
                values: new object[,]
                {
                    { "20301f3d-0c30-43d8-af58-607fc1680b09", "1e6c048e-c80d-4b93-898a-9880e4880bcc", new DateTime(2024, 2, 16, 13, 20, 42, 518, DateTimeKind.Utc).AddTicks(3809), "Hi new user!" },
                    { "20301f3d-0c30-43d8-af58-607fc1680b09", "b85fbdbc-cea6-47ce-9d0e-18cbe49d48de", new DateTime(2024, 2, 16, 13, 20, 42, 518, DateTimeKind.Utc).AddTicks(3710), "Hi yall!" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "13a1bd68-9705-4724-bf31-c91fb35fc3fb");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "147016b1-c866-4776-8bf4-a499d31ef4db");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "689bee58-bb77-4983-ac94-641f275e4b7c");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "8bfbc896-0066-4c15-85ed-377840b49d81");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "96fd0f06-a8d2-469c-b634-aa90616a9780");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "b9a6ed1a-b68f-4778-8603-1fdeee6e52c0");

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumns: new[] { "chat_id", "player_id" },
                keyValues: new object[] { "20301f3d-0c30-43d8-af58-607fc1680b09", "1e6c048e-c80d-4b93-898a-9880e4880bcc" });

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumns: new[] { "chat_id", "player_id" },
                keyValues: new object[] { "20301f3d-0c30-43d8-af58-607fc1680b09", "b85fbdbc-cea6-47ce-9d0e-18cbe49d48de" });

            migrationBuilder.DeleteData(
                table: "shops",
                keyColumn: "id",
                keyValue: "41776c73-bb90-4c25-83b1-4e954366364b");

            migrationBuilder.DeleteData(
                table: "shops",
                keyColumn: "id",
                keyValue: "dcb5b575-7473-48d5-9da5-66aa1537f2fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e6c048e-c80d-4b93-898a-9880e4880bcc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b85fbdbc-cea6-47ce-9d0e-18cbe49d48de");

            migrationBuilder.DeleteData(
                table: "chat",
                keyColumn: "id",
                keyValue: "20301f3d-0c30-43d8-af58-607fc1680b09");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "9210233a-a3b1-4f61-a18f-07f94c5525e1");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "c566d097-7560-4a8f-b19b-d01c031857cf");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "03671655-9f56-4966-bdda-559762aac41f");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "9d3604b6-dbc2-4f66-941d-b163f6f98cf8");

            migrationBuilder.DropColumn(
                name: "money",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "chat",
                columns: new[] { "id", "channel" },
                values: new object[] { "feb339e0-2b59-4bf8-9a9a-2a5a8746abc8", "Global" });

            migrationBuilder.InsertData(
                table: "inventories",
                column: "id",
                values: new object[]
                {
                    "2f4dbcef-d865-4525-8233-26142f311aee",
                    "b100ae64-7302-4ac5-b389-3c13b1eeb76b",
                    "d2c21b88-3f84-4645-8e71-10b69c537bc5",
                    "f55b1758-bcec-4679-b11b-0158813a66a7"
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "class", "ConcurrencyStamp", "Email", "EmailConfirmed", "exp", "hp", "inventory_id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "race", "role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b0afa3d2-2a85-4668-84fc-6234649a57b6", 0, 6, "1257a416-0d5a-4b46-a85b-a31cc2d5f628", "tyler1@gmail.com", false, 70, 150, "d2c21b88-3f84-4645-8e71-10b69c537bc5", false, null, null, null, null, null, false, 0, 1, "c4a9f5b7-9749-4950-bdf6-cc25d97f6152", false, "Tyler1" },
                    { "d775d10a-ab21-439e-8fb6-75506a5095e2", 0, 1, "6d662e7a-3fcb-4833-890c-3c82fcb3d6f6", "juha88@gmail.com", false, 50, 100, "f55b1758-bcec-4679-b11b-0158813a66a7", false, null, null, null, null, null, false, 1, 1, "8c9a6f47-3b62-4180-9e57-01d12398bfd7", false, "Juha88" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "description", "inventory_id", "name", "price" },
                values: new object[,]
                {
                    { "22f0caf7-e36b-4b66-bb02-f72f86e34b7b", "Heals 5 hp", "b100ae64-7302-4ac5-b389-3c13b1eeb76b", "Small Healing Potion", 2.5f },
                    { "342d436b-0445-465d-b7af-f1f52fbd3c73", "Heals 20 hp", "b100ae64-7302-4ac5-b389-3c13b1eeb76b", "Large Healing Potion", 10f },
                    { "60f59f55-5aba-4535-8c59-026f1498e350", "Heals 5 hp", "f55b1758-bcec-4679-b11b-0158813a66a7", "Small Healing Potion", 2.5f },
                    { "9a200cec-b53d-4120-91d6-e8e014a8f9bb", "Heals 20 hp", "d2c21b88-3f84-4645-8e71-10b69c537bc5", "Large Healing Potion", 10f },
                    { "c3a101ce-30e9-41d6-9afa-9d78a8d49c99", "Deals 3 fire damage", "2f4dbcef-d865-4525-8233-26142f311aee", "Magic staff", 60f },
                    { "ffc9a8f9-4b67-4a43-a161-70a89d169506", "Deals 5 damage", "2f4dbcef-d865-4525-8233-26142f311aee", "Two handed sword", 50f }
                });

            migrationBuilder.InsertData(
                table: "shops",
                columns: new[] { "id", "inventory_id", "name" },
                values: new object[,]
                {
                    { "40d3db10-a79e-4119-9051-0488c270ba4b", "2f4dbcef-d865-4525-8233-26142f311aee", "Weapons Shop" },
                    { "dc88c684-7494-42a8-8c75-53b5bd6a0016", "b100ae64-7302-4ac5-b389-3c13b1eeb76b", "Potion Dealer" }
                });

            migrationBuilder.InsertData(
                table: "messages",
                columns: new[] { "chat_id", "player_id", "post_date", "text" },
                values: new object[,]
                {
                    { "feb339e0-2b59-4bf8-9a9a-2a5a8746abc8", "b0afa3d2-2a85-4668-84fc-6234649a57b6", new DateTime(2024, 2, 14, 20, 4, 46, 556, DateTimeKind.Utc).AddTicks(4812), "Hi new user!" },
                    { "feb339e0-2b59-4bf8-9a9a-2a5a8746abc8", "d775d10a-ab21-439e-8fb6-75506a5095e2", new DateTime(2024, 2, 14, 20, 4, 46, 556, DateTimeKind.Utc).AddTicks(4711), "Hi yall!" }
                });
        }
    }
}
