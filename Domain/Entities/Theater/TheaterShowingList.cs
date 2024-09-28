using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using Exception;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Theater;

public class TheaterShowingList : AbstractEntity<TheaterShowingList>
{
    public string MovieName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public TheaterShowingList(): base(){}
    public TheaterShowingList(AppDbContext ctx) : base(ctx){}
    
    public override List<TheaterShowingList> Get()
    {
        throw new NotImplementedException();
    }

    public override TheaterShowingList Create()
    {
        throw new NotImplementedException();
    }

    public override TheaterShowingList Update()
    {
        throw new NotImplementedException();
    }

    public override TheaterShowingList Get(int id)
    {
        var showingList = Ctx.Showings
            .Include(x => x.Movie)
            .Where(x => x.TheaterId == id)
            .Select(x => new TheaterShowingList(Ctx)
            {
                MovieName = x.Movie.Title,
                StartTime = x.StartTime,
                EndTime = x.StartTime.AddSeconds(x.Movie.RunTime)
            }).FirstOrDefault();
        if (showingList is null) throw new WarningException("Theater Showing does not exist");
        return showingList;
    }
}