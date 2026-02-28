using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Dtos.Register
{
    public class RegisterResponseDto
    {
        #region Properties
        public int CustomerId { get; set; }
        public string? Message { get; set; }
        // Response بسيط ما نرجع Token هسه
        #endregion
    }
}
