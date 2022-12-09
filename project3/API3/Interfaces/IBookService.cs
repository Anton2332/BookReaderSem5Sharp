using GrpcClient;

namespace API3.Interfaces;

public interface IBookService
{
    Task<BookModel> GetBookByIdModel(int id);
}