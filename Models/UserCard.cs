using YuGiOh.Models;

public class UserCard
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public UserProfile User { get; set; }

    public int CardId { get; set; }

    public Card Card { get; set; }
}