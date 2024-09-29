using Domain.Access.Interfaces;
using Domain.Entities.Movie;
using Domain.Entities.Theater;
using Exception;
using Logic.Interfaces;

namespace Logic;

public class MovieLogic : IMovieLogic
{
    private readonly IEntityFactory _entityFactory;
    
    public MovieLogic(IEntityFactory entityFactory)
    {
        _entityFactory = entityFactory;
    }

    public MovieTicket PurchaseTicket(int theaterId, int movieId, DateTime showingTime)
    {
        var theaterTickets = _entityFactory.Instantiate<TheaterTicket>();
        var theater = _entityFactory.Instantiate<Theater>();
        var ticket = _entityFactory.Instantiate<MovieTicket>();
        var movie = _entityFactory.Instantiate<Movie>();

        movie = movie.Get(movieId);
        if(DateTime.Now >= showingTime.AddMinutes(movie.RunTime)) throw new WarningException("This Movie Showing has already ended");

        theater = theater.Get(theaterId);
        var theaterTicketList = theaterTickets.GetAll(theaterId)
            .Where(x => x.MovieId == movieId && x.ShowingTime == showingTime)
            .ToList();
        
        if (theater.Capacity < theaterTicketList.Count + 1) throw new WarningException("The theater has no remaining tickets available");

        ticket.MovieId = movieId;
        ticket.TheaterId = theaterId;
        ticket.ShowingTime = showingTime;
        ticket.PurchasedDate = DateTime.Now;
        
        return ticket.Create();
    }

    
    public bool CheckTicket(int ticketId)
    {
        var movieTicket = _entityFactory.Instantiate<MovieTicket>();
        var movie = _entityFactory.Instantiate<Movie>();
        
        movieTicket = movieTicket.Get(ticketId);
        movie = movie.Get(movieTicket.MovieId);
        
        if ((movieTicket.ShowingTime - DateTime.Now).Days >= 1)
            throw new WarningException("This ticket was for a day in the past");
        
        if(movieTicket.ShowingTime.AddSeconds(movie.RunTime / 2) <= DateTime.Now)
            throw new WarningException("This ticket is for a Movie that is past the admission time");

        if (movieTicket.Activated == false)
        {
            movieTicket.Activated = true;
            movieTicket.Update();            
        }
        
        return true;
    }
}