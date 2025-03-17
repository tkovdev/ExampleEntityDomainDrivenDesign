using Microsoft.EntityFrameworkCore;

namespace Data;

[PrimaryKey(nameof(Row), nameof(Number))]
public class Seat
{
    public char Row { get; set; } = 'A';
    public int Number { get; set; } = 1;
}