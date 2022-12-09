using API3.Interfaces;
using GrpcClient;

namespace API3.Services;

public class BookServices : IBookService
{
    private readonly Book.BookClient _client;

    public BookServices(Book.BookClient client)
    {
        _client = client;
    }
    
    public async Task<BookModel> GetBookByIdModel(int id)
    {
        var result = await _client.GetBookByIdAsync(new GetBookByIdModel()
        {
            BookId = id
        });
        return result;
    }
}