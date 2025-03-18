using System.Collections;
using Domain.Entities.Ticket;

namespace Logic.Interfaces;

public interface ITicketLogic
{
    public IList<SeatList> GetAvailableSeats(int theaterId);
}