namespace Data;

public class Theater
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Int16 Capacity { get; set; }
    
    public ICollection<Showing>? Showings { get; set; }
    public ICollection<Seat>? Seats { get; set; }
}