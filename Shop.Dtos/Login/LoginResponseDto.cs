using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Dtos.Login
{
    public class LoginResponseDto
    {
        #region Properties
        public int CustomerId { get; set; }
        public string? Token { get; set; }
        #endregion
    }
}
