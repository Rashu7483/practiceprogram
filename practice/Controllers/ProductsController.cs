using Microsoft.AspNetCore.Mvc;
using practice.Dto;
using practice.Models;
using practice.Services;

namespace practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products= await _productService.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products= await _productService.GetByIdAsync(id);
            if (products == null) {
                return NotFound(new ProductError
                {
                    ProductId = id,
                    ErrorMessage= $"Product not found for the {id}"
                });
            }
            return Ok(products);
             
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Productdto productdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ProductError
                {
                    ErrorMessage = "Invalid product details provided."
                });
            }

            await _productService.AddAsync(productdto);
            return Ok(productdto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Productdto productdto)
        {
            if(id!=productdto.Id)
                return BadRequest(new ProductError
                {
                    ProductId= id,
                    ErrorMessage=$"Invalid {id}"
                });
            await _productService.UpdateAsync(id, productdto);
            return Ok(productdto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id<=0) 
                return BadRequest(new ProductError
                {
                    ProductId = id,
                    ErrorMessage = "Invalid ID."
                });
            await _productService.DeleteAsync(id);
            return Ok();
        }
    }
}
