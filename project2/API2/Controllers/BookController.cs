using BLL2.DTO.Request;
using BLL2.Interfaces;
using DAL2.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedProject.Models;

namespace API2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IPublishEndpoint _publishEndpoint;

    public BookController(IBookService bookService, IPublishEndpoint publishEndpoint)
    {
        _bookService = bookService;
        _publishEndpoint = publishEndpoint;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddBookAsync([FromBody] BookRequestDTO requestDto)
    {
        try
        {
            var id = await _bookService.AddAsync(requestDto);
            // var endPoint = await _bus.GetSendEndpoint(new Uri("queue:book_comment_create"));
            await _publishEndpoint.Publish<BookModel>(new ()
            {
                Id = id
            });
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpPut]
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

    [HttpDelete("{id}")]
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

    [HttpGet("{id}")]
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

    [HttpGet]
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
    
    [HttpPost("GetPagedBooks")]
    public async Task<IActionResult> GetPagedBooksAsync([FromBody]QueryStringParameters query)
    {
        try
        {
            var results = await _bookService.GetPagedBooksAsync(query);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}