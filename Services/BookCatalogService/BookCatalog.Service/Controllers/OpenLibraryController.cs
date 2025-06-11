using BookCatalog.Service.Models;
using BookCatalog.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OpenLibraryController(OpenLibraryClient client) : ControllerBase
{
    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] string? title = null,
        [FromQuery] string? author = null,
        [FromQuery] string? subject = null,
        [FromQuery] int page = 1,
        [FromQuery] int limit = 20,
        CancellationToken cancellationToken = default)
    {
        OpenLibrarySearchResult result = await client.SearchAsync(title, author, subject, page, limit, cancellationToken);
        return Ok(result);
    }
}
