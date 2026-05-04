using BikeStore.Application.Interface;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;

namespace BikeStore.Infrastructure.Service
{
    public class RedisCacheService : ICacheService
    {
        private readonly TimeSpan _defaultExpiration = TimeSpan.FromMinutes(5);
        private readonly IDatabase _redis;

        public RedisCacheService(IConnectionMultiplexer connection)
        {
            _redis = connection.GetDatabase();
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _redis.StringGetAsync(key);
            if (!value.HasValue) 
                return default;

            using var stream = new MemoryStream(value);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, value);

            var bytes = stream.ToArray();
            await _redis.StringSetAsync(key, bytes, expiry ?? _defaultExpiration);
        }

        public async Task RemoveAsync(string key)
        {
            await _redis.KeyDeleteAsync(key);
        }
    }
}
