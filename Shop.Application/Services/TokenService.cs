using Shop.Application.Interfaces;
using Shop.Dtos.Tokens;
using Shop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Services
{
    public class TokenService : ITokenService
    {
        // private properties 
        private readonly IRefreshTokenRepository _refreshTokenRepo;

        // public Constructor 
        public TokenService(IRefreshTokenRepository refreshTokenRepo)
        {
            _refreshTokenRepo = refreshTokenRepo;
        }

        // Function GenerateToken
        public TokenResponseDto GenerateTokens(int customerId)
        {
            var accessToken = "JWT-GENERATED-HERE";
            var refreshToken = Guid.NewGuid().ToString();

            _refreshTokenRepo.AddToken(customerId, refreshToken, DateTime.UtcNow.AddDays(7));

            return new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        // Procedure RevokeRefreshToken
        public void RevokeRefreshToken(string? refreshToken)
        {
            _refreshTokenRepo.RevokeToken(refreshToken);
        }


    }
}
