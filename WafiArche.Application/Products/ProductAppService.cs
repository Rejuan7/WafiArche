using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Application.Products.Dto;
using WafiArche.Domain.Products;
using WafiArche.EntityFrameworkCore.Data;

namespace WafiArche.Application.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Create
        public async Task<ProductDto>CreateProductAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        //Read
        public async Task<List<ProductDto>>GetAllProductAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        //Read By Id
        public async Task<ProductDto>GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new Exception("Product Not Found");
            }
            return _mapper.Map<ProductDto>(product);
        }

        //Update
        public async Task<ProductDto> UpdateProductAsync(int id, ProductDto productDto)
        {
           
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new Exception("Product Not Found");
            }

            // Ensure the Id is not modified
            productDto.Id = product.Id;  

            // Map the properties from productDto to product, ignoring Id
            _mapper.Map(productDto, product);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        //Delete
        public async Task<bool>DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new Exception("Product Not Found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<ProductDto>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
