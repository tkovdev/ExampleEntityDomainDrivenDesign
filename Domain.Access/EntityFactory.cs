using Data.Access;
using Domain.Access.Interfaces;

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
        if (instance is null) throw new Exception($"Could not setup instance of {typeof(T)}");
        return instance;
    }
}