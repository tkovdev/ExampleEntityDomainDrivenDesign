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
        throw new NotImplementedException();
    }
}