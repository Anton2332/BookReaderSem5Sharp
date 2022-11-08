using DAL2.Entitys;
using DAL2.Helpers;
using DAL2.Models;

namespace DAL2.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<Page<Book>> GetPagedBooksAsync(
        // BookCategory[] category, 
        // bool searchByAllCategories,
        // BookTag[] tags,
        // bool searchByAllTags,
        QueryStringParameters queryStringParameters);
}