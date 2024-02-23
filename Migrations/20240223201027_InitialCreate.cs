using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YuGiOh.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true),
                    frameType = table.Column<string>(type: "text", nullable: true),
                    desc = table.Column<string>(type: "text", nullable: true),
                    atk = table.Column<int>(type: "integer", nullable: true),
                    def = table.Column<int>(type: "integer", nullable: true),
                    level = table.Column<int>(type: "integer", nullable: true),
                    race = table.Column<string>(type: "text", nullable: true),
                    attribute = table.Column<string>(type: "text", nullable: true),
                    ygoprodeck_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
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
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
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
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Roles = table.Column<List<string>>(type: "text[]", nullable: true),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    image_url_small = table.Column<string>(type: "text", nullable: false),
                    Cardid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardImage_Cards_Cardid",
                        column: x => x.Cardid,
                        principalTable: "Cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteCards_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CardId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCards_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDecks_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeckCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    DeckId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckCards_UserDecks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "UserDecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05", 0, "038fd2b9-f239-480c-9ffd-bdfcbed365e6", "user3@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEC5F/+2YUJllw7wmcI46jmD9Kuvu6dJY92iOIohIV50c8XB4HZO3t5koBHW7e/9q3g==", null, false, "6586563d-2826-458b-93ad-cfc7cc102969", false, "User3" },
                    { "4342d71c-3d92-49ea-9f84-8f3412b65679", 0, "bd99e82e-c2ef-4279-bf1f-9bb3b83689f0", "user2@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEBIvVkTlusDO3yNEzu9+V8ys/dd+ygwjGlvlQ8x+ee5LHJoA4Wflv6b20kX46B4zZg==", null, false, "03cc4136-742c-4809-ba55-be8e7bb11475", false, "User2" },
                    { "7c8b955a-c256-4505-bf0f-468489633f5f", 0, "1bb55c8b-0a44-4cdc-96eb-e7e5bc30575d", "user5@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAECUu+wfBqQUefUIIy3+ogmsHn3bJbdEg7oiUXCxuMQsq6AuJqtp5Nmy/bdxDy5tCqw==", null, false, "cf635ef5-1c27-4622-bff0-34ba5cf0e5bc", false, "User5" },
                    { "b6d8aa7f-ae65-4feb-95ab-377d810bc270", 0, "28c6ac41-61f0-4b08-9ea7-d6e77d8c2623", "user4@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEBcxmNeCmxlJZcxWGACWJTSqos3kJ0cVmbrj862cNV7TKA7ypC+p2B1ORat07ZGQOw==", null, false, "c4007ce6-6fb1-4eab-8213-304100f408df", false, "User4" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "04e3c893-81d2-4e77-85b2-3bf0d5f2248d", "admin@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEPsF7VTi4GQFrJyHgM5iDbCJhtNl2kJ7pIvO8Lkfqo/1yg/eMcn6McnEo0lsDpD/FQ==", null, false, "28bcbe42-d769-4f7d-bfcf-44b1071cb31f", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "id", "atk", "attribute", "def", "desc", "frameType", "level", "name", "race", "type", "ygoprodeck_url" },
                values: new object[,]
                {
                    { 32864, 1200, "DARK", 900, "A zombie that suddenly appeared from plot #13 - an empty grave.", "normal", 3, "The 13th Grave", "Zombie", "Normal Monster", "https://ygoprodeck.com/card/the-13th-grave-2" },
                    { 62121, 920, "DARK", 1930, "FLIP: All Zombie-Type monsters gain 200 ATK and DEF. During each of your next 4 Standby Phases, each of those Zombie-Type monsters gains 200 more ATK and DEF. These effects last as long as this card is face-up on the field.", "effect", 4, "Castle of Dark Illusions", "Fiend", "Flip Effect Monster", "https://ygoprodeck.com/card/castle-of-dark-illusions-6" },
                    { 549481, 500, "EARTH", 2000, "This creature is shielded with a tough hide of hair and is excellent at defending itself.", "normal", 4, "Prevent Rat", "Beast", "Normal Monster", "https://ygoprodeck.com/card/prevent-rat-52" },
                    { 1184620, 1500, "EARTH", 1200, "A man-hunter with powerful arms that can crush boulders.", "normal", 4, "Kojikocy", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/kojikocy-104" },
                    { 1435851, null, null, null, "A Dragon-Type monster equipped with this card increases its ATK and DEF by 300 points.", "spell", null, "Dragon Treasure", "Equip", "Spell Card", "https://ygoprodeck.com/card/dragon-treasure-125" },
                    { 1557499, null, null, null, "A Fairy-Type monster equipped with this card increases its ATK and DEF by 300 points.", "spell", null, "Silver Bow and Arrow", "Equip", "Spell Card", "https://ygoprodeck.com/card/silver-bow-and-arrow-136" },
                    { 1641882, 900, "EARTH", 700, "\"Petit Angel\" + \"Mystical Sheep #2\"", "fusion", 3, "Fusionist", "Beast", "Fusion Monster", "https://ygoprodeck.com/card/fusionist-145" },
                    { 1784619, 1500, "EARTH", 800, "Fast on its feet, this dinosaur rips enemies to shreds with its sharp claws.", "normal", 4, "Uraby", "Dinosaur", "Normal Monster", "https://ygoprodeck.com/card/uraby-156" },
                    { 2118022, 1500, "WATER", 900, "This amphibian is strong on the attack, but leaves much to be desired when defending.", "normal", 4, "Hyosube", "Aqua", "Normal Monster", "https://ygoprodeck.com/card/hyosube-188" },
                    { 2483611, 1400, "WATER", 1200, "Transforms the water overflowing from a jar into attacking dragons.", "normal", 4, "Water Omotics", "Aqua", "Normal Monster", "https://ygoprodeck.com/card/water-omotics-225" },
                    { 2504891, 2650, "DARK", 2250, "\"Tainted Wisdom\" + \"Ancient Brain\"", "fusion", 7, "Skull Knight", "Spellcaster", "Fusion Monster", "https://ygoprodeck.com/card/skull-knight-226" },
                    { 2863439, 1100, "LIGHT", 1400, "A bird-beast that summons reinforcements with a hand mirror.", "normal", 4, "Fiend Reflection #2", "Winged Beast", "Normal Monster", "https://ygoprodeck.com/card/fiend-reflection-2-257" },
                    { 3027001, null, null, null, "Activate only when your opponent activates a Spell, Trap, or Effect Monster's effect that would destroy a Trap Card(s) you control. Destroy this card instead. (If the cards that would have been destroyed are face-down, you can look at them to confirm.)", "trap", null, "Fake Trap", "Normal", "Trap Card", "https://ygoprodeck.com/card/fake-trap-271" },
                    { 3819470, null, null, null, "When a Trap Card is activated: Pay 1000 LP; negate the activation, and if you do, destroy it.", "trap", null, "Seven Tools of the Bandit", "Counter", "Trap Card", "https://ygoprodeck.com/card/seven-tools-of-the-bandit-343" },
                    { 4031928, null, null, null, "Target 1 monster your opponent controls; take control of it until the End Phase.", "spell", null, "Change of Heart", "Normal", "Spell Card", "https://ygoprodeck.com/card/change-of-heart-359" },
                    { 4206964, null, null, null, "When your opponent Normal or Flip Summons 1 monster with 1000 or more ATK: Target that monster; destroy that target.", "trap", null, "Trap Hole", "Normal", "Trap Card", "https://ygoprodeck.com/card/trap-hole-379" },
                    { 4614116, null, null, null, "Increase the ATK and DEF of a Fiend-Type monster equipped with this card by 300 points.", "spell", null, "Dark Energy", "Equip", "Spell Card", "https://ygoprodeck.com/card/dark-energy-413" },
                    { 5053103, 1700, "EARTH", 1000, "A monster with tremendous power, it destroys enemies with a swing of its axe.", "normal", 4, "Battle Ox", "Beast-Warrior", "Normal Monster", "https://ygoprodeck.com/card/battle-ox-451" },
                    { 5758500, null, null, null, "Target up to 5 cards in any GY(s); banish them.", "spell", null, "Soul Release", "Normal", "Spell Card", "https://ygoprodeck.com/card/soul-release-507" },
                    { 5818798, 1500, "EARTH", 1200, "This monster moves so fast that it looks like an illusion to mortal eyes.\n\n\n(This card is always treated as a \"Phantom Beast\" card.)", "normal", 4, "Gazelle the King of Mythical Beasts", "Beast", "Normal Monster", "https://ygoprodeck.com/card/gazelle-the-king-of-mythical-beasts-513" },
                    { 5901497, 350, "EARTH", 300, "This monster may attack your opponent's Life Points directly.", "effect", 1, "Queen's Double", "Warrior", "Effect Monster", "https://ygoprodeck.com/card/queen-s-double-517" },
                    { 6285791, 1400, "EARTH", 700, "This face-up card on the field is returned to the owner's hand during the End Phase of your turn.", "effect", 3, "The Wicked Worm Beast", "Beast", "Effect Monster", "https://ygoprodeck.com/card/the-wicked-worm-beast-552" },
                    { 6368038, 2300, "EARTH", 2100, "A knight whose horse travels faster than the wind. His battle-charge is a force to be reckoned with.", "normal", 7, "Gaia The Fierce Knight", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/gaia-the-fierce-knight-561" },
                    { 6740720, 2500, "LIGHT", 2300, "A mystical dragon that burns away the unworthy with its mystic flames.", "normal", 7, "Seiyaryu", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/seiyaryu-585" },
                    { 7019529, 1000, "WIND", 800, "If this card attacks a WIND monster, it gains 1000 ATK during the Damage Step only.", "effect", 3, "Insect Soldiers of the Sky", "Insect", "Effect Monster", "https://ygoprodeck.com/card/insect-soldiers-of-the-sky-601" },
                    { 7089711, 450, "EARTH", 500, "FLIP: Select 1 monster on the field and return it to its owner's hand.", "effect", 2, "Hane-Hane", "Beast", "Flip Effect Monster", "https://ygoprodeck.com/card/hane-hane-608" },
                    { 7489323, 300, "EARTH", 250, "As long as this card remains face-up on the field, increase the ATK of all EARTH monsters by 500 points and decrease the ATK of all WIND monsters by 400 points.", "effect", 1, "Milus Radiant", "Beast", "Effect Monster", "https://ygoprodeck.com/card/milus-radiant-640" },
                    { 7805359, 900, "EARTH", 800, "Swallows enemies whole and uses their essence as energy.", "normal", 3, "Niwatori", "Winged Beast", "Normal Monster", "https://ygoprodeck.com/card/niwatori-665" },
                    { 7902349, 200, "DARK", 300, "A forbidden left arm sealed by magic. Whosoever breaks this seal will know infinite power.", "normal", 1, "Left Arm of the Forbidden One", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/left-arm-of-the-forbidden-one-675" },
                    { 8124921, 200, "DARK", 300, "A forbidden right leg sealed by magic. Whosoever breaks this seal will know infinite power.", "normal", 1, "Right Leg of the Forbidden One", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/right-leg-of-the-forbidden-one-689" },
                    { 8201910, 550, "WATER", 500, "As long as this card remains face-up on the field, increase the ATK of all WATER monsters by 500 points and decrease the ATK of all FIRE monsters by 400 points.", "effect", 2, "Star Boy", "Aqua", "Effect Monster", "https://ygoprodeck.com/card/star-boy-695" },
                    { 8471389, 1200, "FIRE", 1400, "An iron wolf with razor-sharp fangs that can penetrate any armor.", "normal", 4, "Giga-Tech Wolf", "Machine", "Normal Monster", "https://ygoprodeck.com/card/giga-tech-wolf-717" },
                    { 9076207, 300, "EARTH", 300, "FLIP: Target 1 Spell Card on the field; destroy that target. (If the target is Set, reveal it, and destroy it if it is a Spell Card. Otherwise, return it to its original position.)", "effect", 1, "Armed Ninja", "Warrior", "Flip Effect Monster", "https://ygoprodeck.com/card/armed-ninja-770" },
                    { 9159938, 800, "EARTH", 900, "Entirely gray, this beast has rarely been seen by mortal eyes.", "normal", 3, "Dark Gray", "Beast", "Normal Monster", "https://ygoprodeck.com/card/dark-gray-777" },
                    { 9293977, 1850, "WIND", 1700, "\"Steel Ogre Grotto #1\" + \"Lesser Dragon\"", "fusion", 6, "Metal Dragon", "Machine", "Fusion Monster", "https://ygoprodeck.com/card/metal-dragon-788" },
                    { 9653271, 1900, "WIND", 1400, "\"Ocubeam\" + \"Mega Thunderball\"", "fusion", 5, "Kaminari Attack", "Thunder", "Fusion Monster", "https://ygoprodeck.com/card/kaminari-attack-816" },
                    { 10071456, 800, "EARTH", 1500, "While the king is away, this queen protects his throne with a mighty defense.", "normal", 4, "Protector of the Throne", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/protector-of-the-throne-873" },
                    { 10189126, 900, "DARK", 1400, "When this card inflicts Battle Damage to your opponent's Life Points, draw 1 card from your Deck.", "effect", 4, "Masked Sorcerer", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/masked-sorcerer-881" },
                    { 10202894, 1550, "WIND", 1200, "This monster swoops down and attacks with a rain of knives stored in its wings.", "normal", 4, "Skull Red Bird", "Winged Beast", "Normal Monster", "https://ygoprodeck.com/card/skull-red-bird-883" },
                    { 10538007, 1750, "EARTH", 1550, "Huge monster with a lion's mane similar to the King of Beasts.", "normal", 5, "Leogun", "Beast", "Normal Monster", "https://ygoprodeck.com/card/leogun-915" },
                    { 11384280, 1400, "DARK", 1300, "You can Tribute 1 monster; inflict 500 damage to your opponent.", "effect", 4, "Cannon Soldier", "Machine", "Effect Monster", "https://ygoprodeck.com/card/cannon-soldier-982" },
                    { 11868825, null, null, null, "Increase your Life Points by 600 points.", "spell", null, "Goblin's Secret Remedy", "Normal", "Spell Card", "https://ygoprodeck.com/card/goblin-s-secret-remedy-1027" },
                    { 11901678, 3200, "DARK", 2500, "\"Summoned Skull\" + \"Red-Eyes Black Dragon\"\r\n\r\n\r\n\r\n(This card is always treated as an \"Archfiend\" card.)", "fusion", 9, "Black Skull Dragon", "Dragon", "Fusion Monster", "https://ygoprodeck.com/card/black-skull-dragon-1029" },
                    { 12206212, 1950, "WIND", 2100, "Cannot be Normal Summoned/Set. Must first be Special Summoned with \"Elegant Egotist\".", "effect", 6, "Harpie Lady Sisters", "Winged Beast", "Effect Monster", "https://ygoprodeck.com/card/harpie-lady-sisters-1052" },
                    { 12472242, 300, "EARTH", 350, "This monster may attack your opponent's Life Points directly.", "effect", 1, "Leghul", "Insect", "Effect Monster", "https://ygoprodeck.com/card/leghul-1079" },
                    { 12580477, null, null, null, "Destroy all monsters your opponent controls.", "spell", null, "Raigeki", "Normal", "Spell Card", "https://ygoprodeck.com/card/raigeki-1087" },
                    { 12607053, null, null, null, "You take no battle damage from your opponent's monsters this turn. Your monsters cannot be destroyed by battle this turn.", "trap", null, "Waboku", "Normal", "Trap Card", "https://ygoprodeck.com/card/waboku-1089" },
                    { 13039848, 1300, "EARTH", 2000, "A giant warrior made of stone. A punch from this creature has earth-shaking results.", "normal", 3, "Giant Soldier of Stone", "Rock", "Normal Monster", "https://ygoprodeck.com/card/giant-soldier-of-stone-1125" },
                    { 13215230, 1200, "EARTH", 900, "When this card is changed from Attack Position to face-up Defense Position, select 1 monster your opponent controls and destroy it.", "effect", 3, "Dream Clown", "Warrior", "Effect Monster", "https://ygoprodeck.com/card/dream-clown-1138" },
                    { 13429800, 1600, "WATER", 800, "A giant white shark with razor-sharp teeth.", "normal", 4, "Great White", "Fish", "Normal Monster", "https://ygoprodeck.com/card/great-white-1151" },
                    { 13599884, 250, "EARTH", 300, "A non Machine-Type Monster attacking \"Steel Scorpion\" will be destroyed at the End Phase of your opponent's 2nd turn after the attack.", "effect", 1, "Steel Scorpion", "Machine", "Effect Monster", "https://ygoprodeck.com/card/steel-scorpion-1166" },
                    { 13723605, 1600, "DARK", 1000, "A monster disguised as a treasure chest that is known to attack the unwary adventurer.", "normal", 4, "Man-Eating Treasure Chest", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/man-eating-treasure-chest-1178" },
                    { 13945283, 1000, "DARK", 1850, "If this card is attacked by a monster, after damage calculation: Return that monster to the hand.", "effect", 4, "Wall of Illusion", "Fiend", "Effect Monster", "https://ygoprodeck.com/card/wall-of-illusion-1192" },
                    { 14141448, 2600, "EARTH", 2500, "This monster cannot be Normal Summoned or Set. This card can only be Special Summoned by Tributing \"Petit Moth\" during your 4th turn after \"Petit Moth\" has been equipped with \"Cocoon of Evolution\".", "effect", 8, "Great Moth", "Insect", "Effect Monster", "https://ygoprodeck.com/card/great-moth-1210" },
                    { 14851496, 1200, "WATER", 1500, "An almost invisible, semi-transparent jellyfish that drifts in the sea.", "normal", 4, "Jellyfish", "Aqua", "Normal Monster", "https://ygoprodeck.com/card/jellyfish-1274" },
                    { 15025844, 800, "LIGHT", 2000, "A delicate elf that lacks offense, but has a terrific defense backed by mystical power.", "normal", 4, "Mystical Elf", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/mystical-elf-1289" },
                    { 15052462, null, null, null, "(This card is not treated as a \"Crystal\" card.)\r\nEquip only to a Zombie monster. It gains 300 ATK/DEF.", "spell", null, "Violet Crystal", "Equip", "Spell Card", "https://ygoprodeck.com/card/violet-crystal-1293" },
                    { 15150365, 1000, "LIGHT", 700, "When this card inflicts Battle Damage to your opponent's Life Points, your opponent discards 1 card randomly from his/her hand.", "effect", 3, "White Magical Hat", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/white-magical-hat-1298" },
                    { 15237615, 2100, "EARTH", 1700, "\"Queen's Double\" + \"Hibikime\"", "fusion", 6, "Empress Judge", "Warrior", "Fusion Monster", "https://ygoprodeck.com/card/empress-judge-1305" },
                    { 15303296, 1000, "DARK", 500, "A very elusive creature that looks like a harmless statue until it attacks.", "normal", 3, "Ryu-Kishin", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/ryu-kishin-1313" },
                    { 15401633, 800, "EARTH", 400, "Serving as a double for the Ruler of the Blue Flame, he's a master swordsman that wields a fine blade.", "normal", 2, "Kagemusha of the Blue Flame", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/kagemusha-of-the-blue-flame-1327" },
                    { 15480588, 1500, "EARTH", 1200, "A lizard with a very tough hide and a vicious bite.", "normal", 4, "Armored Lizard", "Reptile", "Normal Monster", "https://ygoprodeck.com/card/armored-lizard-1332" },
                    { 16353197, 900, "EARTH", 800, "A blood-sucking snake in human form that attacks any living being that passes nearby.", "normal", 3, "Drooling Lizard", "Reptile", "Normal Monster", "https://ygoprodeck.com/card/drooling-lizard-1409" },
                    { 16768387, 1200, "DARK", 1000, "FLIP: Look at up to 5 cards from the top of your Deck, then place them on the top of the Deck in any order.", "effect", 4, "Big Eye", "Fiend", "Flip Effect Monster", "https://ygoprodeck.com/card/big-eye-1444" },
                    { 16972957, 1600, "DARK", 1400, "This fairy rules over the end of existence.", "normal", 5, "Doma The Angel of Silence", "Fairy", "Normal Monster", "https://ygoprodeck.com/card/doma-the-angel-of-silence-1467" },
                    { 17092736, null, null, null, "See the top 5 cards of your opponent's Deck. Return the cards to the Deck in the same order.", "spell", null, "Ancient Telescope", "Normal", "Spell Card", "https://ygoprodeck.com/card/ancient-telescope-1476" },
                    { 17358176, 1100, "LIGHT", 800, "Soothes the souls of others by chanting a mysterious spell.", "normal", 3, "Lady of Faith", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/lady-of-faith-1502" },
                    { 17535588, 850, "WATER", 1400, "A bluish starfish with a solid hide capable of fending off attacks.", "normal", 4, "Armored Starfish", "Aqua", "Normal Monster", "https://ygoprodeck.com/card/armored-starfish-1523" },
                    { 17814387, null, null, null, "Target 1 face-up monster on the field; it gains 500 ATK until the end of this turn.", "trap", null, "Reinforcements", "Normal", "Trap Card", "https://ygoprodeck.com/card/reinforcements-1547" },
                    { 17881964, 1500, "DARK", 1250, "\"Firegrass\" + \"Petit Dragon\"", "fusion", 4, "Darkfire Dragon", "Dragon", "Fusion Monster", "https://ygoprodeck.com/card/darkfire-dragon-1553" },
                    { 17985575, 1200, "DARK", 1100, "Neither player can target Dragon monsters on the field with card effects.", "effect", 4, "Lord of D.", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/lord-of-d-1560" },
                    { 18246479, 1800, "EARTH", 1300, "A bull monster often found in the woods, it charges enemy monsters with a pair of deadly horns.", "normal", 5, "Battle Steer", "Beast-Warrior", "Normal Monster", "https://ygoprodeck.com/card/battle-steer-1584" },
                    { 18710707, 800, "WATER", 700, "Grand King of the Seven Seas, he's able to summon massive tidal waves to drown the enemy.", "normal", 3, "The Furious Sea King", "Aqua", "Normal Monster", "https://ygoprodeck.com/card/the-furious-sea-king-1616" },
                    { 19066538, 2100, "WATER", 1800, "\"Mystic Lamp\" + \"Hyosube\"", "fusion", 6, "Roaring Ocean Snake", "Aqua", "Fusion Monster", "https://ygoprodeck.com/card/roaring-ocean-snake-1648" },
                    { 19159413, null, null, null, "Target 1 face-up Spell, or 1 Set Spell/Trap, on the field; destroy that target if it is a Spell. (If the target is Set, reveal it.)", "spell", null, "De-Spell", "Normal", "Spell Card", "https://ygoprodeck.com/card/de-spell-1653" },
                    { 19523799, null, null, null, "Inflict 800 damage to your opponent.", "spell", null, "Ookazi", "Normal", "Spell Card", "https://ygoprodeck.com/card/ookazi-1683" },
                    { 19613556, null, null, null, "Destroy all Spell and Trap Cards on the field.", "spell", null, "Heavy Storm", "Normal", "Spell Card", "https://ygoprodeck.com/card/heavy-storm-1690" },
                    { 20060230, 300, "EARTH", 1200, "A living suit of armor that attacks enemies with a bone-jarring tackle.", "normal", 3, "Hard Armor", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/hard-armor-1722" },
                    { 20277860, 1500, "DARK", 0, "This warrior blindly swings a deadly blade with devastating force.", "normal", 3, "Armored Zombie", "Zombie", "Normal Monster", "https://ygoprodeck.com/card/armored-zombie-1739" },
                    { 20394040, 1550, "EARTH", 1800, "This card gains 500 ATK for each \"Swamp Battleguard\" you control.", "effect", 5, "Lava Battleguard", "Warrior", "Effect Monster", "https://ygoprodeck.com/card/lava-battleguard-1751" },
                    { 20436034, null, null, null, "You can only equip this card to a monster on your side of the field. Decrease the ATK and DEF of a monster equipped with this card by 500 points. In addition, all the monsters on your opponent's side of the field can only attack the monster equipped with this card, if they attack.", "spell", null, "Ring of Magnetism", "Equip", "Spell Card", "https://ygoprodeck.com/card/ring-of-magnetism-1755" },
                    { 21263083, 1500, "EARTH", 1200, "With skin tinged a bluish-white, this strange creature is a fearsome sight to behold.", "normal", 4, "Pale Beast", "Beast", "Normal Monster", "https://ygoprodeck.com/card/pale-beast-1829" },
                    { 21347810, 400, "EARTH", 500, "This monster may attack your opponent's Life Points directly.", "effect", 2, "Rainbow Flower", "Plant", "Effect Monster", "https://ygoprodeck.com/card/rainbow-flower-1836" },
                    { 21417692, 2000, "DARK", 800, "This card requires a cost of 1000 of your own Life Points to attack.", "effect", 4, "Dark Elf", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/dark-elf-1841" },
                    { 21817254, 750, "WIND", 600, "Rolls along the ground releasing bolts of electricity to attack its enemies.", "normal", 2, "Mega Thunderball", "Thunder", "Normal Monster", "https://ygoprodeck.com/card/mega-thunderball-1877" },
                    { 22702055, null, null, null, "All Fish, Sea Serpent, Thunder, and Aqua monsters on the field gain 200 ATK/DEF, also all Machine and Pyro monsters on the field lose 200 ATK/DEF.", "spell", null, "Umi", "Field", "Spell Card", "https://ygoprodeck.com/card/umi-1952" },
                    { 22910685, 500, "EARTH", 1600, "This youthful king of the forests lives in a green world, abundant with trees and wildlife.", "normal", 3, "Green Phantom King", "Plant", "Normal Monster", "https://ygoprodeck.com/card/green-phantom-king-1972" },
                    { 23424603, null, null, null, "All Dinosaur, Zombie, and Rock monsters on the field gain 200 ATK/DEF.", "spell", null, "Wasteland", "Field", "Spell Card", "https://ygoprodeck.com/card/wasteland-2020" },
                    { 23771716, 1800, "WATER", 800, "A rare rainbow fish that has never been caught by mortal man.", "normal", 4, "7 Colored Fish", "Fish", "Normal Monster", "https://ygoprodeck.com/card/7-colored-fish-2049" },
                    { 24068492, null, null, null, "Inflict 500 damage to your opponent for each monster they control.", "trap", null, "Just Desserts", "Normal", "Trap Card", "https://ygoprodeck.com/card/just-desserts-2075" },
                    { 24094653, null, null, null, "Fusion Summon 1 Fusion Monster from your Extra Deck, using monsters from your hand or field as Fusion Material.", "spell", null, "Polymerization", "Normal", "Spell Card", "https://ygoprodeck.com/card/polymerization-2077" },
                    { 24611934, 1600, "DARK", 1200, "A gargoyle enhanced by the powers of darkness. Very sharp talons make it a worthy opponent.", "normal", 4, "Ryu-Kishin Powered", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/ryu-kishin-powered-2124" },
                    { 24668830, null, null, null, "The ATK of a non Machine-Type monster equipped with this card is decreased by 300 points at each of its Standby Phases.", "spell", null, "Germ Infection", "Equip", "Spell Card", "https://ygoprodeck.com/card/germ-infection-2131" },
                    { 25109950, 800, "WATER", 1300, "Offer 1 monster on your side of the field as a Tribute to increase this monster's ATK by 700 points until the end of the turn.", "effect", 3, "The Little Swordsman of Aile", "Warrior", "Effect Monster", "https://ygoprodeck.com/card/the-little-swordsman-of-aile-2157" },
                    { 25655502, 2300, "DARK", 2000, "\"Crass Clown\" + \"Dream Clown\"", "fusion", 7, "Bickuribox", "Fiend", "Fusion Monster", "https://ygoprodeck.com/card/bickuribox-2207" },
                    { 25769732, null, null, null, "Equip only to a Machine monster. It gains 300 ATK/DEF.", "spell", null, "Machine Conversion Factory", "Equip", "Spell Card", "https://ygoprodeck.com/card/machine-conversion-factory-2214" },
                    { 25833572, 3750, "DARK", 3400, "Cannot be Normal Summoned/Set. Must first be Special Summoned (from your hand) by Tributing 1 \"Sanga of the Thunder\", \"Kazejin\", and \"Suijin\".", "effect", 11, "Gate Guardian", "Warrior", "Effect Monster", "https://ygoprodeck.com/card/gate-guardian-2225" },
                    { 25880422, null, null, null, "Target 1 face-up Attack Position monster your opponent controls; change that target to face-up Defense Position.", "spell", null, "Block Attack", "Normal", "Spell Card", "https://ygoprodeck.com/card/block-attack-2231" },
                    { 25955164, 2600, "LIGHT", 2200, "During damage calculation in your opponent's turn, if this card is being attacked: You can target the attacking monster; make that target's ATK 0 during damage calculation only (this is a Quick Effect). This effect can only be used once while this card is face-up on the field.", "effect", 7, "Sanga of the Thunder", "Thunder", "Effect Monster", "https://ygoprodeck.com/card/sanga-of-the-thunder-2236" },
                    { 26202165, 1000, "DARK", 600, "If this card is sent from the field to the GY: Add 1 monster with 1500 or less ATK from your Deck to your hand, but you cannot activate cards, or the effects of cards, with that name for the rest of this turn. You can only use this effect of \"Sangan\" once per turn.", "effect", 3, "Sangan", "Fiend", "Effect Monster", "https://ygoprodeck.com/card/sangan-2251" },
                    { 26378150, 1800, "EARTH", 1600, "With an axe in each hand, this monster delivers heavy damage.", "normal", 5, "Rude Kaiser", "Beast-Warrior", "Normal Monster", "https://ygoprodeck.com/card/rude-kaiser-2266" },
                    { 28279543, 2000, "DARK", 1500, "A wicked dragon that taps into dark forces to execute a powerful attack.", "normal", 5, "Curse of Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/curse-of-dragon-2404" },
                    { 28470714, 600, "WIND", 700, "As long as this card remains face-up on the field, increase the ATK of all WIND monsters by 500 points and decrease the ATK of all EARTH monsters by 400 points.", "effect", 2, "Bladefly", "Insect", "Effect Monster", "https://ygoprodeck.com/card/bladefly-2423" },
                    { 28546905, 1200, "DARK", 2200, "Manipulates enemy attacks with the power of illusion.", "normal", 5, "Illusionist Faceless Mage", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/illusionist-faceless-mage-2427" },
                    { 28593363, 1900, "WATER", 1600, "\"Bottom Dweller\" + \"Tongyo\"", "fusion", 5, "Deepsea Shark", "Fish", "Fusion Monster", "https://ygoprodeck.com/card/deepsea-shark-2434" },
                    { 28725004, 1250, "DARK", 800, "If this Attack Position card is changed to face-up Defense Position: Shuffle your Deck.", "effect", 3, "Tainted Wisdom", "Fiend", "Effect Monster", "https://ygoprodeck.com/card/tainted-wisdom-2446" },
                    { 28933734, 900, "DARK", 400, "FLIP: Target 1 Trap in your GY; add that target to your hand.", "effect", 2, "Mask of Darkness", "Fiend", "Flip Effect Monster", "https://ygoprodeck.com/card/mask-of-darkness-2456" },
                    { 29155212, 1800, "DARK", 2000, "If \"Castle of Dark Illusions\" is face-up on the field, increase the ATK and DEF of this card by 100 points. As long as this \"Castle of Dark Illusions\" remains face-up on the field, the ATK and DEF of this card continues to increase by 100 points during each of your Standby Phases. This effect continues until your 4th turn after the card is activated.", "effect", 6, "Pumpking the King of Ghosts", "Zombie", "Effect Monster", "https://ygoprodeck.com/card/pumpking-the-king-of-ghosts-2473" },
                    { 29172562, 1400, "EARTH", 1800, "A steel idol worshipped in the Land of Machines.", "normal", 5, "Steel Ogre Grotto #1", "Machine", "Normal Monster", "https://ygoprodeck.com/card/steel-ogre-grotto-1-2475" },
                    { 29380133, 900, "WATER", 1700, "When this card is changed from Attack Position to Defense Position, you can place any number of cards from your hand at the bottom of your Deck in any order you desire.", "effect", 4, "Yado Karu", "Aqua", "Effect Monster", "https://ygoprodeck.com/card/yado-karu-2490" },
                    { 30113682, 2200, "EARTH", 1500, "This club-wielding warrior battles to the end and will never surrender.", "normal", 6, "Judge Man", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/judge-man-2552" },
                    { 30778711, 1600, "DARK", 1300, "This card gains 100 ATK for each monster in your Graveyard.", "effect", 5, "Shadow Ghoul", "Zombie", "Effect Monster", "https://ygoprodeck.com/card/shadow-ghoul-2614" },
                    { 31122090, 1800, "LIGHT", 2000, "This fairy uses her mystical power to protect the weak and provide spiritual support.", "normal", 6, "Gyakutenno Megami", "Fairy", "Normal Monster", "https://ygoprodeck.com/card/gyakutenno-megami-2641" },
                    { 31560081, 300, "LIGHT", 400, "FLIP: Target 1 Spell in your GY; add that target to your hand.", "effect", 1, "Magician of Faith", "Spellcaster", "Flip Effect Monster", "https://ygoprodeck.com/card/magician-of-faith-2683" },
                    { 31786629, 1600, "LIGHT", 1500, "You can discard this card; add up to 2 \"Thunder Dragon\" from your Deck to your hand.", "effect", 5, "Thunder Dragon", "Thunder", "Effect Monster", "https://ygoprodeck.com/card/thunder-dragon-2698" },
                    { 32268901, null, null, null, "Equip only to a FIRE monster. It gains 700 ATK.", "spell", null, "Salamandra", "Equip", "Spell Card", "https://ygoprodeck.com/card/salamandra-2739" },
                    { 32274490, 300, "DARK", 200, "A skeletal ghost that isn't strong but can mean trouble in large numbers.", "normal", 1, "Skull Servant", "Zombie", "Normal Monster", "https://ygoprodeck.com/card/skull-servant-2742" },
                    { 32452818, 1200, "EARTH", 1500, "What this creature lacks in size it makes up for in defense when battling in the prairie.", "normal", 4, "Beaver Warrior", "Beast-Warrior", "Normal Monster", "https://ygoprodeck.com/card/beaver-warrior-2759" },
                    { 32809211, 500, "DARK", 400, "This monster can attack your opponent's Life Points directly.", "effect", 2, "Jinzo #7", "Machine", "Effect Monster", "https://ygoprodeck.com/card/jinzo-7-2795" },
                    { 33064647, 700, "WIND", 1300, "This dragon wears a shield not only for its own protection, but also for ramming its enemies.", "normal", 3, "One-Eyed Shield Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/one-eyed-shield-dragon-2810" },
                    { 33066139, 1380, "DARK", 1930, "FLIP: Select 1 Trap Card on the field and destroy it. If the selected card is Set, pick up and see the card. If it is a Trap Card, it is destroyed. If it is a Spell Card, return it to its original position.", "effect", 5, "Reaper of the Cards", "Fiend", "Flip Effect Monster", "https://ygoprodeck.com/card/reaper-of-the-cards-2811" },
                    { 33178416, 1400, "WATER", 1600, "A missile-launching fish protected by deadly spikes.", "normal", 5, "Misairuzame", "Fish", "Normal Monster", "https://ygoprodeck.com/card/misairuzame-2817" },
                    { 33396948, 1000, "DARK", 1000, "If you have \"Right Leg of the Forbidden One\", \"Left Leg of the Forbidden One\", \"Right Arm of the Forbidden One\" and \"Left Arm of the Forbidden One\" in addition to this card in your hand, you win the Duel.", "effect", 3, "Exodia the Forbidden One", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/exodia-the-forbidden-one-2835" },
                    { 34460851, 900, "FIRE", 1000, "This Spellcaster attacks enemies with fire-related spells such as \"Sea of Flames\" and \"Wall of Fire\".", "normal", 3, "Flame Manipulator", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/flame-manipulator-2926" },
                    { 36121917, 600, "EARTH", 900, "A warrior hidden within an egg that attacks enemies by flinging eggshells.", "normal", 3, "Monster Egg", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/monster-egg-3058" },
                    { 36304921, 1400, "DARK", 1300, "Dressed in a night-black tuxedo, this creature presides over the darkness.", "normal", 4, "Witty Phantom", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/witty-phantom-3067" },
                    { 36607978, null, null, null, "Equip only to a Beast-Warrior-Type monster. It gains 300 ATK and DEF.", "spell", null, "Mystical Moon", "Equip", "Spell Card", "https://ygoprodeck.com/card/mystical-moon-3095" },
                    { 37120512, null, null, null, "Equip only to a DARK monster. It gains 400 ATK and loses 200 DEF.", "spell", null, "Sword of Dark Destruction", "Equip", "Spell Card", "https://ygoprodeck.com/card/sword-of-dark-destruction-3141" },
                    { 37313348, 1000, "WATER", 1500, "A tiger encased in a protective shell that attacks with razor-sharp fangs.", "normal", 4, "Turtle Tiger", "Aqua", "Normal Monster", "https://ygoprodeck.com/card/turtle-tiger-3158" },
                    { 37421579, 1100, "FIRE", 800, "\"Monster Egg\" + \"Hinotama Soul\"", "fusion", 3, "Charubin the Fire Knight", "Pyro", "Fusion Monster", "https://ygoprodeck.com/card/charubin-the-fire-knight-3170" },
                    { 37820550, null, null, null, "Increase the ATK and DEF of a Thunder-Type monster equipped with this card by 300 points.", "spell", null, "Electro-Whip", "Equip", "Spell Card", "https://ygoprodeck.com/card/electro-whip-3205" },
                    { 38142739, 600, "LIGHT", 900, "A quick-moving and tiny fairy that's very difficult to hit.", "normal", 3, "Petit Angel", "Fairy", "Normal Monster", "https://ygoprodeck.com/card/petit-angel-3234" },
                    { 38199696, null, null, null, "Increase your Life Points by 500 points.", "spell", null, "Red Medicine", "Normal", "Spell Card", "https://ygoprodeck.com/card/red-medicine-3238" },
                    { 39004808, 900, "WATER", 800, "An amphibian capable of calling up a massive tidal wave from the dark seas to wipe out enemy monsters.", "normal", 3, "Root Water", "Fish", "Normal Monster", "https://ygoprodeck.com/card/root-water-3307" },
                    { 39111158, 2850, "DARK", 2350, "An unworthy dragon with three sharp horns sprouting from its head.", "normal", 8, "Tri-Horned Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/tri-horned-dragon-3313" },
                    { 39774685, null, null, null, "A Plant-Type monster equipped with this card increases its ATK and DEF by 300 points.", "spell", null, "Vile Germs", "Equip", "Spell Card", "https://ygoprodeck.com/card/vile-germs-3373" },
                    { 40240595, 0, "EARTH", 2000, "You can target 1 \"Petit Moth\" you control; equip this card from your hand to that target. While equipped by this effect, the original ATK/DEF of that \"Petit Moth\" becomes the ATK/DEF of \"Cocoon of Evolution\".", "effect", 3, "Cocoon of Evolution", "Insect", "Effect Monster", "https://ygoprodeck.com/card/cocoon-of-evolution-3420" },
                    { 40374923, 1200, "EARTH", 800, "A mammoth that protects the graves of its pack and is absolutely merciless when facing grave-robbers.", "normal", 3, "Mammoth Graveyard", "Dinosaur", "Normal Monster", "https://ygoprodeck.com/card/mammoth-graveyard-3430" },
                    { 40453765, 1800, "EARTH", 1500, "This card gains 500 ATK for each \"Lava Battleguard\" you control.", "effect", 5, "Swamp Battleguard", "Warrior", "Effect Monster", "https://ygoprodeck.com/card/swamp-battleguard-3441" },
                    { 40640057, 300, "DARK", 200, "During damage calculation, if your opponent's monster attacks (Quick Effect): You can discard this card; you take no battle damage from that battle.", "effect", 1, "Kuriboh", "Fiend", "Effect Monster", "https://ygoprodeck.com/card/kuriboh-3456" },
                    { 40826495, 900, "EARTH", 1000, "A monster born in the lava pits, it generates intense heat that can melt away its enemies.", "normal", 3, "Dissolverock", "Rock", "Normal Monster", "https://ygoprodeck.com/card/dissolverock-3470" },
                    { 41142615, null, null, null, "Discard up to 3 Monster Cards from your hand to the Graveyard.", "spell", null, "The Cheerful Coffin", "Normal", "Spell Card", "https://ygoprodeck.com/card/the-cheerful-coffin-3504" },
                    { 41218256, 1000, "DARK", 800, "Stretching arms and razor-sharp claws make this monster a formidable opponent.", "normal", 3, "Claw Reacher", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/claw-reacher-3518" },
                    { 41356845, null, null, null, "Target 1 face-down Defense Position monster on the field; flip it face-up, then destroy it if its DEF is 2000 or less, or return it face-down if its DEF is more than 2000.", "trap", null, "Acid Trap Hole", "Normal", "Trap Card", "https://ygoprodeck.com/card/acid-trap-hole-3528" },
                    { 41392891, 1300, "DARK", 1400, "A playful little fiend that lurks in the dark, waiting to attack an unwary enemy.", "normal", 4, "Feral Imp", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/feral-imp-3533" },
                    { 41396436, 1600, "WIND", 1200, "With hair shaped like a crown and a body encased in bluish white flames, this bird is a formidable sight.", "normal", 4, "Blue-Winged Crown", "Winged Beast", "Normal Monster", "https://ygoprodeck.com/card/blue-winged-crown-3534" },
                    { 41420027, null, null, null, "When a monster(s) would be Summoned, OR a Spell/Trap Card is activated: Pay half your LP; negate the Summon or activation, and if you do, destroy that card.", "trap", null, "Solemn Judgment", "Counter", "Trap Card", "https://ygoprodeck.com/card/solemn-judgment-3537" },
                    { 41462083, 2400, "WIND", 2000, "\"Time Wizard\" + \"Baby Dragon\"", "fusion", 7, "Thousand Dragon", "Dragon", "Fusion Monster", "https://ygoprodeck.com/card/thousand-dragon-3545" },
                    { 41949033, 1200, "DARK", 1200, "Armed with the Psycho Sword, this sinister assassin rules the bad land.", "normal", 4, "Dark Assailant", "Zombie", "Normal Monster", "https://ygoprodeck.com/card/dark-assailant-3578" },
                    { 42431843, 1000, "DARK", 700, "A fallen fairy that is powerful in the dark.", "normal", 3, "Ancient Brain", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/ancient-brain-3620" },
                    { 43230671, 1400, "EARTH", 1100, "Before the dawn of man, this lizard warrior ruled supreme.", "normal", 4, "Ancient Lizard Warrior", "Reptile", "Normal Monster", "https://ygoprodeck.com/card/ancient-lizard-warrior-3683" },
                    { 43500484, 1200, "EARTH", 900, "A thorny plant found in the darklands that wraps itself around any unwary traveler.", "normal", 3, "Darkworld Thorns", "Plant", "Normal Monster", "https://ygoprodeck.com/card/darkworld-thorns-3711" },
                    { 43973174, null, null, null, "Special Summon up to 2 Dragon monsters from your hand. \"Lord of D.\" must be on the field to activate and to resolve this effect.", "spell", null, "The Flute of Summoning Dragon", "Normal", "Spell Card", "https://ygoprodeck.com/card/the-flute-of-summoning-dragon-3755" },
                    { 44095762, null, null, null, "When an opponent's monster declares an attack: Destroy all your opponent's Attack Position monsters.", "trap", null, "Mirror Force", "Normal", "Trap Card", "https://ygoprodeck.com/card/mirror-force-3764" },
                    { 44209392, null, null, null, "Increase the DEF of 1 face-up monster on the field by 500 points until the end of this turn.", "trap", null, "Castle Walls", "Normal", "Trap Card", "https://ygoprodeck.com/card/castle-walls-3771" },
                    { 44287299, 1100, "EARTH", 1100, "Legendary swordmaster Masaki is a veteran of over 100 battles.", "normal", 4, "Masaki the Legendary Swordsman", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/masaki-the-legendary-swordsman-3777" },
                    { 44519536, 200, "DARK", 300, "A forbidden left leg sealed by magic. Whosoever breaks this seal will know infinite power.", "normal", 1, "Left Leg of the Forbidden One", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/left-leg-of-the-forbidden-one-3796" },
                    { 45042329, 1200, "EARTH", 1300, "This creature attacks with electromagnetic waves.", "normal", 4, "Tripwire Beast", "Thunder", "Normal Monster", "https://ygoprodeck.com/card/tripwire-beast-3841" },
                    { 45121025, 1200, "EARTH", 1400, "An ogre possessed by the powers of the dark. Few can withstand its rapid charge.", "normal", 4, "Ogre of the Black Shadow", "Beast-Warrior", "Normal Monster", "https://ygoprodeck.com/card/ogre-of-the-black-shadow-3846" },
                    { 45231177, 1800, "FIRE", 1600, "\"Flame Manipulator\" + \"Masaki the Legendary Swordsman\"", "fusion", 5, "Flame Swordsman", "Warrior", "Fusion Monster", "https://ygoprodeck.com/card/flame-swordsman-3857" },
                    { 46009906, null, null, null, "A Beast-Type monster equipped with this card increases its ATK and DEF by 300 points.", "spell", null, "Beast Fangs", "Equip", "Spell Card", "https://ygoprodeck.com/card/beast-fangs-3920" },
                    { 46130346, null, null, null, "Inflict 500 damage to your opponent.", "spell", null, "Hinotama", "Normal", "Spell Card", "https://ygoprodeck.com/card/hinotama-3931" },
                    { 46461247, 500, "EARTH", 1100, "FLIP: Select 1 Trap Card on the field and destroy it. If the selected card is Set, pick up and see the card. If it is a Trap Card, it is destroyed. If it is a Spell Card, return it to its original position.", "effect", 3, "Trap Master", "Warrior", "Flip Effect Monster", "https://ygoprodeck.com/card/trap-master-3962" },
                    { 46474915, 1300, "DARK", 1400, "This creature casts a spell of terror and confusion just before attacking its enemies.", "normal", 4, "Magical Ghost", "Zombie", "Normal Monster", "https://ygoprodeck.com/card/magical-ghost-3963" },
                    { 46657337, 600, "EARTH", 300, "This card gains 300 ATK and DEF for each card in your hand.", "effect", 2, "Muka Muka", "Rock", "Effect Monster", "https://ygoprodeck.com/card/muka-muka-3978" },
                    { 46918794, null, null, null, "Inflict 1000 points of damage to your opponent's Life Points and 500 points of damage to your Life Points.", "spell", null, "Tremendous Fire", "Normal", "Spell Card", "https://ygoprodeck.com/card/tremendous-fire-3998" },
                    { 46986414, 2500, "DARK", 2100, "''The ultimate wizard in terms of attack and defense.''", "normal", 7, "Dark Magician", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/dark-magician-4003" },
                    { 47060154, 1500, "DARK", 1000, "Nothing can stop the mad attack of this powerful creature.", "normal", 4, "Mystic Clown", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/mystic-clown-4014" },
                    { 48365709, 1700, "EARTH", 1200, "A silent and deadly warrior specializing in assassinations.", "normal", 5, "Ansatsu", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/ansatsu-4128" },
                    { 49218300, 1450, "DARK", 1200, "A slave of the dark arts, this sorcerer is a master of life-extinguishing spells.", "normal", 4, "Sorcerer of the Doomed", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/sorcerer-of-the-doomed-4199" },
                    { 49888191, 2400, "EARTH", 2000, "A monster so heavy that each step rocks the earth.", "normal", 7, "Garnecia Elefantis", "Beast-Warrior", "Normal Monster", "https://ygoprodeck.com/card/garnecia-elefantis-4252" },
                    { 50005633, 2000, "DARK", 1600, "A monster formed by the vengeful souls of those who passed away in battle.", "normal", 6, "Swordstalker", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/swordstalker-4259" },
                    { 50045299, null, null, null, "Change all face-up Dragon-Type monsters on the field to Defense Position, also they cannot change their battle positions.", "trap", null, "Dragon Capture Jar", "Continuous", "Trap Card", "https://ygoprodeck.com/card/dragon-capture-jar-4261" },
                    { 50152549, null, null, null, "A non Machine-Type monster equipped with this card cannot attack.", "spell", null, "Paralyzing Potion", "Equip", "Spell Card", "https://ygoprodeck.com/card/paralyzing-potion-4271" },
                    { 50913601, null, null, null, "All Dragon, Winged Beast, and Thunder monsters on the field gain 200 ATK/DEF.", "spell", null, "Mountain", "Field", "Spell Card", "https://ygoprodeck.com/card/mountain-4333" },
                    { 50930991, 1700, "LIGHT", 1000, "A dimensional drifter who not only practices sorcery, but is also a sword and martial arts master.", "normal", 4, "Neo the Magic Swordsman", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/neo-the-magic-swordsman-4336" },
                    { 51267887, null, null, null, "Equip only to a Dinosaur monster. It gains 300 ATK/DEF.", "spell", null, "Raise Body Heat", "Equip", "Spell Card", "https://ygoprodeck.com/card/raise-body-heat-4361" },
                    { 51275027, 0, "LIGHT", 100, "When this card is sent to the Graveyard as a result of battle, the Battle Phase for that turn ends immediately.", "effect", 1, "The Unhappy Maiden", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/the-unhappy-maiden-4362" },
                    { 51371017, 900, "WIND", 700, "FLIP: Inflict 500 damage to your opponent for each Spell and Trap Card on your opponent's side of the field.", "effect", 3, "Princess of Tsurugi", "Warrior", "Flip Effect Monster", "https://ygoprodeck.com/card/princess-of-tsurugi-4370" },
                    { 51482758, null, null, null, "Select 1 face-up Trap Card on the field and destroy it.", "spell", null, "Remove Trap", "Normal", "Spell Card", "https://ygoprodeck.com/card/remove-trap-4381" },
                    { 51828629, 1850, "LIGHT", 1500, "\"Guardian of the Labyrinth\" + \"Protector of the Throne\"", "fusion", 5, "Giltia the D. Knight", "Warrior", "Fusion Monster", "https://ygoprodeck.com/card/giltia-the-d-knight-4410" },
                    { 52097679, null, null, null, "Switch the original ATK and DEF of all face-up monsters currently on the field, until the end of this turn.", "spell", null, "Shield & Sword", "Normal", "Spell Card", "https://ygoprodeck.com/card/shield-sword-4436" },
                    { 53129443, null, null, null, "Destroy all monsters on the field.", "spell", null, "Dark Hole", "Normal", "Spell Card", "https://ygoprodeck.com/card/dark-hole-4525" },
                    { 53153481, 700, "EARTH", 1300, "A strange warrior who manipulates three deadly blades with both hands and his tail.", "normal", 3, "Armaill", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/armaill-4528" },
                    { 53293545, 700, "EARTH", 600, "A fire-breathing plant found growing near volcanoes.", "normal", 2, "Firegrass", "Plant", "Normal Monster", "https://ygoprodeck.com/card/firegrass-4542" },
                    { 53375573, 1200, "DARK", 800, "It's said that this King of the Netherworld once had the power to rule over the dark.", "normal", 3, "Dark King of the Abyss", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/dark-king-of-the-abyss-4548" },
                    { 54098121, 1000, "EARTH", 1500, "Each time you or your opponent Normal Summons or Flip Summons a monster, increase your Life Points by 500 points.", "effect", 4, "Mysterious Puppeteer", "Warrior", "Effect Monster", "https://ygoprodeck.com/card/mysterious-puppeteer-4605" },
                    { 54541900, 1500, "EARTH", 1200, "\"M-Warrior #1\" + \"M-Warrior #2\"", "fusion", 4, "Karbonala Warrior", "Warrior", "Fusion Monster", "https://ygoprodeck.com/card/karbonala-warrior-4647" },
                    { 54652250, 450, "EARTH", 600, "FLIP: Target 1 monster on the field; destroy it.", "effect", 2, "Man-Eater Bug", "Insect", "Flip Effect Monster", "https://ygoprodeck.com/card/man-eater-bug-4659" },
                    { 54752875, 2800, "LIGHT", 2100, "\"Thunder Dragon\" + \"Thunder Dragon\"", "fusion", 7, "Twin-Headed Thunder Dragon", "Thunder", "Fusion Monster", "https://ygoprodeck.com/card/twin-headed-thunder-dragon-4666" },
                    { 55144522, null, null, null, "Draw 2 cards.", "spell", null, "Pot of Greed", "Normal", "Spell Card", "https://ygoprodeck.com/card/pot-of-greed-4698" },
                    { 55291359, 1650, "DARK", 1300, "A warrior wizard adept in casting bone-chilling spells.", "normal", 5, "Succubus Knight", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/succubus-knight-4707" },
                    { 55444629, 1200, "WIND", 1000, "A minor dragon incapable of breathing fire.", "normal", 4, "Lesser Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/lesser-dragon-4721" },
                    { 55763552, 200, "FIRE", 1800, "FLIP: Destroy all face-up \"Dragon Capture Jar\"(s) on the field. If you destroy any, change all face-up Dragon-Type monsters on the field to Attack Position.", "effect", 3, "Dragon Piper", "Pyro", "Flip Effect Monster", "https://ygoprodeck.com/card/dragon-piper-4750" },
                    { 55784832, 1550, "DARK", 1300, "A strange fiend with long arms and razor-sharp talons.", "normal", 5, "Morinphen", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/morinphen-4752" },
                    { 55875323, 850, "EARTH", 800, "A non Zombie-Type monster attacking \"Electric Lizard\" cannot attack on its following turn.", "effect", 3, "Electric Lizard", "Thunder", "Effect Monster", "https://ygoprodeck.com/card/electric-lizard-4758" },
                    { 56283725, 700, "EARTH", 1400, "A massive, intelligent spider that traps enemies with webbing.", "normal", 3, "Kumootoko", "Insect", "Normal Monster", "https://ygoprodeck.com/card/kumootoko-4791" },
                    { 56342351, 1000, "EARTH", 500, "Specializing in combination attacks, this warrior uses magnetism to block an enemy's escape.", "normal", 3, "M-Warrior #1", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/m-warrior-1-4796" },
                    { 56830749, null, null, null, "Tribute 1 monster; make your opponent Tribute 1 monster (for no effect).", "spell", null, "Share the Pain", "Normal", "Spell Card", "https://ygoprodeck.com/card/share-the-pain-4840" },
                    { 56907389, 1750, "LIGHT", 1500, "\"Witch of the Black Forest\" + \"Lady of Faith\"", "fusion", 5, "Musician King", "Spellcaster", "Fusion Monster", "https://ygoprodeck.com/card/musician-king-4847" },
                    { 57305373, 900, "EARTH", 700, "A dinosaur with two deadly jaws, it stores electricity in its horn and releases high voltage bolts from the mouth on its back.", "normal", 3, "Two-Mouth Darkruler", "Dinosaur", "Normal Monster", "https://ygoprodeck.com/card/two-mouth-darkruler-4882" },
                    { 58192742, 300, "EARTH", 200, "This small but deadly creature is better off avoided.", "normal", 1, "Petit Moth", "Insect", "Normal Monster", "https://ygoprodeck.com/card/petit-moth-4952" },
                    { 58314394, 1500, "EARTH", 1000, "A surface battle robot that was once used for sea warfare.", "normal", 4, "Ground Attacker Bugroth", "Machine", "Normal Monster", "https://ygoprodeck.com/card/ground-attacker-bugroth-4960" },
                    { 58528964, 1000, "DARK", 800, "\"Skull Servant\" + \"Dissolverock\"", "fusion", 3, "Flame Ghost", "Zombie", "Fusion Monster", "https://ygoprodeck.com/card/flame-ghost-4976" },
                    { 58861941, 300, "WATER", 250, "This monster may attack your opponent's Life Points directly.", "effect", 1, "Ooguchi", "Aqua", "Effect Monster", "https://ygoprodeck.com/card/ooguchi-5007" },
                    { 59197169, null, null, null, "All Fiend and Spellcaster monsters on the field gain 200 ATK/DEF, also all Fairy monsters on the field lose 200 ATK/DEF.", "spell", null, "Yami", "Field", "Spell Card", "https://ygoprodeck.com/card/yami-5032" },
                    { 60862676, 2100, "FIRE", 1800, "Known to many as the \"Burning Executioner\", this monster is capable of burning enemies to cinders.", "normal", 6, "Flame Cerebrus", "Pyro", "Normal Monster", "https://ygoprodeck.com/card/flame-cerebrus-5163" },
                    { 61854111, null, null, null, "Equip only to a Warrior monster. It gains 300 ATK/DEF.", "spell", null, "Legendary Sword", "Equip", "Spell Card", "https://ygoprodeck.com/card/legendary-sword-5237" },
                    { 62340868, 2400, "WIND", 2200, "During damage calculation in your opponent's turn, if this card is being attacked: You can target the attacking monster; make that target's ATK 0 during damage calculation only (this is a Quick Effect). This effect can only be used once while this card is face-up on the field.", "effect", 7, "Kazejin", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/kazejin-5273" },
                    { 63102017, null, null, null, "Select 1 Defense Position monster on your opponent's side of the field and change it to Attack Position.", "spell", null, "Stop Defense", "Normal", "Spell Card", "https://ygoprodeck.com/card/stop-defense-5328" },
                    { 63308047, 1200, "DARK", 1300, "Known as a swamp dweller, this creature is a minion of the dark forces.", "normal", 4, "Terra the Terrible", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/terra-the-terrible-5348" },
                    { 64501875, 1450, "EARTH", 1000, "Confuses enemy monsters with a noise that is harsh to the ears.", "normal", 4, "Hibikime", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/hibikime-5446" },
                    { 66602787, 600, "DARK", 1500, "This clown appears from nowhere and executes very strange moves to avoid enemy attacks.", "normal", 3, "Saggi the Dark Clown", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/saggi-the-dark-clown-5591" },
                    { 66672569, 1600, "DARK", 0, "A dragon revived by sorcery. Its breath is highly corrosive.", "normal", 3, "Dragon Zombie", "Zombie", "Normal Monster", "https://ygoprodeck.com/card/dragon-zombie-5598" },
                    { 66788016, null, null, null, "Destroy the 1 face-up monster your opponent controls that has the lowest ATK (your choice, if tied).", "spell", null, "Fissure", "Normal", "Spell Card", "https://ygoprodeck.com/card/fissure-5609" },
                    { 66889139, 2600, "WIND", 2100, "\"Gaia The Fierce Knight\" + \"Curse of Dragon\"", "fusion", 7, "Gaia the Dragon Champion", "Dragon", "Fusion Monster", "https://ygoprodeck.com/card/gaia-the-dragon-champion-5618" },
                    { 67494157, 1600, "EARTH", 1400, "This weakened dragon can no longer fly, but is still a deadly force to be reckoned with.", "normal", 5, "Crawling Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/crawling-dragon-5674" },
                    { 67629977, 500, "LIGHT", 700, "All LIGHT monsters on the field gain 500 ATK, also all DARK monsters on the field lose 400 ATK.", "effect", 2, "Hoshiningen", "Fairy", "Effect Monster", "https://ygoprodeck.com/card/hoshiningen-5682" },
                    { 67724379, 1500, "DARK", 1200, "A vicious, fire-breathing dragon whose wicked flame corrupts the souls of its victims.", "normal", 4, "Koumori Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/koumori-dragon-5690" },
                    { 68005187, null, null, null, "Target 1 monster your opponent controls; this turn, if you Tribute a monster, you must Tribute that target, as if you controlled it. You cannot conduct your Battle Phase the turn you activate this card.", "spell", null, "Soul Exchange", "Normal", "Spell Card", "https://ygoprodeck.com/card/soul-exchange-5715" },
                    { 68516705, 1300, "EARTH", 1550, "Half man and half horse, this monster is known for its extreme speed.", "normal", 4, "Mystic Horseman", "Beast", "Normal Monster", "https://ygoprodeck.com/card/mystic-horseman-5759" },
                    { 68658728, 600, "FIRE", 550, "All FIRE monsters on the field gain 500 ATK. All WATER monsters on the field lose 400 ATK.", "effect", 2, "Little Chimera", "Beast", "Effect Monster", "https://ygoprodeck.com/card/little-chimera-5769" },
                    { 68846917, 800, "EARTH", 1200, "Protected by a solid body of rock, this monster throws a bone-shattering punch.", "normal", 3, "Rock Ogre Grotto #1", "Rock", "Normal Monster", "https://ygoprodeck.com/card/rock-ogre-grotto-1-5787" },
                    { 69455834, 2000, "DARK", 1530, "Wields the power of darkness to destroy its enemies.", "normal", 5, "King of Yamimakai", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/king-of-yamimakai-5840" },
                    { 69572024, 1350, "WATER", 800, "This monster captures other fish with its long tongue and sucks the energy out of them.", "normal", 4, "Tongyo", "Fish", "Normal Monster", "https://ygoprodeck.com/card/tongyo-5850" },
                    { 70138455, 800, "FIRE", 900, "You can only activate this effect during your Standby Phase. Tribute this face-up card to select and destroy 2 face-up monsters with an ATK 1000 or less.", "effect", 3, "Blast Juggler", "Machine", "Effect Monster", "https://ygoprodeck.com/card/blast-juggler-5903" },
                    { 70681994, 1200, "WIND", 900, "\"Armaill\" + \"One-Eyed Shield Dragon\"", "fusion", 3, "Dragoness the Wicked Knight", "Warrior", "Fusion Monster", "https://ygoprodeck.com/card/dragoness-the-wicked-knight-5939" },
                    { 70781052, 2500, "DARK", 1200, "A fiend with dark powers for confusing the enemy. Among the Fiend-Type monsters, this monster boasts considerable force.\n\n(This card is always treated as an \"Archfiend\" card.)", "normal", 6, "Summoned Skull", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/summoned-skull-5941" },
                    { 70903634, 200, "DARK", 300, "A forbidden right arm sealed by magic. Whosoever breaks this seal will know infinite power.", "normal", 1, "Right Arm of the Forbidden One", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/right-arm-of-the-forbidden-one-5956" },
                    { 71107816, 1800, "DARK", 1000, "When this card inflicts Battle Damage to your opponent, your opponent draws 2 cards.", "effect", 4, "The Bistro Butcher", "Fiend", "Effect Monster", "https://ygoprodeck.com/card/the-bistro-butcher-5976" },
                    { 71407486, 1300, "FIRE", 1000, "A malevolent creature wrapped in flames that attacks enemies with intense fire.", "normal", 4, "Fireyarou", "Pyro", "Normal Monster", "https://ygoprodeck.com/card/fireyarou-5994" },
                    { 71625222, 500, "LIGHT", 400, "Once per turn: You can toss a coin and call it. If you call it right, destroy all monsters your opponent controls. If you call it wrong, destroy as many monsters you control as possible, and if you do, take damage equal to half the total ATK those destroyed monsters had while face-up on the field.", "effect", 2, "Time Wizard", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/time-wizard-6017" },
                    { 72302403, null, null, null, "After this card's activation, it remains on the field, but you must destroy it during the End Phase of your opponent's 3rd turn. When this card is activated: If your opponent controls a face-down monster, flip all monsters they control face-up. While this card is face-up on the field, your opponent's monsters cannot declare an attack.", "spell", null, "Swords of Revealing Light", "Normal", "Spell Card", "https://ygoprodeck.com/card/swords-of-revealing-light-6068" },
                    { 72842870, 1200, "WIND", 1400, "Capable of firing cannonballs from its mouth for long-range attacks, this creature is particularly effective in mountain battles.", "normal", 4, "Tyhone", "Winged Beast", "Normal Monster", "https://ygoprodeck.com/card/tyhone-6111" },
                    { 72892473, null, null, null, "Both players discard as many cards as possible from their hands, then each player draws the same number of cards they discarded.", "spell", null, "Card Destruction", "Normal", "Spell Card", "https://ygoprodeck.com/card/card-destruction-6117" },
                    { 73051941, 1300, "EARTH", 1600, "Appears from underground and attacks with long, snake-like tentacles.", "normal", 5, "Sand Stone", "Rock", "Normal Monster", "https://ygoprodeck.com/card/sand-stone-6133" },
                    { 73134082, null, null, null, "Inflict 600 points of damage to your opponent's Life Points.", "spell", null, "Final Flame", "Normal", "Spell Card", "https://ygoprodeck.com/card/final-flame-6140" },
                    { 73481154, 1500, "EARTH", 1000, "A golem with a massive right hand for crushing its victims.", "normal", 4, "Destroyer Golem", "Rock", "Normal Monster", "https://ygoprodeck.com/card/destroyer-golem-6168" },
                    { 74677422, 2400, "DARK", 2000, "''A ferocious dragon with a deadly attack.''", "normal", 7, "Red-Eyes Black Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/red-eyes-black-dragon-6276" },
                    { 74703140, 2100, "WIND", 1800, "\"Blue-Winged Crown\" + \"Niwatori\"", "fusion", 6, "Punished Eagle", "Winged Beast", "Fusion Monster", "https://ygoprodeck.com/card/punished-eagle-6283" },
                    { 75356564, 600, "WIND", 700, "A very small dragon known for its vicious attacks.", "normal", 2, "Petit Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/petit-dragon-6337" },
                    { 75376965, 1200, "WATER", 900, "A beautiful mermaid that lures voyagers to a watery grave.", "normal", 3, "Enchanting Mermaid", "Fish", "Normal Monster", "https://ygoprodeck.com/card/enchanting-mermaid-6343" },
                    { 75499502, 1200, "EARTH", 1000, "A deadly duo consisting of a beast master and its loyal servant.", "normal", 4, "Master & Expert", "Beast", "Normal Monster", "https://ygoprodeck.com/card/master-expert-6355" },
                    { 76103675, null, null, null, "Inflict 200 points of damage to your opponent's Life Points.", "spell", null, "Sparks", "Normal", "Spell Card", "https://ygoprodeck.com/card/sparks-6407" },
                    { 76184692, 1200, "EARTH", 1000, "A one-eyed behemoth with thick, powerful arms made for delivering punishing blows.", "normal", 4, "Hitotsu-Me Giant", "Beast-Warrior", "Normal Monster", "https://ygoprodeck.com/card/hitotsu-me-giant-6411" },
                    { 76211194, 800, "DARK", 400, "An eyeball fiend created by a servant of the wicked, it uses \"Dark Blasts\" to blow away its enemies.", "normal", 2, "Meda Bat", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/meda-bat-6414" },
                    { 76446915, 1350, "DARK", 1000, "This monster hides in a saucer and only appears when executing an attack.", "normal", 4, "Disk Magician", "Machine", "Normal Monster", "https://ygoprodeck.com/card/disk-magician-6433" },
                    { 76812113, 1300, "WIND", 1400, "This human-shaped animal with wings is beautiful to watch but deadly in battle.", "normal", 4, "Harpie Lady", "Winged Beast", "Normal Monster", "https://ygoprodeck.com/card/harpie-lady-6464" },
                    { 77007920, null, null, null, "Equip only to an Insect monster. It gains 300 ATK/DEF.", "spell", null, "Laser Cannon Armor", "Equip", "Spell Card", "https://ygoprodeck.com/card/laser-cannon-armor-6480" },
                    { 77027445, null, null, null, "Equip only to an Aqua monster. It gains 300 ATK/DEF.", "spell", null, "Power of Kaishin", "Equip", "Spell Card", "https://ygoprodeck.com/card/power-of-kaishin-6482" },
                    { 77414722, null, null, null, "When a Spell Card is activated: Discard 1 card; negate the activation, and if you do, destroy it.", "trap", null, "Magic Jammer", "Counter", "Trap Card", "https://ygoprodeck.com/card/magic-jammer-6510" },
                    { 77622396, null, null, null, "Until the End Phase, all effects that add or subtract ATK or DEF are reversed. (Additions now subtract, and subtractions now add, instead. Multiplications and divisions, including halving/doubling, are not affected.)", "trap", null, "Reverse Trap", "Normal", "Trap Card", "https://ygoprodeck.com/card/reverse-trap-6533" },
                    { 77827521, 1300, "DARK", 900, "This fiend passes judgment on enemies that are locked in coffins.", "normal", 4, "Trial of Nightmare", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/trial-of-nightmare-6548" },
                    { 78010363, 1100, "DARK", 1200, "If this card is sent from the field to the GY: Add 1 monster with 1500 or less DEF from your Deck to your hand, but you cannot activate cards, or the effects of cards, with that name for the rest of this turn. You can only use this effect of \"Witch of the Black Forest\" once per turn.", "effect", 4, "Witch of the Black Forest", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/witch-of-the-black-forest-6561" },
                    { 78780140, 1500, "EARTH", 1800, "A guardian of the woods, this massive tree is believed to be immortal.", "normal", 5, "Trent", "Plant", "Normal Monster", "https://ygoprodeck.com/card/trent-6617" },
                    { 79759861, null, null, null, "Discard 1 card, then target 1 monster on the field; destroy it.", "spell", null, "Tribute to the Doomed", "Normal", "Spell Card", "https://ygoprodeck.com/card/tribute-to-the-doomed-6685" },
                    { 80141480, 1600, "EARTH", 1400, "This monster feeds on whatever it catches in its web.", "normal", 5, "Hunter Spider", "Insect", "Normal Monster", "https://ygoprodeck.com/card/hunter-spider-6718" },
                    { 80604092, null, null, null, "During your Main Phase or your opponent's Battle Phase: You can pay 500 Life Points; immediately after this effect resolves, Normal Summon/Set 1 monster.", "trap", null, "Ultimate Offering", "Continuous", "Trap Card", "https://ygoprodeck.com/card/ultimate-offering-6761" },
                    { 80741828, 550, "DARK", 500, "As long as this card remains face-up on the field, increase the ATK of all DARK monsters by 500 points and decrease the ATK of all LIGHT monsters by 400 points.", "effect", 2, "Witch's Apprentice", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/witch-s-apprentice-6772" },
                    { 80770678, 800, "LIGHT", 2000, "A spirit that soothes the soul with the music of its heavenly harp.", "normal", 4, "Spirit of the Harp", "Fairy", "Normal Monster", "https://ygoprodeck.com/card/spirit-of-the-harp-6776" },
                    { 81057959, 1300, "EARTH", 1100, "Gifted with the power of dragons, this warrior wields a sword created from a dragon's fang.", "normal", 4, "D. Human", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/d-human-6804" },
                    { 81386177, 1650, "WATER", 1700, "This is one sea creature whose wrath is something monsters fear to face.", "normal", 5, "Bottom Dweller", "Fish", "Normal Monster", "https://ygoprodeck.com/card/bottom-dweller-6834" },
                    { 81480461, 2600, "DARK", 2200, "Once per turn: You can target 1 monster your opponent controls; toss a coin 3 times and destroy it if at least 2 of the results are heads.", "effect", 7, "Barrel Dragon", "Machine", "Effect Monster", "https://ygoprodeck.com/card/barrel-dragon-6840" },
                    { 81820689, null, null, null, "Select and see 1 card in your opponent's hand.", "spell", null, "The Inexperienced Spy", "Normal", "Spell Card", "https://ygoprodeck.com/card/the-inexperienced-spy-6868" },
                    { 82542267, null, null, null, "Select up to 2 Monster Card(s) from your opponent's Graveyard. Remove the selected card(s) from play.", "spell", null, "Gravedigger Ghoul", "Normal", "Spell Card", "https://ygoprodeck.com/card/gravedigger-ghoul-6937" },
                    { 83225447, null, null, null, "The equipped monster gains 700 ATK. During each of your Standby Phases, the equipped monster loses 200 ATK.", "spell", null, "Stim-Pack", "Equip", "Spell Card", "https://ygoprodeck.com/card/stim-pack-6983" },
                    { 83464209, 800, "EARTH", 1000, "A monstrous sheep with a long tail for hypnotizing enemies.", "normal", 3, "Mystical Sheep #2", "Beast", "Normal Monster", "https://ygoprodeck.com/card/mystical-sheep-2-7006" },
                    { 83764719, null, null, null, "Target 1 monster in either GY; Special Summon it.", "spell", null, "Monster Reborn", "Normal", "Spell Card", "https://ygoprodeck.com/card/monster-reborn-7027" },
                    { 83887306, null, null, null, "Select and destroy 2 of your monsters and 1 of your opponent's monsters.", "trap", null, "Two-Pronged Attack", "Normal", "Trap Card", "https://ygoprodeck.com/card/two-pronged-attack-7035" },
                    { 84257640, null, null, null, "Increase your Life Points by 1000 points.", "spell", null, "Dian Keto the Cure Master", "Normal", "Spell Card", "https://ygoprodeck.com/card/dian-keto-the-cure-master-7065" },
                    { 84686841, 1000, "DARK", 900, "A fiend that dwells in a blinding curtain of smoke.", "normal", 3, "King Fog", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/king-fog-7102" },
                    { 84926738, 1500, "LIGHT", 1300, "FLIP: Increase your Life Points by 3000 points. When this card is sent from the field to the Graveyard, you lose 5000 Life Points.", "effect", 4, "The Immortal of Thunder", "Thunder", "Flip Effect Monster", "https://ygoprodeck.com/card/the-immortal-of-thunder-7123" },
                    { 85309439, 1000, "LIGHT", 1000, "The Sun and the North Wind join hands to deliver a devastating combination of heat and gale-force winds.", "normal", 3, "Ray & Temperature", "Fairy", "Normal Monster", "https://ygoprodeck.com/card/ray-temperature-7150" },
                    { 85326399, 1600, "WATER", 1300, "Using the spikes sprouting from its body, this creature stabs its opponents and floods them with electricity.", "normal", 5, "Spike Seadra", "Sea Serpent", "Normal Monster", "https://ygoprodeck.com/card/spike-seadra-7153" },
                    { 85602018, null, null, null, "If a monster on your side of the field was sent to your Graveyard this turn, you can Special Summon 1 monster with an ATK of 1500 points or less from your Deck once during this turn. Then shuffle your Deck.", "spell", null, "Last Will", "Normal", "Spell Card", "https://ygoprodeck.com/card/last-will-7174" },
                    { 85639257, 1200, "WATER", 2000, "A wizard of the waters that conjures a liquid wall to crush any enemies that oppose him.", "normal", 4, "Aqua Madoor", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/aqua-madoor-7176" },
                    { 85705804, 800, "WIND", 800, "A vicious bird that attacks from the skies with its whip-like tail.", "normal", 3, "Kurama", "Winged Beast", "Normal Monster", "https://ygoprodeck.com/card/kurama-7182" },
                    { 86088138, 1550, "LIGHT", 1650, "Frightening in appearance, this creature uses its large eyes and ears to keep track of any movement.", "normal", 5, "Ocubeam", "Fairy", "Normal Monster", "https://ygoprodeck.com/card/ocubeam-7210" },
                    { 86318356, null, null, null, "All Warrior and Beast-Warrior monsters on the field gain 200 ATK/DEF.", "spell", null, "Sogen", "Field", "Spell Card", "https://ygoprodeck.com/card/sogen-7232" },
                    { 86325596, 1550, "DARK", 800, "An aristocrat who wields a sword possessed by a malicious spirit that preys on the weak.", "normal", 4, "Baron of the Fiend Sword", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/baron-of-the-fiend-sword-7235" },
                    { 87322377, 2200, "FIRE", 2500, "A mechanical spider with rocket launchers capable of random fire.", "normal", 7, "Launcher Spider", "Machine", "Normal Monster", "https://ygoprodeck.com/card/launcher-spider-7308" },
                    { 87430998, null, null, null, "All Insect, Beast, Plant, and Beast-Warrior monsters on the field gain 200 ATK/DEF.", "spell", null, "Forest", "Field", "Spell Card", "https://ygoprodeck.com/card/forest-7316" },
                    { 87557188, 1500, "LIGHT", 1200, "FLIP: Reveal all face-down cards on the field (Flip Effects are not activated), then return them to their original positions.", "effect", 4, "The Stern Mystic", "Spellcaster", "Flip Effect Monster", "https://ygoprodeck.com/card/the-stern-mystic-7326" },
                    { 87564352, 1500, "DARK", 800, "A dragon that dwells in the depths of darkness, its vulnerability lies in its poor eyesight.", "normal", 4, "Blackland Fire Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/blackland-fire-dragon-7327" },
                    { 87756343, 500, "EARTH", 400, "This monster cannot be Normal Summoned or Set. This card can only be Special Summoned by Tributing \"Petit Moth\" during your 2nd turn after \"Petit Moth\" has been equipped with \"Cocoon of Evolution\".", "effect", 2, "Larvae Moth", "Insect", "Effect Monster", "https://ygoprodeck.com/card/larvae-moth-7341" },
                    { 87796900, 1400, "WIND", 1200, "A dragon commonly found guarding mountain fortresses. Its signature attack is a sweeping dive from out of the blue.", "normal", 4, "Winged Dragon, Guardian of the Fortress #1", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/winged-dragon-guardian-of-the-fortress-1-7345" },
                    { 88279736, null, null, null, "Each time a monster you control inflicts Battle Damage to your opponent, your opponent discards 1 random card.", "trap", null, "Robbin' Goblin", "Continuous", "Trap Card", "https://ygoprodeck.com/card/robbin-goblin-7383" },
                    { 88819587, 1200, "WIND", 700, "Much more than just a child, this dragon is gifted with untapped power.", "normal", 3, "Baby Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/baby-dragon-7424" },
                    { 88979991, 1200, "WIND", 1000, "A huge bee with exceptional strength that's particularly dangerous in a swarm.", "normal", 4, "Killer Needle", "Insect", "Normal Monster", "https://ygoprodeck.com/card/killer-needle-7434" },
                    { 89091579, 500, "EARTH", 700, "Usually found traveling in swarms, this creature's ideal environment is the forest.", "normal", 2, "Basic Insect", "Insect", "Normal Monster", "https://ygoprodeck.com/card/basic-insect-7439" },
                    { 89112729, 1800, "EARTH", 1400, "\"Blast Juggler\" + \"Two-Headed King Rex\"", "fusion", 5, "Cyber Saurus", "Machine", "Fusion Monster", "https://ygoprodeck.com/card/cyber-saurus-7442" },
                    { 89272878, 1000, "EARTH", 1200, "A monster that guards the entrance to the Netherworld.", "normal", 4, "Guardian of the Labyrinth", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/guardian-of-the-labyrinth-7458" },
                    { 89494469, 1300, "DARK", 1100, "A fiend said to dwell in the world of dreams, it attacks enemies in their sleep.", "normal", 4, "Dark Titan of Terror", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/dark-titan-of-terror-7473" },
                    { 89631139, 3000, "LIGHT", 2500, "This legendary dragon is a powerful engine of destruction. Virtually invincible, very few have faced this awesome creature and lived to tell the tale.", "normal", 8, "Blue-Eyes White Dragon", "Dragon", "Normal Monster", "https://ygoprodeck.com/card/blue-eyes-white-dragon-7485" },
                    { 90219263, null, null, null, "If \"Harpie Lady\" is on the field: Special Summon 1 \"Harpie Lady\" or \"Harpie Lady Sisters\" from your hand or Deck.", "spell", null, "Elegant Egotist", "Normal", "Spell Card", "https://ygoprodeck.com/card/elegant-egotist-7533" },
                    { 90357090, 1200, "EARTH", 800, "A snow wolf that's beautiful to the eye, but absolutely vicious in battle.", "normal", 3, "Silver Fang", "Beast", "Normal Monster", "https://ygoprodeck.com/card/silver-fang-7545" },
                    { 90963488, 800, "DARK", 700, "A child-like creature that controls a sleep fiend to beckon enemies into eternal slumber.", "normal", 3, "Nemuriko", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/nemuriko-7600" },
                    { 91152256, 1400, "EARTH", 1200, "An elf who learned to wield a sword, he baffles enemies with lightning-swift attacks.", "normal", 4, "Celtic Guardian", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/celtic-guardian-7610" },
                    { 91595718, null, null, null, "A Spellcaster-Type monster equipped with this card increases its ATK and DEF by 300 points.", "spell", null, "Book of Secret Arts", "Equip", "Spell Card", "https://ygoprodeck.com/card/book-of-secret-arts-7637" },
                    { 91939608, 1600, "LIGHT", 1000, "A deadly doll gifted with mystical power, it is particularly powerful when attacking against dark forces.", "normal", 4, "Rogue Doll", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/rogue-doll-7666" },
                    { 92731455, 500, "EARTH", 1000, "Specializing in combination attacks, this warrior is equipped with a tough, magnetically coated armor.", "normal", 3, "M-Warrior #2", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/m-warrior-2-7720" },
                    { 93221206, 1450, "LIGHT", 1200, "This elf is rumored to have lived for thousands of years. He leads an army of spirits against his enemies.", "normal", 4, "Ancient Elf", "Spellcaster", "Normal Monster", "https://ygoprodeck.com/card/ancient-elf-7760" },
                    { 93553943, 800, "EARTH", 600, "Man-eating plant with poison feelers for attacking enemies.", "normal", 2, "Man Eater", "Plant", "Normal Monster", "https://ygoprodeck.com/card/man-eater-7787" },
                    { 93889755, 1350, "DARK", 1400, "When this card is changed from Defense Position to Attack Position, return 1 monster on your opponent's side of the field to the owner's hand.", "effect", 4, "Crass Clown", "Fiend", "Effect Monster", "https://ygoprodeck.com/card/crass-clown-7810" },
                    { 93900406, 1250, "EARTH", 800, "A player controlling this monster loses 300 Life Points during each of his/her Standby Phases when this card is face-up on the field. Control of this card is shifted to your opponent by paying 500 Life Points at your own End Phase.", "effect", 3, "Mushroom Man #2", "Warrior", "Effect Monster", "https://ygoprodeck.com/card/mushroom-man-2-7813" },
                    { 94675535, 800, "EARTH", 1000, "A fast-moving, bird-like creature that strangles opposing monsters with its long, thin arms.", "normal", 3, "Larvas", "Beast", "Normal Monster", "https://ygoprodeck.com/card/larvas-7876" },
                    { 94773007, 2200, "EARTH", 100, "When this card declares an attack: Toss a coin and call it. If you call it wrong, lose half your Life Points.", "effect", 4, "Jirai Gumo", "Insect", "Effect Monster", "https://ygoprodeck.com/card/jirai-gumo-7886" },
                    { 94905343, 2000, "EARTH", 1700, "\"Battle Ox\" + \"Mystic Horseman\"", "fusion", 6, "Rabid Horseman", "Beast-Warrior", "Fusion Monster", "https://ygoprodeck.com/card/rabid-horseman-7898" },
                    { 95727991, 1000, "WATER", 2000, "Once per turn: You can Tribute 1 monster; inflict damage to your opponent equal to half the Tributed monster's ATK on the field.", "effect", 5, "Catapult Turtle", "Aqua", "Effect Monster", "https://ygoprodeck.com/card/catapult-turtle-7973" },
                    { 95952802, 1800, "EARTH", 1400, "\"Silver Fang\" + \"Darkworld Thorns\"", "fusion", 5, "Flower Wolf", "Beast", "Fusion Monster", "https://ygoprodeck.com/card/flower-wolf-7989" },
                    { 96851799, 600, "FIRE", 500, "An intensely hot flame creature that rams anything standing in its way.", "normal", 2, "Hinotama Soul", "Pyro", "Normal Monster", "https://ygoprodeck.com/card/hinotama-soul-8054" },
                    { 97360116, 1000, "DARK", 500, "The speed of this warrior creates an intense vacuum that can slice through a monster's hide.", "normal", 3, "Unknown Warrior of Fiend", "Warrior", "Normal Monster", "https://ygoprodeck.com/card/unknown-warrior-of-fiend-8096" },
                    { 97590747, 1800, "DARK", 1000, "A genie of the lamp that is at the beck and call of its master.", "normal", 4, "La Jinn the Mystical Genie of the Lamp", "Fiend", "Normal Monster", "https://ygoprodeck.com/card/la-jinn-the-mystical-genie-of-the-lamp-8115" },
                    { 98049915, 400, "DARK", 300, "This monster can attack your opponent's Life Points directly.", "effect", 1, "Mystic Lamp", "Spellcaster", "Effect Monster", "https://ygoprodeck.com/card/mystic-lamp-8148" },
                    { 98069388, null, null, null, "When a monster(s) would be Summoned: Tribute 1 monster; negate the Summon, and if you do, destroy that monster(s).", "trap", null, "Horn of Heaven", "Counter", "Trap Card", "https://ygoprodeck.com/card/horn-of-heaven-8149" },
                    { 98252586, null, null, null, "Increase the ATK and DEF of a Winged Beast-Type monster equipped with this card by 300 points.", "spell", null, "Follow Wind", "Equip", "Spell Card", "https://ygoprodeck.com/card/follow-wind-8163" },
                    { 98374133, null, null, null, "An EARTH monster equipped with this card increases its ATK by 400 points and decreases its DEF by 200 points.", "spell", null, "Invigoration", "Equip", "Spell Card", "https://ygoprodeck.com/card/invigoration-8174" },
                    { 98434877, 2500, "WATER", 2400, "During damage calculation in your opponent's turn, if this card is being attacked: You can target the attacking monster; make that target's ATK 0 during damage calculation only (this is a Quick Effect). This effect can only be used once while this card is face-up on the field.", "effect", 7, "Suijin", "Aqua", "Effect Monster", "https://ygoprodeck.com/card/suijin-8179" },
                    { 98495314, null, null, null, "The equipped monster gains 500 ATK/DEF. If this card is sent to your GY: Place it on top of your Deck.", "spell", null, "Sword of Deep-Seated", "Equip", "Spell Card", "https://ygoprodeck.com/card/sword-of-deep-seated-8185" },
                    { 98818516, 1200, "EARTH", 1000, "A savage beast that carries a big bamboo stick for beating down its enemies.", "normal", 4, "Frenzied Panda", "Beast", "Normal Monster", "https://ygoprodeck.com/card/frenzied-panda-8207" },
                    { 99551425, 2400, "DARK", 2400, "\"Giga-Tech Wolf\" + \"Cannon Soldier\"", "fusion", 7, "Labyrinth Tank", "Machine", "Fusion Monster", "https://ygoprodeck.com/card/labyrinth-tank-8266" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IdentityUserId", "LastName", "Roles", "UserName" },
                values: new object[,]
                {
                    { 1, "101 Main St.", null, "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator", null, null },
                    { 2, "900 Willow Ave.", null, "Suzy", "4342d71c-3d92-49ea-9f84-8f3412b65679", "Bumpkin", null, null },
                    { 3, "133 W Elm St.", null, "Billy", "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05", "Mack", null, null },
                    { 4, "6161 Maple St.", null, "Lizzie", "b6d8aa7f-ae65-4feb-95ab-377d810bc270", "McGuire", null, null },
                    { 5, "775 N Spruce St.", null, "Macy", "7c8b955a-c256-4505-bf0f-468489633f5f", "Greene", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardImage_Cardid",
                table: "CardImage",
                column: "Cardid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeckCards_CardId",
                table: "DeckCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckCards_DeckId",
                table: "DeckCards",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCards_CardId",
                table: "FavoriteCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCards_UserId",
                table: "FavoriteCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCards_CardId",
                table: "UserCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCards_UserId",
                table: "UserCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDecks_UserId",
                table: "UserDecks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CardImage");

            migrationBuilder.DropTable(
                name: "DeckCards");

            migrationBuilder.DropTable(
                name: "FavoriteCards");

            migrationBuilder.DropTable(
                name: "UserCards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UserDecks");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
