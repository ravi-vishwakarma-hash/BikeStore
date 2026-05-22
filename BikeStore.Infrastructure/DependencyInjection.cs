using BikeStore.Application.Interface;
using BikeStore.Domain.Interfaces.Products;
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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var redisSettings = configuration
                .GetSection("Redis")
                .Get<RedisSettings>()
                ?? throw new InvalidOperationException("Redis settings missing");

            var muxer = ConnectionMultiplexer.Connect(
                new ConfigurationOptions
                {
                    EndPoints = { { redisSettings.Host, redisSettings.Port } },
                    User = redisSettings.User,
                    Password = redisSettings.Password
                });


            services.AddSingleton<IConnectionMultiplexer>(muxer);

            services.AddScoped<ICacheService, RedisCacheService>();


            services.AddDbContextPool<BikeDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("bike_store_db");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException(
                        "Database connection string is not configured. Please set 'ConnectionStrings:bike_store_db'.");
                }
                options.UseSqlServer(connectionString);
            } );


            // Register repositories and services
            services.AddScoped<IProducts, Repositories.ProductRepository>();
            services.AddScoped<Service.Product.ProductService>();


            return services;
        }
    }

    internal class RedisSettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
