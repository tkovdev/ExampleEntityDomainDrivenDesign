using Microsoft.EntityFrameworkCore;

namespace Domain.Access.Interfaces;

public interface IEntity<T>
{
    public IQueryable<T> AsQueryable();
    public T Get(int id);
    public IList<T> Get();
    public IList<T> GetAll(int id);
    public T Create();
    public T Update();
    public T Delete(int id);
    public void AddCtx(DbContext ctx);
}