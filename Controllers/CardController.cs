using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuGiOh.Data;
using YuGiOh.Models;
using YuGiOh.Models.DTOs;

namespace YuGiOh.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CardController : ControllerBase
{
    private YuGiOhDbContext _dbContext;

    public CardController(YuGiOhDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult GetAllCards()
    {
        try
        {
            List<CardDTO> Cards = _dbContext.Cards
            .OrderBy(c => c.name)
            .Include(c => c.card_images).Select(c => 
                new CardDTO
                {
                    Id = c.id,
                    Name = c.name,
                    Type = c.type,
                    FrameType = c.frameType,
                    Desc = c.desc,
                    Atk = c.atk,
                    Def = c.def,
                    Level = c.level,
                    Race = c.race,
                    Attribute = c.attribute,
                    Ygoprodeck_url = c.ygoprodeck_url,
                    card_images = c.card_images.Select(ci => new CardImageDTO
                    {
                        Id = ci.id,
                        ImageUrl = ci.image_url_small,
                        Cardid = ci.Cardid
                    }).ToList()
                }
            ).ToList();

            return Ok(Cards);
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad data: {ex}");
        }
    }

    [HttpGet("cardId")]
    // [Authorize]
    public IActionResult GetCardById(int cardId)
    {
        try
        {
            Card foundCard = _dbContext.Cards.Include(c => c.card_images).FirstOrDefault(c => c.id == cardId);

            if (foundCard == null)
            {
                return NotFound("No card found with given Id");
            }

            return Ok(foundCard);
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad Data: {ex}");
        }
    }
}