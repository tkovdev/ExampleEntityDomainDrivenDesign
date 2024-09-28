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
    
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id, [FromQuery] bool details = false)
    {
        if (details)
        {
            var res = _entityAccess.Get<Movie>(id);
            return StatusCode(StatusCodes.Status200OK, res);    
        }
        else
        {
            var res = _entityAccess.Get<MovieList>(id);
            return StatusCode(StatusCodes.Status200OK, res);
        }
    }
    
    [HttpGet("{id}/showings")]
    public IActionResult Get(int id)
    {
        var res = _entityAccess.GetAll<MovieShowing>(id);
        return StatusCode(StatusCodes.Status200OK, res);
    }
    
    [HttpPost()]
    public IActionResult Create([FromBody] Movie movie)
    {
        // var res = _movieLogic.CreateMovie(movie);
        return StatusCode(StatusCodes.Status200OK, null);
    }
    
    [HttpPost("purchaseTicket")]
    public IActionResult PurchaseTicket([FromBody] MovieTicket ticket)
    {
        // var res = _movieLogic.PurchaseTicket(ticket.TheaterId, ticket.MovieId, ticket.ShowingTime);
        return StatusCode(StatusCodes.Status200OK, null);
    }
    
    [HttpGet("checkTicket/{ticketId}")]
    public IActionResult PurchaseTicket([FromRoute] int ticketId)
    {
        // var res = _movieLogic.CheckTicket(ticketId);
        return StatusCode(StatusCodes.Status200OK, null);
    }
}