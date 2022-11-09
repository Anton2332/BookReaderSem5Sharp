using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
        => _bookService = bookService;
    
    [HttpPost("AddBook")]
    public async Task<IActionResult> AddBookAsync([FromBody] BookRequestDTO requestDto)
    {
        try
        {
            await _bookService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut("UpdateBook")]
    public async Task<IActionResult> UpdateBookAsync([FromBody] BookRequestDTO requestDto)
    {
        try
        {
            await _bookService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("DeleteBook/{id}")]
    public async Task<IActionResult> DeleteBookAsync(int id)
    {
        try
        {
            await _bookService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetBook/{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        try
        {
            var result = await _bookService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetBooks")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _bookService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}