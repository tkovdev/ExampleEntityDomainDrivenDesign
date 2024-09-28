using Data.Access;
using Domain.Access;
using Domain.Access.Interfaces;
using Domain.Entities.Movie;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IEntityAccess _entityAccess;

    public MoviesController(IEntityAccess entityAccess)
    {
        _entityAccess = entityAccess;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var res = _entityAccess.Get<MovieList>();
        return StatusCode(StatusCodes.Status200OK, res);
    }
}