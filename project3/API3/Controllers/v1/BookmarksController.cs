using API3.Interfaces;
using Application.Bookmark.Commands.CreateBookmark;
using Application.Bookmark.Commands.DeleteBookmark;
using Application.Bookmark.Commands.UpdateBookmark;
using Application.Bookmark.Queries.GetBookmark;
using Application.Bookmark.Queries.GetBookmarks;
using Application.Bookmark.Queries.GetBookmarksByTypeBookmarkId;
using Domain.QueryMapper;
using Grpc.Net.Client;
using GrpcClient;
using Microsoft.AspNetCore.Mvc;

namespace API3.Controllers.v1;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class BookmarksController : BaseController
{

    private IBookService _client;

    public BookmarksController( IBookService client)
    {
        _client = client;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBookmark([FromBody] CreateBookmarkDTO createBookmarkDto)
    {
        var result = await Mediator.Send(new CreateBookmarkCommand()
        {
            CreateBookmarkDto = createBookmarkDto
        });

        return Ok(result);
    }

    [HttpPost("GetBookmarks")]
    public async Task<IActionResult> GetTypeBookmarks([FromBody] QueryOptions options)
    {
        var results = await Mediator.Send(new GetBookmarksQuery()
        {
            QueryOptions = options
        });

        return Ok(results);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> UpdateBookmark([FromBody] UpdateBookmarkDTO updateBookmarkDto, int id)
    {
        var result = await Mediator.Send(new UpdateBookmarkCommand()
        {
            Id = id,
            UpdateBookmarkDto = updateBookmarkDto,
        });

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookmark(int id)
    {
        var result = await Mediator.Send(new DeleteBookmarkCommand()
        {
            Id = id,
        });

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookmarkById(int id)
    {
        var result = await Mediator.Send(new GetBookmarkQuery()
        {
            Id = id,
        });

        return Ok(result);
    }

    [HttpPost("GetBookmarkByTypeBookmarkId/{typeBookmarkId}")]
    public async Task<IActionResult> GetBookmarkByTypeBookmarkId([FromBody]QueryOptions options ,int typeBookmarkId)
    {
        var results = await Mediator.Send(new GetBookmarksByTypeBookmarkIdQuery()
        {
            TypeBookmarkId = typeBookmarkId,
            QueryOptions = options,
        });

        try
        {
            foreach (var item in results)
            {
                var book_data = await _client.GetBookByIdModel(item.BookId);
                item.BookDescription = book_data.Description;
                item.BookName = book_data.Name;
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
        }

        return Ok(results);
    }
    
}