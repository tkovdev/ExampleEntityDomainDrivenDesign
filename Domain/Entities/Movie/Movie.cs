using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using Exception;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Movie;

public class Movie : AbstractEntity<Movie>
{
    public int Id { get; set; } = 0;
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public UInt16 RunTime { get; set; }
    public int DirectorId { get; set; }

    public Movie(AppDbContext ctx) : base(ctx)
    {
    }

    public override IList<Movie> Get()
    {
        var movie = Ctx.Movies
            .Include(x => x.Director)
            .Select(x => new Movie(Ctx)
            {
                Id = x.Id,
                Title = x.Title,
                RunTime = x.RunTime,
                ReleaseDate = x.ReleaseDate,
                DirectorId = x.Director.Id
            }).ToList();
        if (movie is null) throw new WarningException("Movie does not exist");
        return movie;
    }

    public override Movie Get(int movieId)
    {
        var movie = Ctx.Movies
            .Include(x => x.Director)
            .Where(x => x.Id == movieId)
            .Select(x => new Movie(Ctx)
            {
                Id = x.Id,
                Title = x.Title,
                RunTime = x.RunTime,
                ReleaseDate = x.ReleaseDate,
                DirectorId = x.Director.Id
            }).FirstOrDefault();
        if (movie is null) throw new WarningException("Movie does not exist");
        return movie;
    }

    public override Movie Create()
    {
        var director = Ctx.Directors.First(x => x.Id == DirectorId);
        var create = new Data.Movie()
        {
            Director = director,
            ReleaseDate = ReleaseDate,
            Title = Title,
            RunTime = RunTime
        };
        Ctx.Movies.Add(create);
        Ctx.SaveChanges();
        if (create.Id == 0) throw new CriticalException("Movie not created!");

        Id = create.Id;

        return this;
    }
}