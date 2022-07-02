using AE.Github.User.Application.UseCases.GetGithubUser;

namespace AE.Github.User.Application.Repositories
{
    public interface IUserRepository
    {
        Task<GetGithubUserOutput> GetUserFromCacheAsync(string key, CancellationToken cancellationToken);

        Task SaveCacheAsync(string key, GetGithubUserOutput cacheObject, CancellationToken cancellationToken);
    }
}
