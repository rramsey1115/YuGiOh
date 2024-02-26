using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using YuGiOh.Models;

namespace YuGiOh.Data;
public class YuGiOhDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<UserProfile> UserProfiles { get; set; }

    public DbSet<Card> Cards { get; set; }

    public DbSet<CardImage> CardImages { get; set; }

    public DbSet<UserDeck> UserDecks { get; set; }

    public DbSet<FavoriteCard> FavoriteCards { get; set; }

    public DbSet<DeckCard> DeckCards { get; set; }

    public DbSet<UserCard> UserCards { get; set; }

    public YuGiOhDbContext(DbContextOptions<YuGiOhDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Replace "path/to/your/file.json" with the actual path to your JSON file
        var jsonFilePath = "./Data/cardsData.json";
        
        // Read the contents of the JSON file
        var jsonContent = File.ReadAllText(jsonFilePath);

        // Deserialize JSON using System.Text.Json.JsonSerializer
        var data = System.Text.Json.JsonSerializer.Deserialize<List<Card>>(jsonContent);

        int cardCount = 0;
        foreach (var item in data)
        {
            cardCount++;

            modelBuilder.Entity<CardImage>().HasData(
                new CardImage
                {
                    id = cardCount,
                    image_url_small = item.card_images[0].image_url_small,
                    Cardid = item.id
                }
            );

            modelBuilder.Entity<Card>().HasData(
                new Card
                {
                    id = item.id,
                    name = item.name,
                    type = item.type,
                    frameType = item.frameType,
                    desc = item.desc,
                    atk = item.atk,
                    def = item.def,
                    level = item.level,
                    race = item.race,
                    attribute = item.attribute,
                    ygoprodeck_url = item.ygoprodeck_url
                }
            );

        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Admin",
                NormalizedName = "Admin"
            }
        );

        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Admin",
                Email = "admin@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "4342d71c-3d92-49ea-9f84-8f3412b65679",
                UserName = "User2",
                Email = "user2@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05",
                UserName = "User3",
                Email = "user3@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "b6d8aa7f-ae65-4feb-95ab-377d810bc270",
                UserName = "User4",
                Email = "user4@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "7c8b955a-c256-4505-bf0f-468489633f5f",
                UserName = "User5",
                Email = "user5@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            }
        );

        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Admina",
                LastName = "Strator",
                Address = "101 Main St."
            },
            new UserProfile
            {
                Id = 2,
                IdentityUserId = "4342d71c-3d92-49ea-9f84-8f3412b65679",
                FirstName = "Suzy",
                LastName = "Bumpkin",
                Address = "900 Willow Ave."
            },
            new UserProfile
            {
                Id = 3,
                IdentityUserId = "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05",
                FirstName = "Billy",
                LastName = "Mack",
                Address = "133 W Elm St."
            },
            new UserProfile
            {
                Id = 4,
                IdentityUserId = "b6d8aa7f-ae65-4feb-95ab-377d810bc270",
                FirstName = "Lizzie",
                LastName = "McGuire",
                Address = "6161 Maple St."
            },
            new UserProfile
            {
                Id = 5,
                IdentityUserId = "7c8b955a-c256-4505-bf0f-468489633f5f",
                FirstName = "Macy",
                LastName = "Greene",
                Address = "775 N Spruce St."
            }
        );

        SeedData(modelBuilder);
    }
}