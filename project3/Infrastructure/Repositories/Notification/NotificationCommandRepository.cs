using Domain.Interfaces.Notification;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories.Notification;

public class NotificationCommandRepository : INotificationCommandRepository
{
    private readonly IDataContext _context;

    public NotificationCommandRepository(IDataContext context)
    {
        _context = context;
    }
    
    public void Create(Domain.Entities.Notification entity)
    {
        try
        {
            _context.Notifications.InsertOne(entity);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public bool Update(int id, Domain.Entities.Notification entity)
    {
        try
        {
            ReplaceOneResult actionResult = _context.Notifications.ReplaceOne(c => c.Id == id, entity);
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
            DeleteResult actionResult = _context.Notifications.DeleteOne(d => d.Id == id);
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}