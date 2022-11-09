using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
        => _categoryService = categoryService;
    
    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryRequestDTO requestDto)
    {
        try
        {
            await _categoryService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategoryAsync([FromBody] CategoryRequestDTO requestDto)
    {
        try
        {
            await _categoryService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {
        try
        {
            await _categoryService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetCategory/{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        try
        {
            var result = await _categoryService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetCategories")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _categoryService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}