namespace Data;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public DateTime ReleaseDate { get; set; } = DateTime.UnixEpoch;
    public UInt16 RunTime { get; set; } = 0;
    
    public Director Director { get; set; }
    public ICollection<Showing>? Showings { get; set; }
}