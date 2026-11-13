using BusinessLogic.Services.Interfaces;
using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Salla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProducetService _productService;
        public ProductsController(
          IProducetService productService
          )
        {
            _productService = productService;


        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<ProductResponseDTO>>> GetAll()
        {
            var productsDto = _productService.GetAllAsync();
            return Ok(new { productsDto });

        }
        [HttpGet("{id}")]
        [AllowAnonymous]

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ProductResponseDTO productResponse = await _productService.GetByIdAsync(id);
            if (productResponse is null) return NotFound();
            return Ok(productResponse);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductRequestDTO productRequest)
        {
            await _productService.CreateFile(productRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductRequestDTO productRequest)
        {
            bool isExist = await _productService.Update(id, productRequest);
            if (isExist is false) return NotFound(new { message = "Not found" });
            return Ok(new { message = "Updated" });
        }
        [HttpPatch("{id}/toggle-status")]
        public async Task<IActionResult> ToggleStatus([FromRoute] int id)
        {
            bool isExist = await _productService.ToggleStatus(id);
            if (isExist is false) return NotFound(new { message = "Not found" });
            return Ok(new { message = "Updated" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool isExist = await _productService.DeleteFile(id);
            if (isExist is false) return NotFound(new { message = "Not found" });
            return Ok(new { message = "Deleted" });
        }
    }
}
