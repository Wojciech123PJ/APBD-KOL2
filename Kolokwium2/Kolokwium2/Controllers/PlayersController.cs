using Kolokwium2.Data;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public PlayersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    // HTTP GET http://localhost:5000/api/players/{id}/matches
    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayerMatches(int id)
    {
        if (id <= 0)
            return BadRequest("Id has to be greater than 0. ");
        try
        {
            var matches = await _dbService.GetPlayerMatches(id);
            return Ok(matches);
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
    }
    
    // HTTP GET http://localhost:5000/api/players
    [HttpPost]
    public async Task<IActionResult> AddPlayerMatches([FromBody] PlayerMatchInputDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            await _dbService.AddPlayerMatches(dto);
            return Created("", null);
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}