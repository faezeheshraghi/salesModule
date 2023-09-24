using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesModule.Data;
using SalesModule.Models;

namespace SalesModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepository<Product> _productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return Ok(await _productRepository.GetAllAsync());
        }
       
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product Product)
        {
            _productRepository.Add(Product);
            return Ok(await _productRepository.SaveChangesAsync());
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product Product)
        {
            _productRepository.Update(Product);
            return Ok(await _productRepository.SaveChangesAsync());
        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Int64 id)
        {
            await _productRepository.Delete(id);
            return Ok(await _productRepository.SaveChangesAsync());
        }
    }
}
