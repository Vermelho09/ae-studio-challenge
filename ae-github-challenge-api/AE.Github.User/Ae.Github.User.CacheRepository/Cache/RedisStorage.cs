using Newtonsoft.Json;
using StackExchange.Redis;

namespace Ae.Github.User.CacheRepository.Cache
{
    public class RedisStorage<T> : IRedisStorage<T> where T : class
    {
        private readonly IDatabase _database;

        public RedisStorage(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<T> GetByKeyAsync(string key)
        {
            var result = await _database.StringGetAsync(key);
            return result.IsNull ? null : JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<bool> SetAsync(string key, T value)
        {
            var data = JsonConvert.SerializeObject(value);
            return await _database.StringSetAsync(key, data);
        }
    }
}
