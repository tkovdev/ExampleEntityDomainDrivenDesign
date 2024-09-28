namespace Domain.Access.Interfaces;

public interface IEntityAccess
{
    public IList<T> Get<T>() where T : IEntity<T>;
    public IList<T> GetAll<T>(int id) where T : IEntity<T>;
    public T Get<T>(int id) where T : IEntity<T>;
}