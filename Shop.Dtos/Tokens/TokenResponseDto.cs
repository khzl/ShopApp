using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Dtos.Tokens
{
    public class TokenResponseDto
    {
        #region Properties
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        #endregion
    }
}
