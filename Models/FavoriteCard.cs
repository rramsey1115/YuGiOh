using YuGiOh.Models;

public class FavoriteCard
{
    public int Id { get; set; }

    public int CardId { get; set; }

    public Card Card { get; set; }

    public int UserId { get; set; }

    public UserProfile User { get; set; }
}