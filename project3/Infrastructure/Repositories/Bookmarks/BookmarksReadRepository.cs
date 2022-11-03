using System.Linq.Dynamic.Core;
using System.Reflection;
using Domain.Interfaces.Bookmark;
using Domain.QueryMapper;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories.Bookmarks;

public class BookmarksReadRepository : IBookmarkReadRepository
{

    private readonly IDataContext _context;

    public BookmarksReadRepository(IDataContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Domain.Entities.Bookmarks> GetAll(QueryOptions options)
    {
        try
        {
            PropertyInfo sortByDate =
                typeof(Domain.Entities.Bookmarks).GetProperty(options.SortBy?.Trim() ?? "UpdatedAt") ??
                typeof(Domain.Entities.Bookmarks).GetProperty("CreatedAt");
            
            if (options.Sort?.Trim().ToLower() == "asc")
            {
                return _context.Bookmarks.AsQueryable()
                    .OrderBy(sortByDate.Name)
                    .Take(options.Limit)
                    .ToList();
            }
            else
            {
                return _context.Bookmarks.AsQueryable()
                    .OrderBy($"{sortByDate.Name} DESC")
                    .Take(options.Limit)
                    .ToList();
            }
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public Domain.Entities.Bookmarks Get(int id)
    {
        try
        {
            var result = _context.Bookmarks.Find(x => x.Id == id).FirstOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public IEnumerable<Domain.Entities.Bookmarks> GetByTypeBookmarkId(int typeBookmarkId, QueryOptions options)
    {
        try
        {
            PropertyInfo sortByDate =
                typeof(Domain.Entities.Bookmarks).GetProperty(options.SortBy?.Trim() ?? "UpdatedAt") ??
                typeof(Domain.Entities.Bookmarks).GetProperty("CreatedAt");
            
            if (options.Sort?.Trim().ToLower() == "asc")
            {
                return _context.Bookmarks.AsQueryable()
                    .Where(x => x.TypeBookmarkId == typeBookmarkId)
                    .OrderBy(sortByDate.Name)
                    .Take(options.Limit)
                    .ToList();
            }
            else
            {
                return _context.Bookmarks.AsQueryable()
                    .Where(x => x.TypeBookmarkId == typeBookmarkId)
                    .OrderBy($"{sortByDate.Name} DESC")
                    .Take(options.Limit)
                    .ToList();
            }
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public Domain.Entities.Bookmarks GetByBookId(int BookId)
    {
        try
        {
            var result = _context.Bookmarks.Find(x => x.BookId == BookId).FirstOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}