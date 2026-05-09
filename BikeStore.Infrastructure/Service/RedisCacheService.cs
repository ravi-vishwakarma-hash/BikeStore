using BikeStore.Application.Interface;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace BikeStore.Infrastructure.Service
{
    public class RedisCacheService : ICacheService
    {
        private readonly TimeSpan _defaultExpiration = TimeSpan.FromMinutes(5);
        private readonly IDatabase _redis;
        private readonly ILogger<RedisCacheService> _logger;

        public RedisCacheService(IConnectionMultiplexer connection, ILogger<RedisCacheService> logger)
        {
            _redis = connection.GetDatabase();
            _logger = logger;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _redis.StringGetAsync(key);
            if (!value.HasValue) {
                _logger.LogInformation("Cache miss for key: {Key}", key);
                return default;
            }

            using var stream = new MemoryStream(value);
            _logger.LogInformation("Cache hit for key: {Key}", key);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, value);

            var bytes = stream.ToArray();
            await _redis.StringSetAsync(key, bytes, expiry ?? _defaultExpiration);
            _logger.LogInformation("Cache set for key: {Key}", key);
        }

        public async Task RemoveAsync(string key)
        {
            await _redis.KeyDeleteAsync(key);
            _logger.LogInformation("Cache removed for key: {Key}", key);
        }
    }
}
