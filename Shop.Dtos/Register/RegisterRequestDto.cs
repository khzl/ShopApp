using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Dtos.Register
{
    public class RegisterRequestDto
    {
        #region Properties
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        #endregion
    }
}
