using App.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.API.Controllers
{
    public class ProductsController(IProductService productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
          var serviceResult = await productService.GetAllListAsync();
            //if (productResult.IsSuccess())
            //{
            //    return Ok(productResult.Data);
            //}
            //else
            //{
            //    return BadRequest(productResult.ErrorMessage);
            //}
            return CreateActionResult(serviceResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id) =>  CreateActionResult(await productService.GetByIdAsync(id)); //2.KOLAY KULLANIM.



        //CustomController sayesinde daha kısa olucak
        // if (productResult.Status ==HttpStatusCode.NoContent)
        // {
        //     new ObjectResult(null) { StatusCode = (int)productResult.Status.GetHashCode() };
        // }
        //return new ObjectResult(productResult) { StatusCode = (int)productResult.Status.GetHashCode() }; 
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var serviceResult = await productService.CreateAsync(request);
            return CreateActionResult(serviceResult);  //getbyId kolay kullanım buda uzun .
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request)
        {
            var serviceResult = await productService.UpdateAsync(id, request);
            return CreateActionResult(serviceResult);  //getbyId kolay kullanım buda uzun .
        }

    }
}
