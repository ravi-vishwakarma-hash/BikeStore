using BikeStore.Application.Interface;
using BikeStore.Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace BikeStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configureration)
        {
            var redisConnection = configureration["Redis:ConnectionString"];

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection));

            services.AddScoped<ICacheService, RedisCacheService>();

            return services;
        }
    }
}
