using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookAuthorController : ControllerBase
{
    private readonly IBookAuthorService _bookAuthorService;

    public BookAuthorController(IBookAuthorService bookAuthorService)
        => _bookAuthorService = bookAuthorService;
    
    [HttpPost]
    public async Task<IActionResult> AddBookAuthorAsync([FromBody] BookAuthorRequestDTO requestDto)
    {
        try
        {
            await _bookAuthorService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBookAuthorAsync([FromBody] BookAuthorRequestDTO requestDto)
    {
        try
        {
            await _bookAuthorService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookAuthorAsync(int id)
    {
        try
        {
            await _bookAuthorService.DeleteAsync(id);

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
            var results = await _bookAuthorService.GetAllAuthorsByBookIdAsync(bookId, null);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}