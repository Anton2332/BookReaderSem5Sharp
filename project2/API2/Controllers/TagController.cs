using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
        => _tagService = tagService;
    
    [HttpPost("AddTag")]
    public async Task<IActionResult> AddTagAsync([FromBody] TagRequestDTO requestDto)
    {
        try
        {
            await _tagService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut("UpdateTag")]
    public async Task<IActionResult> UpdateTagAsync([FromBody] TagRequestDTO requestDto)
    {
        try
        {
            await _tagService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("DeleteTag/{id}")]
    public async Task<IActionResult> DeleteTagAsync(int id)
    {
        try
        {
            await _tagService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetTag/{id}")]
    public async Task<IActionResult> GetTagById(int id)
    {
        try
        {
            var result = await _tagService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetTags")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _tagService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}