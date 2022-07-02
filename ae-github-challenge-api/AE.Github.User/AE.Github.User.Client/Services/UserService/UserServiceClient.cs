using AE.Github.User.Application.Clients;
using AE.Github.User.Application.UseCases.GetGithubUser;
using AE.Github.User.Client.Responses;
using Newtonsoft.Json;

namespace AE.Github.User.Client.Services.UserService
{
    public class UserServiceClient : IUserServiceClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public UserServiceClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("GitHub");
        }

        public async Task<GetGithubUserOutput> GetUserAsync(GetGithubUserInput input, CancellationToken cancellationToken)
        {
            var getUserUrl = "users/" + input.UserName;
            var response = await _httpClient.GetAsync(getUserUrl, cancellationToken);
            var userResponse = await ReadResponseAsync<UserResponse>(response);

            var profileStarsCount = await GetStarredRepositories(input, cancellationToken);

            var userOutput = new GetGithubUserOutput()
            {
                ProfilePicUrl = userResponse.Avatar_url,
                StarsCount = profileStarsCount
            };

            return userOutput;
        }


        private async Task<int> GetStarredRepositories(GetGithubUserInput input, CancellationToken cancellationToken)
        {
            var getStarsFromUserUrl = "users/" + input.UserName + "/starred";
            var response = await _httpClient.GetAsync(getStarsFromUserUrl, cancellationToken);
            var responseList = await ReadResponseAsync<ICollection<dynamic>>(response);

            return responseList.Count;
        }

        private static async Task<T> ReadResponseAsync<T>(HttpResponseMessage httpResponse)
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
            return default(T);
        }
    }
}
