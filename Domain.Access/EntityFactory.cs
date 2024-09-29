using System.Reflection;
using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using Exception;

namespace Domain.Access;

public class EntityFactory : IEntityFactory
{
    private AppDbContext _ctx;
    
    public EntityFactory(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public T Instantiate<T>() where T : IEntity<T>
    {
        var instance = (T?)Activator.CreateInstance(typeof(T), [_ctx]);
        if (instance is null) throw new FatalException($"Could not setup instance of {typeof(T)}");
        return instance;
    }

    public T Instantiate<T>(T existingEntity) where T : IEntity<T>
    {
        var instance = existingEntity;
        existingEntity.AddCtx(_ctx);
        if (instance is null) throw new FatalException($"Could not setup instance of {typeof(T)}");
        return instance;
    }
}