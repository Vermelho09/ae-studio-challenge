namespace Ae.Github.User.CacheRepository.Cache
{
    public interface IRedisStorage<T> where T : class
    {
        Task<T> GetByKeyAsync(string key);
        Task<bool> SetAsync(string key, T value);
    }
}
