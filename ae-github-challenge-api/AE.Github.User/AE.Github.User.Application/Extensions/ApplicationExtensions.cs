using AE.Github.User.Application.UseCases.GetGithubUser;
using Microsoft.Extensions.DependencyInjection;

namespace AE.Github.User.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGetGithubUser), typeof(GetGithubUser));
            return services;
        }
    }
}
