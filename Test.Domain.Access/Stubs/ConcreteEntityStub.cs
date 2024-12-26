using Data.Access;
using Domain.Access.Abstractions;
using Exception;
using Microsoft.EntityFrameworkCore;

namespace Test.Logic;

public class ConcreteEntityStub : AbstractEntity<ConcreteEntityStub>
{
    public int Id { get; set; } = 0;

    protected AppDbContext Ctx { get; set; }

    public ConcreteEntityStub()
    {
        
    }
    
    public ConcreteEntityStub(AppDbContext ctx)
    {
        Ctx = ctx;
    }
    
    public override IList<ConcreteEntityStub> GetAll(int id) => new List<ConcreteEntityStub>();
    public override IList<ConcreteEntityStub> Get() => new List<ConcreteEntityStub>();
    public override ConcreteEntityStub Get(int id) => new ConcreteEntityStub();
    public override ConcreteEntityStub Create() => new ConcreteEntityStub();
    public override ConcreteEntityStub Update() => new ConcreteEntityStub();
    public override ConcreteEntityStub Delete(int id) => new ConcreteEntityStub();
}