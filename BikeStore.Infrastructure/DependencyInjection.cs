using BikeStore.Application.Interface;
using BikeStore.Infrastructure.Persistence.DbContext;
using BikeStore.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace BikeStore.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add infrastructure services to the service collection. Add redis cache service and database context.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configureration"></param>
        /// <returns>return IServiceCollection</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configureration)
        {
            //var redisSettings = configureration
            //    .GetSection("Redis")
            //    .Get<RedisSettings>()
            //    ?? throw new InvalidOperationException("Redis settings missing");


            //var redisConnection = configureration["Redis:ConnectionString"];

            //if (string.IsNullOrWhiteSpace(redisConnection))
            //{
            //    throw new InvalidOperationException(
            //        "Redis connection string is not configured. Please set 'Redis:ConnectionString'.");
            //}

            //services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection));

            //services.AddScoped<ICacheService, RedisCacheService>();


            services.AddDbContextPool<BikeDbContext>(options =>
            {
                var connectionString = configureration.GetConnectionString("bike_store_db");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException(
                        "Database connection string is not configured. Please set 'ConnectionStrings:bike_store_db'.");
                }
                options.UseSqlServer(connectionString);
            } );

            return services;
        }
    }
}
