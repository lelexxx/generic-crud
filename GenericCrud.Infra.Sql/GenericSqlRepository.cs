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

        public virtual T? Add(T entity)
        {
            return Context.Set<T>().Add(entity) as T;
        }

        public virtual bool Delete(int entityId)
        {
            T? entity = GetById(entityId);
            if (entity == null) return false;
            Context.Set<T>().Remove(entity);

            return Context.SaveChanges() == 1;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual T? GetById(int id)
        {
            return Context.Set<T>().FirstOrDefault(entity => entity.Id == id);
        }

        public virtual T? Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.SaveChanges();

            return Context.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
        }
    }
}