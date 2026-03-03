using Shop.Dtos.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Interfaces
{
    public interface ITokenService
    {
        // Contracts

        // GenerateTokens
        public TokenResponseDto GenerateTokens(int customerId);

        // Procedure RevokeRefreshToken
        public void RevokeRefreshToken(string? refreshToken);
    }
}
