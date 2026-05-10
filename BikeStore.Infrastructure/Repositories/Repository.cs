using BikeStore.Infrastructure.Persistence.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Infrastructure.Repositories
{
    internal abstract class Repository<TEntity> (BikeDbContext dbContext)
         where TEntity : class
    {

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }

    }
}
