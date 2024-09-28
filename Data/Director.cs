namespace Data;

public class Director
{
    public int Id { get; set; }
    public string GivenName { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;

    public ICollection<Movie>? Movies = null;
}