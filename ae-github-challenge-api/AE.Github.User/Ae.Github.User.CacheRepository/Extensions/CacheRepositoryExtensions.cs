using Ae.Github.User.CacheRepository.Cache;
using Ae.Github.User.CacheRepository.Repositories;
using AE.Github.User.Application.Repositories;
using AE.Github.User.Application.UseCases.GetGithubUser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Ae.Github.User.CacheRepository.Extensions
{
    public static class CacheRepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var multiplexerConn = ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnectionString"));
            services.AddSingleton<IConnectionMultiplexer>(multiplexerConn);

            services.AddScoped<IRedisStorage<GetGithubUserOutput>, RedisStorage<GetGithubUserOutput>>();


            return services;
        }
    }
}
