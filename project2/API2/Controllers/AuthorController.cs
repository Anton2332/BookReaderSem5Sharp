using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService) => _authorService = authorService;

    [HttpPost("AddAuthor")]
    public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorRequestDTO authorResponseDto)
    {
        try
        {
            await _authorService.AddAsync(authorResponseDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut("UpdateAuthor")]
    public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorRequestDTO authorResponseDto)
    {
        try
        {
            await _authorService.UpdateAsync(authorResponseDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("DeleteAuthor/{id}")]
    public async Task<IActionResult> DeleteAuthorAsync(int id)
    {
        try
        {
            await _authorService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetAuthor/{id}")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
        try
        {
            var result = await _authorService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetAuthors")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _authorService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpPost("GetAuthorsWithoutIds")]
    public async Task<IActionResult> GetAllWithoutAsync(int[] ids)
    {
        try
        {
            var results = await _authorService.GetAllWithoutIdsAsync(ids);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
    
}