using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookTagController : ControllerBase
{
    private readonly IBookTagService _bookTagService;

    public BookTagController(IBookTagService bookTagService)
        => _bookTagService = bookTagService;
    
    [HttpPost]
    public async Task<IActionResult> AddBookTagAsync([FromBody] BookTagRequestDTO requestDto)
    {
        try
        {
            await _bookTagService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBookTagAsync([FromBody] BookTagRequestDTO requestDto)
    {
        try
        {
            await _bookTagService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookTagAsync(int id)
    {
        try
        {
            await _bookTagService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookTagById(int id)
    {
        try
        {
            var result = await _bookTagService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _bookTagService.GetAllAsync();
            return Ok(results);
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
            var results = await _bookTagService.GetAllTagsByBookIdAsync(bookId, null);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
    
    
}