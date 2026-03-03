using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class Entity_RefreshToken
    {
        #region Properties
        public int TokenId { get; set; }
        public int CustomerId { get; set; }
        public string? Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; }
        #endregion
    }
}
