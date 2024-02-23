using YuGiOh.Models.DTOs;

public class DeckCardDTO
{
    public int Id { get; set; }

    public int CardId { get; set; }

    public CardDTO Card { get; set; }

    public int DeckId { get; set; }

    public UserDeckDTO Deck { get; set; }

}