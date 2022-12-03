using DAL2.Entitys;
using DAL2.Helpers;
using DAL2.Interfaces;
using DAL2.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(DBContext dbContext) : base(dbContext) {}
    
    public async Task<Page<Book>> GetPagedBooksAsync(
        // BookCategory[] category, 
        // bool searchByAllCategories,
        // BookTag[] tags,
        // bool searchByAllTags,
        QueryStringParameters queryStringParameters)
    {
        var items = Items;
        // foreach (var c in category)
        // {
        //     items = items.Where(x => x.BookCategory.Contains(c));
        // }
        //
        // foreach (var c in tags)
        // {
        //     items = items.Where(x => x.BookTag.Contains(c)); 
        // }
        

        var result = await items.ToPagedAsync(queryStringParameters);
        return result;
    }

    public async Task<IEnumerable<Book>> GetBooksByIdsAsync(List<int> ids)
    {
        var results = await Items.Where(b => ids.Contains(b.Id)).ToListAsync();

        return results;
    }
}