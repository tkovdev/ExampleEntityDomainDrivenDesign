using Data.Access;
using Domain.Access.Interfaces;
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
    
    public abstract IList<T> Get();
    public abstract T Get(int id);
    public abstract T Create();
    public abstract T Update();
}