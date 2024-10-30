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

    [HttpGet("{cardId}")]
    [Authorize]
    public IActionResult GetCardById(int cardId)
    {
        try
        {
            Card foundCard = _dbContext.Cards.Include(c => c.card_images).FirstOrDefault(c => c.id == cardId);

            if (foundCard == null)
            {
                return NotFound($"No card found with given Id of {cardId}");
            }

            return Ok(foundCard);
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad Data: {ex}");
        }
    }


    [HttpGet("userCards/{userId}")]
    public IActionResult GetUserCardsByUserId(int userId)
    {
        try
        {
            List<UserCard> foundCards = _dbContext.UserCards.Include(userCard => userCard.Card).ThenInclude(card => card.card_images).Where(userCard => userCard.UserId == userId).ToList();

            if (foundCards == null)
            {
                return NotFound("No user cards found");
            }

            return Ok(foundCards);
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad Data: {ex}");
        }
    }

    [HttpPost("userCards/add/{cardId}/{userId}")]
    public IActionResult AddCardToFavorites(int cardId, int userId)
    {
        try
        {
            // Check if the UserCard already exists
            var existingUserCard = _dbContext.UserCards
                .FirstOrDefault(uc => uc.CardId == cardId && uc.UserId == userId);

            if (existingUserCard != null)
            {
                return Conflict($"Card with CardId={cardId} is already in the favorites for UserId={userId}.");
            }

            _dbContext.UserCards.Add(new UserCard
            {
                UserId = userId,
                CardId = cardId
            }
            );
            _dbContext.SaveChanges();
            return Ok(new { UserId = userId, CardId = cardId});
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad Request - Exception: {ex}");
        }
    }


    [HttpDelete("userCards/remove/{cardId}/{userId}")]
    public IActionResult RemoveCardFromMyDeck(int cardId, int userId)
    {
        try
        {
            UserCard foundUserCard = _dbContext.UserCards.FirstOrDefault(uc => uc.CardId == cardId && uc.UserId == userId);

            if (foundUserCard == null)
            {
                return NotFound($"No Card found with matching CardId={cardId} and UserId={userId}");
            }
            _dbContext.UserCards.Remove(foundUserCard);
            _dbContext.SaveChanges();

            return Ok(foundUserCard);
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad Request - Exception: {ex}");
        }
    }
}