using BikeStore.Infrastructure.Persistence.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Infrastructure.Repositories
{
    /// <summary>
    /// This is a generic repository class that provides basic CRUD operations for entities of type TEntity. It uses the BikeDbContext to interact with the database and perform operations such as adding, removing, and updating entities. The class is designed to be inherited by specific repository classes that will implement additional methods for specific entities. The TEntity type parameter is constrained to be a class, ensuring that it can be used with Entity Framework Core's DbSet<TEntity> for database operations.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="dbContext"></param>
    internal abstract class Repository<TEntity> (BikeDbContext dbContext)
         where TEntity : class
    {
        protected readonly BikeDbContext dbContext = dbContext;


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
