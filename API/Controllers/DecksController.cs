using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DecksController : ControllerBase
{
    private readonly IServiceManager _service;

    public DecksController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAllPublicDecks()
    {
        var decks = await _service.DeckService.GetPublicDecksAsync(false);

        return Ok(decks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDeck([FromBody] DeckForCreationDto deck)
    {
        var deckResponse = await _service.DeckService.CreateDeckAsync(deck, false);

        //return CreatedAtRoute("GetDeck", deckResponse);
        return Created();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteDeck(Guid id)
    {
        await _service.DeckService.DeleteDeckAsync(id, false);
        return NoContent();
    }
}