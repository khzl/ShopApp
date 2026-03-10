using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Interfaces.Dapper.Interface.Products
{
    public interface IProductQueryRepository
    {
        // Contracts

        // Get All Products
        public Task<IEnumerable<Entity_Product>> GetAllProductsAsync();

        // Search + Pagination
        public Task<(IEnumerable<Entity_Product>, int totalCount)> SearchAsync(
            string searchTerm, int pageNumber, int pageSize);
    }
}
