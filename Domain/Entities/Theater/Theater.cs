using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using Exception;

namespace Domain.Entities.Theater;

public class Theater : AbstractEntity<Theater>
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    
    public Theater() : base() { }
    public Theater(AppDbContext ctx) : base(ctx){}

    public override IList<Theater> Get()
    {
        throw new NotImplementedException();
    }

    public override Theater Get(int id)
    {
        var theater = Ctx.Theaters
            .Where(x => x.Id == id)
            .Select(x =>
                new Theater(Ctx)
                {
                    Name = x.Name,
                    Capacity = x.Capacity
                })
            .FirstOrDefault();
        if (theater is null) throw new WarningException("Theater does not exist");
        return theater;
    }
}