using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Dtos.Login
{
    public class LoginRequestDto
    {
        #region Properties
        public string? Email { get; set; }
        public string? Password { get; set; }
        #endregion
    }
}
