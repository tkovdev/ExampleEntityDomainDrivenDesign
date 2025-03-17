using Microsoft.EntityFrameworkCore;

namespace Data.Access;

public class AppDbContext : DbContext
{
    public AppDbContext(){}
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Showing> Showings { get; set; }
    public DbSet<Theater> Theaters { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Seat> Seats { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}