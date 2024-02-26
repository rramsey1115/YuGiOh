using System.ComponentModel.DataAnnotations;

namespace YuGiOh.Models;

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

    public List<CardImage>? card_images { get; set; }

}