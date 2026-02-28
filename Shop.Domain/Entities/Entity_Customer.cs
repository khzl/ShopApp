using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{

    public class Entity_Customer
    {
        #region Property
        public int CustomerId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public bool IsActive { get; set; }

        #endregion
        /*
         * Domain 
         * ما يعرف UI ولا API و لا SQL 
         */
    }
}
