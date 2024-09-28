namespace Data;

public class Ticket
{
    public int Id { get; set; }
    public DateTime PurchasedDate { get; set; }
    public UInt16 Price { get; set; }
    
    public Showing Showing { get; set; }
    public bool Activated { get; set; } = false;

}