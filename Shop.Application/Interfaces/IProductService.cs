using Shop.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Interfaces
{
    public interface IProductService
    {
        // Contracts

        // GetAll Products
        public Task<IEnumerable<Product_Dto>> GetAllProductsAsync();

        // Search Products
        public Task<PagedResult_Dto<Product_Dto>> SearchProductsAsync(
            string searchTerm, int pageNumber, int pageSize);
    }
}
