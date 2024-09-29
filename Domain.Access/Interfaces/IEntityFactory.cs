namespace Domain.Access.Interfaces;

public interface IEntityFactory
{
    public T Instantiate<T>() where T : IEntity<T>;
    public T Instantiate<T>(T existingEntity) where T : IEntity<T>;
}