using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using Exception;

namespace Domain.Entities.Theater;

public class TheaterTicketList : AbstractEntity<TheaterTicketList>
{
    public int TicketId { get; set; }
    public int MovieId { get; set; }
    public DateTime ShowingTime { get; set; }
    
    public TheaterTicketList() : base(){}
    public TheaterTicketList(AppDbContext ctx) : base(ctx) {}
    
    public override TheaterTicketList Get(int id)
    {
       var theaterTicket = Ctx.Tickets
            .Where(x => x.Showing.TheaterId == id)
            .Select(x => new TheaterTicketList(Ctx)
            {
                TicketId = x.Id,
                MovieId = x.Showing.MovieId,
                ShowingTime = x.Showing.StartTime
            }).FirstOrDefault();
       if (theaterTicket is null) throw new WarningException("Theater Ticket does not exist");
       return theaterTicket;
    }

    public override TheaterTicketList Create()
    {
        throw new NotImplementedException();
    }

    public override TheaterTicketList Update()
    {
        throw new NotImplementedException();
    }

    public override List<TheaterTicketList> Get()
    {
        throw new NotImplementedException();
    }
}