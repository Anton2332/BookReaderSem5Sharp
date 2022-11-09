using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

public class PageController : ControllerBase
{
    private readonly IPageService _pageService;

    public PageController(IPageService pageService)
        => _pageService = pageService;
    
    [HttpPost("AddPage")]
    public async Task<IActionResult> AddPageAsync([FromBody] PageRequestDTO requestDto)
    {
        try
        {
            await _pageService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut("UpdatePage")]
    public async Task<IActionResult> UpdatePageAsync([FromBody] PageRequestDTO requestDto)
    {
        try
        {
            await _pageService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("DeletePage/{id}")]
    public async Task<IActionResult> DeletePageAsync(int id)
    {
        try
        {
            await _pageService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetPage/{id}")]
    public async Task<IActionResult> GetPageById(int id)
    {
        try
        {
            var result = await _pageService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetPages")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _pageService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}