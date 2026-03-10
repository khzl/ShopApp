using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces;
using Shop.Application.Services;
namespace Shop.Application
{
    public static class BusinessStartup
    {
        public static IServiceCollection AddBusinessLayer(
            this IServiceCollection services)
        {
            // Here we register our application services , which contain the business logic of our application.
            // DI (Dependancy Injections)
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
