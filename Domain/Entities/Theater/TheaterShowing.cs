using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using Exception;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Theater;

public class TheaterShowing : AbstractEntity<TheaterShowing>
{
    public string MovieName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public TheaterShowing(AppDbContext ctx) : base(ctx){}

    public override IList<TheaterShowing> GetAll(int id)
    {
        return Ctx.Showings
            .Where(x => x.TheaterId == id)
            .Select(x => new TheaterShowing(Ctx)
            {
                MovieName = x.Movie.Title,
                StartTime = x.StartTime,
                EndTime = x.StartTime.AddSeconds(x.Movie.RunTime)
            }).ToList();
    }
}