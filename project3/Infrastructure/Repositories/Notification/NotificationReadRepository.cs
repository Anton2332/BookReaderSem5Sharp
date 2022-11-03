using System.Linq.Dynamic.Core;
using System.Reflection;
using Domain.Interfaces.Notification;
using Domain.QueryMapper;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories.Notification;

public class NotificationReadRepository : INotificationReadRepository
{
    private readonly IDataContext _context;

    public NotificationReadRepository(IDataContext context)
    {
        _context = context;
    }


    public IEnumerable<Domain.Entities.Notification> GetAll(QueryOptions options)
    {
        try
        {
            PropertyInfo sortByDate =
                typeof(Domain.Entities.Bookmarks).GetProperty(options.SortBy?.Trim() ?? "UpdatedAt") ??
                typeof(Domain.Entities.Bookmarks).GetProperty("CreatedAt");
            
            if (options.Sort?.Trim().ToLower() == "asc")
            {
                return _context.Notifications.AsQueryable()
                    .OrderBy(sortByDate.Name)
                    .Take(options.Limit)
                    .ToList();
            }
            else
            {
                return _context.Notifications.AsQueryable()
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

    public Domain.Entities.Notification Get(int id)
    {
        try
        {
            var result = _context.Notifications.Find(x => x.Id == id).FirstOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public IEnumerable<Domain.Entities.Notification> GetByBookmarkId(int bookmarkId, bool isRead, QueryOptions options)
    {
        
        try
        {
            PropertyInfo sortByDate =
                typeof(Domain.Entities.Bookmarks).GetProperty(options.SortBy?.Trim() ?? "UpdatedAt") ??
                typeof(Domain.Entities.Bookmarks).GetProperty("CreatedAt");
            
            if (options.Sort?.Trim().ToLower() == "asc")
            {
                return _context.Notifications.AsQueryable()
                    .Where(x => x.BookmarkId == bookmarkId && x.IsRead == isRead)
                    .OrderBy(sortByDate.Name)
                    .Take(options.Limit)
                    .ToList();
            }
            else
            {
                return _context.Notifications.AsQueryable()
                    .Where(x => x.BookmarkId == bookmarkId && x.IsRead == isRead)
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

    public IEnumerable<Domain.Entities.Notification> GetAll(bool isRead, QueryOptions options)
    {
        try
        {
            PropertyInfo sortByDate =
                typeof(Domain.Entities.Bookmarks).GetProperty(options.SortBy?.Trim() ?? "UpdatedAt") ??
                typeof(Domain.Entities.Bookmarks).GetProperty("CreatedAt");
            
            if (options.Sort?.Trim().ToLower() == "asc")
            {
                return _context.Notifications.AsQueryable()
                    .Where(x => x.IsRead == isRead)
                    .OrderBy(sortByDate.Name)
                    .Take(options.Limit)
                    .ToList();
            }
            else
            {
                return _context.Notifications.AsQueryable()
                    .Where(x => x.IsRead == isRead)
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