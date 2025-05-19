using App.Repositories;
using App.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Products
{
    public class ProductService(IProductRepository productRepository) :IProductService
    {
       public async Task<ServiceResult< List<Product>>> GetTopPriceProductAsync(int count)
        {
            var products = await productRepository.GetTopPriceProductAsync(count);
            return new ServiceResult<List<Product>>()
            {
               Data = products,
            }; 
        }
        public async Task<ServiceResult<Product>> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if(product is null)
            {
              ServiceResult<Product>.Fail(errorMessage: "Product not found", HttpStatusCode.NotFound);
            }

            return ServiceResult<Product>.Succes(product!);
        }
    }
    
}
