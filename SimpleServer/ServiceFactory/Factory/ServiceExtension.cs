using Domain;
using Domain.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceFactory.Factory
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, string conectionString)
        {
            Console.WriteLine($"You can use this {conectionString} in the DB Implementation :O ");
            services.AddScoped<IGreetingObject, GreetingObject>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }


    }
}