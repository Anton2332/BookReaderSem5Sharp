using Application.TypeBookmark.Commands;
using Application.TypeBookmark.Commands.CreateTypeBookmark;
using Application.TypeBookmark.Commands.DeleteTypeBookmark;
using Application.TypeBookmark.Commands.UpdateTypeBookmark;
using Application.TypeBookmark.Queries.GetTypeBookmark;
using Application.TypeBookmark.Queries.GetTypeBookmarks;
using Application.TypeBookmark.Queries.GetTypeBookmarksByUserId;
using Domain.QueryMapper;
using Microsoft.AspNetCore.Mvc;

namespace API3.Controllers.v1;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class TypeBookmarksController : BaseController
{
    [HttpPost("AddTypeBookmark")]
    public async Task<IActionResult> CreatTypeBookmark([FromBody] TypeBookmarkDTO createTypeBookmarkDto)
    {
        var result = await Mediator.Send(new CreateTypeBookmarkCommand()
        {
            CreateTypeBookmarkDto = new TypeBookmarkDTO(createTypeBookmarkDto)
        });

        return Ok(result);
    }

    [HttpPost("GetTypeBookmarks")]
    public async Task<IActionResult> GetTypeBookmarks([FromBody] QueryOptions options)
    {
        var results = await Mediator.Send(new GetTypeBookmarksQuery()
        {
            QueryOptions = options
        });

        return Ok(results);
    }

    [HttpPut("UpdateTypeBookmark/{id}")]
    public async Task<ActionResult<bool>> UpdateTypeBookmark([FromBody] TypeBookmarkDTO updateTypeBookmarkDto, int id)
    {
        var result = await Mediator.Send(new UpdateTypeBookmarkCommand()
        {
            UpdateTypeBookmarkDto = updateTypeBookmarkDto,
            Id = id,
        });

        return Ok(result);
    }

    [HttpDelete("DeleteTypeBookmark/{id}")]
    public async Task<IActionResult> DeleteTypeBookmark(int id)
    {
        var result = await Mediator.Send(new DeleteTypeBookmarkCommand()
        {
            Id = id,
        });

        return Ok(result);
    }

    [HttpGet("GetTypeBookmarkBy/{id}")]
    public async Task<IActionResult> GetTypeBookmarkById(int id)
    {
        var result = await Mediator.Send(new GetTypeBookmarkQuery()
        {
            Id = id,
        });

        return Ok(result);
    }

    [HttpPost("GetTypeBookmarksByUserId/{userId}")]
    public async Task<IActionResult> GetTypeBookmarksByUserId(string userId,[FromBody] QueryOptions options)
    {
        var result = await Mediator.Send(new GetTypeBookmarksByUserIdQuery()
        {
            Id = userId,
            QueryOptions = options,
        });
    
        return Ok(result);
    }
}