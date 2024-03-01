

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YuGiOh.Data;

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

}