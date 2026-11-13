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

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<CategoryResponseDTO>>> GetAll()
        {
            var categoryDTOs = await _categoryService.GetAllAsync();
            return Ok(new { categoryDTOs });

        }
        [HttpGet("{id}")]
        [AllowAnonymous]

        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            CategoryResponseDTO categoryResponseDTO = await _categoryService.GetByIdAsync(id);
            if (categoryResponseDTO is null) return NotFound();
            return Ok(categoryResponseDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequestDTO categoryDTO)
        {
            await _categoryService.CreateAsync(categoryDTO);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryRequestDTO categoryRequestDTO)
        {
            bool isExist = await _categoryService.Update(id, categoryRequestDTO);
            if (isExist is false) return NotFound(new { message = "Not found" });
            return Ok(new { message = "Updated" });
        }
        [HttpPatch("{id}/toggle-status")]
        public async Task<IActionResult> ToggleStatus([FromRoute] int id)
        {
            bool isExist = await _categoryService.ToggleStatus(id);
            if (isExist is false) return NotFound(new { message = "Not found" });
            return Ok(new { message = "Updated" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool isExist = await _categoryService.Delete(id);
            if (isExist is false) return NotFound(new { message = "Not found" });
            return Ok(new { message = "Deleted" });
        }
    }
}
