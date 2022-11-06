using Application.Notification.Commands;
using Application.Notification.Commands.CreateNotification;
using Application.Notification.Commands.DeleteNotification;
using Application.Notification.Commands.UpdateNotification;
using Application.Notification.Queries.GetNotification;
using Application.Notification.Queries.GetNotifications;
using Application.Notification.Queries.GetNotificationsByBookmarkId;
using Domain.QueryMapper;
using Microsoft.AspNetCore.Mvc;

namespace API3.Controllers.v1;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class NotificationController : BaseController
{
    [HttpPost("AddNotification")]
    public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationDTO createNotificationDto)
    {
        var result = await Mediator.Send(new CreateNotificationCommand()
        {
            CreateNotificationDto = createNotificationDto,
        });

        return Ok(result);
    }

    [HttpPost("GetNotifications/{isRead}")]
    public async Task<IActionResult> GetNotifications([FromBody] QueryOptions options, bool isRead)
    {
        var results = await Mediator.Send(new GetNotificationsQuery()
        {
            isRead = isRead,
            QueryOptions = options,
        });

        return Ok(results);
    }

    [HttpPut("UpdateNotificatoin/{id}")]
    public async Task<IActionResult> UpdateNotification([FromBody] NotificationDTO updateNotificationDto, int id)
    {
        var result = await Mediator.Send(new UpdateNotificationCommand()
        {
            UpdateNotificationDto = updateNotificationDto,
            Id = id
        });

        return Ok(result);
    }

    [HttpDelete("DeleteNotification/{id}")]
    public async Task<IActionResult> DeleteNotification(int id)
    {
        var result = await Mediator.Send(new DeleteNotificationCommand()
        {
            Id = id
        });

        return Ok(result);
    }

    [HttpGet("GetNotification/{id}")]
    public async Task<IActionResult> GetNotificationById(int id)
    {
        var result = await Mediator.Send(new GetNotificationQuery()
        {
            Id = id
        });

        return Ok(result);
    }

    [HttpPost("GetNotificationByBookmarkId/{bookmarkId}/{isRead}")]
    public async Task<IActionResult> GetNotificationByBookmarkId(int bookmarkId,bool isRead,[FromBody] QueryOptions options)
    {
        var results = await Mediator.Send(new GetNotificationsByBookmarkIdQuery()
        {
            IsRead = isRead,
            QueryOptions = options,
            BookmarkId = bookmarkId,
        });

        return Ok(results);
    }



}