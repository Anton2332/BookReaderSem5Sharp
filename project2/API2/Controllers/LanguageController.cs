using BLL2.DTO.Request;
using BLL2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

public class LanguageController : ControllerBase
{
    private readonly ILanguageService _languageService;

    public LanguageController(ILanguageService languageService)
        => _languageService = languageService;
    
    [HttpPost("AddLanguage")]
    public async Task<IActionResult> AddLanguageAsync([FromBody] LanguageRequestDTO requestDto)
    {
        try
        {
            await _languageService.AddAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut("UpdateLanguage")]
    public async Task<IActionResult> UpdateLanguageAsync([FromBody] LanguageRequestDTO requestDto)
    {
        try
        {
            await _languageService.UpdateAsync(requestDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("DeleteLanguage/{id}")]
    public async Task<IActionResult> DeleteLanguageAsync(int id)
    {
        try
        {
            await _languageService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetLanguage/{id}")]
    public async Task<IActionResult> GetLanguageById(int id)
    {
        try
        {
            var result = await _languageService.GetByIdAsync(id);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetLanguages")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var results = await _languageService.GetAllAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}