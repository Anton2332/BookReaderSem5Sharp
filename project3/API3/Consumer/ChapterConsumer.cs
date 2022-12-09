using Application.Notification.Commands.CreateNotification;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedProject.Models;

namespace API3.Consumer;

public class ChapterConsumer : IConsumer<ChapterModel>
{
    private IMediator _mediator;

    public ChapterConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<ChapterModel> context)
    {
        var data = new CreateNotificationDTO()
        {
            BookId = context.Message.BookId,
            ChapterId = context.Message.ChapterId,
            ChapterName = context.Message.ChapterName
        };
        var result = await _mediator.Send(new CreateNotificationCommand()
        {
            CreateNotificationDto = data
        });
        Console.WriteLine(result);
    }
}