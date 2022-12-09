using BLL2.DTO.Request;
using BLL2.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedProject.Models;

namespace API2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ChapterController : ControllerBase
{
    private readonly IChapterService _chapterService;
    private readonly IPublishEndpoint _publishEndpoint;

    public ChapterController(IChapterService chapterService, IPublishEndpoint publishEndpoint)
    {
        _chapterService = chapterService;
        _publishEndpoint = publishEndpoint;
    }


    [HttpPost]
    public async Task<IActionResult> AddChapterAsync([FromBody] ChapterRequestDTO requestDto)
    {
        try
        {
            await _chapterService.AddAsync(requestDto);
            Console.WriteLine(requestDto);
            await _publishEndpoint.Publish<ChapterModel>(new()
            {
                BookId = requestDto.BookId,
                ChapterId = requestDto.ChapterId,
                ChapterName = requestDto.ChapterName,
                CreatedAt = requestDto.CreatedAt
            });
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut]
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

    [HttpDelete("{id}")]
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

    [HttpGet("{id}")]
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

    [HttpGet]
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
    
    [HttpGet("GetAllByBookId/{bookId}")]
    public async Task<IActionResult> GetAllChapterByBookIdAsync(int bookId)
    {
        try
        {
            var result = await _chapterService.GetAllByBookIdAsync(bookId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("GetCountByBookId/{bookId}")]
    public async Task<IActionResult> GetCountChapterByBookIdAsync(int bookId)
    {
        try
        {
            var result = await _chapterService.GetCountChapterByCountIdAsync(bookId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
    
    [HttpGet("GetLastChapters")]
    public async Task<IActionResult> GetLastChapters()
    {
        try
        {
            var results = await _chapterService.GetLastChapterAsync();
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

}