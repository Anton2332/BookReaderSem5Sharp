using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserBookController : ControllerBase
{
    private readonly IUserBookService _userBookService;

    public UserBookController(IUserBookService userBookService)
        => _userBookService = userBookService;
    
    [HttpPost]
    public async Task<IActionResult> AddTagAsync([FromBody] UserBookRequestDTO requestDto)
    {
        try
        {
            await _userBookService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTagAsync([FromBody] UserBookRequestDTO requestDto)
    {
        try
        {
            await _userBookService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTagAsync(string id)
    {
        try
        {
            await _userBookService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagById(string id)
    {
        try
        {
            var result = await _userBookService.GetByIdAsync(id);

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
            var results = await _userBookService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}