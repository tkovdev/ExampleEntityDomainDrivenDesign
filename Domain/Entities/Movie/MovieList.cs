using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using Exception;

namespace Domain.Entities.Movie;

public class MovieList : AbstractEntity<MovieList>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public MovieList() : base(){}
    public MovieList(AppDbContext ctx) : base(ctx){}
    
    public override List<MovieList> Get()
    {
        return Ctx.Movies.Select(x => new MovieList(Ctx)
        {
            Id   = x.Id,
            Name = x.Title
        }).ToList();
    }

    public override MovieList Create()
    {
        throw new NotImplementedException();
    }

    public override MovieList Update()
    {
        throw new NotImplementedException();
    }

    public override MovieList Get(int id)
    {
        throw new NotImplementedException();
    }
}