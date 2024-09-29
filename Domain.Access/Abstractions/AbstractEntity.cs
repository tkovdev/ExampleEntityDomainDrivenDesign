using Data.Access;
using Domain.Access.Interfaces;
using Exception;
using Microsoft.EntityFrameworkCore;

namespace Domain.Access.Abstractions;

public abstract class AbstractEntity<T> : IEntity<T>
{
    protected AppDbContext Ctx { get; set; }

    public AbstractEntity()
    {
        
    }
    
    public AbstractEntity(AppDbContext ctx)
    {
        Ctx = ctx;
    }
    
    public virtual IList<T> GetAll(int id) => throw new NotImplementedException();
    public virtual IList<T> Get() => throw new NotImplementedException();
    public virtual T Get(int id) => throw new NotImplementedException();
    public virtual T Create() => throw new NotImplementedException();
    public virtual T Update() => throw new NotImplementedException();
    public void AddCtx(DbContext ctx)
    {
        if (ctx is null) throw new FatalException("DbContext cannot be null when adding it to the Entity");
        if(ctx.GetType() != typeof(AppDbContext)) throw new FatalException("DbContext must be of type AppDbContext");
        
        Ctx = (AppDbContext)ctx;
    }
}