using Ae.Github.User.CacheRepository.Cache;
using AE.Github.User.Application.Repositories;
using AE.Github.User.Application.UseCases.GetGithubUser;

namespace Ae.Github.User.CacheRepository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRedisStorage<GetGithubUserOutput> _redis;
        public UserRepository(IRedisStorage<GetGithubUserOutput> redis)
        {
            _redis = redis;
        }

        public async Task<GetGithubUserOutput> GetUserFromCacheAsync(string key, CancellationToken cancellationToken)
        {
            return await _redis.GetByKeyAsync(key);
        }

        public async Task SaveCacheAsync(string key, GetGithubUserOutput cacheObject, CancellationToken cancellationToken)
        {
            await _redis.SetAsync(key, cacheObject);
        }
    }
}
