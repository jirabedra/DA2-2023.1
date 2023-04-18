using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<DbContext, SimpleServerContext>(o => o.UseSqlServer(conectionString));
            return services;
        }


    }
}