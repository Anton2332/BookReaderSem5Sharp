using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

public class ChapterController : ControllerBase
{
    private readonly IChapterService _chapterService;

    public ChapterController(IChapterService chapterService)
        => _chapterService = chapterService;
    
    [HttpPost("AddChapter")]
    public async Task<IActionResult> AddChapterAsync([FromBody] ChapterRequestDTO requestDto)
    {
        try
        {
            await _chapterService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut("UpdateChapter")]
    public async Task<IActionResult> UpdateChapterAsync([FromBody] ChapterRequestDTO requestDto)
    {
        try
        {
            await _chapterService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("DeleteChapter/{id}")]
    public async Task<IActionResult> DeleteChapterAsync(int id)
    {
        try
        {
            await _chapterService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetChapter/{id}")]
    public async Task<IActionResult> GetChapterById(int id)
    {
        try
        {
            var result = await _chapterService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetChapters")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _chapterService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}