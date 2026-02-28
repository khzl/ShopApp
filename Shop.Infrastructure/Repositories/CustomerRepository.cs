using Dapper;
using Shop.Domain.Entities;
using Shop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Shop.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _db;

        // Constructor to initialize the database connection
        public CustomerRepository(IDbConnection db)
        {
            _db = db;
        }

        // GetByEmail method to retrieve a customer by their email address
        // Return type changed to nullable to reflect that no matching customer may be found.
        public Entity_Customer? GetByEmail(string? email)
        {
            return _db.QueryFirstOrDefault<Entity_Customer>(
                "sp_GetCustomerForLogin",
                new { Email = email },
                commandType: CommandType.StoredProcedure);
        }

        // Create Account 
        // Insfrastrucutre ينفذ اوامر الداتا بيس فقط 
        public int CreateAccount(string? fullName,string? email,string? passwordHash)
        {
            return _db.ExecuteScalar<int>(
                "sp_RegisterCustomer",
                new
                {
                    FullName = fullName,
                    Email = email,
                    PasswordHash = passwordHash
                },
                commandType: CommandType.StoredProcedure
             );
        }


    }
}
