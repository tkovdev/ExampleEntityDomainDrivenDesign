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
        try
        {

            var instance = Activator.CreateInstance<T>();
            instance.AddCtx(_ctx);
            return instance;
        }
        catch (System.Exception e)
        {
            throw new FatalException($"Cannot create instance of {typeof(T)}");
        }
    }

    public T Instantiate<T>(T existingEntity) where T : IEntity<T>
    {
        var instance = existingEntity;
        existingEntity.AddCtx(_ctx);
        return instance;
    }
}