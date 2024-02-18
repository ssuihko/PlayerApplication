using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlayerApplication.Migrations
{
    /// <inheritdoc />
    public partial class createWorldInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "chat",
                columns: new[] { "id", "channel" },
                values: new object[] { "7eab79c3-0e32-441b-92c9-85b1068c8ee7", "Global" });

            migrationBuilder.InsertData(
                table: "inventories",
                column: "id",
                values: new object[]
                {
                    "00dfbbf1-b1bc-4f52-be8a-c23dbb628108",
                    "0363f4bb-1733-4305-bfc7-9193ef6cd9b9",
                    "6ff04a16-8061-471f-85fb-19156ec97482",
                    "dde1b9da-9fa5-469f-96d8-71fc0ae9658c",
                    "e8c7fb0d-f1f5-46c0-85c8-10639ea4ca9a"
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "class", "ConcurrencyStamp", "Email", "EmailConfirmed", "exp", "hp", "inventory_id", "LockoutEnabled", "LockoutEnd", "money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "race", "role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9886e82e-0b2d-4d78-a061-b8d4694a08fa", 0, 1, "8480d081-a808-449d-99b6-523eb617c773", "juha88@gmail.com", false, 50, 100, "dde1b9da-9fa5-469f-96d8-71fc0ae9658c", false, null, 50f, null, null, null, null, false, 1, 1, "aceca4ab-727e-450a-ac98-d82f3601bc76", false, "Juha88" },
                    { "b3c47842-36f7-40fb-a3c1-c058df671094", 0, 6, "60db261d-f99f-427b-ac71-c6e88282aaa0", "tyler1@gmail.com", false, 70, 150, "6ff04a16-8061-471f-85fb-19156ec97482", false, null, 50f, null, null, null, null, false, 0, 1, "374eeb6b-0360-499c-bdb3-f46d43c86b03", false, "Tyler1" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "description", "inventory_id", "name", "price" },
                values: new object[,]
                {
                    { "10d68a72-2be7-437e-a27a-585a8418f5c1", "Deals 5 damage", "e8c7fb0d-f1f5-46c0-85c8-10639ea4ca9a", "Two handed sword", 50f },
                    { "64fb6fd3-731a-485f-842d-36cc3fdde11a", "Heals 5 hp", "0363f4bb-1733-4305-bfc7-9193ef6cd9b9", "Small Healing Potion", 2.5f },
                    { "9f0aa512-c858-439c-b366-15ea99a9bf37", "Heals 3 hp", "00dfbbf1-b1bc-4f52-be8a-c23dbb628108", "Green herb", 2.5f },
                    { "cdbb4d1e-cffb-4530-adac-2b003676155f", "Deals 3 fire damage", "e8c7fb0d-f1f5-46c0-85c8-10639ea4ca9a", "Magic staff", 60f },
                    { "d1581178-0477-4e13-8336-bd721689ecda", "Heals 20 hp", "6ff04a16-8061-471f-85fb-19156ec97482", "Large Healing Potion", 10f },
                    { "da704cfa-db21-4aeb-848c-0f6d17f55549", "Heals 5 hp", "dde1b9da-9fa5-469f-96d8-71fc0ae9658c", "Small Healing Potion", 2.5f },
                    { "e0f44726-878c-4a10-aac9-731bc51353a3", "Heals 20 hp", "0363f4bb-1733-4305-bfc7-9193ef6cd9b9", "Large Healing Potion", 10f }
                });

            migrationBuilder.InsertData(
                table: "shops",
                columns: new[] { "id", "inventory_id", "name" },
                values: new object[,]
                {
                    { "17418100-67cb-4ea2-8eff-176169e77be6", "e8c7fb0d-f1f5-46c0-85c8-10639ea4ca9a", "Weapons Shop" },
                    { "563c9f7f-eea2-47ac-b480-72e147400a2b", "0363f4bb-1733-4305-bfc7-9193ef6cd9b9", "Potion Dealer" }
                });

            migrationBuilder.InsertData(
                table: "messages",
                columns: new[] { "chat_id", "player_id", "post_date", "text" },
                values: new object[,]
                {
                    { "7eab79c3-0e32-441b-92c9-85b1068c8ee7", "9886e82e-0b2d-4d78-a061-b8d4694a08fa", new DateTime(2024, 2, 18, 13, 27, 34, 401, DateTimeKind.Utc).AddTicks(5656), "Hi yall!" },
                    { "7eab79c3-0e32-441b-92c9-85b1068c8ee7", "b3c47842-36f7-40fb-a3c1-c058df671094", new DateTime(2024, 2, 18, 13, 27, 34, 401, DateTimeKind.Utc).AddTicks(5728), "Hi new user!" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "10d68a72-2be7-437e-a27a-585a8418f5c1");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "64fb6fd3-731a-485f-842d-36cc3fdde11a");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "9f0aa512-c858-439c-b366-15ea99a9bf37");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "cdbb4d1e-cffb-4530-adac-2b003676155f");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "d1581178-0477-4e13-8336-bd721689ecda");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "da704cfa-db21-4aeb-848c-0f6d17f55549");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "e0f44726-878c-4a10-aac9-731bc51353a3");

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumns: new[] { "chat_id", "player_id" },
                keyValues: new object[] { "7eab79c3-0e32-441b-92c9-85b1068c8ee7", "9886e82e-0b2d-4d78-a061-b8d4694a08fa" });

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumns: new[] { "chat_id", "player_id" },
                keyValues: new object[] { "7eab79c3-0e32-441b-92c9-85b1068c8ee7", "b3c47842-36f7-40fb-a3c1-c058df671094" });

            migrationBuilder.DeleteData(
                table: "shops",
                keyColumn: "id",
                keyValue: "17418100-67cb-4ea2-8eff-176169e77be6");

            migrationBuilder.DeleteData(
                table: "shops",
                keyColumn: "id",
                keyValue: "563c9f7f-eea2-47ac-b480-72e147400a2b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9886e82e-0b2d-4d78-a061-b8d4694a08fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3c47842-36f7-40fb-a3c1-c058df671094");

            migrationBuilder.DeleteData(
                table: "chat",
                keyColumn: "id",
                keyValue: "7eab79c3-0e32-441b-92c9-85b1068c8ee7");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "00dfbbf1-b1bc-4f52-be8a-c23dbb628108");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "0363f4bb-1733-4305-bfc7-9193ef6cd9b9");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "e8c7fb0d-f1f5-46c0-85c8-10639ea4ca9a");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "6ff04a16-8061-471f-85fb-19156ec97482");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "dde1b9da-9fa5-469f-96d8-71fc0ae9658c");

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
    }
}
