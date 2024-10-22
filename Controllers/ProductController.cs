using BlazorApi.Models;
using BlazorApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApi.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository; 
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return await Task.Run(() => Ok(productRepository.GetProducts().Result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProduct createProduct)
        {
            return await Task.Run(() => Ok(productRepository.CreateProduct(createProduct).Result));
        }

        [HttpPut]
        public async Task<IActionResult> ModifyProduct(ModifyProduct modifyProduct)
        {
            return await Task.Run(() => Ok(productRepository.ModifyProduct(modifyProduct).Result));

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return await Task.Run(() => Ok(productRepository.DeleteProduct(id).Result));

        }
    }
}
