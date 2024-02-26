using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using YuGiOh.Data;

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
            return Ok(_dbContext.Cards.Select(c => c));
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad data: {ex}");
        }
    }
}