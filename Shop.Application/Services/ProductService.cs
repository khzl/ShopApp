using Shop.Application.Interfaces;
using Shop.Dtos.Products;
using Shop.Infrastructure.Interfaces.Dapper.Interface.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Services
{
    public class ProductService : IProductService
    {
        // private properties
        private readonly IProductQueryRepository _productQueryRepo;

        // public Constructor
        public ProductService(IProductQueryRepository productQueryRepo)
        {
            _productQueryRepo = productQueryRepo;
        }

        // Feature 4 -> Get All Products
        public async Task<IEnumerable<Product_Dto>> GetAllProductsAsync()
        {
            var products = await _productQueryRepo.GetAllProductsAsync();

            return products.Select(p => new Product_Dto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price
            });
        }

        // Feature 5 -> Search And Paginations
        public async Task<PagedResult_Dto<Product_Dto>> SearchProductsAsync(
            string searchTerm, int pageNumber , int pageSize)
        {
            var (products, total) = await _productQueryRepo.SearchAsync(searchTerm, pageNumber, pageSize);

            return new PagedResult_Dto<Product_Dto>
            {
                Items = products.Select(p => new Product_Dto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price
                }),
                TotalCount = total
            };
        }


    }
}
