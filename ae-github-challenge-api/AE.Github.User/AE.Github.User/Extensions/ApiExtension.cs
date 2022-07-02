using AE.Github.User.Application.UseCases.GetGithubUser;
using MediatR;
using System.Reflection;

namespace AE.Github.User.Extensions
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetGithubUser).GetTypeInfo().Assembly);
            services.AddScoped<IMediator, Mediator>();

            return services;
        }
    }
}
