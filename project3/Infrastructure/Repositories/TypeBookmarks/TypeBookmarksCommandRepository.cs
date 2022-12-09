using Domain.Interfaces.TypeBookmark;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories.TypeBookmarks;

public class TypeBookmarksCommandRepository : ITypeBookmarkCommandRepository
{

    private readonly IDataContext _context;

    public TypeBookmarksCommandRepository(IDataContext context)
    {
        _context = context;
    }
    
    public void Create(Domain.Entities.TypeBookmarks entity)
    {
        try
        {
            var lastItem = _context.TypeBookmarks.Find(x => x.Id != -1)
                .Sort("{_id:-1}")
                .Limit(1)
                .FirstOrDefault();
            entity.Id = lastItem.Id + 1;
            
            Console.WriteLine(lastItem.Id);
            
            _context.TypeBookmarks.InsertOne(entity);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public bool Update(int id, Domain.Entities.TypeBookmarks entity)
    {
        try
        {
            ReplaceOneResult actionResult = _context.TypeBookmarks.ReplaceOne(c => c.Id == id, entity);
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
            DeleteResult actionResult = _context.TypeBookmarks.DeleteOne(d => d.Id == id);
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}