using Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Infrastructure;
using Shop.Dtos.Login;
using BCrypt.Net;
using Shop.Dtos.Register;
using Shop.Infrastructure.Interfaces.Dapper.Interface.Customers;

namespace Shop.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepo;
        
        // Constructor to inject the customer repository dependency
        public AuthService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        // Login Feature Implementation (Feature 1)
        public LoginResponseDto Login(LoginRequestDto request)
        {
            var customer = _customerRepo.GetByEmail(request.Email);

            if (customer == null)
                throw new Exception("Invalid credentials.");

            if (!customer.IsActive)
                throw new Exception("Account is inactive.");


            return new LoginResponseDto
            {
                CustomerId = customer.CustomerId,
                Token = "FAKE-JWT-FOR-NOW"
            };
        }

        // Feature 2 Register (Create Account)
        public RegisterResponseDto Register(RegisterRequestDto request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new Exception("Email is required");

            if (string.IsNullOrEmpty(request.Password) || request.Password.Length < 6)
                throw new Exception("Password must be at least 6 characters long");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var customerId = _customerRepo.CreateAccount(
                request.FullName,
                request.Email,
                passwordHash
                );

            return new RegisterResponseDto
            {
                CustomerId = customerId,
                Message = "Account Created Successfully"
            };
        }
    }
}
