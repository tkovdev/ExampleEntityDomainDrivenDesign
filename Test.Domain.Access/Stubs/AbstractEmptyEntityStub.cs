using Domain.Access.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Test.Logic;

public abstract class AbstractEmptyEntityStub : IEntity<AbstractEmptyEntityStub>
{
    public abstract IQueryable<AbstractEmptyEntityStub> AsQueryable();
    public abstract AbstractEmptyEntityStub Get(int id);
    public abstract IList<AbstractEmptyEntityStub> Get();
    public abstract IList<AbstractEmptyEntityStub> GetAll(int id);
    public abstract AbstractEmptyEntityStub Create();
    public abstract AbstractEmptyEntityStub Update();
    public abstract AbstractEmptyEntityStub Delete(int id);
    public abstract void AddCtx(DbContext ctx);
}