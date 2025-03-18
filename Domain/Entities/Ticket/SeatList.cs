using Data.Access;
using Domain.Access.Abstractions;

namespace Domain.Entities.Ticket;

public class SeatList : AbstractEntity<SeatList>
{
    public int TheaterId { get; set; } = 0;
    public char SeatRow { get; set; } = 'A';
    public int SeatNumber { get; set; } = 1;
    
    public SeatList() : base() { }
    public SeatList(AppDbContext ctx) : base(ctx) { }

    public override IQueryable<SeatList> AsQueryable()
    {
        var theaterSeats = Ctx.Theaters.Where(x => x.Seats != null).SelectMany(x => x.Seats!);
        return theaterSeats.Select(x => new SeatList()
        {
            TheaterId = x. 
        });
    }

    public override IList<SeatList> GetAll(int theaterId)
    {
        return Ctx.Theaters.Where(x => x.Id == theaterId).SelectMany(x => x.Seats).Select(x => new SeatList()
        {
            SeatNumber = x.Number,
            SeatRow = x.Row
        }).ToList();
    }
}