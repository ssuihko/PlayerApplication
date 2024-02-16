using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlayerApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEnumType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "1b3e5d05-9b21-4295-9a03-e36e9a96f252");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "34a79d72-3456-4041-852e-b5617a4ffb21");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "8229d094-4124-4e64-a90d-af5dd3e65e1f");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "84b38adf-dce8-4133-a0b1-77f8470106a7");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "8fc1d792-0ea6-4563-8e3f-ef99fbd04a9b");

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "id",
                keyValue: "a950ebfd-767f-4d12-9df1-cab0de202709");

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumns: new[] { "chat_id", "player_id" },
                keyValues: new object[] { "6facb665-5ea9-4bbb-8b00-8d84e34fec4e", "05734c6b-7836-4c46-b42c-88cd90f765a5" });

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumns: new[] { "chat_id", "player_id" },
                keyValues: new object[] { "6facb665-5ea9-4bbb-8b00-8d84e34fec4e", "c7d07e91-c014-4cee-bb8a-364af790b34e" });

            migrationBuilder.DeleteData(
                table: "shops",
                keyColumn: "id",
                keyValue: "b1573d4f-d447-4349-aa71-8496edbc75fc");

            migrationBuilder.DeleteData(
                table: "shops",
                keyColumn: "id",
                keyValue: "f81345bb-21e7-484c-b273-40ae9c0573e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "05734c6b-7836-4c46-b42c-88cd90f765a5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7d07e91-c014-4cee-bb8a-364af790b34e");

            migrationBuilder.DeleteData(
                table: "chat",
                keyColumn: "id",
                keyValue: "6facb665-5ea9-4bbb-8b00-8d84e34fec4e");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "85b84f78-e8c0-465c-ba70-c40c2e25c67c");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "b27823d2-b7e6-445c-a175-a68d85d3dbb3");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "77d3924f-fe76-4aff-8e9b-04714ba6ee57");

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "id",
                keyValue: "a99f6fcf-a1c6-4465-b600-4c01a65fa37f");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "chat",
                columns: new[] { "id", "channel" },
                values: new object[] { "6facb665-5ea9-4bbb-8b00-8d84e34fec4e", "Global" });

            migrationBuilder.InsertData(
                table: "inventories",
                column: "id",
                values: new object[]
                {
                    "77d3924f-fe76-4aff-8e9b-04714ba6ee57",
                    "85b84f78-e8c0-465c-ba70-c40c2e25c67c",
                    "a99f6fcf-a1c6-4465-b600-4c01a65fa37f",
                    "b27823d2-b7e6-445c-a175-a68d85d3dbb3"
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "class", "ConcurrencyStamp", "Email", "EmailConfirmed", "exp", "hp", "inventory_id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "race", "role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "05734c6b-7836-4c46-b42c-88cd90f765a5", 0, 1, "ddc9e27d-8579-433e-b69d-14289fe8e9b6", "juha88@gmail.com", false, 50, 100, "a99f6fcf-a1c6-4465-b600-4c01a65fa37f", false, null, null, null, null, null, false, 1, 1, "0e0708f6-773b-4ae0-939d-3d460f09796f", false, "Juha88" },
                    { "c7d07e91-c014-4cee-bb8a-364af790b34e", 0, 6, "681b9f39-3cc2-406b-a731-607e23ba1600", "tyler1@gmail.com", false, 70, 150, "77d3924f-fe76-4aff-8e9b-04714ba6ee57", false, null, null, null, null, null, false, 0, 1, "c4f7901b-d8bf-4627-bea4-2eaede073f14", false, "Tyler1" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "description", "inventory_id", "name", "price" },
                values: new object[,]
                {
                    { "1b3e5d05-9b21-4295-9a03-e36e9a96f252", "Deals 5 damage", "b27823d2-b7e6-445c-a175-a68d85d3dbb3", "Two handed sword", 50f },
                    { "34a79d72-3456-4041-852e-b5617a4ffb21", "Deals 3 fire damage", "b27823d2-b7e6-445c-a175-a68d85d3dbb3", "Magic staff", 60f },
                    { "8229d094-4124-4e64-a90d-af5dd3e65e1f", "Heals 5 hp", "85b84f78-e8c0-465c-ba70-c40c2e25c67c", "Small Healing Potion", 2.5f },
                    { "84b38adf-dce8-4133-a0b1-77f8470106a7", "Heals 20 hp", "77d3924f-fe76-4aff-8e9b-04714ba6ee57", "Large Healing Potion", 10f },
                    { "8fc1d792-0ea6-4563-8e3f-ef99fbd04a9b", "Heals 5 hp", "a99f6fcf-a1c6-4465-b600-4c01a65fa37f", "Small Healing Potion", 2.5f },
                    { "a950ebfd-767f-4d12-9df1-cab0de202709", "Heals 20 hp", "85b84f78-e8c0-465c-ba70-c40c2e25c67c", "Large Healing Potion", 10f }
                });

            migrationBuilder.InsertData(
                table: "shops",
                columns: new[] { "id", "inventory_id", "name" },
                values: new object[,]
                {
                    { "b1573d4f-d447-4349-aa71-8496edbc75fc", "85b84f78-e8c0-465c-ba70-c40c2e25c67c", "Potion Dealer" },
                    { "f81345bb-21e7-484c-b273-40ae9c0573e8", "b27823d2-b7e6-445c-a175-a68d85d3dbb3", "Weapons Shop" }
                });

            migrationBuilder.InsertData(
                table: "messages",
                columns: new[] { "chat_id", "player_id", "post_date", "text" },
                values: new object[,]
                {
                    { "6facb665-5ea9-4bbb-8b00-8d84e34fec4e", "05734c6b-7836-4c46-b42c-88cd90f765a5", new DateTime(2024, 2, 14, 11, 23, 2, 508, DateTimeKind.Utc).AddTicks(2215), "Hi yall!" },
                    { "6facb665-5ea9-4bbb-8b00-8d84e34fec4e", "c7d07e91-c014-4cee-bb8a-364af790b34e", new DateTime(2024, 2, 14, 11, 23, 2, 508, DateTimeKind.Utc).AddTicks(2293), "Hi new user!" }
                });
        }
    }
}
