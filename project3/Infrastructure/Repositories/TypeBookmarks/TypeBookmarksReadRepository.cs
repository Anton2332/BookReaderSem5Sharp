using System.Linq.Dynamic.Core;
using System.Reflection;
using Domain.Interfaces.TypeBookmark;
using Domain.QueryMapper;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories.TypeBookmarks;

public class TypeBookmarksReadRepository : ITypeBookmarkRepository
{
    private readonly IDataContext _context;

    public TypeBookmarksReadRepository(IDataContext context)
    {
        _context = context;
    }
    public IEnumerable<Domain.Entities.TypeBookmarks> GetAll(QueryOptions options)
    {
        try
        {
            PropertyInfo sortByDate =
                typeof(Domain.Entities.Bookmarks).GetProperty(options.SortBy?.Trim() ?? "UpdatedAt") ??
                typeof(Domain.Entities.Bookmarks).GetProperty("CreatedAt");
            
            if (options.Sort?.Trim().ToLower() == "asc")
            {
                return _context.TypeBookmarks.AsQueryable()
                    .OrderBy(sortByDate.Name)
                    .Take(options.Limit)
                    .ToList();
            }
            else
            {
                return _context.TypeBookmarks.AsQueryable()
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

    public Domain.Entities.TypeBookmarks Get(int id)
    {
        try
        {
            var result = _context.TypeBookmarks.Find(x => x.Id == id).FirstOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public IEnumerable<Domain.Entities.TypeBookmarks> GetByUserId(string userId, QueryOptions options)
    {
        try
        {
            PropertyInfo sortByDate =
                typeof(Domain.Entities.Bookmarks).GetProperty(options.SortBy?.Trim() ?? "UpdatedAt") ??
                typeof(Domain.Entities.Bookmarks).GetProperty("CreatedAt");
            
            if (options.Sort?.Trim().ToLower() == "asc")
            {
                return _context.TypeBookmarks.AsQueryable()
                    .Where(x => x.UserId == userId)
                    .OrderBy(sortByDate.Name)
                    .Take(options.Limit)
                    .ToList();
            }
            else
            {
                return _context.TypeBookmarks.AsQueryable()
                    .Where(x => x.UserId == userId)
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
}