using YuGiOh.Models;

public class DeckCard
{
    public int Id { get; set; }

    public int CardId { get; set; }

    public Card Card { get; set; }

    public int DeckId { get; set; }

    public UserDeck Deck { get; set; }

}