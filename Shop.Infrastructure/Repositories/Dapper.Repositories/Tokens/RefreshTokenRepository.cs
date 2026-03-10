using Dapper;
using Shop.Infrastructure.Interfaces.Dapper.Interface.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shop.Infrastructure.Repositories.Dapper.Repositories.Tokens
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        // private properties
        private readonly IDbConnection _db;

        // public Constructor
        public RefreshTokenRepository(IDbConnection db)
        {
            _db = db;
        }

        // Procedure Add Token
        public void AddToken(int customerId, string? token, DateTime expiry)
        {
            _db.Execute(
                "sp_AddRefreshToken",
                new
                {
                    CustomerId = customerId,
                    Token = token,
                    ExpiryDate = expiry
                },
                commandType: CommandType.StoredProcedure);
        }

        // Procedure Revoke Token
        public void RevokeToken(string? token)
        {
            _db.Execute(
                "sp_RevokeRefreshToken",
                new
                {
                    Token = token
                },
                commandType: CommandType.StoredProcedure);
        }

    }
}
