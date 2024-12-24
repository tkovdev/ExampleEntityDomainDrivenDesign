using Domain.Access.Interfaces;

namespace Logic.Interfaces;

public interface ICrudLogic
{
    public T Get<T>(int id) where T : IEntity<T>;
    public IList<T> Get<T>() where T : IEntity<T>;
    public IList<T> GetAll<T>(int id) where T : IEntity<T>;
    public T Create<T>(T instance) where T : IEntity<T>;
    public T Update<T>(T instance) where T : IEntity<T>;
    public T Delete<T>(int id) where T : IEntity<T>;
}