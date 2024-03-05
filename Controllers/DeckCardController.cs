
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuGiOh.Data;
using YuGiOh.Models.DTOs;

namespace YuGiOh.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DeckCardController : ControllerBase
{
    private YuGiOhDbContext _dbContext;

    public DeckCardController(YuGiOhDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
    }

    [HttpPost("cardId/deckId")]
    // [Authorize]
    public IActionResult AddCardToDeck(int deckId, int cardId)
    {
        try
        {

            DeckCard newDeckCard = new DeckCard
            {
                CardId = cardId,
                UserDeckId = deckId
            };

            _dbContext.DeckCards.Add(newDeckCard);
            _dbContext.SaveChanges();

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad Data: {ex}");
        }
    }

    [HttpGet("deckId")]
    // [Authorize]
    public IActionResult GetDeckCardsByDeckId(int deckId)
    {
        try
        {
            if(deckId < 1)
            {
                return BadRequest("DeckId must be an integer greater than 1");
            }

            var foundDeck = _dbContext.UserDecks.FirstOrDefault(ud => ud.Id == deckId);

            if(foundDeck == null)
            {
                return BadRequest("No deck found with given Id");
            }

            List<DeckCard> DeckCards = _dbContext.DeckCards
            .Include(dc => dc.Card).ThenInclude(c => c.card_images)
            .Where(dc => dc.UserDeckId == deckId)
            .ToList();

            return Ok(DeckCards.Select(dc => 
                new DeckCardDTO
                {
                    Id = dc.Id,
                    CardId = dc.CardId,
                    Card = new CardDTO
                    {
                        Id = dc.Card.id,
                        Name = dc.Card.name,
                        Type = dc.Card.type,
                        FrameType = dc.Card.frameType,
                        Desc = dc.Card.desc,
                        Atk = dc.Card.atk,
                        Def = dc.Card.def,
                        Level = dc.Card.level,
                        Race = dc.Card.race,
                        Attribute = dc.Card.attribute,
                        Ygoprodeck_url = dc.Card.ygoprodeck_url,
                        card_images = dc.Card.card_images.Select(ci => new CardImageDTO
                        {
                            Id = ci.id,
                            ImageUrl = ci.image_url_small,
                            Cardid = ci.Cardid
                        }).ToList()
                    },
                    UserDeckId = dc.UserDeckId
                }).ToList()
            );

        }
        catch (Exception ex)
        {
            return BadRequest($"Bad data: {ex}");
        }
    }

}