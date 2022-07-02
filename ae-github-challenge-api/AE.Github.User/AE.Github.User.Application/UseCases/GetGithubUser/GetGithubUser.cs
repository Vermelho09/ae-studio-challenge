using AE.Github.User.Application.Clients;
using AE.Github.User.Application.Repositories;
using Polly;

namespace AE.Github.User.Application.UseCases.GetGithubUser
{
    public class GetGithubUser : IGetGithubUser
    {
        private readonly IUserServiceClient _userServiceClient;
        private readonly IUserRepository _userRepository;
        public GetGithubUser(IUserServiceClient userServiceClient, IUserRepository userRepository)
        {
            _userServiceClient = userServiceClient;
            _userRepository = userRepository;
        }

        public async Task<GetGithubUserOutput> Handle(GetGithubUserInput input, CancellationToken cancellationToken)
        {
            var result = await Policy<GetGithubUserOutput>.Handle<Exception>()
                .OrResult(result => result is null)
                .FallbackAsync(async a => await GetUserFromService(input, cancellationToken))
                .ExecuteAndCaptureAsync(async () => await GetUserFromCache(input, cancellationToken));

            return result.Result;
        }

        private async Task<GetGithubUserOutput> GetUserFromService(GetGithubUserInput input, CancellationToken cancellationToken)
        {
            var userGithub = await _userServiceClient.GetUserAsync(input, cancellationToken);

            if (userGithub == null) return null;

            await _userRepository.SaveCacheAsync(input.UserName, userGithub, cancellationToken);

            return userGithub;
        }

        private async Task<GetGithubUserOutput> GetUserFromCache(GetGithubUserInput input, CancellationToken cancellationToken)
        {
            var userGithub = await _userRepository.GetUserFromCacheAsync(input.UserName, cancellationToken);
            return userGithub;
        }
    }
}
