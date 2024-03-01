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

public class DeckController : ControllerBase
{
    private YuGiOhDbContext _dbContext;

    public DeckController(YuGiOhDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
    }

    [HttpGet("userId")]
    // [Authorize]
    public IActionResult GetUserDecks(int userId)
    {
        try
        {
            List<UserDeck> foundDecks = _dbContext.UserDecks
            .Include(u => u.DeckCards).ThenInclude(dc => dc.Card).ThenInclude(card => card.card_images)
            .Include(u => u.User)
            .Where(d => d.UserId == userId)
            .ToList();

            if (foundDecks == null) {
                return NotFound();
            }

            return Ok(foundDecks.Select(deck => {
                return new UserDeckDTO
                {
                    Id = deck.Id,
                    Name = deck.Name,
                    UserId = deck.UserId,
                    User = new UserProfileDTO
                    {
                        Id = deck.User.Id,
                        FirstName = deck.User.FirstName,
                        LastName = deck.User.LastName
                    },
                    DeckCards = deck.DeckCards.Select(dc => 
                    new DeckCardDTO
                    {
                        Id = dc.Id,
                        CardId = dc.CardId,
                        UserDeckId = dc.UserDeckId,
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
                            card_images = dc.Card.card_images.Select(ci =>
                            new CardImageDTO
                            {
                                Id = ci.id,
                                ImageUrl = ci.image_url_small,
                                Cardid = ci.Cardid
                            }).ToList()
                        }
                    }).ToList()
                };
            }).ToList());
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad data: {ex}");
        }
    }

    [HttpGet("deckId")]
    // [Authorize]
    public IActionResult GetCardsByDeckId(int DeckId)
    {
        try
        {
            List<UserDeck> foundDeck = _dbContext.UserDecks
            .Where(ud => ud.Id == DeckId)
            .Include(ud => ud.DeckCards).ThenInclude(dc => dc.Card)
            .Include(ud => ud.User)
            .ToList();

            if(foundDeck == null)
            {
                return NotFound("No deck with given Id");
            }

            return Ok(foundDeck);
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad data: {ex}");
        }
    }

    
}