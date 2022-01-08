using GenericCrud.Infra.Dtos;

namespace GenericCrud.Infra.Interfaces;

public interface IGenericRepository<T> where T : class, IGenericIdSqlDto
{
    T? Add(T entity);
    bool Delete(int entityId);
    IEnumerable<T> GetAll();
    T? GetById(int id);
    T? Update(T entity);
}