using System.Text.Json;
using API.DTOs;
using API.Entities.Exceptions;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog.Config;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DecksController : ControllerBase
{
    private readonly IServiceManager _service;

    public DecksController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAllPublicDecks([FromQuery] DeckParameters deckParameters)
    {
        var pagedResult = await _service.DeckService.GetPublicDecksAsync(deckParameters, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.decks);
    }

    [HttpGet("{id:guid}", Name = "DeckById")]
    public async Task<IActionResult> GetDeck(Guid id)
    {
        var deck = await _service.DeckService.GetDeckById(id, User.Identity.Name, trackChanges: false);

        return Ok(deck);
    }

    [Authorize]
    [HttpGet("currentUser")]
    public async Task<IActionResult> GetDecksForCurrentUser([FromQuery] DeckParameters deckParameters)
    {
        var pagedResult = await _service.DeckService.GetDecksForCurrentUser(deckParameters, User.Identity.Name, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.decks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDeck([FromBody] DeckForCreationDto deck)
    {
        var createdDeck = await _service.DeckService.CreateDeckAsync(deck, User.Identity.Name, trackChanges: false);

        return CreatedAtRoute("DeckById", new { id = createdDeck.Id }, createdDeck);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteDeck(Guid id)
    {
        await _service.DeckService.DeleteDeckAsync(id, trackChanges: false);
        return NoContent();
    }
}