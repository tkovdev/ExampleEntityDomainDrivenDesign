using Data.Access;
using Domain.Access.Abstractions;
using Domain.Entities.Theater;
using Domain.Access.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Movie;

public class MovieShowingList : AbstractEntity<MovieShowingList>
{
    public string TheaterName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public MovieShowingList(): base(){}
    public MovieShowingList(AppDbContext ctx) : base(ctx){}
    
    public override MovieShowingList Get(int id)
    {
        throw new NotImplementedException();
    }

    public override MovieShowingList Create()
    {
        throw new NotImplementedException();
    }

    public override MovieShowingList Update()
    {
        throw new NotImplementedException();
    }

    public override IList<MovieShowingList> Get()
    {
        return Ctx.Showings
            .Include(x => x.Movie)
            .Select(x => new MovieShowingList(Ctx)
            {
                TheaterName = x.Theater.Name,
                StartTime = x.StartTime,
                EndTime = x.StartTime.AddSeconds(x.Movie.RunTime)
            }).ToList();    
    }
}