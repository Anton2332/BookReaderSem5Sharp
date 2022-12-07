using BLL1.DTO.Requests;
using BLL1.Interfaces;
using DAL1.Interface;
using MassTransit;
using SharedProject.Models;

namespace API1.Consumer;

// public class BookConsumer : IConsumer<BookModel>
// {
//     private readonly IBookCommentsService _bookCommentsService;
//
//     public BookConsumer(IBookCommentsService bookCommentsService)
//     {
//         _bookCommentsService = bookCommentsService;
//     }
//     public async Task Consume(ConsumeContext<BookModel> context)
//     {
//         var data = context.Message.Id;
//         await _bookCommentsService.AddAsync(new BookCommentsRequestDTO() { Id = data });
//         var r = await _bookCommentsService.GetAllAsync();
//         foreach (var i in r)
//         {
//             Console.WriteLine(i.Id);
//         }
//     }
// }
