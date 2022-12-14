using System.Runtime.InteropServices;
using BLL1.DTO.Requests;
using BLL1.DTO.Responses;
using BLL1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private ICommentsService _commentsService;

    public CommentsController(ICommentsService commentsService)
    {
        _commentsService = commentsService;
    }

    [HttpGet("GetAllCommentsByBookId/{bookId}")]
    public async Task<ActionResult<IEnumerable<CommentsResponsDTO>>> GetAllByBookId(int bookId)
    {
        try
        {
            var results = await _commentsService.GetAllByBookIdAsync(bookId);
            if (results == null)
                return StatusCode(StatusCodes.Status204NoContent);
            return Ok(results);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
    
    [HttpGet("GetCommentsByBookId/{bookId}")]
    public async Task<ActionResult<IEnumerable<CommentsResponsDTO>>> GetCommentsByBookId(int bookId)
    {
        try
        {
            var results = await _commentsService.GetCommentsByBookIdAsync(bookId);
            if (results.Count() == 0)
            {
                return NoContent();
            }
            return Ok(results);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    [HttpGet("GetRepliesByCommentId/{commentId}")]
    public async Task<ActionResult<IEnumerable<CommentsResponsDTO>>> GetAllRepliesByCommentId(int commentId)
    {
        try
        {
            var results = await _commentsService.GetRepliesByCommentIdAsync(commentId);
            return Ok(results);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddComment([FromBody] CommentsRequestDTO comment)
    {
        try
        {
            await _commentsService.AddAsync(comment);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateComment(CommentsRequestDTO comment)
    {
        try
        {
            await _commentsService.UpdateAsync(comment);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteComment(int id)
    {
        try
        {
            await _commentsService.DeleteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

}