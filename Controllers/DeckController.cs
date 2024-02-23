using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using YuGiOh.Data;

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

    [HttpGet]
    public IActionResult GetDecks()
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad data: {ex}");
        }
    }
}