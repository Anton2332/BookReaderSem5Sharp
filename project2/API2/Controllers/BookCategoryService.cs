using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

public class BookCategoryService : ControllerBase
{
    private readonly IBookCategoryService _bookCategoryService;

    public BookCategoryService(IBookCategoryService bookCategoryService)
        => _bookCategoryService = bookCategoryService;
    
    [HttpPost("AddBookCategory")]
    public async Task<IActionResult> AddBookCategoryAsync([FromBody] BookCategoryRequestDTO requestDto)
    {
        try
        {
            await _bookCategoryService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut("UpdateBookCategory")]
    public async Task<IActionResult> UpdateBookCategoryAsync([FromBody] BookCategoryRequestDTO requestDto)
    {
        try
        {
            await _bookCategoryService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("DeleteBookCategory/{id}")]
    public async Task<IActionResult> DeleteBookCategoryAsync(int id)
    {
        try
        {
            await _bookCategoryService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetBookCategory/{id}")]
    public async Task<IActionResult> GetBookCategoryById(int id)
    {
        try
        {
            var result = await _bookCategoryService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetBookCategory")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _bookCategoryService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}