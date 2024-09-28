namespace Domain.Access.Interfaces;

public interface IEntityFactory
{
    public T Instantiate<T>() where T : IEntity<T>;
}