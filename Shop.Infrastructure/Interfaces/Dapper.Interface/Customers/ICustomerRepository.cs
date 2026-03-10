using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Interfaces.Dapper.Interface.Customers
{
    public interface ICustomerRepository
    {
        // Contracts for customer data access methods, e.g., GetCustomerById, AddCustomer, etc.
        public Entity_Customer? GetByEmail(string? email);
        public int CreateAccount(string? fullName, string? email, string? passwordHash);
    }
}
