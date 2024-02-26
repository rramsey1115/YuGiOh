using System.ComponentModel.DataAnnotations;

namespace YuGiOh.Models.DTOs;

public class CardDTO 
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Type { get; set; }

    public string FrameType { get; set; }

    public string Desc { get; set; }

    public int Atk { get; set; }

    public int Def { get; set; }

    public int Level { get; set; }

    public string Race { get; set; }

    public string Attribute { get; set; }

    public string Ygoprodeck_url { get; set; }

    public List<CardImageDTO> card_images { get; set; }

}