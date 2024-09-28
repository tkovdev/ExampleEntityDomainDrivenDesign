using Data.Access;
using Domain.Access.Abstractions;
using Domain.Entities.Theater;
using Domain.Access.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Movie;

public class MovieShowing : AbstractEntity<MovieShowing>
{
    public string TheaterName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public MovieShowing(): base(){}
    public MovieShowing(AppDbContext ctx) : base(ctx){}

    public override IList<MovieShowing> GetAll(int id)
    {
        return Ctx.Showings
            .Where(x => x.Movie.Id == id)
            .Select(x => new MovieShowing(Ctx)
            {
                TheaterName = x.Theater.Name,
                StartTime = x.StartTime,
                EndTime = x.StartTime.AddSeconds(x.Movie.RunTime)
            }).ToList();
    }
}