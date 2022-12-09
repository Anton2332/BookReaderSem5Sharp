using BLL2.Interfaces;
using Grpc.Core;
using GrpcServer;

namespace API2.Service;

public class BookService : Book.BookBase
{
    private readonly IBookService _bookService;
    
    public BookService(IBookService bookService)
    {
        _bookService = bookService;
    }
  
    public override async Task<BookModel> GetBookById(GetBookByIdModel request, 
        ServerCallContext context)
    {
        try
        {
            var result = await _bookService.GetByIdAsync(request.BookId);
            return await Task.FromResult(new BookModel()
            {
                BookId = result.Id,
                Description = result.Description,
                Name = result.Name
            });
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public override async Task<BooksModel> GetBooksByIds(GetBookByIdsModel request, ServerCallContext context)
    {
        try
        {
            var numIds = request.Ids.Split(',').Select(id => (Ok: int.TryParse(id, out int x), Value: x));

            var idsToSelect = numIds
                .Select(id => id.Value).ToList();
            var result = await _bookService.GetByIdsAsync(idsToSelect);
            // var results = List<Book>
            return null;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}