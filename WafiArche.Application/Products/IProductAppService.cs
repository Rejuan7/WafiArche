using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Application.Products.Dto;
using WafiArche.Domain.Products;

namespace WafiArche.Application.Products
{
    public interface IProductAppService
    {
        // CREATE
        Task<ProductDto> CreateProductAsync(ProductDto productDto);

        // READ ALL
        Task<List<ProductDto>> GetAllProductsAsync();

        // READ BY ID
        Task<ProductDto> GetProductByIdAsync(int id);

        // UPDATE
        Task<ProductDto> UpdateProductAsync(int id, ProductDto productDto);

        // DELETE
        Task<bool> DeleteProductAsync(int id);
    }
}
