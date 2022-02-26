using GenericCrud.Infra.Dtos;
using GenericCrud.Infra.Interfaces;

namespace GenericCrud.Infra.Fake;

public class GenericFakeRepository<T> : IGenericRepository<T> where T : class, IGenericIdSqlDto
{
    protected List<T> Context { get; set; } = new();

    public T? Add(T entity)
    {
        int lastId = Context.Max(e => e.Id);
        entity.Id = lastId + 1;

        Context.Add(entity);

        return entity;
    }

    public bool Delete(int entityId)
    {
        T? entity = GetById(entityId);
        if (entity == null) 
            return false;

        return Context.Remove(entity);
    }

    public IEnumerable<T> GetAll()
    {
        return Context.ToList();
    }

    public T? GetById(int id)
    {
        return Context.FirstOrDefault(entity => entity.Id == id);
    }

    public T? Update(T entity)
    {
        T? oldEntity = GetById(entity.Id);
        if (oldEntity == null)
            return null;

        Context.Remove(oldEntity);
        Context.Add(entity);

        return Context.FirstOrDefault(e => e.Id == entity.Id);
    }
}