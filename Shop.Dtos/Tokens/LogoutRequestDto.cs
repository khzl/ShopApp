using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Dtos.Tokens
{
    public class LogoutRequestDto
    {
        #region Properties
        public string? RefreshToken { get; set; }
        #endregion
    }
}
