using BLL1.DTO.Responses;
using BLL1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController: ControllerBase
{
    private ICommentsService _commentsService;

    public CommentsController(ICommentsService commentsService)
    {
        _commentsService = commentsService;
    }

    [HttpGet("GetAllComments")]
    public async Task<ActionResult<IEnumerable<CommentsResponsDTO>>> GetAllByBookId(int bookId)
    {
        try
        {
            var results = await _commentsService.GetAllByBookIdAsync(bookId);
            return Ok(results);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
}