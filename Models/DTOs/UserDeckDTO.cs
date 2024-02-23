using YuGiOh.Models;
using YuGiOh.Models.DTOs;

public class UserDeckDTO
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int UserId { get; set; }

    public UserProfileDTO User { get; set; }

    public List<DeckCardDTO> DeckCards { get; set; }

}