﻿using BLL1.DTO.Requests;
using BLL1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentLikesController : ControllerBase
{
    private ICommentsLikesService _commentsLikesService;

    public CommentLikesController(ICommentsLikesService commentsLikesService)
    {
        _commentsLikesService = commentsLikesService;
    }

    [HttpGet("GetCountLikesByCommentIdAsync")]
    public async Task<ActionResult<IEnumerable<int>>> GetCountLikesByCommentId(int id)
    {
        try
        {
            var result = await _commentsLikesService.CountLikesByCommentIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
    
    [HttpGet("GetCountDislikeByCommentIdAsync")]
    public async Task<ActionResult<IEnumerable<int>>> GetCountDislikeByCommentId(int id)
    {
        try
        {
            var result = await _commentsLikesService.CountDislikesByCommentIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    [HttpPost("Like")]
    public async Task<ActionResult<int?>> Like([FromBody] CommentLikesRequestDTO likesRequestDto)
    {
        try
        {
            var id = await _commentsLikesService.AddLikeAsync(likesRequestDto);
            return Ok(id);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
    
    [HttpPost("Dislike")]
    public async Task<ActionResult<int?>> Dislike([FromBody] CommentLikesRequestDTO likesRequestDto)
    {
        try
        {
            var id = await _commentsLikesService.AddDislikeAsync(likesRequestDto);
            return Ok(id);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

}