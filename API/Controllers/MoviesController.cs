using Domain.Entities.Movie;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly ICrudLogic _crudLogic;
    private readonly IMovieLogic _movieLogic;

    public MoviesController(ICrudLogic crudLogic, IMovieLogic movieLogic)
    {
        _crudLogic = crudLogic;
        _movieLogic = movieLogic;
    }

    [HttpGet]
    public IActionResult GetMovieList()
    {
        var res = _crudLogic.Get<MovieList>();
        return StatusCode(StatusCodes.Status200OK, res);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetMovieById([FromRoute] int id, [FromQuery] bool details = false)
    {
        if (details)
        {
            var res = _crudLogic.Get<Movie>(id);
            return StatusCode(StatusCodes.Status200OK, res);    
        }
        else
        {
            var res = _crudLogic.Get<MovieList>(id);
            return StatusCode(StatusCodes.Status200OK, res);
        }
    }
    
    [HttpGet("{id}/showings")]
    public IActionResult GetShowingsByMovieId(int id)
    {
        var res = _crudLogic.GetAll<MovieShowing>(id);
        return StatusCode(StatusCodes.Status200OK, res);
    }
    
    [HttpPost()]
    public IActionResult CreateMovie([FromBody] Movie movie)
    {
        var res = _crudLogic.Create(movie);
        return StatusCode(StatusCodes.Status200OK, res);
    }
    
    [HttpPost("purchaseTicket")]
    public IActionResult PurchaseTicket([FromBody] MovieTicket ticket)
    {
        var res = _movieLogic.PurchaseTicket(ticket.TheaterId, ticket.MovieId, ticket.ShowingTime);
        return StatusCode(StatusCodes.Status200OK, res);
    }
    
    [HttpGet("checkTicket/{ticketId}")]
    public IActionResult CheckTicket([FromRoute] int ticketId)
    {
        var res = _movieLogic.CheckTicket(ticketId);
        return StatusCode(StatusCodes.Status200OK, res);
    }
}