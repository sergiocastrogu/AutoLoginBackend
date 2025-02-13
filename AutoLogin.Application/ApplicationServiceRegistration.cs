using AutoLogin.Application.Interfaces;
using AutoLogin.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLogin.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services)
        {
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IRegisterService, RegisterService>();
            services.AddTransient<ISecureService, SecureService>();
            return services;
        }
    }
}
