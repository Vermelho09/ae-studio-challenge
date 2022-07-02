using AE.Github.User.Application.UseCases.GetGithubUser;

namespace AE.Github.User.Application.Clients
{
    public interface IUserServiceClient
    {
        Task<GetGithubUserOutput> GetUserAsync(GetGithubUserInput input, CancellationToken cancellationToken);
    }
}