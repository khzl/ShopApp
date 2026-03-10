using Dapper;
using Shop.Domain.Entities;
using Shop.Infrastructure.Interfaces.Dapper.Interface.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shop.Infrastructure.Repositories.Dapper.Repositories.Products
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        // private properties 
        private readonly IDbConnection _db;

        // public Constructor
        public ProductQueryRepository(IDbConnection db)
        {
            _db = db;
        }

        // Feature 4 => Get All Products 
        public async Task<IEnumerable<Entity_Product>> GetAllProductsAsync()
        {
            return await _db.QueryAsync<Entity_Product>(
                "sp_GetAllProducts",
                commandType: CommandType.StoredProcedure);
        }

        // Feature 5 => Search + Pagination
        public async Task<(IEnumerable<Entity_Product> , int)> SearchAsync(
            string searchTerm , int pageNumber , int pageSize)
        {
            var result = await _db.QueryAsync<ProductWithCount>(
                "sp_SearchProducts",
                new
                {
                    SearchTerm = searchTerm,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                },
                commandType: CommandType.StoredProcedure);

            var items = result.ToList();

            var total = items.FirstOrDefault()?.TotalCount ?? 0;

            return (items, total);
        }

        // Class داخلي For Mapping
        private class ProductWithCount : Entity_Product
        {
            // Properties
            public int TotalCount { get; set; }
        }
    }
}
