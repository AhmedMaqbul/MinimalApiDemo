namespace MinimalApiDemo.Data.Abstractions;

public interface IRepository<T> where T : IEntity
{
    List<T> GetAll();
    T? GetById(Guid id);
    void Add(T item);
    bool Delete(Guid id);
    bool Update(Guid id, T updatedItem);
}
