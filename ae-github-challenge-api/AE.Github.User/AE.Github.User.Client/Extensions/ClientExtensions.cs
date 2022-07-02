using AE.Github.User.Application.Clients;
using AE.Github.User.Client.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace AE.Github.User.Client.Extensions
{
    public static class ClientExtensions
    {
        public static IServiceCollection AddClients(this IServiceCollection services)
        {
            services.AddScoped<IUserServiceClient, UserServiceClient>();
            return services;
        }
    }
}
