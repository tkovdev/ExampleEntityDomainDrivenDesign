using Data.Access;
using Domain.Access;
using Domain.Access.Interfaces;
using Domain.Entities.Movie;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IEntityFactory _entityFactory;
    private readonly IMovieLogic _movieLogic;

    public MoviesController(IEntityFactory entityFactory, IMovieLogic movieLogic)
    {
        _entityFactory = entityFactory;
        _movieLogic = movieLogic;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var instance = _entityFactory.Instantiate<MovieList>();
        var res = instance.Get();
        return StatusCode(StatusCodes.Status200OK, res);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id, [FromQuery] bool details = false)
    {
        if (details)
        {
            var instance = _entityFactory.Instantiate<Movie>();
            var res = instance.Get(id);
            return StatusCode(StatusCodes.Status200OK, res);    
        }
        else
        {
            var instance = _entityFactory.Instantiate<MovieList>();
            var res = instance.Get(id);
            return StatusCode(StatusCodes.Status200OK, res);
        }
    }
    
    [HttpGet("{id}/showings")]
    public IActionResult Get(int id)
    {
        var instance = _entityFactory.Instantiate<MovieShowing>();
        var res = instance.GetAll(id);
        return StatusCode(StatusCodes.Status200OK, res);
    }
    
    [HttpPost()]
    public IActionResult Create([FromBody] Movie movie)
    {
        var instance = _entityFactory.Instantiate(movie);
        var res = instance.Create();
        return StatusCode(StatusCodes.Status200OK, res);
    }
    
    [HttpPost("purchaseTicket")]
    public IActionResult PurchaseTicket([FromBody] MovieTicket ticket)
    {
        var res = _movieLogic.PurchaseTicket(ticket.TheaterId, ticket.MovieId, ticket.ShowingTime);
        return StatusCode(StatusCodes.Status200OK, res);
    }
    
    [HttpGet("checkTicket/{ticketId}")]
    public IActionResult PurchaseTicket([FromRoute] int ticketId)
    {
        var res = _movieLogic.CheckTicket(ticketId);
        return StatusCode(StatusCodes.Status200OK, res);
    }
}