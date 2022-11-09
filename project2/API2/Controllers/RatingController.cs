using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

public class RatingController : ControllerBase
{
    private readonly IRatingService _ratingService;

    public RatingController(IRatingService ratingService)
        => _ratingService = ratingService;
    
    [HttpPost("AddRating")]
    public async Task<IActionResult> AddPageAsync([FromBody] RatingRequestDTO requestDto)
    {
        try
        {
            await _ratingService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut("UpdateRating")]
    public async Task<IActionResult> UpdatePageAsync([FromBody] RatingRequestDTO requestDto)
    {
        try
        {
            await _ratingService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("DeleteRating/{id}")]
    public async Task<IActionResult> DeletePageAsync(int id)
    {
        try
        {
            await _ratingService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetRating/{id}")]
    public async Task<IActionResult> GetPageById(int id)
    {
        try
        {
            var result = await _ratingService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetRatings")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _ratingService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}