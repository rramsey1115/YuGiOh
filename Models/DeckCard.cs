
using System.ComponentModel.DataAnnotations.Schema;
using YuGiOh.Models;

public class DeckCard
{
    public int Id { get; set; }

    [ForeignKey("Card")]
    public int CardId { get; set; }

    public Card? Card { get; set; }

    [ForeignKey("UserDeck")]
    public int UserDeckId { get; set; }

    public UserDeck? UserDeck { get; set; }
}