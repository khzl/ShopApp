using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Shop.Infrastructure.DbContext;
using Shop.Infrastructure.Interfaces;
using Shop.Infrastructure.Repositories;

namespace Shop.Infrastructure
{
    public static class DataStartup
    {
        public static IServiceCollection AddDataLayer(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // DbContext registration for Entity Framework Core
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // Dapper registration for raw SQL queries and stored procedures 
            services.AddScoped<IDbConnection>(sp =>
            new SqlConnection(
                configuration.GetConnectionString("DefaultConnection")));

            // Dapper Repositories registration
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Return the service collection so the extension can be chained
            return services;
        }
    }
}
