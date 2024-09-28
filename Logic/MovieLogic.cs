using Domain.Access.Interfaces;
using Domain.Entities.Movie;
using Logic.Interfaces;

namespace Logic;

public class MovieLogic : IMovieLogic
{
    private readonly IEntityAccess _entityAccess;
    
    public MovieLogic(IEntityAccess entityAccess)
    {
        _entityAccess = entityAccess;
    }

    public MovieTicket PurchaseTicket(int theaterId, int movieId, DateTime showingTime)
    {
        throw new NotImplementedException();
    }

    public bool CheckTicket(int ticketId)
    {
        throw new NotImplementedException();
    }
}