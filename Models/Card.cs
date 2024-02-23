using System.ComponentModel.DataAnnotations;

namespace YuGiOh.Models;

public class CardImage
{
    public int Id { get; set; }
    public string image_url_small { get; set; }
    public int Cardid { get; set; } // Foreign key
}

public class Card
{
    [Required]
    public int id { get; set; }

    [Required]
    public string name { get; set; }

    public string? type { get; set; }

    public string? frameType { get; set; }

    public string? desc { get; set; }

    public int? atk { get; set; }

    public int? def { get; set; }

    public int? level { get; set; }

    public string? race { get; set; }

    public string? attribute { get; set; }

    public string? ygoprodeck_url { get; set; }

    public CardImage CardImage { get; set; }

    public string imageUrl => CardImage.image_url_small;

}