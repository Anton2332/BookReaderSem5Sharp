using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

public class StatusController : ControllerBase
{
    private readonly IStatusService _statusService;

    public StatusController(IStatusService statusService)
        => _statusService = statusService;
    
    [HttpPost("AddStatus")]
    public async Task<IActionResult> AddStatusAsync([FromBody] StatusRequestDTO requestDto)
    {
        try
        {
            await _statusService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut("UpdateStatus")]
    public async Task<IActionResult> UpdateStatusAsync([FromBody] StatusRequestDTO requestDto)
    {
        try
        {
            await _statusService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("DeleteStatus/{id}")]
    public async Task<IActionResult> DeleteStatusAsync(int id)
    {
        try
        {
            await _statusService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetStatus/{id}")]
    public async Task<IActionResult> GetStatusById(int id)
    {
        try
        {
            var result = await _statusService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetStatuses")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _statusService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}