using Data.Access;
using Domain.Access.Interfaces;

namespace Domain.Access;

public class EntityAccess : IEntityAccess
{
    private AppDbContext _ctx;
    
    public EntityAccess(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public IList<T> GetAll<T>(int id) where T : IEntity<T>
    {
        var instance = Instantiate<T>();
        return instance.GetAll(id);
    }
    
    public IList<T> Get<T>() where T : IEntity<T>
    {
        var instance = Instantiate<T>();
        return instance.Get();
    }

    public T Get<T>(int id) where T : IEntity<T>
    {
        var instance = Instantiate<T>();
        return instance.Get(id);
    }
    
    private T Instantiate<T>() where T : IEntity<T>
    {
        var instance = (T?)Activator.CreateInstance(typeof(T), [_ctx]);
        if (instance is null) throw new Exception($"Could not setup instance of {typeof(T)}");
        return instance;
    }
}