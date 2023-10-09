using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserManager.Business.Services.Contracts;
using UserManager.Business.Services.Implementation;

namespace UserManager.Business.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleUserService, RoleUserService>();

            return services;
        }
    }
}