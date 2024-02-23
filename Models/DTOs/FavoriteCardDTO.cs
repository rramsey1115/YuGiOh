using YuGiOh.Models;
using YuGiOh.Models.DTOs;

public class FavoriteCardDTO
{
    public int Id { get; set; }

    public int CardId { get; set; }

    public CardDTO Card { get; set; }

    public int UserId { get; set; }

    public UserProfile User { get; set; }
}