using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using Exception;

namespace Domain.Entities.Movie;

public class MovieList : AbstractEntity<MovieList>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public MovieList(AppDbContext ctx) : base(ctx){}
    
    public override List<MovieList> Get()
    {
        return Ctx.Movies.Select(x => new MovieList(Ctx)
        {
            Id   = x.Id,
            Name = x.Title
        }).ToList();
    }

    public override MovieList Get(int movieId)
    {
        var movieList = Ctx.Movies.Select(x => new MovieList(Ctx)
        {
            Id   = x.Id,
            Name = x.Title
        }).FirstOrDefault(x => x.Id == movieId);
        
        if (movieList is null) throw new WarningException("Movie does not exist");
        return movieList;
    }
}