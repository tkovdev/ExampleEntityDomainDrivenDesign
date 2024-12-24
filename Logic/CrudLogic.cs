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
        throw new NotImplementedException();
    }

    public T Create<T>(T instance) where T : IEntity<T>
    {
        throw new NotImplementedException();
    }

    public T Update<T>(T instance) where T : IEntity<T>
    {
        throw new NotImplementedException();
    }
    
    public T Delete<T>(int id) where T : IEntity<T>
    {
        throw new NotImplementedException();
    }
}