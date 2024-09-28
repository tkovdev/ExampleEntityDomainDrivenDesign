namespace Domain.Access.Interfaces;

public interface IEntity<T>
{
    public T Get(int id);
    public IList<T> Get();
    public IList<T> GetAll(int id);
    public T Create();
    public T Update();
}