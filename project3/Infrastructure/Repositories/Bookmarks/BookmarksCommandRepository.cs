using Domain.Interfaces.Bookmark;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories.Bookmarks;

public class BookmarksCommandRepository : IBookmarkCommandRepository
{
    private readonly IDataContext _context;

    public BookmarksCommandRepository(IDataContext context)
    {
        _context = context;
    }
    public void Create(Domain.Entities.Bookmarks entity)
    {
        try
        {
            _context.Bookmarks.InsertOne(entity);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public bool Update(int id, Domain.Entities.Bookmarks entity)
    {
        try
        {
            ReplaceOneResult actionResult = _context.Bookmarks.ReplaceOne(c => c.Id == id, entity);
            return actionResult.IsAcknowledged && actionResult.MatchedCount > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            DeleteResult actionResult = _context.Bookmarks.DeleteOne(d => d.Id == id);
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}