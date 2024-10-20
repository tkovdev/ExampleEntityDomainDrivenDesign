using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using Exception;

namespace Domain.Entities.Theater;

public class TheaterTicket : AbstractEntity<TheaterTicket>
{
    public int TicketId { get; set; }
    public int MovieId { get; set; }
    public DateTime ShowingTime { get; set; }
    
    public TheaterTicket(AppDbContext ctx) : base(ctx) {}
    
    public override IList<TheaterTicket> GetAll(int id)
    { 
        return Ctx.Tickets
            .Where(x => x.Showing.TheaterId == id)
            .Select(x => new TheaterTicket(Ctx)
            {
                TicketId = x.Id,
                MovieId = x.Showing.MovieId,
                ShowingTime = x.Showing.StartTime
            }).ToList();
    }
}