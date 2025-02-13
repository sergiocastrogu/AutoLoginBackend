using AutoLogin.Persistence.Context;
using AutoLogin.Persistence.Contracts;
using AutoLogin.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

namespace AutoLogin.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LoginDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"))
            );
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}
