using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

public class BookAuthorController : ControllerBase
{
    private readonly IBookAuthorService _bookAuthorService;

    public BookAuthorController(IBookAuthorService bookAuthorService)
        => _bookAuthorService = bookAuthorService;
    
    [HttpPost("AddBookAuthor")]
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

    [HttpPut("UpdateBookAuthor")]
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

    [HttpDelete("DeleteBookAuthor/{id}")]
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

    [HttpGet("GetBookAuthor/{id}")]
    public async Task<IActionResult> GetBookAuthorById(int id)
    {
        try
        {
            var result = await _bookAuthorService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetBookAuthors")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _bookAuthorService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}