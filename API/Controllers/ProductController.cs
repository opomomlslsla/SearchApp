using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/Products")]
[ApiController]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet("query")]
    public async Task<IActionResult> Query([FromQuery] string term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return BadRequest("Search term is required.");
        }

        var result = await mediator.Send(new GetProductsQuery(term));

        return Ok(result);
    }
}
