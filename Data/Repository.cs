using MinimalApiDemo.Data.Abstractions;

namespace MinimalApiDemo.Data;

public class Repository<T> : IRepository<T> where T : IEntity
{
    protected readonly List<T> _items;

    public Repository(List<T>? initialItems = null)
    {
        _items = initialItems ?? [];
    }

    public List<T> GetAll()
    {
        return _items;
    }

    public T? GetById(Guid id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    public bool Delete(Guid id)
    {
        var item = GetById(id);

        if (item is null)
            return false;

        _items.Remove(item);

        return true;
    }

    public bool Update(Guid id, T updatedItem)
    {
        var existingItem = GetById(id);

        if (existingItem is null)
            return false;

        var index = _items.IndexOf(existingItem);
        _items[index] = updatedItem;

        return true;
    }
}
