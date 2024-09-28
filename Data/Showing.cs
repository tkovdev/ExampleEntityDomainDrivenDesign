using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

[EntityTypeConfiguration(typeof(ShowingConfiguration))]
public class Showing
{
    public int TheaterId { get; set; }
    public int MovieId { get; set; }
    public DateTime StartTime { get; set; }
    
    
    public Theater Theater { get; set; }
    public Movie Movie { get; set; }
    public ICollection<Ticket> SoldTickets { get; set; }
}

public class ShowingConfiguration : IEntityTypeConfiguration<Showing>
{
    public void Configure(EntityTypeBuilder<Showing> builder)
    {
        builder.HasKey(x => new { x.TheaterId, x.MovieId, x.StartTime });
    }
}