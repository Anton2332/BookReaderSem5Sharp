using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookCategoryService : ControllerBase
{
    private readonly IBookCategoryService _bookCategoryService;

    public BookCategoryService(IBookCategoryService bookCategoryService)
        => _bookCategoryService = bookCategoryService;
    
    [HttpPost]
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

    [HttpPut]
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

    [HttpDelete("{id}")]
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

    [HttpGet("GetAllByBookId/{bookId}")]
    public async Task<IActionResult> GetAllByBookIdAsync(int bookId)
    {
        try
        {
            var results = await _bookCategoryService.GetAllCategoriesByBookIdAsync(bookId, null);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}