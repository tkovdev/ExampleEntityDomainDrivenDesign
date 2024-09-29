using Data;
using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using Exception;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Movie;

public class MovieTicket : AbstractEntity<MovieTicket>
{
    public int TheaterId { get; set; }
    public int MovieId { get; set; }
    public DateTime ShowingTime { get; set; }

    public int TicketId { get; set; } = 0;
    public DateTime PurchasedDate { get; set; } = DateTime.MinValue;
    public UInt16 Price { get; set; } = UInt16.MinValue;
    public string TheaterName { get; set; } = String.Empty;
    public string MovieName { get; set; } = String.Empty;
    public bool Activated { get; set; } = false;
    public string Discount { get; set; } = String.Empty;

    
    public MovieTicket() : base(){}
    public MovieTicket(AppDbContext ctx) : base(ctx){}

    public override MovieTicket Get(int ticketId)
    {
        var ticket = Ctx.Tickets
            .Include(x => x.Showing.Movie)
            .Include(x => x.Showing.Theater)
            .Where(x => x.Id == ticketId)
            .Select(x => new MovieTicket(Ctx)
            {
                TheaterId = x.Showing.TheaterId,
                MovieId = x.Showing.MovieId,
                TicketId = x.Id,
                PurchasedDate = x.PurchasedDate,
                Price = x.Price,
                MovieName = x.Showing.Movie.Title,
                ShowingTime = x.Showing.StartTime,
                TheaterName = x.Showing.Theater.Name,
                Activated = x.Activated
            }).FirstOrDefault();
        if (ticket is null) throw new WarningException("Ticket not found!");
        return ticket;
    }

    public override MovieTicket Create()
    {
        var showing = Ctx.Showings
            .Include(x => x.Theater)
            .Include(x => x.Movie)
            .FirstOrDefault(x => x.TheaterId == TheaterId && x.MovieId == MovieId && x.StartTime == ShowingTime);
        if (showing is null) throw new CriticalException("Showing does not exist for given movie, theater &/or time");

        Price = 12;
        if (Discount == "SENIOR" || Discount == "CHILD") Price = (UInt16)(Price * .8);
        
        var create = new Ticket()
        {
            Price = Price,
            PurchasedDate = PurchasedDate,
            Showing = showing
        };
        Ctx.Tickets.Add(create);
        Ctx.SaveChanges();

        if (create.Id == 0) throw new CriticalException("Ticket not created!");
        
        return Get(create.Id);
    }

    public override MovieTicket Update()
    {
        var existing = Ctx.Tickets.Include(x => x.Showing).FirstOrDefault(x => x.Id == TicketId);
        if (existing is null) throw new WarningException("Ticket does not exist");
        
        existing.PurchasedDate = PurchasedDate;
        existing.Price = Price;
        existing.Activated = Activated;

        Ctx.Update(existing);
        Ctx.SaveChanges();
        
        return Get(TicketId);
    }
}