using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlayerApplication.Migrations
{
    /// <inheritdoc />
    public partial class ThirdInitiateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    channel = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inventories",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    race = table.Column<int>(type: "integer", nullable: false),
                    @class = table.Column<int>(name: "class", type: "integer", nullable: false),
                    exp = table.Column<int>(type: "integer", nullable: false),
                    hp = table.Column<int>(type: "integer", nullable: false),
                    inventory_id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_inventories_inventory_id",
                        column: x => x.inventory_id,
                        principalTable: "inventories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    inventory_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_items_inventories_inventory_id",
                        column: x => x.inventory_id,
                        principalTable: "inventories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shops",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    inventory_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shops", x => x.id);
                    table.ForeignKey(
                        name: "FK_shops_inventories_inventory_id",
                        column: x => x.inventory_id,
                        principalTable: "inventories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    player_id = table.Column<string>(type: "text", nullable: false),
                    chat_id = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    post_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => new { x.player_id, x.chat_id });
                    table.ForeignKey(
                        name: "FK_messages_AspNetUsers_player_id",
                        column: x => x.player_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_messages_chat_chat_id",
                        column: x => x.chat_id,
                        principalTable: "chat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_inventory_id",
                table: "AspNetUsers",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_inventory_id",
                table: "items",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_chat_id",
                table: "messages",
                column: "chat_id");

            migrationBuilder.CreateIndex(
                name: "IX_shops_inventory_id",
                table: "shops",
                column: "inventory_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "shops");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "chat");

            migrationBuilder.DropTable(
                name: "inventories");
        }
    }
}
