using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Interfaces
{
    public interface IRefreshTokenRepository
    {
        // Contracts
        
        // Procedure Add
        public void AddToken(int customerId, string? token, DateTime expiry);
        
        // Procedure Revoke
        public void RevokeToken(string? token); 
    }
}
