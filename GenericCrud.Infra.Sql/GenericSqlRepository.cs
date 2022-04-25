using GenericCrud.Infra.Dtos;
using GenericCrud.Infra.Interfaces;

namespace GenericCrud.Infra.Sql
{
    public class GenericSqlRepository<T> : IGenericRepository<T> where T : class, IGenericIdSqlDto
    {
        protected MainDbContext Context { get; set; }

        public GenericSqlRepository(MainDbContext context)
        {
            Context = context;
        }

        public T? Add(T entity)
        {
            return Context.Set<T>().Add(entity) as T;
        }

        public bool Delete(int entityId)
        {
            T? entity = GetById(entityId);
            if (entity == null) 
                return false;

            Context.Set<T>().Remove(entity);

            return Context.SaveChanges() == 1;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return Context.Set<T>().SingleOrDefault(entity => entity.Id == id);
        }

        public T? Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.SaveChanges();

            return Context.Set<T>().SingleOrDefault(e => e.Id == entity.Id);
        }
    }
}