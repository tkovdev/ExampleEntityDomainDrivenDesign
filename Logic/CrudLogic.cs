using Domain.Access.Interfaces;
using Logic.Interfaces;

namespace Logic;

public class CrudLogic : ICrudLogic
{
    private readonly IEntityFactory _entityFactory;
    
    public CrudLogic(IEntityFactory entityFactory)
    {
        _entityFactory = entityFactory;
    }
    
    public T Get<T>(int id) where T : IEntity<T>
    {
        var instance = _entityFactory.Instantiate<T>();
        var res = instance.Get(id);
        return res;
    }

    public IList<T> Get<T>() where T : IEntity<T>
    {
        var instance = _entityFactory.Instantiate<T>();
        var res = instance.Get();
        return res;    
    }

    public IList<T> GetAll<T>(int id) where T : IEntity<T>
    {
        var instance = _entityFactory.Instantiate<T>();
        var res = instance.GetAll(id);
        return res; 
    }

    public T Create<T>(T instance) where T : IEntity<T>
    {
        var res = instance.Create();
        return res;
    }

    public T Update<T>(T instance) where T : IEntity<T>
    {
        var res = instance.Update();
        return res;
    }
    
    public T Delete<T>(int id) where T : IEntity<T>
    {
        var instance = _entityFactory.Instantiate<T>();
        var res = instance.Delete(id);
        return res;
    }
}