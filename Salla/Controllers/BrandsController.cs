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

    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<BrandResponseDTO>>> GetAllBrands()
        {
            var brands = await _brandService.GetAllAsync();
            return Ok(new { brands });
        }
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<BrandResponseDTO>> GetByIdBrand(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            if(brand == null)
                return NotFound(new { message = "Brand not found" });
            return Ok(new { brand });
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(BrandRequestDTO brand)
        {
            await _brandService.CreateFileAsync(brand);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBrand(int id, BrandRequestDTO brand)
        {
            await _brandService.Update(id, brand);
            return NoContent();
        }
        [HttpPut("{id:int}/toggle-status")]
        public async Task<IActionResult> ToggleStatus( int id)
        {
            bool isExist = await _brandService.ToggleStatus(id);
            if (isExist is false) 
                return NotFound(new { message = "Not found" });
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            bool isExist = await _brandService.DeleteFileAsync(id);
            if (isExist is false)
                return NotFound(new { message = "Not found" });
            return NoContent();
        }
    }
}
