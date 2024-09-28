namespace Domain.Access.Interfaces;

public interface IEntity<T>
{
    public T Get(int id);
    public IList<T> Get();
    public T Create();
    public T Update();
}