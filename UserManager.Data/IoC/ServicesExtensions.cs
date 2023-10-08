using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManager.Data.Contexts.Contracts;
using UserManager.Data.Contexts.Implementation;
using UserManager.Data.Repositories.Contracts;
using UserManager.Data.Repositories.Implementation;

namespace UserManager.Data.IoC
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlDbConnection")),
            ServiceLifetime.Transient);
        }

        public static void ConfigureDbContext(this IServiceCollection services) 
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleUserRepository, RoleUserRepository>();

            return services;
        }
    }
}