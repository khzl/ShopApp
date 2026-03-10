using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Dtos.Products
{
    public class Product_Dto
    {
        #region Properties
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        #endregion
    }
}
