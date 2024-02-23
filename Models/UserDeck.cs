using YuGiOh.Models;

public class UserDeck 
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int UserId { get; set; }

    public UserProfile User { get; set; }

    public List<DeckCard> DeckCards { get; set; }

    
}