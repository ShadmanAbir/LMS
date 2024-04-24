using LMS.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace LMS.Domain.Repositories
{
        public class GenericRepository<TEntity> where TEntity : class
        {
            internal LMSContext context;
            internal DbSet<TEntity> dbSet;

            public GenericRepository(LMSContext context)
            {
                this.context = context;
                this.dbSet = context.Set<TEntity>();

            }

            public virtual IQueryable<TEntity> Get()
            {
                return dbSet.AsQueryable();
            }

            public virtual TEntity GetByID(object id)
            {
                return dbSet.Find(id);
            }

            public virtual void Insert(TEntity entity)
            {
                dbSet.Add(entity);
            }

            public virtual void Delete(object id)
            {
                TEntity entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
            }

            public virtual void Delete(TEntity entityToDelete)
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }

            public virtual void Update(TEntity entityToUpdate)
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
        }
}
